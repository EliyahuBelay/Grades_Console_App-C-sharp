using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades_App
{
    public class Professor
    {
        public string nameProfesor;
        public string nameStudent;
        public string id;
        public short[] arrayGrades;

        public Professor(string nameProfesor, string nameStudent,string id, short[]arrayGrades)
        {
            this.nameProfesor = nameProfesor;
            this.nameStudent = nameStudent;
            this.id = id;
            this.arrayGrades = arrayGrades;
        }

        public static void ProfessorAction()
        {
            
            switch (ContainerToStartMenue())
            {
                case 1:
                    try
                    {
                        GettProfessorNameAndNumOfStudents();
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("put how many students you want professor IN NUMBERS please");
                        Console.WriteLine("please try again.");
                        Console.WriteLine();
                        ProfessorAction();
                    }
                    break;
                case 2:

                    break;
            }
            



        }

        //static byte ContainerToStartMenue()// need some work..
        //{
        //    try
        //    {
        //        return StartMenu();
        //    }
        //    catch (FormatException)
        //    {
        //        Console.WriteLine("");
        //        Console.WriteLine("put IN NUMBERS please");
        //        Console.WriteLine("please try again.");
        //        ProfessorAction();
        //    }
        //}
        static byte StartMenu()
        {
            try
            {
                Console.WriteLine("Hello What you want to do ");
                Console.WriteLine("");
                Console.WriteLine("for addinng a student - press 1 | for printing first student details - press 2 |");
                return byte.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("put IN NUMBERS please");
                Console.WriteLine("please try again.");
                return ProfessorAction();
            }
            
        }
        static void GettProfessorNameAndNumOfStudents()
        {
            Console.WriteLine("Professor please put youe name");
            string profesorName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("and now put how many students you want professor");
            int bunchOfStudents = int.Parse(Console.ReadLine());

            GetListOfInctances(profesorName, bunchOfStudents);

            GetArrayOfStrings(profesorName, bunchOfStudents);
                //throw new FormatException("put how many students you want professor IN NUMBERS please");//neve succeed to do it.
            static void GetListOfInctances(string profesorName, int bunchOfStudents)
            {
                List<Professor> listOfinctances = new List<Professor>();
                for (int i = 0; i < bunchOfStudents; i++)
                {
                    Console.WriteLine("put the name of the student");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("put the id of the student");
                    string studentId = Console.ReadLine();
                    Console.WriteLine("put three grades for the student");
                    short[] listOne = new short[] { short.Parse(Console.ReadLine()), short.Parse(Console.ReadLine()), short.Parse(Console.ReadLine()) };
                    listOfinctances.Add(new Professor(profesorName, studentName, studentId, listOne));
                }
                int counter = 0;
                FileStream fs = new FileStream($@"C:\test\{profesorName}.txt", FileMode.Create, FileAccess.Write);
                using (StreamWriter file1 = new StreamWriter(fs))
                {
                    foreach (Professor professor in listOfinctances)
                    {
                        file1.WriteLine($"ID:{counter} Taz:{professor.id} name:{professor.nameStudent} gredes:{professor.arrayGrades[0]} {professor.arrayGrades[1]} {professor.arrayGrades[2]},");
                        counter++;
                    }
                }
            }
            static void GetArrayOfStrings(string profesorName, int bunchOfStudents)
            {
                List<string> arrayOfStudent = new List<string> { };
                FileStream sw = new FileStream($@"C:\test\{profesorName}.txt", FileMode.Open, FileAccess.Read);
                using (StreamReader file2 = new StreamReader(sw))
                {
                    for (int i = 0; i < bunchOfStudents; i++)
                    {
                        arrayOfStudent.Add(file2.ReadLine());
                    }
                }
            }

        }
       //static void PrintFirstChild()
       // {
       //     Console.WriteLine("Professor please put youe name");
       //     string profesorName = Console.ReadLine();
       //     FileStream fs = new FileStream($@"C:\test\{profesorName}.txt",FileMode.Open,FileAccess.Read);
       //     using(StreamReader file = new StreamReader(fs))
       //     {
       //         string studentDetails = file.ReadLine();
       //     }
       // }
        
    }
}
