namespace Leona.Models.Tokens
{
    public class ErrorToken : Token
    {
        public ErrorToken(TokenType type, int rowNumber) : base(type, rowNumber)
        {
            LineNumber = rowNumber;
        }

        public override bool EqualToToken(Token other)
        {
            if (other.Type != Type)
                return false;

            return LineNumber == ((ErrorToken)other).LineNumber;
        }
    }
}
