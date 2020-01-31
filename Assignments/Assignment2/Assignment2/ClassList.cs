using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class ClassList
    {
        public Student[] students { get; set; }
        public int currentStudentsInClass { get; set; }

        public ClassList(Student[] students)
        {
            this.students = students;
            this.currentStudentsInClass = this.students.Length;
        }

        public ClassList(Student student)
        {
            this.students = new Student[1];
            this.students[0] = student;
            this.currentStudentsInClass = 1;
        }

        // Return true if success, return false if not
        public bool Insert(Student student, int index)
        {
            // Check if index is invalid
            if (index > this.students.Length || index < 0)
            {
                return false;
            }

            // If the array is full
            if (this.students[this.students.Length - 1] != null)
            {
                // Increase the size of the array * 2 (so as not to resize too often)
                resize(this.students.Length * 2);
            }

            // Move each item before insertion point over one index
            for (int i = index; i < this.currentStudentsInClass; i++)
            {
                this.students[i + 1] = this.students[i];
            }

            // Insert student into index
            this.students[index] = student;
            this.currentStudentsInClass++;

            return true;
        }

        // Return true if success
        public bool Delete(int index)
        {
            // If invalid index
            if (this.students[index] == null || index > this.students.Length - 1 ||
                this.currentStudentsInClass == 0)
            {
                return false;
            }

            // Delete student
            this.students[index] = null;

            // Decrement current number of students in class
            this.currentStudentsInClass--;

            // Move all elements one to left
            for (int i = index; i < this.currentStudentsInClass; i++)
            {
                this.students[i] = this.students[i + 1];
            }

            // If the array is 1/4 full then shrink the array by half (avoid thrashing)
            if (this.currentStudentsInClass > 0 && this.students.Length / 4 == this.currentStudentsInClass)
            {
                resize(this.students.Length / 2);
            }

            return true;
        }

        private void resize(int newSize)
        {
            // Create new array twice the size of previous array
            Student[] resizedStudentArray = new Student[newSize];

            // Copy students to new array
            for (int i = 0; i < this.currentStudentsInClass; i++)
            {
                resizedStudentArray[i] = this.students[i];
            }

            this.students = resizedStudentArray;
        }
    }
}