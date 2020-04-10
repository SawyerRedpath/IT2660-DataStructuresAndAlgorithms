using System;

namespace BinaryTreeAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(new Student { Id = 1, GPA = 3.5, Name = "James Smith" });
            binaryTree.Insert(new Student { Id = 2, GPA = 2.5, Name = "Michael Smith" });
            binaryTree.Insert(new Student { Id = 3, GPA = 1.5, Name = "Robert Smith" });
            binaryTree.Insert(new Student { Id = 4, GPA = 3.6, Name = "Maria Garcia" });
            binaryTree.Insert(new Student { Id = 5, GPA = 3.7, Name = "David Smith" });
            binaryTree.Insert(new Student { Id = 6, GPA = 3.2, Name = "Maria Rodriguez" });
            binaryTree.Insert(new Student { Id = 7, GPA = 3.6, Name = "Sawyer Redpath" });

            Console.WriteLine("In Order Traversal, printing sorted Binary Search Tree");
            binaryTree.InOrderTraversal();

            Console.WriteLine("\nFind the student with the name Sawyer Redpath");
            var node = binaryTree.Find("Sawyer Redpath");
            Console.WriteLine("Student Name: " + node.Student.Name
                + ", Student ID#: " + node.Student.Id
                + ", Student GPA: " + node.Student.GPA);

            Console.WriteLine("\nHard delete of student with name Michael Smith");
            binaryTree.Remove("Michael Smith");
            binaryTree.InOrderTraversal();

            Console.WriteLine("\nSoft delete of student with name Maria Garcia");
            binaryTree.SoftDelete("Maria Garcia");
            binaryTree.InOrderTraversal();

            // Update
            Console.WriteLine("\nUpdating student Sawyer Redpath GPA to 3.9");
            var nodeToUpdate = binaryTree.Find("Sawyer Redpath");
            nodeToUpdate.Student.GPA = 3.9;
            binaryTree.InOrderTraversal();





        }
    }
}
