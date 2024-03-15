// See https://aka.ms/new-console-template for more information

using System;

namespace Application
{
    class Program
    {
        static Random rnd = new Random(); // create a random number generator for questions
        static List<Result> results = new List<Result>();
        public struct Result
        {
            public int num1;
            public int num2;
            public string operation;
            public int userAnswer;
            public int correctAnswer;
            public bool isCorrect;
        }
        public static void ReadAndDisplayResults()
        {
            Console.WriteLine("Results");
            foreach (Result result in results)
            {
                if (result.isCorrect == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(result.num1 + " " + result.operation + " " + result.num2 + " = " + result.userAnswer + " (Correct answer: " + result.correctAnswer + ") " + (result.isCorrect ? "Correct" : "Incorrect"));
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.num1 + " " + result.operation + " " + result.num2 + " = " + result.userAnswer + " (Correct answer: " + result.correctAnswer + ") " + (result.isCorrect ? "Correct" : "Incorrect"));
                    Console.ResetColor();
                }
              
            }
        }
        public static void GiveFeedback(int correctAnswer, bool isCorrect)
        {
            if (isCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Incorrect! The correct answer is {correctAnswer}");
                Console.ResetColor();
            }
        }

        public static void Addition()
        {
            Console.WriteLine("Addition");
            int num1 = GenerateRandomNumber(1, 100);
            int num2 = GenerateRandomNumber(1, 100);
            int userAnswer = HandleUserAnswer(num1, num2, "+");
            int correctAnswer = num1 + num2;
            bool isCorrect = (userAnswer == correctAnswer);
            GiveFeedback(correctAnswer,isCorrect);
            if (isCorrect)
            {
                addResultToList(num1, num2, "+", userAnswer, correctAnswer, true);
            }
            else
            {
                addResultToList(num1, num2, "+", userAnswer, correctAnswer, false);
            }
        }

        public static void Subtration()
        {
            Console.WriteLine("Subtraction");
            int num1 = GenerateRandomNumber(1, 100);
            int num2 = GenerateRandomNumber(1, 100);
            int userAnswer = HandleUserAnswer(num1, num2, "-");
            int correctAnswer = num1 - num2;
            bool isCorrect = (userAnswer == correctAnswer);
            GiveFeedback(correctAnswer, isCorrect);
            if (isCorrect)
            {
                addResultToList(num1, num2, "-", userAnswer, correctAnswer, true);
            }
            else
            {
                addResultToList(num1, num2, "-", userAnswer, correctAnswer, false);
            }
        }

        public static void Multiplication()
        {
            Console.WriteLine("Multiplication");
            int num1 = GenerateRandomNumber(1, 100);
            int num2 = GenerateRandomNumber(1, 100);
            int userAnswer = HandleUserAnswer(num1, num2, "*");
            int correctAnswer = num1 * num2;
            bool isCorrect = (userAnswer == correctAnswer);
            GiveFeedback(correctAnswer, isCorrect);
            if (isCorrect)
            {
                addResultToList(num1, num2, "*", userAnswer, correctAnswer, true);
            }
            else
            {
                addResultToList(num1, num2, "*", userAnswer, correctAnswer, false);
            }
        }

        public static int FindSuitableDivisorForQuotientToBeInteger(int divident)
        {
            int divisor;
            while (true)
            {
                divisor = GenerateRandomNumber(1, 100);
                if (divident % divisor == 0)
                {
                    return divisor;
                }
            }
        }

        public static void Division()
        {          
            Console.WriteLine("Division");
            int divident = GenerateRandomNumber(0, 100);
            int divisor = FindSuitableDivisorForQuotientToBeInteger(divident);
            int userAnswer = HandleUserAnswer(divident, divisor, "/");
            int correctAnswer = divident / divisor;
            bool isCorrect = (userAnswer == correctAnswer);
            GiveFeedback(correctAnswer, isCorrect);
            if (isCorrect)
            {
                addResultToList(divident, divisor, "/", userAnswer, correctAnswer, true);
            }
            else
            {
                addResultToList(divident, divisor, "/", userAnswer, correctAnswer, false);
            }
        }


        public static void addResultToList(int num1, int num2, string operation, int userAnswer, int correctAnswer, bool isCorrect)
        {
            Result result;
            result.num1 = num1;
            result.num2 = num2;
            result.operation = operation;
            result.userAnswer = userAnswer;
            result.correctAnswer = correctAnswer;
            result.isCorrect = isCorrect;
            results.Add(result);
        }

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return (rnd.Next(minValue, maxValue));
        }

        public static int HandleUserAnswer(int num1, int num2, string operation) // returns user's answer as an int. Loops until user enters a valid answer.
        {
            while (true)
            {
                Console.WriteLine("To view game history, enter H");
                Console.WriteLine("What is " + num1.ToString() + " " + operation + " " + num2.ToString());
                var rawUserAnswer = Console.ReadLine();

                if (rawUserAnswer == "H" || rawUserAnswer == "h") // allow user to view game history
                {
                    ReadAndDisplayResults();
                    continue;
                }
                int userAnswerInt = 0; 
                try
                {
                    userAnswerInt = Int32.Parse(rawUserAnswer); // raw choice will never be null because because ReadLine() returns empty string if there is no input, not null
                }
                catch (FormatException)
                {
                    Console.WriteLine("You entered a value that is not a number, H or did not enter anything. Please enter a valid answer!: ");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Are you trying to break me? Please enter a valid answer!: ");
                    continue;
                }
                return userAnswerInt;
            }
        }
        public static void DisplayMainMenu()
        {
            Console.WriteLine("Choose operation");

            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Show results");
        }

        static void Main(string[] args)
        {
            bool inputIsInvalid = false;
            int choiceInt = 0;

            Console.WriteLine("Math Game");
            DisplayMainMenu();

            while (!inputIsInvalid) // loop until user enters a valid choice
            {
                Console.Write("Enter your choice: ");
                var rawChoice = Console.ReadLine();

                try
                {
                    choiceInt = Int32.Parse(rawChoice); // raw choice will never be null because because ReadLine() returns empty string if there is no input, not null
                }
                catch (FormatException)
                {
                    Console.WriteLine("You entered a value that is not a number or did not enter anything. Please enter a number corresponding to your choice!: ");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Are you trying to break me? Please enter a number corresponding to your choice!: ");
                    continue;
                }

                if (choiceInt < 1 || choiceInt > 4)
                {
                    Console.WriteLine("Number must be between 1 and 5 inclusive! Please enter a number corresponding to your choice!: ");
                    continue;
                }

                else
                {
                    inputIsInvalid = true; // if we make it this far, user input is valid - leave loop
                }
            }

            if (choiceInt == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    Addition();
                }
            }
            else if (choiceInt == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    Subtration(); ;
                }  
            }
            else if (choiceInt == 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    Multiplication(); ;
                }
            }
            else if (choiceInt == 4)
            {
                for (int i = 0; i < 10; i++)
                {
                   Division();
                }
            }
            else if (choiceInt == 5)
            {
                ReadAndDisplayResults();
            }

        }



    }
}






