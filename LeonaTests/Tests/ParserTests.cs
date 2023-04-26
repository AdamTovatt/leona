using Leona.Helpers;
using Leona.Models;
using LeonaTests.Utilities;

namespace LeonaTests.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void SampleInput01()
        {
            const string inputFileName = "SampleInput01.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            Lexer lexer = new Lexer(input);
            Parser parser = new Parser(lexer);
            ParseTree tree = parser.Parse();

            string expectedTree = "<Down>\r\n<Forward 1>\r\n<Turn Left 90>\r\n<Forward 1>\r\n<Turn Left 90>\r\n<Forward 1>\r\n<Turn Left 90>\r\n<Forward 1>\r\n<Turn Left 90>\r\n";

            Assert.AreEqual(expectedTree.RemoveControlCharacters(), tree.ToString().RemoveControlCharacters());
        }

        [TestMethod]
        public void SampleInput02()
        {
            const string inputFileName = "SampleInput02.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            Lexer lexer = new Lexer(input);
            Parser parser = new Parser(lexer);
            ParseTree tree = parser.Parse();

            string expectedString = "<Down>\r\n<Up>\r\n<Down>\r\n<Down>\r\n<Repeat 3 [<Color #FF0000><Forward 1><Turn Left 10><Color #000000><Forward 2><Turn Left 20>]>\r\n<Color #111111>\r\n<Repeat 1 [<Backward 1>]>\r\n";

            Assert.AreEqual(expectedString.RemoveControlCharacters(), tree.ToString().RemoveControlCharacters());
        }
    }
}
