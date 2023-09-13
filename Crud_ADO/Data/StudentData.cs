using Crud_ADO.Models;
using Crud_ADO.Utility;
using System.Data;
using System.Data.SqlClient;

namespace Crud_ADO.Data
{
    public class StudentData
    {
        string connectionstring = ConnectionString.ConnectionName;

       //When we have to show the data then we have to make list
       
        public List<Student> GetAllStudent()
        {
            List<Student> liststudents = new List<Student>();

            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllStudent", con);

                sqlCommand.CommandType=CommandType.StoredProcedure;

                con.Open(); 

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) { 
                Student student = new Student();
                    student.Id = Convert.ToInt32(reader["ID"]);

                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Address = reader["Address"].ToString();

                    liststudents.Add(student);




                }
                con.Close();




            }



            return liststudents;
        }

        public void AddStudent(Student student)
        {
            using(SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sqlCommand = new SqlCommand("SPAddStudent", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                sqlCommand.Parameters.AddWithValue("@Mobile", student.Mobile);
                sqlCommand.Parameters.AddWithValue("@Address", student.Address);


                connection.Open();
                sqlCommand.ExecuteNonQuery();

                connection.Close();

            }
        }



        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sqlCommand = new SqlCommand("SPUpdateStudent", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", student.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                sqlCommand.Parameters.AddWithValue("@Mobile", student.Mobile);
                sqlCommand.Parameters.AddWithValue("@Address", student.Address);


                connection.Open();
                sqlCommand.ExecuteNonQuery();

                connection.Close();

            }
        }


        public void DeleteStudent(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sqlCommand = new SqlCommand("SPDeleteStudent", connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                


                connection.Open();
                sqlCommand.ExecuteNonQuery();

                connection.Close();

            }
        }


        public Student DetailStudent(int? id)
        {
            Student student1 = new Student();



            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string query = "SELECT * FROM STUDENT WHERE Id=@Id";
                SqlCommand sqlCommand = new SqlCommand(query, con);

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                   
                    student1.Id = Convert.ToInt32(reader["Id"]);

                    student1.FirstName = reader["FirstName"].ToString();
                    student1.LastName = reader["LastName"].ToString();
                    student1.Email = reader["Email"].ToString();
                    student1.Mobile = reader["Mobile"].ToString();
                    student1.Address = reader["Address"].ToString();

                



                }
                con.Close();




            }

            return student1;

            
        }



    }
}
