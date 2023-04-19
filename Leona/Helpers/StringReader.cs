using System.Text;

namespace Leona.Helpers
{
    public class StringReader
    {
        private string fullString;

        private int currentIndex = 0;
        private int currentLine = 1;

        public char CurrentCharacter { get { return fullString[currentIndex]; } } // should only be used for debugging purposes
        public char LastStoppingCharachter { get; set; }

        public int CurrentLine { get { return currentLine; } }
        public bool CanRead { get { return currentIndex < fullString.Length; } }

        private int? savedIndex;
        private int? savedLine;

        public StringReader(string fullString)
        {
            this.fullString = fullString;
        }

        public void BeginPeekMode()
        {
            savedIndex = currentIndex;
            savedLine = currentLine;
        }

        public void EndPeekMode()
        {
            if (savedIndex != null)
                currentIndex = savedIndex.Value;

            if (savedLine != null)
                currentLine = savedLine.Value;

            savedIndex = null;
            savedLine = null;
        }

        public bool Peek(out char character)
        {
            if (currentIndex >= fullString.Length)
            {
                character = '\0';
                return false;
            }

            character = fullString[currentIndex];

            return true;
        }

        /// <summary>
        /// Will read a single character from the internal strings
        /// </summary>
        /// <param name="character">The character that was read</param>
        /// <returns>Wether or not reading was possible</returns>
        public bool Read(out char character)
        {
            if (currentIndex >= fullString.Length)
            {
                character = '\0';
                return false;
            }

            character = fullString[currentIndex];

            if (character == '\n') // increase current line number if a line break is reached
                currentLine++;

            currentIndex++;

            return true;
        }

        /// <summary>
        /// Will search for a character, returning wether or not it was found
        /// </summary>
        public bool Search(char character)
        {
            if (currentIndex >= fullString.Length)
                return false;

            for (int i = currentIndex; i < fullString.Length; i++)
            {
                if (fullString[i] == character)
                {
                    currentIndex = i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Will read a single character from the internal strings but will exclude the characters in the excludeCharacters array
        /// </summary>
        /// <param name="character">The character that was read</param>
        /// <param name="excludeCharacters">The characters that should not be allowed to be read</param>
        /// <returns>Wether or not reading was possible</returns>
        public bool Read(out char character, params char[] excludeCharacters)
        {
            currentIndex++;

            if (currentIndex >= fullString.Length)
            {
                character = '\0';
                return false;
            }

            character = fullString[currentIndex];

            if (character == '\n') // increase current line number if a line break is reached
                currentLine++;

            if (excludeCharacters.Contains(character))
                return false;

            return true;
        }

        /// <summary>
        /// Will read until any of the stopping characters are reached
        /// </summary>
        public bool ReadUntill(out string result, params char[] stoppingCharacters)
        {
            StringBuilder resultBuilder = new StringBuilder();

            bool foundCharacter = false;

            char character;
            while (Read(out character))
            {
                if (stoppingCharacters.Contains(character))
                {
                    LastStoppingCharachter = character;

                    foundCharacter = true;
                    GoBack(1);
                    break;
                }

                resultBuilder.Append(character);
            }

            result = resultBuilder.ToString();

            return foundCharacter;
        }

        public StringReader GoBack(int steps)
        {
            currentIndex -= steps;
            return this;
        }

        public StringReader GoForward(int steps)
        {
            currentIndex += steps;
            return this;
        }

        public void IncreaseLine(int amount)
        {
            currentLine += amount;
        }

        public void DecreaseLine(int amount)
        {
            currentLine -= amount;
        }
    }
}