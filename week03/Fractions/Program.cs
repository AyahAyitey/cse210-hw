using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
string playAgain = "yes";

// Stretch Challenge 2: play-again outer loop
while (playAgain == "yes")
{
    // Core Requirement 3: generate random magic number 1-100
    int magicNumber = randomGenerator.Next(1, 101);
    int guess = 0;

    // Stretch Challenge 1: guess counter
    int guessCount = 0;

    // Core Requirement 2: loop until guessed
    while (guess != magicNumber)
    {
        Console.Write("What is your guess? ");
        string userInput = Console.ReadLine() ?? "";
        guess = int.Parse(userInput);
        guessCount++;

        // Core Requirement 1: higher/lower hints
        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
    }

    // Stretch Challenge 1: report number of guesses
    Console.WriteLine($"It took you {guessCount} guesses.");

    // Stretch Challenge 2: ask to play again
    Console.Write("Do you want to play again? ");
    playAgain = Console.ReadLine() ?? "";
}

    }
}
