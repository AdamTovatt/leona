namespace Leona.Models.Tokens
{
    public abstract class Token
    {
        public TokenType Type { get; set; }
        public int LineNumber { get; set; }

        public Token(TokenType type, int lineNumber)
        {
            Type = type;
            LineNumber = lineNumber;
        }

        public abstract bool EqualToToken(Token other);

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType().BaseType != typeof(Token))
                return false;

            Token other = (Token)obj;

            if (other.Type != Type || other.LineNumber != LineNumber)
                return false;

            return EqualToToken(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type);
        }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
