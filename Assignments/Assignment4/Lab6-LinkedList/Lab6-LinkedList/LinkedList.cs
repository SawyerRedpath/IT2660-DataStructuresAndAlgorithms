using System;

namespace Lab6_LinkedList
{
    public class LinkedList
    {
        /// <summary>
        /// The root node of the list
        /// </summary>
        public Node RootNode { get; set; }

        /// <summary>
        /// The last node in the list
        /// </summary>
        public Node LastNode { get; set; }

        /// <summary>
        /// The size of the list
        /// </summary>
        public int Size { get; set; }

        public LinkedList(Node node)
        {
            this.RootNode = node;
            this.LastNode = node;
            this.Size = 1;
        }

        public void InsertNodeAtPosition(Node node, int position)
        {
            //Edge case, check if position == 0 or == linked list size
            if (position == 0)
            {
                this.PrependNewRoot(node);
            }
            else if (position == this.Size)
            {
                this.Append(node);
            }
            else
            {
                // General case
                Node previousNode = this.GetNodeAtPosition(position - 1);
                node.NextNode = previousNode.NextNode;

                previousNode.NextNode = node;

                this.Size++;
            }
        }

        public void PrependNewRoot(Node node)
        {
            node.NextNode = RootNode;
            this.RootNode = node;
            this.Size++;
        }

        public void Append(Node node)
        {
            this.LastNode.NextNode = node;
            this.LastNode = node;
            this.Size++;
        }

        public void PrintOutList()
        {
            Node walker = this.RootNode;

            for (int i = 1; i <= this.Size; i++)
            {
                Console.WriteLine(walker.Value);
                walker = walker.NextNode;
            }
        }

        public void Delete(int position)
        {
            Node node = GetNodeAtPosition(position);


            if (position == 0)
            {
                this.RootNode = this.RootNode.NextNode;

            }

            else if (position == this.Size - 1)
            {
                this.LastNode = GetNodeAtPosition(position - 1);
               
            }
            
            else
            {
                Node previousNode = this.GetNodeAtPosition(position - 1);
                previousNode.NextNode = node.NextNode;
            }

            this.Size--;
        }

        private Node GetNodeAtPosition(int position)
        {
            Node walker = this.RootNode;

            for (int i = 0; i < position; i++)
            {
                walker = walker.NextNode;
            }

            return walker;
        }
    }
}