using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace updateDelte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            student1.Student_Name = "Sıla ";
            student1.Student_LastName = "8";
            student1.Student_ClassName = "C";
            student1.Student_Class = 8;

            StudentManeger student2 = new StudentManeger();
            student2.Add(student1);

            Console.WriteLine("İşlem Tamam");




            StudentManeger studentManager = new StudentManeger();
            List<Student> students = studentManager.List();

        
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Student_Id}, Adı: {student.Student_Name}, Soyadı: {student.Student_LastName}, Sınıf: {student.Student_ClassName}, Ders: {student.Student_Class}");
            }

            Console.ReadLine(); 
        }


       

        
    }

}