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
                _head = new Node(data, _head); 
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

            if (index < 0 || index >= Count)
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
                removedNode = _head; // the removed Node was "head" prior to this run
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

            // Guard med besked for tom liste er ikke nødvendig da det opfanges af næste exception : index >= 0

            if (index < 0 || index >= Count) // Count er ikke "nul-baseret" og derfor "større end eller LIG med"
            {
                throw new IndexOutOfRangeException($"Er du helt sikker? \t Index er {index} ");
            }
            Node current = _head;
           
            // Pas lidt på med at anvende en operator (index--) i et boolsk udtryk (index-- > 0)
            // Operatoren vil blive kørt før det boolske udtryk - har index så den værdi som du forventer eller er den en lavere ?
            // Måske undersøge edge cases - start og slut af løkken ?

            //Vedr.  "Pas lidt på med at anvende en operator (index--) i et boolsk udtryk (index-- > 0) ...."
            // Det er ikke rigtig Mester: index dekrementeres faktisk efter sammenligning,
            // måske tænker du på (--index > 0) ??

            while (index-- > 0)
            {
                current = current.Next;
            }
            current.Data = data;
        }

        public void Move(int from, int to)
        {
            // Tom liste opfanges af exception nedenfor

            if (from < 0 )
            {
                throw new IndexOutOfRangeException("\"From\" værdien er ugyldig! - mindre end nul");
            }
            if (from >= Count)
            {
                throw new IndexOutOfRangeException("\"From\" værdien er ugyldig! - større end antal af elementer i listen");
            }
            if (to < 0)
            {
                throw new IndexOutOfRangeException("\"To\" værdien er ugyldig! - mindre end nul");
            }
            if (to >= Count)
            {
                throw new IndexOutOfRangeException("\"To\" værdien er ugyldig! - større end antal af elementer i listen");
            }

            // Antagelse: to er højere end from
            // Kan man anvende det samme "to index" når en node bliver "klippet" ud af den linkedede liste ?
            // Brian her er jeg dig svar skyldig - jeg opfatter denne methode som een der fjerner element MEN
            // samtidig også tilføjer et tilsvarende i samme process... hmmm
            // Bør det være uændret, en højere eller en lavere ?
            // Jeg vil mene efter return er Count uændret..

            // Holder antagelsen om at to er højere end from altid ?
            // Her tror jeg vi ser forskelligt på målsætningen for Move.
            // Min kode virker så "to" kan være mindre end "from".
            // Man kan om du vil flytte "begge veje"... se evt aktuel kode i Program.cs

            var fromNode = RemoveAt(from);
            // Med ! angiver du at der med garanti er data. Kan en node oprettes med null som "data" ?

            // Jeg mener at udråbstegnet vedrører Node'n - ikke "data" !?
            // Jeg "satser" på at der er en Node - eneste sted dette ikke er tilfældet er vist nok "head"...
            // Mth til "data" tror jeg nedenstående overlever null som data...
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
