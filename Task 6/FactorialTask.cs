using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public class FactorialTask
    {
        public async static Task<int> FactorialDigitSum(int n)
        {
            int sum;
            double factorial=1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            sum = 0;
            while (factorial != 0)
            {
                sum += (int)(factorial % 10);
                factorial /= 10;
            }
            return sum;
        }
    }
}
