using System;
using System.Text;

    class Program {


        private static int generateRandomNumber() {
            StringBuilder randomNumber = new StringBuilder("", 4);
            Random rand = new Random();

            // Generates a random digit beween 1 and 6 (Inclusively) for each digit
            randomNumber.Append(rand.Next(1, 7));
            randomNumber.Append(rand.Next(1, 7));
            randomNumber.Append(rand.Next(1, 7));
            randomNumber.Append(rand.Next(1, 7));

            return Int32.Parse(randomNumber.ToString());
        }

        static int Main(string[] args) {
            int tries = 10, answer = 0;

            Console.Write(generateRandomNumber());

            return 0;
        }
    }
