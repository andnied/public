using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frog
{
    class Program
    {
        static void Main(string[] args)
        {
            int inches = 0;
            string tryAgain = string.Empty;

            do
            {
                Console.WriteLine("Please provide the number of inches.");
                var read = Console.ReadLine();

                if (int.TryParse(read, out inches))
                {
                    if (inches < 1)
                        Console.WriteLine("The number of inches should be greater than 0.");
                    else
                    {
                        var tree = new MovementTree(inches);
                        tree.FillNodes();
                        var result = tree.CountPaths();

                        Console.WriteLine(string.Format("There are {0} possibilities.", result));
                    }
                }
                else
                    Console.WriteLine("Incorrect argument. Should be a number.");

                Console.WriteLine("Want to try again? (y/n)");
                tryAgain = Console.ReadLine();
            } while (tryAgain == "y");
        }
    }
}
