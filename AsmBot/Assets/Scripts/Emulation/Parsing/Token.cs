using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Parsing
{
    public class Token
    {
        public string Value { get; }
        public TokenType Type { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public Token(string value)
        {
            Value = value;
            switch (value)
            {
                case "+":
                    Type = TokenType.Plus;
                    return;
                case "-":
                    Type = TokenType.Minus;
                    return;
                case "[":
                    Type = TokenType.LeftBracket;
                    return;
                case "]":
                    Type = TokenType.RightBracket;
                    return;
                case ":":
                    Type = TokenType.Colon;
                    return;
                case ",":
                    Type = TokenType.Comma;
                    return;
            }
            if (char.IsDigit(value[0]))
            {
                Type = TokenType.Number; //assume everything beginning with a digit is a number
                //TODO: try to actually parse as a number and throw error
                return;
            }
            if (IsRegister(value))
            {
                Type = TokenType.Register;
                return;
            }
            if (value[value.Length - 1] == 'h')
            {
                if (ParsingUtil.IsHex(value.Substring(0, value.Length - 1)))
                {
                    Type = TokenType.Number;
                    return;
                }
            }
            //TODO: check for known instruction names (get from reflection aswell?)
            Type = TokenType.Symbol;
        }

        public override string ToString()
        {
            return $"[{Type}]:{Value}";
        }

        private static bool IsRegister(string value)
        {
            //TODO: this sucks, but at least i dont have seperate lists of what is a register and what isnt
            try
            {
                var tmp = new RegisterOperand(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public enum TokenType
    {
        Unknown = 0,
        Instruction,
        Symbol,
        Label,
        Number,
        Plus,
        Minus,
        LeftBracket,
        RightBracket,
        Colon,
        Comma,
        String,
        NewLine,
        Register,
    }
}
