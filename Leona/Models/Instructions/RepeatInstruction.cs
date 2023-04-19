using Leona.Helpers;
using Leona.Models.Drawing;
using Leona.Models.Exceptions;
using Leona.Models.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leona.Models.Instructions
{
    public class RepeatInstruction : Instruction
    {
        public int Count { get; set; }
        public List<Instruction> SubInstructions { get; set; }

        public RepeatInstruction() 
        { 
            SubInstructions = new List<Instruction>();
        }

        public override RepeatInstruction Read(Lexer lexer)
        {
            if(lexer.ReadToken(out Token repeatToken))
            {
                if (!lexer.ReadToken(out Token decimalToken) || decimalToken.Type != TokenType.Decimal)
                    throw new SyntaxException(repeatToken.LineNumber);

                Count = ((DecimalToken)decimalToken).Value;

                if(!lexer.PeekToken(out Token nextToken) || nextToken.Type == TokenType.Period)
                    throw new SyntaxException(repeatToken.LineNumber);

                if(nextToken.Type != TokenType.Quote)
                {
                    SubInstructions.Add(GetInstruction(lexer, nextToken));
                }
                else
                {
                    bool didRead = false;

                    lexer.ReadToken(out _); // read the opening qoute token
                    while(lexer.PeekToken(out Token peekedToken) && peekedToken.Type != TokenType.Quote)
                    {
                        if(peekedToken.Type == TokenType.EndOfFile)
                            throw new SyntaxException(peekedToken.LineNumber);

                        SubInstructions.Add(GetInstruction(lexer, peekedToken));

                        didRead = true;
                    }

                    if(!lexer.ReadToken(out Token closingToken) || closingToken.Type != TokenType.Quote || !didRead) // read the closing qoute token
                        throw new SyntaxException(closingToken.LineNumber);
                }

                return this;
            }

            throw new ReadInstructionException();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder($"<Repeat {Count} [");

            foreach (Instruction instruction in SubInstructions)
                result.Append(instruction.ToString());

            result.Append("]>");

            return result.ToString();
        }

        public override void Execute(Turtle turtle)
        {
            for (int i = 0; i < Count; i++)
            {
                foreach (Instruction instruction in SubInstructions)
                    instruction.Execute(turtle);
            }
        }
    }
}
