using System;
using System.Text;

class Program {

    /* Method used to convert an int number into an array of ints of the input number's digits */
    private static int[] numbersToArray(int number) {
        int[] array = new int[4];
        int count = 3;
        while (number != 0) {
            array[count] = number % 10;
            number /= 10;
            count--;
        }
        return array;
    } 

    /* Helper method for compareNumbers(int[], int[]) to create an ordered string of "+" and "-" */
    private static string generateHint(int count, string str) {
        StringBuilder temp = new StringBuilder();
        for(int i = 0; i < count; i++) {
            temp.Append(str);
        }
        return temp.ToString();
    }

    /*  Method for comparing two arrays of number where 
        a "+" is added to hint if digit is correct and in correct index
        a "-" is added to hint if digit is correct but in wrong index
        a " " is added to hint if digit is wrong
     */
    private static string compareNumbers(int[] answer, int[] userInput) {
        StringBuilder hint = new StringBuilder("", 4);
        int plusCount = 0;
        int minusCount = 0;
        int blankCount = 0;
        for(int i = 0; i < 4; i++) {
            if(answer[i] == userInput[i]) {
                plusCount++;
                answer[i] = -2;
            } else if (Array.IndexOf(answer, userInput[i]) > -1) {
                minusCount++;
            } else {
                blankCount++;
            }
        }
        hint.Append(generateHint(plusCount, "+"));
        hint.Append(generateHint(minusCount, "-"));
        hint.Append(generateHint(blankCount, " "));
        return String.Join("", hint);
    }

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


    /* Main method handling user input and calling additional methods to create the Mastermind Game*/
    static int Main(string[] args) {
        int count = 1;
        int answer = generateRandomNumber();

        // Simulates Mastermind game by giving 10 attempts to guess a number
        while (count <= 10) {
            int userInput;
            bool userValidInput = false;

            // User input until they have given a valid number
            do {
                Console.WriteLine("Attempts remaining: " + (11 - count));
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
                    Console.WriteLine("Invalid number entered. Try Again.");
                }
            } while (!userValidInput);

            // Compare the two inputs
            string hint = compareNumbers(numbersToArray(answer), numbersToArray(userInput));
            if(String.Equals(hint, "++++")) {
                Console.WriteLine("Correct! You guessed it in " + count + " attempts");
                break;
            } else {
                Console.WriteLine("hint: " + hint);
                count++;
            }

        }; 
        // If the user failed to guess the number in 10 attempts
        if (count > 10) {
            Console.WriteLine("Failed number of attempts. The correct answer was " + answer);
        }
        return 0;
    }
}
