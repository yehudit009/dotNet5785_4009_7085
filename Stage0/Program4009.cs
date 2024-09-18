// See https://aka.ms/new-console-template for more information
using System.Transactions;

partial class Program
{
    static void Main(string[] args)
    {
        Welcome4009();
        Welcome7085();
        Console.ReadKey();
    }
    static partial void Welcome7085();

    private static void Welcome4009()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Enter your name");
        string name = Console.ReadLine();
        Console.WriteLine("{0}, welcome", name);
    }
}