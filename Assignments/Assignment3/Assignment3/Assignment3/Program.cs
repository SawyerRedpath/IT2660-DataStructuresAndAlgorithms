using System;

namespace Assignment3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ClassListStackVersion algorithmClass = new ClassListStackVersion(new Student(0, "FirstName", "LastName", 3.0));

            Console.WriteLine("Class begins with 1 student \n");

            Console.WriteLine("Push students\n");
            for (int i = 1; i < 16; i++)
            {
                algorithmClass.Push(new Student(i, "FirstName" + i.ToString(), "LastName" + i.ToString(), 3.0));

                Console.WriteLine("Student " + (i + 1).ToString() + " pushed");
                Console.WriteLine("Current array size = " + algorithmClass.students.Length + "\n");
            }

            Console.WriteLine();
            Console.WriteLine("Pop students");

            for(int i = 0; i < 14; i++)
            {
                Student student = algorithmClass.Pop();
                Console.WriteLine("Stack student #" + (algorithmClass.currentStudentsInClass +1).ToString() + " popped");
                Console.WriteLine("Current stack size = " + algorithmClass.students.Length + "\n");
            }
        }
    }
}