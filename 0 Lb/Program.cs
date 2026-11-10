using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Lb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Я внес изменения для проверки коммита!");
            int firstNumber = 10;
            int secondNumber = 5;
            int sum = firstNumber + secondNumber;
            Console.WriteLine($"Сумма чисел {firstNumber} и {secondNumber} равна: {sum}");
            Console.ReadKey();
        }
    }
}
