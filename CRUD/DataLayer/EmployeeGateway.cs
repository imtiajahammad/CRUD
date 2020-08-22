using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD.DataLayer
{
    public class EmployeeGateway
    {
        public List<EmployeeModel> GetEmployee()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            using (SqlConnection con =new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                string query = "select 	id, firstname, lastname, age, address, dateofbirth from Employee";
                SqlCommand cmd = new SqlCommand(query,con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeModel employeeModel = new EmployeeModel();
                        employeeModel.Id = Convert.ToInt32(reader["id"]);
                        employeeModel.FirstName = reader["firstname"].ToString();
                        employeeModel.LastName = reader["lastname"].ToString();
                        //employeeModel.Age = Convert.ToInt32(reader["age"]);
                        employeeModel.Age = Convert.ToDecimal(reader["age"]);
                        employeeModel.Address = reader["address"].ToString();
                        employeeModel.DateOfBirth = Convert.ToDateTime(reader["dateofbirth"]);
                        employees.Add(employeeModel);
                    }
                    con.Close();
                }
                catch(Exception ex)
                {
                    //error message
                }
            }
            return employees;
        }
        public EmployeeModel GetEmployee(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                string query = "select 	id, firstname, lastname, age, address, dateofbirth from Employee where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {                        
                        employeeModel.Id = Convert.ToInt32(reader["id"]);
                        employeeModel.FirstName = reader["firstname"].ToString();
                        employeeModel.LastName = reader["lastname"].ToString();
                        //employeeModel.Age = Convert.ToInt32(reader["age"]);
                        employeeModel.Age = Convert.ToDecimal(reader["age"]);
                        employeeModel.Address = reader["address"].ToString();
                        employeeModel.DateOfBirth = Convert.ToDateTime(reader["dateofbirth"]);                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    //error message
                }
            }
            return employeeModel;
        }
        public void UpdateEmployee(EmployeeModel employeeModel)
        {            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                string query = "Update Employee set firstname=@firstname, lastname=@lastname, age=@age, address=@address, dateofbirth=@dateofbirth where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", employeeModel.Id);
                cmd.Parameters.AddWithValue("@firstname", employeeModel.FirstName);
                cmd.Parameters.AddWithValue("@lastname", employeeModel.LastName);
                cmd.Parameters.AddWithValue("@age", employeeModel.Age);
                cmd.Parameters.AddWithValue("@address", employeeModel.Address);
                cmd.Parameters.AddWithValue("@dateofbirth", employeeModel.DateOfBirth);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    //error message
                }
            }
            
        }
        public void CreateEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                string query = "insert into Employee(firstname,lastname,age,address,dateofbirth) Values(@firstname,@lastname,@age,@address,@dateofbirth) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firstname", employeeModel.FirstName);
                cmd.Parameters.AddWithValue("@lastname", employeeModel.LastName);
                cmd.Parameters.AddWithValue("@age", employeeModel.Age);
                cmd.Parameters.AddWithValue("@address", employeeModel.Address);
                cmd.Parameters.AddWithValue("@dateofbirth", employeeModel.DateOfBirth);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    //error message
                }
            }
        }
        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                string query = "delete from Employee where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    //error message
                }
            }
        }
    }
}