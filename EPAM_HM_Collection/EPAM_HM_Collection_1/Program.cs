using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_HM_Collection_1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(1);
            linkedList.Add(3);
            linkedList.Add(5);
            linkedList.Add(2);
            linkedList.Add(4);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
