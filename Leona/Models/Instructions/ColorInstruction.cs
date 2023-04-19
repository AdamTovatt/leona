using Leona.Helpers;
using Leona.Models.Drawing;
using Leona.Models.Exceptions;
using Leona.Models.Tokens;

namespace Leona.Models.Instructions
{
    public class ColorInstruction : Instruction
    {
        public string? HexadecimalColor { get; set; }

        public override void Execute(Turtle turtle)
        {
            turtle.Pen.SetColor(HexadecimalColor!);
        }

        public override ColorInstruction Read(Lexer lexer)
        {
            if (lexer.ReadToken(out Token colorToken))
            {
                if (!lexer.ReadToken(out Token hexaDecimalToken) || hexaDecimalToken!.Type != TokenType.Hexadecimal)
                    throw new SyntaxException(colorToken.LineNumber); // throw syntax error if there was no next token or the next token was not a HexadecimalToken

                AssertNextTokenIsPeriod(lexer);

                HexadecimalColor = ((HexadecimalToken)hexaDecimalToken).Value;
                return this;
            }

            throw new ReadInstructionException();

        }

        public override string ToString()
        {
            return $"<Color #{HexadecimalColor}>";
        }
    }
}
