using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
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
                    // var text = "SIX.MIXED.PIXIES.SIFT.SIXTY.PIXIE.DUST.BOXES";

                    (string result, int index) = BWT.BWTransform(text);
                    Console.WriteLine("The result: {0}", result);
                    break;
                case 2:
                    Console.WriteLine("Enter a string: ");
                    text = Console.ReadLine();
                    Console.WriteLine("Enter position: ");
                    int position = int.Parse(Console.ReadLine());

                    Console.WriteLine("The result: {0} {1}", text, position);
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