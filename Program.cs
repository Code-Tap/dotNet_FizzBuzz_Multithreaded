using System;
using System.Threading;
using System.Collections.Generic;

namespace Fizzbuzz
{
    class Program
    {
        static IEnumerable<int> GenerateWithYield()
        {
            int index = 0;
            while (true)
                yield return index++;
        }

        public static void MethodWithThreadPool()
        {
        foreach ( int num in GenerateWithYield()){
                ThreadPool.QueueUserWorkItem(new WaitCallback(state => StartBuzzer(num)));   
            }           
        }

        public static void StartBuzzer(int num) {  
                Console.WriteLine($"{num} :: {Buzzer(num)}");
        }

        public static string Buzzer(int i)
        {
            string msg = "";
            if (i % 3 == 0) { msg += "Fizz"; }
            if (i % 5 == 0) { msg += "Buzz"; }
            return (msg);
        }
        static void Main(string[] args)
        {
            MethodWithThreadPool();
        }
    }
}