using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async_await2
{
    class Program
    {
        static int GetFibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        static Task<int> GetFibnacciAsync(int n)
        {
            return Task.Run(() => GetFibonacci(n));
        }


        static async Task Main(string[] args)
        {
            // to read: https://www.i-programmer.info/programming/c/1514-async-await-and-the-ui-problem.html

            while (true)
            {
                Console.WriteLine("Dati n pentru fibo(n): ");
                int n = int.Parse(Console.ReadLine());

                Task.Run(async () =>
                {
                    var fiboResult = await GetFibnacciAsync(n);
                    Console.WriteLine($"fibo({n})=" + fiboResult);
                });

                Console.WriteLine("Cum te cheama?");
                string raspuns = Console.ReadLine();
                Console.WriteLine($"Salut, {raspuns}");
            }
        }
    }
}
