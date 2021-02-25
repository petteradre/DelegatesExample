using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesExample
{
    class Program
    {
        public delegate int findBigNumber(List<int> lst);
        static int BigNumber(List<int> listNumber)
        {
            return listNumber.OrderByDescending(d => d).First();
        }
        static void Main(string[] args)
        {
            List<int> FirstNumbers = new List<int> { 1, 243, 23, 12 };
            List<int> SeconndNumbers = new List<int> { 1, 43, 23, 12, 67,609 };
            List<int> ThridNumbers = new List<int> { 1, 43, 23, 12, 61, 212 };

            //Forma 1
            findBigNumber search = BigNumber;
            Console.WriteLine(search(FirstNumbers));
            //Forma 2
            findBigNumber search1 = delegate (List<int> lista)
            {
                return lista.OrderByDescending(d => d).First();
            };
            Console.WriteLine(search1(SeconndNumbers));
            //Forma 3
            findBigNumber search2 = Find => Find.OrderByDescending(d => d).First();
            Console.WriteLine(search2(ThridNumbers));
            NumbersList objectNumberList = new NumbersList();
            objectNumberList.SendNumbers(BigNumber, FirstNumbers);
            Console.ReadKey();
        }
        public class NumbersList
        {
            public void SendNumbers(findBigNumber big, List<int> listNumber)
            {
                Console.WriteLine("Search Numbers");
                int NumberSend = big(listNumber);
                Console.WriteLine("The number to send is: " + NumberSend);
            }
        }
    }
}
