namespace StudentInfo
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            SortedDictionary<string, List<Student>> studentInClasses = new SortedDictionary<string, List<Student>>(); 

            using (StreamReader inputStream = new StreamReader(@"../../student.txt"))
            {
                string line = inputStream.ReadLine();

                while (line != null)
                {
                    string[] splitedLine = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string studentClass = splitedLine[2];
                    Student currentStudent = new Student(splitedLine[0], splitedLine[1]);

                    if (studentInClasses.ContainsKey(studentClass))
                    {
                        studentInClasses[studentClass].Add(currentStudent);
                    }
                    else
                    {
                        studentInClasses.Add(studentClass, new List<Student>() { currentStudent });
                    }

                    line = inputStream.ReadLine();
                }
            }

            foreach (var element in studentInClasses)
            {
                Console.Write("Class: {0} ", element.Key);

                foreach (var student in element.Value)
                {
                    Console.Write(student.ToString());
                }

                Console.WriteLine();
                Console.WriteLine(new string('-', Console.WindowWidth - 2));
            }
        }
    }
}
