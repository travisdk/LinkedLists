namespace LinkedLists
{
    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }
        public Node(object data, Node next = null)
        {
            Data = data;
            Next = next;
        }
    }
}
