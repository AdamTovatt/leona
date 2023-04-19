using Leona.Helpers;
using Leona.Models.Drawing;
using Leona.Models.Exceptions;
using Leona.Models.Tokens;

namespace Leona.Models.Instructions
{
    public class MoveInstruction : Instruction
    {
        public int Distance { get; set; }
        public bool Forward { get; set; }

        public override void Execute(Turtle turtle)
        {
            turtle.Pen.Move(Distance * (Forward ? 1 : -1));
        }

        public override MoveInstruction Read(Lexer lexer)
        {
            if (lexer.ReadToken(out Token moveToken)) // read the current token
            {
                if (!lexer.ReadToken(out Token decimalToken) || decimalToken!.Type != TokenType.Decimal) // read the next token
                    throw new SyntaxException(decimalToken.LineNumber); // throw syntax error if there was no next token or the next token was not decimal

                AssertNextTokenIsPeriod(lexer);
                
                Distance = ((DecimalToken)decimalToken).Value;
                Forward = moveToken.Type == TokenType.Forward;
                return this;
            }

            throw new ReadInstructionException();
        }

        public override string ToString()
        {
            string name = Forward ? "Forward" : "Backward";
            return $"<{name} {Distance}>";
        }
    }
}
