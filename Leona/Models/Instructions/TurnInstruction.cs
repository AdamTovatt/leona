using Leona.Helpers;
using Leona.Models.Drawing;
using Leona.Models.Exceptions;
using Leona.Models.Tokens;

namespace Leona.Models.Instructions
{
    public class TurnInstruction : Instruction
    {
        public int Angle { get; set; }
        public bool Right { get; set; }

        public override void Execute(Turtle turtle)
        {
            turtle.Pen.Turn(Angle * (Right ? -1 : 1));
        }

        public override TurnInstruction Read(Lexer lexer)
        {
            if (lexer.ReadToken(out Token turnToken))
            {
                if (!lexer.ReadToken(out Token turnAngleToken) || turnAngleToken.Type != TokenType.Decimal)
                    throw new SyntaxException(turnToken.LineNumber); // throw syntax error if there was no next token or the next token was not a DecimalToken

                AssertNextTokenIsPeriod(lexer);

                Angle = ((DecimalToken)turnAngleToken).Value;
                Right = turnToken.Type == TokenType.Right;
                return this;
            }

            throw new ReadInstructionException();
        }

        public override string ToString()
        {
            string name = Right ? "Right" : "Left";
            return $"<Turn {name} {Angle}>";
        }
    }
}
