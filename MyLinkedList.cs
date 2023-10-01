namespace LinkedLists
{
    internal class MyLinkedList
    {
        private Node? _head;
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

            // Index kunne vel også ligge udenfor listen i den "positive ende"
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
                // Hvad menes med kommentaren: "head is removed" ? 
                // Som det er nu så sættes removedNode som en reference til _head.
                // _head forbliver vel den samme ? 🤔
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

        public void ReplaceAt(int index, object data)
        {
            // Guard Clause for en tom liste ?
            if (index < 0 || index >= Count) // Count er ikke "nul-baseret" og derfor "større end eller LIG med"
            {
                throw new IndexOutOfRangeException("Er du helt sikker?");
            }
            Node current = _head;
            // Pas lidt på med at anvende en operator (index--) i et boolsk udtryk (index-- > 0)
            // Operatoren vil blive kørt før det boolske udtryk - har index så den værdi som du forventer eller er den en lavere ?
            // Måske undersøge edge cases - start og slut af løkken ?
            while (index-- > 0)
            {
                current = current.Next;
            }
            current.Data = data;
        }

        public void Move(int from, int to)
        {
            // Vil koden kunne virke hvis listen er tom ?
            // En Guard Clause (IsEmpty) ?

            // Du fanger edge cases men fejlbeskeden er måske ikke så informativ 😉
            // Overvej om du vil have >= eller om det bør være >
            // Count er antallet (og starter med at tælle fra 1) - index er positionen (og starter med at tælle fra 0)
            if (from < 0 || from >= Count || to < 0 || to >= Count)
            {
                throw new IndexOutOfRangeException("Noget er galt med \"from\" og/eller \"to\" værdierne");
            }

            // Antagelse: to er højere end from
            // Kan man anvende det samme "to index" når en node bliver "klippet" ud af den linkedede liste ?
            // Bør det være uændret, en højere eller en lavere ?
            // Holder antagelsen om at to er højere end from altid ?
            var fromNode = RemoveAt(from);
            // Med ! angiver du at der med garanti er data. Kan en node oprettes med null som "data" ?
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
