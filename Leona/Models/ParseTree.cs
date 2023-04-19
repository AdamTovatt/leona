using Leona.Models.Exceptions;
using Leona.Models.Instructions;
using System.Text;

namespace Leona.Models
{
    public class ParseTree
    {
        public SyntaxException? SyntaxException { get; set; }
        public List<Instruction> Instructions { get; set; }

        public ParseTree()
        { 
            Instructions = new List<Instruction>();
        }

        public void AddInstruction(Instruction instruction)
        {
            Instructions.Add(instruction);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach(Instruction instruction in Instructions)
                result.AppendLine(instruction.ToString());

            return result.ToString();
        }
    }
}
