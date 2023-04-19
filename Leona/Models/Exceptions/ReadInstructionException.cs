namespace Leona.Models.Exceptions
{
    public class ReadInstructionException : Exception
    {
        public ReadInstructionException() : base("An attempt to read an instruction from a lexer without readable tokens was made") { }
    }
}
