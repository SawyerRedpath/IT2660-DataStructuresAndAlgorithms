using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_LinkedList
{
    public class Node
    {
        /// <summary>
        /// The value of the node
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The next node in the linked list
        /// </summary>
        public Node NextNode { get; set; }

        /// <summary>
        /// Constructs a new node with the given value
        /// </summary>
        /// <param name="value">The value to be given to the node</param>
        public Node(string value)
        {
            this.Value = value;
        }

       
    }
}
