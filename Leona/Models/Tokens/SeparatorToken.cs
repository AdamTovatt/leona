namespace Leona.Models.Tokens
{
    public class SeparatorToken : Token
    {
        public SeparatorToken(TokenType type, int rowNumber) : base(type, rowNumber) { }

        public override bool EqualToToken(Token other)
        {
            return other.Type == Type;
        }
    }
}
