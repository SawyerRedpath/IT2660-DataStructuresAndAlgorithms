using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeAssignment
{
    class Node
    {
        public Student Student { get; set; }

        public Node LeftChild { get; set; }

        public Node RightChild { get; set; }

        public bool IsDeleted { get; set; }

        public Node(Student student)
        {
            this.Student = student;
        }

        // Traverse tree until find student name we are looking for
        public Node Find(string studentNameToFind)
        {
            // this node is the current node;
            Node currentNode = this;

            // loop through this node and all it's children
            while (currentNode != null)
            {
                // If current node student name equals to name searchinf for, return it
                if (string.Compare(studentNameToFind, currentNode.Student.Name) == 0 && IsDeleted == false) // check for soft delete
                {
                    return currentNode;
                }
                // If name to search for is greater than current node name then go to right node
                else if (string.Compare(studentNameToFind, currentNode.Student.Name) == 1)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                { // otherwise if value to search for is less than current go to left child node
                    currentNode = currentNode.LeftChild;
                }
     
            }

            // Could not find node
            return null;
        }

        // Method recursively calls itself down the tree until it find an open spot
        public void Insert(Student student)
        {
            // If students name is greater or equal to the parent then insert to right node
            if ( string.Compare(student.Name, this.Student.Name) >= 0)
            { // if right child is null create new node
                if(RightChild == null)
                {
                    RightChild = new Node(student);
                }
                else
                { // if right child not null recursively call insert on right child
                    RightChild.Insert(student);
                }
            }
            else
            { // if the students name is less than the parent then insert to left node
                if(LeftChild == null)
                { // if the left child is null create a new node
                    LeftChild = new Node(student);
                }

                else
                { // If the left child is not null then recursively call insert on left child
                    LeftChild.Insert(student);
                }
            }
        }

        // Will print student names in ascending order
        // Prints Left -> Root -> Right nodes recursively on each sub tree
        public void InOrderTraversal()
        {
            // Traverse left down tree until reach node with null child
            if (LeftChild != null) LeftChild.InOrderTraversal();

            // Then print the root node
            Console.WriteLine(Student.Name + ", GPA = " + Student.GPA + ", ID # " + Student.Id + ", SoftDeleted: " + IsDeleted);

            if (RightChild != null)
            {
                RightChild.InOrderTraversal();
            }

            
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
