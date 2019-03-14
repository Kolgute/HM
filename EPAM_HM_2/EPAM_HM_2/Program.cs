using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_HM_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длинну 2-х массивов");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            int[] b = new int[n];

            Console.WriteLine("Введите первый массив");

            for(int i = 0; i <= a.Length - 1; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Введите второй массив");

            for (int i = 0; i <= a.Length - 1; i++)
            {
                b[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(CheckArrays(a, b)); // Если может быть такое что в массиве А только 1 значение, например 11, а в массиве Б есть несколько квадратов 11
            Console.WriteLine(CheckArraysAnother(a, b)); // Если в массите А только 1 значение наминала, например, 11, то и в массиве Б может быть только 1 квадрат 11
            Console.ReadLine();
        }
        static bool CheckArrays(int[] a, int[] b)
        {
            bool JFalse=false;

            for (int i = 0; i< b.Length; i++)
            {
                JFalse = false;
                for (int j = 0; j < a.Length; j++)
                {                   
                    if (b[i] == Math.Pow(a[j], 2))
                    {
                        JFalse = true;
                        break;
                    }                  
                }
                if (JFalse == false) { break; }
            }
            if (JFalse == false)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        static bool CheckArraysAnother(int[] a, int[] b)
        {
            bool JFalse = false;

            for (int i = 0; i < b.Length; i++)
            {
                JFalse = false;
                for (int j = 0; j < a.Length; j++)
                {
                    if (b[i] == Math.Pow(a[j], 2))
                    {
                        JFalse = true;
                        a[j] = 0;
                        break;
                    }
                }
                if (JFalse == false) { break; }
            }
            if (JFalse == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }

}
