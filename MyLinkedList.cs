using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class MyLinkedList
    {

        private Node _head;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
        public MyLinkedList()
        {
            Count = 0;
            _head = null;
        }

        public void Add(int index, object data)
        {
          
            if (index < 0)
            {
                throw new IndexOutOfRangeException($"Er du helt sikker? \t Index er {index}");
            }
            if (index > Count)
            {
                index = Count;
            }
            Node current = _head;
            if (IsEmpty || index == 0)
            {
                _head = new Node(data, _head); // skubbet ind før eksisterende "head"
            }
            else
            {
                
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = new Node(data, current.Next);
            }
            Count++;
        }

        public void Add(object data)
        {
            Add(Count, data);
        }


        public Node? RemoveAt(int index)
        {

            Node removedNode = null;
        
            if (index < 0)
            {
                throw new IndexOutOfRangeException($"Er du helt sikker? \t Index er {index}");
            }
            if (IsEmpty)
            {
                Console.WriteLine("Intet at fjerne!");
                return null;
            }

            Node current = _head;
            if (index == 0)
            {
                removedNode = _head; // head is removed
                _head = current.Next;
                
            }
            else
            {
            
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                removedNode = current.Next; // the node to remove 
                current.Next = current.Next.Next;
            }
            Count--;
            return removedNode;
        }

        public void ReplaceAt(int index, object data) {

            if (index < 0 || index >= Count) // Count er ikke "nul-baseret" og derfor "større end eller LIG med"
            {
                throw new IndexOutOfRangeException("Er du helt sikker?");
            }
            Node current = _head;
            while (index-- > 0)
            {
                current = current.Next;
            }
            current.Data = data;

        }
        public void Move(int from, int to)
        {
            if (from < 0 || from >= Count || to < 0 || to >= Count)  
            {
                throw new IndexOutOfRangeException("Noget er galt med \"from\" og/eller \"to\" værdierne");
            }

            var fromNode = RemoveAt(from);
            Add(to, fromNode!.Data);
        }
        public void Print()
        {
            Node current = _head;
            Console.WriteLine("-------------------------------------------------------------");
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"{i}\t{current.Data}");
                current = current.Next;
            }
        }
    }
}
