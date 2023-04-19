namespace Leona.Models.Exceptions
{
    public class SyntaxException : Exception
    {
        private int lineNumber;

        public SyntaxException(string message) : base(message) { }

        public SyntaxException(int lineNumber) : base($"Syntax error at line {lineNumber}")
        {
            this.lineNumber = lineNumber;
        }
    }
}
