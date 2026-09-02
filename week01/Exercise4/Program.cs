using System;

class Program
{
    static void Main(string[] args)
    {
        using System.Collections.Generic;

List<int> numbers = new List<int>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");

// Collect numbers until user enters 0
int userNumber = -1;
while (userNumber != 0)
{
    Console.Write("Enter number: ");
    string userInput = Console.ReadLine() ?? "";
    userNumber = int.Parse(userInput);

    if (userNumber != 0)
    {
        numbers.Add(userNumber);
    }
}

// Core Requirement 1: compute sum
int sum = 0;
foreach (int number in numbers)
{
    sum += number;
}
Console.WriteLine($"The sum is: {sum}");

// Core Requirement 2: compute average
double average = (double)sum / numbers.Count;
Console.WriteLine($"The average is: {average}");

// Core Requirement 3: find the maximum
int largest = numbers[0];
foreach (int number in numbers)
{
    if (number > largest)
    {
        largest = number;
    }
}
Console.WriteLine($"The largest number is: {largest}");

// Stretch Challenge 1: find the smallest positive number
int smallestPositive = int.MaxValue;
foreach (int number in numbers)
{
    if (number > 0 && number < smallestPositive)
    {
        smallestPositive = number;
    }
}
if (smallestPositive != int.MaxValue)
{
    Console.WriteLine($"The smallest positive number is: {smallestPositive}");
}

// Stretch Challenge 2: sort and display the list
numbers.Sort();
Console.WriteLine("The sorted list is:");
foreach (int number in numbers)
{
    Console.WriteLine(number);
}

    }
}
