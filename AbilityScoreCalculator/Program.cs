using System;

namespace AbilityScoreCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while (true)
            {
                calculator.Roll = ReadInt(calculator.Roll, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quite, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }

        private static double ReadDouble(double lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();
            if (double.TryParse(line, out double value))
            {
                Console.WriteLine(" using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine(" using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }

        /// <summary>
        /// Writes a prompt and reads an int value from the console.
        /// </summary>
        /// <param name="lastUsedValue">The default value.</param>
        /// <param name="prompt">Prompt to print to the console.</param>
        /// <returns>The int value read, or the default value if unable to parse</returns>
        static int ReadInt(int lastUsedValue, string prompt)
        {
            /// Write the prompy followed by [default value]:
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            /// Read the line from the input and try to parse it
            string line = Console.ReadLine();
            /// If it can be parsed, write " using value" + value to console
            if (int.TryParse(line, out int value))
            {
                Console.WriteLine(" using value " + value);
                return value;
                /// Otherwise write" using default value" + lastUsedValue to the console
            }
            else
            {
                Console.WriteLine(" using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }
    }

    class AbilityScoreCalculator
    {
        public int Roll = 14;
        public double DivideBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;

        public void CalculateAbilityScore()
        {
            // Divide the starting roll
            double divided = Roll / DivideBy;

            // Add to the result
            int added = AddAmount += (int)divided;

            // Make sure it's greater than the minimum
            if (added < Minimum)
            {
                Score = Minimum;
            } else
            {
                Score = added;
            }
        }
    }
}
