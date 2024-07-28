using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MathGame
{
    public class MathGame
    {
        private static List<string> gameHistory = new List<string>();
        private static Random random = new Random();

        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Math Game");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Random");
                Console.WriteLine("6. View History");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "7")
                    break;

                switch (choice)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        string operation = GetOperationName(choice);
                        MenuChoice(operation);
                        break;

                    case "5":
                        RandomMode();
                        break;

                    case "6":
                        ViewHistory();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private static string GetOperationName(string choice)
        {
            return choice switch
            {
                "1" => "Addition",
                "2" => "Subtraction",
                "3" => "Multiplication",
                "4" => "Division",
                _ => throw new ArgumentException("Invalid choice")
            };
        }


        private static void RandomMode()
        {
            Console.Write("How many questions you want to do in Random Mode? = ");
            int qCount = GetIntInput();

            Console.WriteLine("Choose difficulty level:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Choose difficulty: ");
            int difficulty = GetIntInput();

            int minRange, maxRange;
            switch (difficulty)
            {
                case 1:
                    minRange = 0; maxRange = 10; // Easy difficulty
                    break;
                case 2:
                    minRange = 0; maxRange = 50; // Medium difficulty
                    break;
                case 3:
                    minRange = 0; maxRange = 100; // Hard difficulty
                    break;
                default:
                    Console.WriteLine("Invalid difficulty choice. Defaulting to Medium.");
                    minRange = 0; maxRange = 50;
                    break;
            }

            for (int i = 0; i < qCount; i++)
            {
                string[] operations = { "Addition", "Subtraction", "Multiplication", "Division" };
                int randomIndex = random.Next(operations.Length);
                string selectedOperation = operations[randomIndex];

                Console.WriteLine("Randomly selected operation: " + selectedOperation);

                PlayGame(selectedOperation, minRange, maxRange);
            }
        }

        private static void MenuChoice(string operation)
        {
            Console.Write($"How many questions you want to do of {operation} = ");
            int qCount = GetIntInput();

            Console.WriteLine("Choose difficulty level:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.Write("Choose difficulty: ");
            int difficulty = GetIntInput();

            int minRange, maxRange;
            switch (difficulty)
            {
                case 1:
                    minRange = 0; maxRange = 10; // Easy difficulty
                    break;
                case 2:
                    minRange = 0; maxRange = 50; // Medium difficulty
                    break;
                case 3:
                    minRange = 0; maxRange = 100; // Hard difficulty
                    break;
                default:
                    Console.WriteLine("Invalid difficulty choice. Defaulting to Medium.");
                    minRange = 0; maxRange = 50;
                    break;
            }

            for (int i = 0; i < qCount; i++)
            {
                PlayGame(operation, minRange, maxRange);
            }
        }

        private static void PlayGame(string operation, int minRange = 0, int maxRange = 100)
        {
            Stopwatch stopwatch = new();

            int num1 = random.Next(minRange, maxRange + 1);
            int num2 = random.Next(minRange, maxRange + 1);

            int correctAnswer = 0;
            string question = "";

            switch (operation)
            {
                case "Addition":
                    correctAnswer = num1 + num2;
                    question = $"{num1} + {num2}";
                    break;
                case "Subtraction":
                    correctAnswer = num1 - num2;
                    question = $"{num1} - {num2}";
                    break;
                case "Multiplication":
                    correctAnswer = num1 * num2;
                    question = $"{num1} * {num2}";
                    break;
                case "Division":
                    while (num1 % num2 != 0 || num2 == 0)
                    {
                        num1 = random.Next(minRange, maxRange + 1);
                        num2 = random.Next(minRange, maxRange + 1);
                    }
                    correctAnswer = num1 / num2;
                    question = $"{num1} / {num2}";
                    break;
            }
            Console.Write($"{question} = ");
            stopwatch.Start();
            int userAnswer = GetIntInput();
            stopwatch.Stop();
            int elapsedTimeInMilliseconds = (int)stopwatch.ElapsedMilliseconds;
            double elapsedTimeInSeconds = (double)elapsedTimeInMilliseconds / 1000;

            if (userAnswer == correctAnswer)
            {
                Console.WriteLine($"Correct! \nTime taken to solve = {elapsedTimeInSeconds}s.");
                gameHistory.Add($"{question} = {userAnswer} (Correct)\n   Time taken to solve = {elapsedTimeInSeconds}s.");
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer is {correctAnswer}.");
                gameHistory.Add($"{question} = {userAnswer} (Wrong, Correct: {correctAnswer})");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ViewHistory()
        {
            int i = 0;
            Console.Clear();
            Console.WriteLine("Game History:");
            foreach (var entry in gameHistory)
            {
                i++;
                Console.WriteLine($"{i}. {entry}\n");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private static int GetIntInput()
        {
            int userInput;
            string message = "Invalid input. Please enter an Integer.";

            while (true)
            {
                try
                {
                    string inputString = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputString))
                    {
                        Console.WriteLine(message);
                        continue;
                    }

                    if (int.TryParse(inputString, out userInput))
                    {
                        return userInput;
                    }
                    else { Console.WriteLine(message); }
                }
                catch (FormatException)
                {
                    Console.WriteLine(message);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input value is too large or small for an integer.");
                }
            }
        }
    }
}
