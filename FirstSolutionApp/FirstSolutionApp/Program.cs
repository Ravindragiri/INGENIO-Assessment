using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
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

                #region First Solution

                FirstSolution firstSolution = new FirstSolution();
                Result result = firstSolution.GetResult(input);
                if (result != null)
                {
                    Console.WriteLine(string.Format(@"Output: ParentCategoryID = {0}, Name = {1}, Keywords = {2}",
                    result.ParentCategoryId, result.Name, result.Keywords));
                }
                else
                {
                    Console.WriteLine("No Result");
                }

                #endregion First Solution
            }
        }
    }
}
