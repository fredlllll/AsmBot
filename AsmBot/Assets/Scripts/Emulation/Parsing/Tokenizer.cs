using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Parsing
{
    public static class Tokenizer
    {
        public static List<Token> Tokenize(List<string> lines)
        {
            var tokens = new List<Token>();
            for (int lineNumber = 1; lineNumber <= lines.Count; lineNumber++)
            {
                string line = lines[lineNumber];
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                if (line.StartsWith(':'))
                {
                    throw new Exception("lines can not start with a colon: " + lineNumber);
                }
                StringBuilder currentToken = new StringBuilder();
                char stringStartChar = '\0';
                bool inString = false;
                bool firstToken = true;

                for (int pos = 0; pos < line.Length; ++pos)
                {
                    char c = line[pos];
                    if (inString)
                    {
                        if (c == '\\')
                        {
                            if (pos + 1 < line.Length)
                            {
                                char next = line[pos + 1];
                                if (next == '\\')
                                {
                                    pos++;
                                    currentToken.Append('\\');
                                }
                                else if (next == stringStartChar)
                                {
                                    pos++;
                                    currentToken.Append(stringStartChar);
                                }
                                else
                                {
                                    currentToken.Append(c);
                                }
                            }
                            else
                            {
                                currentToken.Append(c);
                            }
                        }
                        else if (c == stringStartChar)
                        {
                            inString = false;
                            currentToken.Append(c);
                            tokens.Add(new Token(TokenType.String, currentToken.ToString()));
                            currentToken.Clear();
                        }
                        else
                        {
                            currentToken.Append(c);
                        }
                    }
                    else
                    {
                        if (char.IsWhiteSpace(c))
                        {
                            if (currentToken.Length > 0)
                            {
                                tokens.Add(new Token(currentToken.ToString()));
                                currentToken.Clear();
                            }
                        }
                        else if (c == '\'' || c == '"')
                        {
                            if (currentToken.Length > 0)
                            {
                                tokens.Add(new Token(currentToken.ToString()));
                                currentToken.Clear();
                            }
                            inString = true;
                            stringStartChar = c;
                            currentToken.Append(c);
                        }
                        else if ("[]+-,".Contains(c))
                        {
                            if (currentToken.Length > 0)
                            {
                                tokens.Add(new Token(currentToken.ToString()));
                                currentToken.Clear();
                            }
                            tokens.Add(new Token(c.ToString()));
                        }
                        else if (c == ':')
                        {
                            if (currentToken.Length > 0)
                            {
                                tokens.Add(new Token(TokenType.Label, currentToken.ToString()));
                                currentToken.Clear();
                            }
                            tokens.Add(new Token(c.ToString()));
                        }
                        else
                        {
                            currentToken.Append(c);
                        }
                    }
                }
                if (currentToken.Length > 0)
                {
                    if (inString)
                    {
                        throw new Exception($"unclosed string in line {lineNumber}");
                    }
                    tokens.Add(new Token(currentToken.ToString()));
                }
                tokens.Add(new Token(TokenType.NewLine, "\n"));
            }
            return tokens;
        }
    }
}
