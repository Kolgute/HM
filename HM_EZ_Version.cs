using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_HM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательность цифр через пробел");
            string line = Console.ReadLine();
            string[] words = line.Split(' ');

            Console.WriteLine(GetResult(words));
            Console.ReadLine();

        }

        static int GetResult(string[] words)
        {
           int NumPlus = 0,NumMinus = 0,Value=0;
            int[] word = new int[words.Length];
            for(int i = 0; i < words.Length; i++)
            {
                word[i] = Int32.Parse(words[i]);
            }
            for(int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] - word[i + 1] == -1)
                {
                    NumMinus += -1;
                }
                else
                {
                    NumPlus++;
                    Value = word[i] +1;
                }
            }
            if (NumPlus == 1)
            {
                return Value;
            }
            else
            {
                return -1;
            }
        }
    }
}
