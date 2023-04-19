using Leona.Helpers;
using Leona.Models.Instructions;

namespace Leona.Models.Drawing
{
    public class Turtle
    {
        public TurtlePen Pen { get; set; }
        public Picture Picture { get; set; }

        public Turtle()
        {
            Picture = new Picture();
            Pen = new TurtlePen(Picture);
        }

        public ParseTree Parse(string input)
        {
            Lexer lexer = new Lexer(input);
            Parser parser = new Parser(lexer);
            return parser.Parse();
        }

        public string? Run(ParseTree tree)
        {
            if(tree.SyntaxException != null)
                return tree.SyntaxException.Message;

            foreach (Instruction instruction in tree.Instructions)
            {
                instruction.Execute(this);
            }

            return Picture.ToString();
        }

        public Picture GetPicture(ParseTree tree)
        {
            foreach (Instruction instruction in tree.Instructions)
            {
                instruction.Execute(this);
            }

            return Picture;
        }
    }
}
