using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    public class Async
    {
        private async static Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result =  await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private async static Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private async static Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }
        private async static Task<int> IKnowWhoKnowsThis(int n)
        {
            return await Task_6.FactorialTask.FactorialDigitSum(n);
        }
    }
}
