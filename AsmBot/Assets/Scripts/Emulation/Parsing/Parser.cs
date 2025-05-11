using Assets.Scripts.Emulation.Instructions;
using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering;

namespace Assets.Scripts.Emulation.Parsing
{
    public static class Parser
    {
        static Dictionary<string, InstructionInfo> instructionInfos = new();

        class InstructionInfo
        {
            public InstructionInfoAttribute instructionInfo;
            public Type instructionType;
        }

        static Parser()
        {
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(Instruction).IsAssignableFrom(t))
                {
                    var info = t.GetCustomAttribute<InstructionInfoAttribute>();
                    if (info != null)
                    {
                        instructionInfos[info.mnemonic] = new InstructionInfo() { instructionInfo = info, instructionType = t };
                    }
                }
            }
        }

        struct ParserState
        {
            public List<Token> tokens;
            public int tokenIndex;

            public Token GetNextToken()
            {
                if (tokenIndex >= tokens.Count)
                {
                    return null;
                }
                return tokens[tokenIndex++];
            }

            public Operand[] GetOperands(int count)
            {
                if(count == 0)
                {
                    var next = GetNextToken(); //newline
                    if(next.Type != TokenType.NewLine)
                    {
                        throw new Exception("expected 0 operands");
                    }
                    return Array.Empty<Operand>();
                }
                var retval = new Operand[count];
                int i = 0;
                while(count > 0)
                {
                    var token = GetNextToken();
                    if(token.Type == TokenType.Register)
                    {
                        retval[i++] = new RegisterOperand(token.Value);
                    }else if(token.Type == TokenType.Number)
                    {
                        retval[i++] = new NumberOperand(token.Value);
                    }
                    else if(token.Type == TokenType.LeftBracket)
                    {
                        //we only handle [ax] stuff, no immediate offset, as that can be done by adding to ax before (for now)
                        token = GetNextToken();
                        if (token.Type != TokenType.Register)
                        {
                            throw new Exception("expected register, got: " + token.Type);
                        }
                        retval[i++] = new AddressOperand(token.Value);
                        token = GetNextToken();
                        if (token.Type != TokenType.RightBracket)
                        {
                            throw new Exception("expected right bracket, got: " + token.Type);
                        }
                    }
                    else 
                    {
                        throw new Exception("unknown operand type: " + token.Type);
                    }
                    var next = GetNextToken(); //either comma or newline
                    count--;
                    if (count == 0)
                    {
                        if (next.Type != TokenType.NewLine)
                        {
                            throw new Exception("too many operands");
                        }
                    }
                    else
                    {
                        if(next.Type != TokenType.Comma)
                        {
                            throw new Exception("not enough operands");
                        }
                    }
                    
                }
                return retval;
            }
        }

        public static Program Parse(List<Token> tokens)
        {
            Program program = new Program();
            var state = new ParserState()
            {
                tokenIndex = 0,
                tokens = tokens
            };
            Token token;
            while ((token = state.GetNextToken()) != null)
            {
                if (token.Type == TokenType.Label)
                {
                    var nextToken = state.GetNextToken();
                    if (nextToken.Type != TokenType.Colon)
                    {
                        throw new SyntaxException("Label has to be followed by colon");
                    }
                    nextToken = state.GetNextToken();
                    if (nextToken.Type != TokenType.NewLine)
                    {
                        throw new SyntaxException("No text allowed after label definition");
                    }
                    program.Labels[token.Value] = program.Instructions.Count;
                }
                else if (token.Type == TokenType.Instruction)
                {
                    if (instructionInfos.TryGetValue(token.Value.ToUpper(), out var instructionInfo))
                    {
                        var instruction = Activator.CreateInstance(
                            instructionInfo.instructionType,
                            new object[] { state.GetOperands(instructionInfo.instructionInfo.operandCount) }
                            );
                        if (instruction != null)
                        {
                            program.Instructions.Add((Instruction)instruction);
                        }
                        else
                        {
                            throw new Exception("could not instantiate instruction " + token.Value);
                        }
                    }
                    else
                    {
                        throw new SyntaxException("Unknown instruction " + token.Value);
                    }
                }
                else
                {
                    throw new SyntaxException("First Token must be instruction");
                }
            }

            return program;
        }
    }
}
