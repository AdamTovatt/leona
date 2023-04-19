using Leona.Helpers;
using Leona.Models.Drawing;
using Leona.Models.Exceptions;
using Leona.Models.Tokens;

namespace Leona.Models.Instructions
{
    public class PenInstruction : Instruction
    {
        public bool MoveUp { get; set; }

        public override void Execute(Turtle turtle)
        {
            turtle.Pen.IsDown = !MoveUp;
        }

        public override PenInstruction Read(Lexer lexer)
        {
            if (lexer.ReadToken(out Token penToken)) // read the current token
            {
                AssertNextTokenIsPeriod(lexer);

                MoveUp = penToken.Type == TokenType.Up; // could lead to errors if this method is called with a token that is not a pen type
                return this;
            }

            throw new ReadInstructionException();
        }

        public override string ToString()
        {
            string name = MoveUp ? "Up" : "Down";
            return $"<{name}>";
        }
    }
}
