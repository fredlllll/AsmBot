using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Assets.Scripts.Emulation.Instructions
{
    public static class InstructionsUtil
    {
        public class InstructionClassInfo
        {
            public InstructionInfoAttribute instructionInfo;
            public Type instructionType;
        }

        public static readonly Dictionary<ushort, InstructionClassInfo> opcodeToInfo = new();
        public static readonly Dictionary<string, InstructionClassInfo> mnemonicToInfo = new();

        static InstructionsUtil()
        {
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(Instruction).IsAssignableFrom(t) && !t.IsAbstract)
                {
                    var info = t.GetCustomAttribute<InstructionInfoAttribute>();
                    if (info != null)
                    {
                        var classInfo = new InstructionClassInfo() { instructionInfo = info, instructionType = t };
                        mnemonicToInfo[info.Mnemonic] = classInfo;
                        opcodeToInfo[info.OpCode] = classInfo;
                    }
                }
            }
        }

        public static Instruction FromStream(BinaryReader br)
        {
            ushort opcode = (ushort)br.Read7BitEncodedInt();
            var info = opcodeToInfo[opcode];
            return (Instruction)Activator.CreateInstance(info.instructionType, new object[] { br });
        }
    }
}
