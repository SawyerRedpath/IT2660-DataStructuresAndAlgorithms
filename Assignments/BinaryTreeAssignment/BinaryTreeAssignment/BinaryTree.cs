using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeAssignment
{
    class BinaryTree
    {
        private Node root;

        public void Insert(Student student)
        {
            // If root is not null then call the insert method on root node
            if(this.root != null)
            {
                root.Insert(student);
            }
            else
            { // If root is null then set the rooot to be a new node with this data passed in
                root = new Node(student);
            }
        }

        public Node Find(string studentNameToFind)
        {
            // if the root is not null then call the find method on root
            if (root != null)
            {
                // call node method Find
                return root.Find(studentNameToFind);
            }

            else
            { // the root is null so return null, there is nothing to find
                return null;
            }
        }

        public void Remove(string studentNameToDelete)
        {
            // Set the current and aprent node to root so we can remove using the parents reference
            Node current = root;
            Node parent = root;
            bool isLeftChild = false; // keep track of which child of parent should be removed

            // empty tree case
            if (current == null)
            { // nothing to remove, return
                return;
            }

            // Find node to delete
            // Loop through until not not found OR we find node with matching data
            while (current != null && !current.Student.Name.Equals(studentNameToDelete))
            {
                // set current node to be parent reference then look at its children
                parent = current;

                // if the name we are looking for is less than current node then look at left child
                if (string.Compare(studentNameToDelete, current.Student.Name) == -1)
                {
                    current = current.LeftChild;
                    isLeftChild = true; // Set variable since we are looking at its left child
                }
                else
                { // otherwise look at right child
                    current = current.RightChild;
                    isLeftChild = false; // Set variable since we are looking at right child
                }
            }

            // if node not found nothing to delete, return
            if (current == null) return;

            // If we found a leaf node (no children)
            if (current.RightChild == null && current.LeftChild == null)
            {
                // Root doesn't have parent to check what child it is so just set to null
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    // When it's not root node
                    // see which child of the parent needs to be deleted
                    if (isLeftChild)
                    {
                        // remove reference to left child node
                        parent.LeftChild = null;
                    }
                    else
                    { // remove reference to right child node
                        parent.RightChild = null;
                    }
                }
            }
            else if (current.RightChild == null) // currently only has a left child so set the parents node child to be this node left child
            {
                // If current node is the root then we just set root to left child
                if (current == root)
                {
                    root = current.LeftChild;
                }
                else
                {
                    // see which child of parent is to be deleted
                    if (isLeftChild) // is this right or left child check
                    {
                        // current is left child, set right node of parent to current node left child
                        parent.LeftChild = current.LeftChild;
                    }
                }
            }
            else if (current.LeftChild == null) // currentony only have right child so set parents node child to be this nodes right
            {
                // If current node is the root then set root to right child node
                if (current == root)
                {
                    root = current.RightChild;
                }
                else
                {
                    // see which child of parent to dlete
                    if (isLeftChild)
                    {
                        // current is left child, set left node of parent to current nodes right child
                        parent.LeftChild = current.RightChild;
                    }
                    else
                    { // current is right child so set right node of parent to current nodes right child
                        parent.RightChild = current.RightChild;
                    }
                }
            }
            else
            { // current node hase both a left and right child

                // Go to right node and find the leaf node of the left child as this will be smallest
                // that is greater than current node. May also have right child, right child would become left child of the parent of this leaf or "successor"

                // Find successor
                Node successor = GetSuccessor(current);

                // if current node is root node then the new root is successor node
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                { // if is left child set parents left hcild as successor
                    parent.LeftChild = successor;
                }
                else
                { // if it is right child set parents right childas successor
                    parent.RightChild = successor;
                }

            }
        }

        public void SoftDelete(string studentNameToDelete)
        {
            Node toDelete = Find(studentNameToDelete);
            if (toDelete != null)
            {
                toDelete.Delete();
            }
        }

        private Node GetSuccessor(Node node)
        {
            var parentOfSuccessor = node;
            var successor = node;
            var current = node.RightChild;

            // Start at right child, go down every left child node
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftChild; // go to left next node
            }
            // if successor not only right node then
            if (successor != node.RightChild)
            {
                // set left node on parent node of successor to right child node of successor incase it has one
                parentOfSuccessor.LeftChild = successor.RightChild;
                // attach right child node of node to be deleted to successor right node
                successor.RightChild = node.RightChild;
            }
            // attach left child node of node being deleted to successor leftnode 
            successor.LeftChild = node.LeftChild;

            return successor;
        }

        // Keeps going left down tree until bottom then recursive to parent, then right, ascending tree.
        public void InOrderTraversal()
        {
            if (root != null) root.InOrderTraversal();
        }
    }
}
