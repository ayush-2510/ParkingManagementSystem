using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2lab4
{
    public class UserService : IUserService
    {

        public List<String> getUsers()
        {
            List<String> users = new List<string>();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Id from UserInfo";
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    users.Add(rdr["Id"].ToString());
                }
                return users;
            }
        }

        public void deleteUser(string Email)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Delete from UserInfo where Email=@Email";
                cmd.Connection = con;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Email";
                parameterId.Value = Email;
                cmd.Parameters.Add(parameterId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void updateUser(User user,string Email) {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Update UserInfo set UserName=@UserName,Password=@Password,Email=@Email where Email=@UserEmail";
                cmd.Connection = con;
                SqlParameter parameterId = new SqlParameter
                {
                    ParameterName = "@UserEmail",
                    Value = Email,
                };
                cmd.Parameters.Add(parameterId);
                SqlParameter parameterName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = user.UserName,
                };
                cmd.Parameters.Add(parameterName);
                SqlParameter parameterPassword = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password,
                };
                cmd.Parameters.Add(parameterPassword);
                SqlParameter parameterEmail = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = user.Email,
                };
                cmd.Parameters.Add(parameterEmail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public User viewUser(string Id) {
            User user = new User();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select Id,Username,Password,Email from UserInfo where Id=@UserId";
                cmd.Connection = con;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@UserId";
                parameterId.Value = Id;
                cmd.Parameters.Add(parameterId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.UserName = rdr["Username"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Password = rdr["Password"].ToString();
                    return user;
                }
                else
                {
                    user.Id = -1;
                    user.UserName = "User not Found";
                    return user;
                }
            }
        }

        public User viewUser1(string Email)
        {
            User user = new User();
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select Id,Username,Password,Email from UserInfo where Email=@Email";
                cmd.Connection = con;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Email";
                parameterId.Value = Email;
                cmd.Parameters.Add(parameterId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.UserName = rdr["Username"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Password = rdr["Password"].ToString();
                    return user;
                }
                else
                {
                    user.Id = -1;
                    user.UserName = "User not Found";
                    return user;
                }
            }
        }

        public User loginUser(string Email, string Password)
        {   
            User user = new User();

            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select Id,Username,Password,Email from UserInfo where Email=@Email and Password=@Password";
                cmd.Connection = con;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Email";
                parameterId.Value = Email;
                cmd.Parameters.Add(parameterId);
                SqlParameter parameterId1 = new SqlParameter();
                parameterId1.ParameterName = "@Password";
                parameterId1.Value = Password;
                cmd.Parameters.Add(parameterId1);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    user.Id = Convert.ToInt32(rdr["Id"]);
                    user.UserName = rdr["Username"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.Password = rdr["Password"].ToString();
                    return user;
                }
                else {
                    user.Id = -1;
                    user.UserName = "User not Found";
                    return user;
                }
            }
            
        }

        public int registerUser(User user)
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ParkingManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into UserInfo (Username , Password , Email) values(@UserName,@Password,@Email)";
                SqlParameter parameterName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = user.UserName,
                };
                cmd.Parameters.Add(parameterName);
                SqlParameter parameterPassword = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password,
                };
                cmd.Parameters.Add(parameterPassword);
                SqlParameter parameterEmail = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = user.Email,
                };
                cmd.Parameters.Add(parameterEmail);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return 0;
        }
    }
}
