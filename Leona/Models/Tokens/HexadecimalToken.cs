namespace Leona.Models.Tokens
{
    public class HexadecimalToken : Token
    {
        public string Value { get; set; }

        public HexadecimalToken(TokenType type, int rowNumber, string hexadecimalValue) : base(type, rowNumber) 
        {
            Value = hexadecimalValue.ToUpper();
        }

        public override bool EqualToToken(Token other)
        {
            if(other.Type != Type)
                return false;

            return Value == ((HexadecimalToken)other).Value;
        }
    }
}
