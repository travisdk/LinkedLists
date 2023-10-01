namespace LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myList = new MyLinkedList();

            myList.Add("Henrik");
            myList.Add("Stine");
            myList.Add("Per");
            myList.Add("Lone");
            myList.Add("Hans");
            myList.Print();
            myList.Move(2, 0);
            myList.Print();



        }
    }
}