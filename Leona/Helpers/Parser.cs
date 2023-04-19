using Leona.Models;
using Leona.Models.Exceptions;
using Leona.Models.Instructions;
using Leona.Models.Tokens;

namespace Leona.Helpers
{
    public class Parser
    {
        private Lexer lexer;

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
        }

        public ParseTree Parse()
        {
            ParseTree tree = new ParseTree();

            try
            {
                while (lexer.PeekToken(out Token token))
                {
                    tree.AddInstruction(Instruction.GetInstruction(lexer, token!));
                }
            }
            catch (SyntaxException syntaxException)
            {
                tree.SyntaxException = syntaxException;
            }

            return tree;
        }
    }
}
