using Leona.Models.Tokens;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Leona.Helpers
{
    public class Lexer
    {
        private static readonly Dictionary<TokenType, List<TokenType>> expectedTokensAfterToken = new Dictionary<TokenType, List<TokenType>>()
        {
            {TokenType.Forward, new List<TokenType>() { TokenType.Decimal } },
            {TokenType.Backward, new List<TokenType>() { TokenType.Decimal  }},
            {TokenType.Left, new List<TokenType>() { TokenType.Decimal  }},
            {TokenType.Right, new List<TokenType>() { TokenType.Decimal  }},
            {TokenType.Down, new List<TokenType>() { TokenType.Period }},
            {TokenType.Up, new List<TokenType>() { TokenType.Period }},
            {TokenType.Color, new List<TokenType>() { TokenType.Hexadecimal }},
            {TokenType.Repeat, new List<TokenType>() { TokenType.Decimal }},
            {TokenType.Period, new List<TokenType>()
            {
                TokenType.Quote,
                TokenType.Forward,
                TokenType.Backward,
                TokenType.Left,
                TokenType.Right,
                TokenType.Down,
                TokenType.Up,
                TokenType.Color,
                TokenType.Repeat
            }},
            {TokenType.Quote, new List<TokenType>()
            {
                TokenType.Quote,
                TokenType.Up,
                TokenType.Down,
                TokenType.Forward,
                TokenType.Backward,
                TokenType.Left,
                TokenType.Right,
                TokenType.Color,
                TokenType.Repeat
            }},
            {TokenType.Decimal, new List<TokenType>()
            {
                TokenType.Up,
                TokenType.Down,
                TokenType.Period,
                TokenType.Quote,
                TokenType.Forward,
                TokenType.Backward,
                TokenType.Left,
                TokenType.Right,
                TokenType.Color,
                TokenType.Repeat
            }},
            {TokenType.Hexadecimal, new List<TokenType>() { TokenType.Period }},
        };

        private static readonly Dictionary<string, CommandToken> commands = new Dictionary<string, CommandToken>()
        {
            { "FORW", new CommandToken(TokenType.Forward, -1) },
            { "BACK", new CommandToken(TokenType.Backward, -1) },
            { "LEFT", new CommandToken(TokenType.Left, -1) },
            { "RIGHT", new CommandToken(TokenType.Right, -1) },
            { "DOWN", new CommandToken(TokenType.Down, -1) },
            { "UP", new CommandToken(TokenType.Up, -1) },
            { "COLOR", new CommandToken(TokenType.Color, -1) },
            { "REP", new CommandToken(TokenType.Repeat, -1) }
        };

        /// <summary>
        /// The current tokens that have been tokenized from the input string
        /// </summary>
        public List<Token> Tokens { get; private set; }

        /// <summary>
        /// Should mostly be used for debugging
        /// </summary>
        public Token? CurrentToken { get { if (PeekToken(out Token? token)) return token; return null; } }

        /// <summary>
        /// The current index of the token cursor
        /// </summary>
        private int tokenIndex = 0;

        /// <summary>
        /// Constructor for the Lexer class, will initialize the commandsByLengthDictionary with appropriate values
        /// </summary>
        public Lexer(string input)
        {
            Tokens = Tokenize(input);
        }

        public void ResetTokenCursor()
        {
            tokenIndex = 0;
        }

        public List<Token> ReadAllTokens()
        {
            List<Token> tokens = new List<Token>();

            tokenIndex = 0;

            while (ReadToken(out Token? token))
            {
                if (token == null)
                    continue;

                tokens.Add(token);

                if (token.Type == TokenType.Error)
                    return tokens;
            }

            Token? lastToken = tokens.LastOrDefault();
            if (lastToken != null && lastToken.Type != TokenType.Period && lastToken.Type != TokenType.Quote) // if the last token is not a period, we should return an error
                tokens.Add(new ErrorToken(TokenType.Error, tokens.Last().LineNumber)); // the error will be at the last token's row number

            return tokens;
        }

        public bool PeekToken(out Token resultingToken)
        {
            return ReadToken(out resultingToken, false);
        }

        public bool ReadToken(out Token resultingToken)
        {
            return ReadToken(out resultingToken, true);
        }

        private bool ReadToken(out Token resultingToken, bool increaseIndex)
        {
            if (tokenIndex >= Tokens.Count)
            {
                resultingToken = new EndOfFileToken(Tokens.Count > 0 ? Tokens.Last().LineNumber : 0);
                return false;
            }

            Token token = Tokens[tokenIndex];

            if (token.Type == TokenType.Error) // return error token straight away
            {
                resultingToken = token;
            }
            else
            {
                if (tokenIndex != 0) // is not the first token, let's check if the current token is a token that was expected after the previous token
                {
                    if (TokenIsAllowedAfterToken(Tokens[tokenIndex - 1], token))
                        resultingToken = token;
                    else
                        resultingToken = new ErrorToken(TokenType.Error, token.LineNumber);
                }
                else
                    resultingToken = token;

                if (increaseIndex)
                    tokenIndex++;
            }
            return true;
        }

        public bool TokenIsAllowedAfterToken(Token firstToken, Token secondToken)
        {
            if (expectedTokensAfterToken.TryGetValue(firstToken.Type, out List<TokenType>? expectedTokens))
                return expectedTokens != null && expectedTokens.Contains(secondToken.Type);

            return false;
        }

        /// <summary>
        /// Will tokenize a string
        /// </summary>
        private List<Token> Tokenize(string input)
        {
            List<Token> result = new List<Token>(); // the list of tokens that will be returned
            StringReader reader = new StringReader(input);

            while (reader.Peek(out char currentChar))
            {
                if (currentChar == '\n')
                {
                    reader.GoForward(1).IncreaseLine(1);
                    continue;
                }
                else if (currentChar == ' ' || currentChar == '\r' || currentChar == '\t') // we should just ignore all "empty" characters
                {
                    reader.GoForward(1);
                    continue;
                }
                else if (currentChar == '%') // this is the start of a comment
                {
                    ReadComment(reader);
                }
                else if (currentChar == '.')
                {
                    reader.GoForward(1);
                    result.Add(new SeparatorToken(TokenType.Period, reader.CurrentLine));
                }
                else if (currentChar == '"')
                {
                    reader.GoForward(1);
                    result.Add(new SeparatorToken(TokenType.Quote, reader.CurrentLine));
                }
                else if (currentChar == '#')
                {
                    Token value = ReadHexadecimal(reader);

                    result.Add(value);

                    if (value.GetType() == typeof(ErrorToken))
                        return result;
                }
                else if (char.IsNumber(currentChar))
                {
                    Token value = ReadDecimal(reader);

                    result.Add(value);

                    if (value.GetType() == typeof(ErrorToken))
                        return result;
                }
                else // if we haven't found anything else that matches the current character, it must be the start of a command
                {
                    Token token = ReadCommand(reader);

                    result.Add(token);

                    if (token.GetType() == typeof(ErrorToken))
                        return result;
                }
            }

            return result;
        }

        private void ReadComment(StringReader reader)
        {
            reader.ReadUntill(out string _, '\n');
            reader.GoForward(1);
        }

        private Token ReadCommand(StringReader reader)
        {
            int tokenStartLine = reader.CurrentLine;

            if (reader.ReadUntill(out string readResult, ' ', '.', '%', '\r', '\n', '\t'))
            {
                string currentToken = readResult.ToUpper(); // let's make the current token to uppercase to make the lexer case insensitive

                if (reader.LastStoppingCharachter == '\n')
                    reader.DecreaseLine(1);

                if (commands.TryGetValue(currentToken, out CommandToken? commandToken))
                {
                    return new CommandToken(commandToken.Type, tokenStartLine);
                }
            }

            return new ErrorToken(TokenType.Error, HasMoreThanCommentsLeft(reader) ? reader.CurrentLine : tokenStartLine);
        }

        private bool HasMoreThanCommentsLeft(StringReader reader)
        {
            if (!reader.CanRead)
                return false;

            bool result = false;

            reader.BeginPeekMode();

            while (reader.Read(out char character))
            {
                if (character == '%')
                {
                    ReadComment(reader);
                }
                else
                {
                    result = true;
                    break;
                }
            }

            reader.EndPeekMode();
            return result;
        }

        private Token ReadDecimal(StringReader reader)
        {
            int tokenStartLine = reader.CurrentLine;
            StringBuilder result = new StringBuilder();

            char character;
            while (reader.Read(out character) && character != ' ' && character != '.' && character != '%' && character != '\r' && character != '\n' && character != '\t')
            {
                if (!char.IsDigit(character))
                    return new ErrorToken(TokenType.Error, tokenStartLine);

                result.Append(character);
            } // om sista är \n readuntill funkar ej denna

            if (character == '\n')
                reader.DecreaseLine(1);

            reader.GoBack(1);

            int decimalValue = int.Parse(result.ToString());

            if (decimalValue == 0)
                return new ErrorToken(TokenType.Error, tokenStartLine);

            return new DecimalToken(TokenType.Decimal, tokenStartLine, decimalValue);
        }

        private Token ReadHexadecimal(StringReader reader)
        {
            int tokenStartLine = reader.CurrentLine;
            StringBuilder result = new StringBuilder();

            reader.GoForward(1);

            char character;
            while (reader.Read(out character) && character != ' ' && character != '.' && character != '%' && character != '\r' && character != '\n' && character != '\t')
            {
                if (!character.GetIsHexadecimal())
                    return new ErrorToken(TokenType.Error, tokenStartLine);

                result.Append(character);
            }

            if (character == '\n')
                reader.DecreaseLine(1);

            reader.GoBack(1);

            return new HexadecimalToken(TokenType.Hexadecimal, tokenStartLine, result.ToString());
        }
    }
}
