using System;

class Program
{
    static void Main(string[] args)
    {
       // Main logic - call each function in order
DisplayWelcome();

string name = PromptUserName();
int number = PromptUserNumber();
int squared = SquareNumber(number);

DisplayResult(name, squared);

// Displays the welcome message
static void DisplayWelcome()
{
    Console.WriteLine("Welcome to the program!");
}

// Asks for and returns the user's name
static string PromptUserName()
{
    Console.Write("Please enter your name: ");
    string name = Console.ReadLine() ?? "";
    return name;
}

// Asks for and returns the user's favorite number
static int PromptUserNumber()
{
    Console.Write("Please enter your favorite number: ");
    string userInput = Console.ReadLine() ?? "";
    int number = int.Parse(userInput);
    return number;
}

// Accepts an integer and returns it squared
static int SquareNumber(int number)
{
    return number * number;
}

// Displays the user's name and their squared number
static void DisplayResult(string name, int squaredNumber)
{
    Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
}

    }
}
