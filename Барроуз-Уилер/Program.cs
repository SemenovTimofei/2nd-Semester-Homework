using System;

internal class Program
{
    static void Main(string[] args)
    {
        if (!Testing.TestAll())
        {
            Console.WriteLine("Testing failed\n");
            return;
        }

        Console.WriteLine("0 - Exit\n" +
            "1 - Burrows-Wheeler Transformation\n" +
            "2 - Reverse Burrows-Wheeler Transformation\n");
        Console.WriteLine("Enter command: ");

        int command = int.Parse(Console.ReadLine());

        while (command != 0)
        {
            switch (command)
            {
                case 0:
                    continue;
                case 1:
                    Console.WriteLine("Enter a string: ");
                    var text = Console.ReadLine();

                    (string result, int index) = BWT.BWTransform(text);
                    Console.WriteLine("The result: {0}, {1}", result, index);
                    break;
                case 2:
                    Console.WriteLine("Enter a string: ");
                    text = Console.ReadLine();
                    Console.WriteLine("Enter position: ");
                    int endPosition = int.Parse(Console.ReadLine());

                    string inverseResult = BWT.InverseBWT(text, endPosition);

                    Console.WriteLine("The result: {0}", inverseResult);
                    break;
                default:
                    Console.WriteLine("Invalid input\n");
                    break;
            }

            Console.WriteLine("Enter command: ");
            command = int.Parse(Console.ReadLine());
        }
        return;
    }
}