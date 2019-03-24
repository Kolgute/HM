using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_HM_Collection_1
{
    class Node <T>
    {
        public T Data { get; set; } // Значение, хранящееся в узле

        public Node(T data)
        {
            Data = data;
        }

        public Node<T> Next { get; set; } // Следующий узел
    }
}
