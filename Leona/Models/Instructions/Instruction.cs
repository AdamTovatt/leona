using Leona.Helpers;
using Leona.Models.Drawing;
using Leona.Models.Exceptions;
using Leona.Models.Tokens;

namespace Leona.Models.Instructions
{
    public abstract class Instruction
    {
        public abstract Instruction Read(Lexer lexer);

        public void AssertNextTokenIsPeriod(Lexer lexer)
        {
            if (!lexer.ReadToken(out Token nextToken) || nextToken!.Type != TokenType.Period) // read the next token
                throw new SyntaxException(nextToken.LineNumber); // throw syntax error if there was no next token or the next token was not a period
        }

        public static Instruction GetInstruction(Lexer lexer, Token token)
        {
            switch (token.Type)
            {
                case TokenType.Forward:
                case TokenType.Backward:
                    return new MoveInstruction().Read(lexer);
                case TokenType.Left:
                case TokenType.Right:
                    return new TurnInstruction().Read(lexer);
                case TokenType.Up:
                case TokenType.Down:
                    return new PenInstruction().Read(lexer);
                case TokenType.Color:
                    return new ColorInstruction().Read(lexer);
                case TokenType.Repeat:
                    return new RepeatInstruction().Read(lexer);
                default:
                    throw new SyntaxException(token.LineNumber);
            }
        }

        public abstract void Execute(Turtle turtle);
    }
}
