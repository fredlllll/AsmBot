using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Rendering;

namespace Assets.Scripts.Emulation.Compiling
{
    public class AsmbotGrammarListener : asmbotGrammarBaseListener
    {
        public readonly List<IProgramLine> programLines = new List<IProgramLine>();

        public readonly StringBuilder tokenNames = new StringBuilder();

        LabelDefLine currentLabelDef = null;
        InstructionLine currentInstruction = null;

        bool isInMemoryOperand = false;

        public override void EnterLabelDef([NotNull] asmbotGrammarParser.LabelDefContext context)
        {
            programLines.Add(currentLabelDef = new LabelDefLine());
        }

        public override void ExitLabelDef([NotNull] asmbotGrammarParser.LabelDefContext context)
        {
            currentLabelDef = null;
        }

        public override void EnterInstr([NotNull] asmbotGrammarParser.InstrContext context)
        {
            programLines.Add(currentInstruction = new InstructionLine() { Mnemonic = context.GetChild(0).GetText()});
        }

        public override void ExitInstr([NotNull] asmbotGrammarParser.InstrContext context)
        {
            currentInstruction = null;
        }

        public override void EnterLabel([NotNull] asmbotGrammarParser.LabelContext context)
        {
            if (currentLabelDef != null)
            {
                currentLabelDef.Label = context.GetText();
            }
            if (isInMemoryOperand)
            {
                currentInstruction.Operands.Add(new MemoryLabelOperand() { Label = context.GetText() });
            }
        }

        public override void EnterRegisterOperand([NotNull] asmbotGrammarParser.RegisterOperandContext context)
        {
            if (currentInstruction != null)
            {
                currentInstruction.Operands.Add(new RegisterOperand() { Register = Registers.RegisterNameToRegister(context.GetText()) });
            }
        }

        public override void EnterMemoryOperand([NotNull] asmbotGrammarParser.MemoryOperandContext context)
        {
            isInMemoryOperand = true;
        }

        public override void ExitMemoryOperand([NotNull] asmbotGrammarParser.MemoryOperandContext context)
        {
            isInMemoryOperand = false;
        }

        public override void EnterRegister([NotNull] asmbotGrammarParser.RegisterContext context)
        {
            if (isInMemoryOperand)
            {
                currentInstruction.Operands.Add(new MemoryRegisterOperand() { Register = Registers.RegisterNameToRegister(context.GetText()) });
            }
        }

        public override void EnterLabelOperand([NotNull] asmbotGrammarParser.LabelOperandContext context)
        {
            if (currentInstruction != null)
            {
                currentInstruction.Operands.Add(new LabelOperand() { Label = context.GetText() });
            }
        }

        public override void EnterImmediateOperand([NotNull] asmbotGrammarParser.ImmediateOperandContext context)
        {
            if (currentInstruction != null)
            {
                var str = context.GetText().ToLower();
                ushort value = 0;
                if (str.EndsWith('h'))
                {
                    value = ushort.Parse(str.Substring(0, str.Length - 1), System.Globalization.NumberStyles.HexNumber);
                }
                else
                {
                    value = ushort.Parse(str);
                }
                currentInstruction.Operands.Add(new ImmediateOperand() { Value = value });
            }

        }

        public override void EnterEveryRule([NotNull] ParserRuleContext context)
        {
            var str = "Enter " + asmbotGrammarParser.ruleNames[context.RuleIndex];
            if (context.ChildCount == 1)
            {
                str += " " + context.GetText();
            }
            tokenNames.AppendLine(str);
        }

        public override void ExitEveryRule([NotNull] ParserRuleContext context)
        {
            tokenNames.AppendLine("Exit " + asmbotGrammarParser.ruleNames[context.RuleIndex]);
        }
    }
}
