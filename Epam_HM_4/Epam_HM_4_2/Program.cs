using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_HM_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Flower[] flower = new Flower[4];
            int Price = 0;

            Console.WriteLine("Введите колличество Роз и цену за 1 штуку");
            Rose rose = new Rose();
            rose.HowMany = int.Parse(Console.ReadLine());
            rose.Price = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите колличество Гвоздик и цену за 1 штуку");
            Carnations carnations = new Carnations();
            carnations.HowMany = int.Parse(Console.ReadLine());
            carnations.Price = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите колличество Тюльпанов и цену за 1 штуку");
            Tulips tulips = new Tulips();
            tulips.HowMany = int.Parse(Console.ReadLine());
            tulips.Price = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите колличество Лилий и цену за 1 штуку");
            Lilies liliess = new Lilies();
            liliess.HowMany = int.Parse(Console.ReadLine());
            liliess.Price = int.Parse(Console.ReadLine());

            flower[0] = rose;
            flower[1] = carnations;
            flower[2] = tulips;
            flower[3] = liliess;

            for(int i = 0; i < flower.Length; i++)
            {
                Price += flower[i].GetPrice();
            }

            Console.WriteLine("Итоговая стоимость букета = {0} ", Price);
            Console.ReadLine();


        }
    }
}
