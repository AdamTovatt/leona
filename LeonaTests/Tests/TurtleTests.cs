using Leona.Models.Drawing;
using LeonaTests.Utilities;

namespace LeonaTests.Tests
{
    [TestClass]
    public class TurtleTests
    {
        [TestMethod]
        public void SampleInput01()
        {
            const string inputFileName = "SampleInput01.txt";
            const string outputFileName = "SampleOutput01.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput02()
        {
            const string inputFileName = "SampleInput02.txt";
            const string outputFileName = "SampleOutput02.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput03()
        {
            const string inputFileName = "SampleInput03.txt";
            const string outputFileName = "SampleOutput03.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput04()
        {
            const string inputFileName = "SampleInput04.txt";
            const string outputFileName = "SampleOutput04.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput05()
        {
            const string inputFileName = "SampleInput05.txt";
            const string outputFileName = "SampleOutput05.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput06()
        {
            const string inputFileName = "SampleInput06.txt";
            const string outputFileName = "SampleOutput06.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput07()
        {
            const string inputFileName = "SampleInput07.txt";
            const string outputFileName = "SampleOutput07.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput08()
        {
            const string inputFileName = "SampleInput08.txt";
            const string outputFileName = "SampleOutput08.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput09()
        {
            const string inputFileName = "SampleInput09.txt";
            const string outputFileName = "SampleOutput09.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput10()
        {
            const string inputFileName = "SampleInput10.txt";
            const string outputFileName = "SampleOutput10.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput11()
        {
            const string inputFileName = "SampleInput11.txt";
            const string outputFileName = "SampleOutput11.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput12()
        {
            const string inputFileName = "SampleInput12.txt";
            const string outputFileName = "SampleOutput12.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput13()
        {
            const string inputFileName = "SampleInput13.txt";
            const string outputFileName = "SampleOutput13.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SampleInput14()
        {
            const string inputFileName = "SampleInput14.txt";
            const string outputFileName = "SampleOutput14.txt";

            string? input = TestUtilities.ReadTestFile(inputFileName);
            string? expectedOutput = TestUtilities.ReadTestFile(outputFileName);

            Assert.IsNotNull(input, $"Error when reading file from {inputFileName}");
            Assert.IsNotNull(expectedOutput, $"Error when reading file from {outputFileName}");

            Turtle turtle = new Turtle();
            string output = turtle.Run(turtle.Parse(input));

            Assert.AreEqual(expectedOutput, output);
        }
    }
}