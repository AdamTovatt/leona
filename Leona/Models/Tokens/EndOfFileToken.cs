using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leona.Models.Tokens
{
    public class EndOfFileToken : Token
    {
        public EndOfFileToken(int rowNumber) : base(TokenType.EndOfFile, rowNumber) { }

        public override bool EqualToToken(Token other)
        {
            return other.Type == Type;
        }
    }
}
