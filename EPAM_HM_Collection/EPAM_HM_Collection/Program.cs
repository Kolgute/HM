using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_HM_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите тест");
            string line = Console.ReadLine();

            line = line.ToLower();

            string[] word = line.Split(' ');

            Dictionary<string, int> col = new Dictionary<string, int>();

            for (int i = 0; i< word.Length; i++)
            {
                if (col.ContainsKey(word[i]) == true)
                {
                    col[word[i]]++;
                }
                else
                {
                    col.Add(word[i], 1);
                }
            }

            foreach (KeyValuePair<string, int> keyValue in col)
            {
                double Value = keyValue.Value + 0.00;
                double Lenght = word.Length + 0.00;
                double d = 0.00;
                d = (Value / Lenght * 100);
                Console.WriteLine($"{keyValue.Key}  -  {d:00}%");
            }
            Console.ReadLine();

        }
    }
}
