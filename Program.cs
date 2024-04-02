using System;
using System.Text;

    class Program {

        /*Method for generating a random number where digits are beween 1 and 6 (Inclusively) for each digit */
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
            int tries = 10, count = 1;
            int answer = generateRandomNumber();

            while (count > 0) {
                int userInput;
                bool userValidInput = false;

                // User input until they have given a valid number
                do {
                    Console.WriteLine("Enter as four digit number (Digits are 1-6): ");
                    if(int.TryParse(Console.ReadLine(), out userInput) && userInput > 999 && userInput < 10000) {
                        int temp = userInput;
                        // Validation of the user's input that it is 4 digits in length and digits are between 1 and 6 inclusively
                        for(int i = 0; i < 4; i++) {
                            if(temp % 10 > 0 && temp % 10 < 7) {
                                userValidInput = true;
                                temp = temp / 10;
                            } else {
                                userValidInput = false;
                                break;
                            }
                        }
                    }
                    if(!userValidInput) {
                        Console.WriteLine("Incorrect number entered. Try Again.");
                    }
                } while (!userValidInput);

                // Compare the two inputs
            }; 
            return 0;
        }
    }
