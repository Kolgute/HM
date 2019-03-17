using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_HM_4_2
{
    class Flower
    {
        public int Price { get; set; }
        public int HowMany { get; set; }
        public virtual int GetPrice()
        {
            return Price * HowMany;
        } 
    }

    class Rose : Flower
    {
        public override int GetPrice()
        {
            Console.WriteLine($"У нас {HowMany} Роз и их стоимость = {Price * HowMany}");
            return Price * HowMany;
        }
    }

    class Carnations : Flower
    {
        public override int GetPrice()
        {
            Console.WriteLine($"У нас {HowMany} гвоздик и их стоимость = {Price * HowMany}");
            return Price * HowMany;
        }
    }

    class Tulips : Flower
    {
        public override int GetPrice()
        {
            Console.WriteLine($"У нас {HowMany} Тюльпанов и их стоимость = {Price * HowMany}");
            return Price * HowMany;
        }
    }

    class Lilies : Flower
    {
        public override int GetPrice()
        {
            Console.WriteLine($"У нас {HowMany} Лилий и их стоимость = {Price * HowMany}");
            return Price * HowMany;
        }
    }
}
