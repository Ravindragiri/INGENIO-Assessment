using ConsoleApp6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSolutionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Input(0 to exit): ");

            while (true)
            {
                var val = Console.ReadLine();
                if (val.Equals("0", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                int input = Convert.ToInt32(val);

                #region Second Solution

                SecondSolution secondSolution = new SecondSolution();
                IEnumerable<int> categoryIds = secondSolution.GetLevelResult(input);
                if (categoryIds != null && categoryIds.Any())
                {
                    Console.WriteLine(string.Format("[{0}]", string.Join(", ", categoryIds.OrderBy(e => e).ToArray())));
                }
                else
                {
                    Console.WriteLine("No Result");
                }

                #endregion Second Solution
            }
        }
    }
}
