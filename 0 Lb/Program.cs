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
            Console.WriteLine("Привет! Ладно, пошутила, не последний))");
            int firstNumber = 10; //комментарий для коммита
            int secondNumber = 5;
            int sum = firstNumber + secondNumber;
            Console.WriteLine($"Сумма чисел {firstNumber} и {secondNumber} равна: {sum}");
            if (sum % 2 == 0)
                Console.WriteLine("Сумма четная");
            else
                Console.WriteLine("Сумма нечетная");
            Console.WriteLine("А это проверка с ветки Development");
            Console.WriteLine("Конец программы");
            Console.ReadKey();
        }
    }
}
}
