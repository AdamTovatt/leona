namespace Leona.Models.Tokens
{
    public class DecimalToken : Token
    {
        public int Value { get; set; }

        public DecimalToken(TokenType type, int rowNumber, int value) : base(type, rowNumber)
        {
            Value = value;
        }

        public override bool EqualToToken(Token other)
        {
            if (other.Type != Type)
                return false;

            return Value == ((DecimalToken)other).Value;
        }
    }
}
