using Leona.Helpers;
using Leona.Models.Tokens;
using LeonaTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonaTests.Tests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void SampleInput01()
        {
            const string inputFileName = "SampleInput01.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Down, 3),
                new SeparatorToken(TokenType.Period, 3),

                new CommandToken(TokenType.Forward, 4),
                new DecimalToken(TokenType.Decimal, 4, 1),
                new SeparatorToken(TokenType.Period, 4),
                new CommandToken(TokenType.Left, 4),
                new DecimalToken(TokenType.Decimal, 4, 90),
                new SeparatorToken(TokenType.Period, 4),

                new CommandToken(TokenType.Forward, 5),
                new DecimalToken(TokenType.Decimal, 5, 1),
                new SeparatorToken(TokenType.Period, 5),
                new CommandToken(TokenType.Left, 5),
                new DecimalToken(TokenType.Decimal, 5 ,90),
                new SeparatorToken(TokenType.Period, 5),

                new CommandToken(TokenType.Forward, 6),
                new DecimalToken(TokenType.Decimal, 6 ,1),
                new SeparatorToken(TokenType.Period, 6),
                new CommandToken(TokenType.Left, 6),
                new DecimalToken(TokenType.Decimal, 6, 90),
                new SeparatorToken(TokenType.Period, 6),

                new CommandToken(TokenType.Forward,7),
                new DecimalToken(TokenType.Decimal, 7, 1),
                new SeparatorToken(TokenType.Period, 7),
                new CommandToken(TokenType.Left, 7),
                new DecimalToken(TokenType.Decimal, 7, 90),
                new SeparatorToken(TokenType.Period, 7),
            };

            Lexer lexer = new Lexer(input);

            Assert.AreEqual(expectedTokens.Count, lexer.Tokens.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], lexer.Tokens[i]);
            }
        }

        [TestMethod]
        public void SampleInput02()
        {
            const string inputFileName = "SampleInput02.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Down, 2),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Up, 2),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Down, 2),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Down, 2),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Repeat, 6),
                new DecimalToken(TokenType.Decimal, 6, 3),
                new SeparatorToken(TokenType.Quote, 6),
                new CommandToken(TokenType.Color, 6),
                new HexadecimalToken(TokenType.Hexadecimal, 6, "FF0000"),
                new SeparatorToken(TokenType.Period, 6),
                new CommandToken(TokenType.Forward, 7),
                new DecimalToken(TokenType.Decimal, 7, 1),
                new SeparatorToken(TokenType.Period, 7),
                new CommandToken(TokenType.Left, 7),
                new DecimalToken(TokenType.Decimal, 7, 10),
                new SeparatorToken(TokenType.Period, 7),
                new CommandToken(TokenType.Color, 8),
                new HexadecimalToken(TokenType.Hexadecimal, 8, "000000"),
                new SeparatorToken(TokenType.Period, 8),
                new CommandToken(TokenType.Forward, 9),
                new DecimalToken(TokenType.Decimal, 9, 2),
                new SeparatorToken(TokenType.Period, 9),
                new CommandToken(TokenType.Left, 9),
                new DecimalToken(TokenType.Decimal, 9, 20),
                new SeparatorToken(TokenType.Period, 9),
                new SeparatorToken(TokenType.Quote, 9),
                new CommandToken(TokenType.Color, 11),
                new HexadecimalToken(TokenType.Hexadecimal, 13, "111111"),
                new SeparatorToken(TokenType.Period, 13),
                new CommandToken(TokenType.Repeat, 14),
                new DecimalToken(TokenType.Decimal, 14, 1),
                new SeparatorToken(TokenType.Backward, 14),
                new DecimalToken(TokenType.Decimal, 14, 1),
                new SeparatorToken(TokenType.Period, 14),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        // this is not a parser error since we have a decimal value that has letters in it thus resulting in a lexer error not parser
        [TestMethod]
        public void SampleInput03()
        {
            const string inputFileName = "SampleInput03.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Color, 2),
                new ErrorToken(TokenType.Error, 2),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput04()
        {
            const string inputFileName = "SampleInput04.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Repeat, 2),
                new DecimalToken(TokenType.Decimal, 2, 5),
                new SeparatorToken(TokenType.Quote, 2),
                new CommandToken(TokenType.Down, 2),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Forward, 2),
                new DecimalToken(TokenType.Decimal, 2, 1),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Left, 2),
                new DecimalToken(TokenType.Decimal, 2, 10),
                new SeparatorToken (TokenType.Period, 2),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput05()
        {
            const string inputFileName = "SampleInput05.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Forward, 2),
                new ErrorToken(TokenType.Error, 2),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput06()
        {
            const string inputFileName = "SampleInput06.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Forward, 2),
                new ErrorToken(TokenType.Error, 3),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput07()
        {
            const string inputFileName = "SampleInput07.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Down, 3),
                new SeparatorToken(TokenType.Period, 3),
                new ErrorToken(TokenType.Error, 3),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput08()
        {
            const string inputFileName = "SampleInput08.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Down, 2),
                new ErrorToken(TokenType.Error, 2)
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput09()
        {
            const string inputFileName = "SampleInput09.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Repeat, 2),
                new ErrorToken(TokenType.Error, 2)
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput10()
        {
            const string inputFileName = "SampleInput10.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Repeat, 2),
                new DecimalToken(TokenType.Decimal, 2, 2),
                new CommandToken (TokenType.Repeat, 2),
                new DecimalToken(TokenType.Decimal, 2, 4),
                new CommandToken(TokenType.Forward, 2),
                new DecimalToken(TokenType.Decimal, 2, 1),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Repeat, 3),
                new DecimalToken(TokenType.Decimal, 4, 2),
                new SeparatorToken(TokenType.Quote, 5),
                new CommandToken(TokenType.Down, 6),
                new SeparatorToken(TokenType.Period, 7),
                new CommandToken(TokenType.Forward, 8), // is correct. 
                new DecimalToken(TokenType.Decimal, 8, 1),
                new CommandToken(TokenType.Left, 9), //becomes line 10 for some reason
                new DecimalToken(TokenType.Decimal, 9, 1),
                new SeparatorToken(TokenType.Period, 9),
                new SeparatorToken(TokenType.Quote, 10),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput11()
        {
            const string inputFileName = "SampleInput11.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
                new CommandToken(TokenType.Repeat, 2),
                new DecimalToken(TokenType.Decimal, 2, 2),
                new SeparatorToken(TokenType.Quote,2),
                new CommandToken(TokenType.Up, 2),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken (TokenType.Forward, 2),
                new DecimalToken(TokenType.Decimal, 2, 10),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Down, 2),
                new SeparatorToken (TokenType.Period, 2),
                new CommandToken(TokenType.Repeat, 2),
                new DecimalToken(TokenType.Decimal, 2, 3),
                new SeparatorToken(TokenType.Quote, 2),
                new CommandToken(TokenType.Left, 2),
                new DecimalToken(TokenType.Decimal, 2, 120),
                new SeparatorToken(TokenType.Period, 2),
                new CommandToken(TokenType.Forward, 2),
                new DecimalToken(TokenType.Decimal, 2, 1),
                new SeparatorToken(TokenType.Period, 2),
                new SeparatorToken(TokenType.Quote, 2),
                new SeparatorToken(TokenType.Quote,2),
                new CommandToken(TokenType.Repeat, 4),
                new DecimalToken(TokenType.Decimal, 4, 3),
                new SeparatorToken(TokenType.Quote, 4),
                new CommandToken(TokenType.Repeat, 4),
                new DecimalToken(TokenType.Decimal, 4, 2),
                new SeparatorToken(TokenType.Quote, 4),
                new CommandToken (TokenType.Right, 4),
                new DecimalToken(TokenType.Decimal, 4, 2),
                new CommandToken(TokenType.Period, 4),
                new CommandToken(TokenType.Forward, 4),
                new DecimalToken(TokenType.Decimal, 4, 1),
                new SeparatorToken (TokenType.Period, 4),
                new SeparatorToken(TokenType.Quote, 4),
                new CommandToken(TokenType.Color, 5),
                new HexadecimalToken(TokenType.Hexadecimal, 5, "FF0000"),
                new SeparatorToken(TokenType.Period, 5),
                new CommandToken(TokenType.Forward, 5),
                new DecimalToken(TokenType.Decimal, 5, 10),
                new SeparatorToken(TokenType.Period, 5),
                new CommandToken(TokenType.Color, 5),
                new HexadecimalToken(TokenType.Hexadecimal, 5, "0000FF"),
                new SeparatorToken(TokenType.Period, 5),
                new SeparatorToken(TokenType.Quote, 5),
                new CommandToken(TokenType.Backward, 7),
                new DecimalToken(TokenType.Decimal, 7, 10),
                new SeparatorToken(TokenType.Period, 7),
                new CommandToken(TokenType.Color, 12),
                new HexadecimalToken(TokenType.Hexadecimal, 12, "ABCDEF"),
                new SeparatorToken(TokenType.Period, 12),
                new CommandToken(TokenType.Left, 12),
                new DecimalToken(TokenType.Decimal, 12, 70),
                new SeparatorToken(TokenType.Period, 12),
                new CommandToken(TokenType.Forward, 12),
                new DecimalToken(TokenType.Decimal, 12, 10),
                new SeparatorToken(TokenType.Period, 12),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }

        [TestMethod]
        public void SampleInput12()
        {
            const string inputFileName = "SampleInput12.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");

            List<Token> expectedTokens = new List<Token>()
            {
               new CommandToken(TokenType.Down, 1),
               new SeparatorToken(TokenType.Period, 1),
               new CommandToken(TokenType.Repeat, 8),
               new DecimalToken(TokenType.Decimal, 8, 2),
               new CommandToken (TokenType.Repeat, 8),
               new DecimalToken(TokenType.Decimal, 9, 1),
               new SeparatorToken(TokenType.Quote, 9),
               new CommandToken(TokenType.Repeat, 9),
               new DecimalToken(TokenType.Decimal, 9, 2),
               new CommandToken(TokenType.Repeat, 9),
               new DecimalToken(TokenType.Decimal, 9, 2),
               new SeparatorToken(TokenType.Quote, 9),
               new CommandToken(TokenType.Forward, 9),
               new DecimalToken(TokenType.Decimal, 9, 1),
               new SeparatorToken (TokenType.Period, 9),
               new SeparatorToken(TokenType.Quote, 9),
               new CommandToken(TokenType.Left, 10),
               new DecimalToken(TokenType.Decimal, 10, 45),
               new SeparatorToken(TokenType.Period, 10),
               new SeparatorToken(TokenType.Quote, 10),
            };

            Lexer lexer = new Lexer(input);

            List<Token> output = lexer.ReadAllTokens();

            Assert.AreEqual(expectedTokens.Count, output.Count, "Missmatch in token count");

            for (int i = 0; i < expectedTokens.Count; i++)
            {
                Assert.AreEqual(expectedTokens[i], output[i]);
            }
        }
    }
}
