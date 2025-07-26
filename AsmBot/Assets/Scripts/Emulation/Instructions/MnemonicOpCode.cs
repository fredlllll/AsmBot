using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    public enum MnemonicOpCode
    {
        NOP = 0,

        ADD, //Add
        ADC, //Add with carry
        SUB, //Sub
        SBB, //sub with borrow
        MUL, //unsigned multiply
        IMUL, //signed multiply
        DIV, //unsigned Divide
        IDIV, //signed Divide

        PUSH, //Push value on stack
        POP, //Pop value from stack

        JMP, //Jmp in same segment
        LJMP, //Jmp with given segment
        JCXZ, //jump if cx=0
        CALL, //Call routine
        RET, //return from routine

        //some jump mnemonics have the same opcode
        JO, //(OF=1)
        JNO, //(OF=0)

        JC, //(CF=1)
        JB = JC,
        JNAE = JC,

        JNC,//(CF=0)
        JAE = JNC, 
        JNB = JNC,

        JZ, //(ZF=1)
        JE = JZ,

        JNZ, //(ZF=0)
        JNE = JNZ,

        JBE, //(CF=1 or ZF=1)
        JNA = JBE,

        JA, //(CF=0 and ZF=0)
        JNBE = JA,

        JS, //(SF=1)
        JNS, //(SF=0)

        //we dont have the parity flag, but ill leave this here for reference
        /*
        JP, //(PF=1)
        JPE = JP,

        JNP, //(PF=0)
        JPO = JNP,
        */

        JL, //(SF<>OF)
        JNGE = JL,

        JNL, //(SF=OF)
        JGE = JNL,

        JLE, //(ZF=1 or SF<>OF)
        JNG = JLE,

        JNLE, //(ZF=0 and SF=OF)
        JG = JNLE,

        LOOP, //jump if --CX!=0
        LOOPE, //jump if --CX!=0 and ZF=1
        LOOPZ = LOOPE,
        LOOPNE, //jump if --CX!=0 and ZF=0
        LOOPNZ = LOOPNE,

        MOV, //move value

        IN, //input from port
        OUT, //output to port

        HLT,

        INC, //increment by 1
        DEC, //decrement by 1

        AND,
        OR,
        XOR,
        NOT,
        SHL,
        SAL,
        SHR,
        SAR,
        CBW, //convert byte to word, sign extended (AL => AX)
        CWD, //convert word to double word, sign extended (AX => DX:AX)
        NEG, // -operand

        CLC, //clear carry flag CF = 0
        STC, //set carry flag
        CMC, //Complement carry flag CF = !CF

        CMP, //Compare operands

        INT, //call interrupt
        INTO, //call interrupt if overflow flag is set
        //IRET, //return from interrupt, but we dont do interrupts in software, so not relevant

        LEA, //load effective address
        TEST, //compare operators and set CF and ZF

        DBG = 0x7fff
    }
}
