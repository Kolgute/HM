using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_HM_Collection_1
{
    class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;

        int count;

        public int Count
        {
            get { return count; }
        } 

        public bool Empty
        {
            get { return count == 0; }
        }

        public void Add (T data)
        {
            Node<T> node = new Node<T>(data);
            
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;               
            }
            tail = node;
            count++;
            Autosort();
        }

        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {

                    if (previous != null) // Если элемент находится не первым
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    Autosort();
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        
        public bool Containt(T data)
        {
            Node<T> current = head;

            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Autosort()
        {
            for (int i = 0; i < count; i++)
            {
                T data;
                Node<T> current = head;

                while (current.Next != null)
                {
                    dynamic CurData = current.Data;
                    dynamic CurDataNext = current.Next.Data;
                    {
                        if (CurData > CurDataNext)
                        {
                            data = current.Data;
                            current.Data = current.Next.Data;
                            current.Next.Data = data;

                        }
                    }
                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
