namespace Leona.Models.Tokens
{
    public class CommandToken : Token
    {
        public CommandToken(TokenType type, int rowNumber) : base(type, rowNumber) { }

        public override bool EqualToToken(Token other)
        {
            return other.Type == Type;
        }
    }
}
