namespace Assignment3
{
    internal class ClassListStackVersion
    {
        public Student[] students { get; set; }
        public int currentStudentsInClass { get; set; }

        public ClassListStackVersion(Student[] students)
        {
            this.students = students;
            this.currentStudentsInClass = this.students.Length;
        }

        public ClassListStackVersion(Student student)
        {
            this.students = new Student[1];
            this.students[0] = student;
            this.currentStudentsInClass = 1;
        }

        public bool IsEmpty()
        {
            return currentStudentsInClass == 0;
        }

        public Student Peek()
        {
            return this.students[currentStudentsInClass - 1];
        }

        public void Push(Student student)
        {
            if (currentStudentsInClass == students.Length)
            {
                Resize(2 * students.Length);
            }
            students[currentStudentsInClass++] = student;
        }

        private void Resize(int newCapacity)
        {
            Student[] copy = new Student[newCapacity];
            for (int i = 0; i < currentStudentsInClass; i++)
            {
                copy[i] = students[i];
            }

            this.students = copy;
        }

        public Student Pop()
        {
            Student student = students[--currentStudentsInClass];
            students[currentStudentsInClass] = null;
            if (currentStudentsInClass > 0 && currentStudentsInClass == students.Length / 4)
            {
                Resize(students.Length / 2);
            }
            return student;
        }
    }
}