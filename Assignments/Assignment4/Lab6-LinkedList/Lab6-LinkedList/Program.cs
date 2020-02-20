using System;

namespace Lab6_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList(new Node("D"));

            list.Append(new Node("E"));
            list.Append(new Node("F"));

            list.InsertNodeAtPosition(new Node("A"), 0);
            list.InsertNodeAtPosition(new Node("B"), 1);
            list.InsertNodeAtPosition(new Node("C"), 2);
            list.InsertNodeAtPosition(new Node("G"), 6);

           

            list.PrintOutList();

            Console.WriteLine("Size: " + list.Size);

            Console.WriteLine("Deleting 3 nodes");

            list.Delete(0);
            list.Delete(5);
            list.Delete(2);

            
            Console.WriteLine("Size: " + list.Size);
        }
    }
}
