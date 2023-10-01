namespace LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myList = new MyLinkedList();
            myList.Add("Henrik");
            myList.Add("Stine");
            myList.Print();
            myList.RemoveAt(1);
            myList.Add("Børge");
            myList.Add("Per");
            myList.Add("Claus");
            myList.Add("Jørgen");
            myList.Print();
            myList.Move(2, 4);
            myList.Print();
            myList.Move(0, 3);
            myList.Print();
        }
    }
}