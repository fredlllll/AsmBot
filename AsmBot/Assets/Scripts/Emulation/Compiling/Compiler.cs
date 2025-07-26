using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Emulation.Instructions;
using Assets.Scripts.Emulation.Instructions.Operands;

namespace Assets.Scripts.Emulation.Compiling
{
    public class Compiler
    {
        public static byte[] Compile(string source)
        {
            ICharStream stream = CharStreams.fromString(source);
            ITokenSource lexer = new asmbotGrammarLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            asmbotGrammarParser parser = new asmbotGrammarParser(tokens);
            IParseTree tree = parser.prog();
            AsmbotGrammarListener listener = new();
            ParseTreeWalker.Default.Walk(listener, tree);

            int address = 0;
            List<Instruction> instructions = new();
            Dictionary<string, int> labelToAddress = new();
            foreach (var line in listener.programLines)
            {
                if (line is LabelDefLine labelDefLine)
                {
                    labelToAddress[labelDefLine.Label] = address;
                }
                else if (line is InstructionLine instructionLine)
                {
                    //create instruction instance
                    var mnemonic = instructionLine.Mnemonic.ToUpper();
                    if (InstructionsUtil.mnemonicToInfo.TryGetValue(mnemonic, out var instructionInfo))
                    {
                        var instruction = Activator.CreateInstance(
                            instructionInfo.instructionType,
                            new object[] { instructionLine.Operands.ToArray() }
                            ) as Instruction;
                        if (instruction != null)
                        {
                            instructions.Add(instruction);
                            instruction.Address = address;
                            address += instruction.GetSizeInBytes();
                        }
                        else
                        {
                            throw new Exception("could not instantiate instruction " + instructionInfo.instructionType.FullName);
                        }
                    }
                    else
                    {
                        throw new Exception("Unknown instruction " + mnemonic);
                    }
                }
            }

            foreach (var instruction in instructions)
            {
                //TODO: extra checks for jmp and call to support long jumps and calls
                for (int i = 0; i < instruction.Operands.Length; ++i)
                {
                    var op = instruction.Operands[i];
                    if (op is LabelOperand labelOperand)
                    {
                        instruction.Operands[i] = new ImmediateOperand((ushort)labelToAddress[labelOperand.label]);
                    }
                    else if (op is MemoryLabelOperand memoryLabelOperand)
                    {
                        instruction.Operands[i] = new MemoryImmediateOperand((ushort)labelToAddress[memoryLabelOperand.label]);
                    }
                }
            }

            MemoryStream ms = new();

            foreach (var instruction in instructions)
            {
                var bytes = instruction.GetBytes();
                ms.Write(bytes);
            }

            return ms.ToArray();
        }
    }
}
