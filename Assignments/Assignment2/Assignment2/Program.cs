using System;

namespace Assignment2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ClassList algorithmClass = new ClassList(new Student(0, "FirstName", "LastName", 3.0));

            Console.WriteLine("Class begins with 1 student \n");

            Console.WriteLine("Insert students\n");
            for (int i = 1; i < 16; i++)
            {
                if (algorithmClass.Insert(new Student(i, "FirstName" + i.ToString(), "LastName" + i.ToString(), 3.0), i))
                {
                    Console.WriteLine("Student " + (i + 1).ToString() + " inserted");
                    Console.WriteLine("Current array size = " + algorithmClass.students.Length + "\n");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Delete students");
            Random random = new Random();

            for (int i = 0; i < 14; i++)
            {
                int randomNumber = random.Next(0, 5);
                if (algorithmClass.Delete(randomNumber))
                {
                    Console.WriteLine("Student index" + randomNumber + " deleted");
                    Console.WriteLine("Current array size = " + algorithmClass.students.Length + "\n");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Remaining Students:");
            for (int i = 0; i < algorithmClass.currentStudentsInClass; i++)
            {
                Console.WriteLine(algorithmClass.students[i].FirstName + " " + algorithmClass.students[i].LastName);
            }
        }
    }
}