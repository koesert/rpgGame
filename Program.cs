using System;

public class Program
{
    public static void User()
    {
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string lastName = Console.ReadLine();

        Console.WriteLine($"Your full name is: {firstName} {lastName}");
    }
}
