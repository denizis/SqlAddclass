using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace updateDelte
{
    internal class StudentManeger
    {
        public void Add(Student student)
        {
            string connectionString = "Data Source=DENIZ\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Student ( Student_Name, Student_LastName,Student_ClassName,Student_Class) VALUES ( @Student_Name, @Student_LastName,@Student_ClassName,@Student_Class)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Student_Id", student.Student_Id);
                    command.Parameters.AddWithValue("@Student_Name", student.Student_Name);
                    command.Parameters.AddWithValue("@Student_LastName", student.Student_LastName);
                    command.Parameters.AddWithValue("@Student_ClassName", student.Student_ClassName);
                    command.Parameters.AddWithValue("@Student_Class", student.Student_LastName);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Öğrenci başarıyla eklendi.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Öğrenci ekleme hatası: " + ex.Message);
                    }
                }
            }

        }

        public List<Student> List()
        {
            List<Student> students = new List<Student>();

            
            string connectionString = "Data Source=DENIZ\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True;Connect Timeout=30";

            
            string query = "SELECT Student_Id, Student_Name, Student_LastName, Student_ClassName, Student_Class FROM Student";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                       
                        connection.Open();

                    
                        SqlDataReader reader = command.ExecuteReader();

                        
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                Student_Id = Convert.ToInt32(reader["Student_Id"]),
                                Student_Name = reader["Student_Name"].ToString(),
                                Student_LastName = reader["Student_LastName"].ToString(),
                                Student_ClassName = reader["Student_ClassName"].ToString(),
                                Student_Class = Convert.ToInt32(reader["Student_Class"])
                            };

                            students.Add(student); 
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Veri çekme hatası: " + ex.Message);
                    }
                }
            }

            return students; 
        }

    }



    }
