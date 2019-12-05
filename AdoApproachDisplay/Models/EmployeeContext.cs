using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoApproachDisplay.Models
{
    public class EmployeeContext
    {

       

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());

        //public object EmpID { get; private set; }

        public List<EmployeeModel> GetEmployeeDetails()
        {
            SqlCommand cmd = new SqlCommand("GetInfo", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<EmployeeModel> list = new List<EmployeeModel>();

            foreach ( DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpID = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.Password = Convert.ToString(dr[2]);
                emp.CPassword = Convert.ToString(dr[3]);
                emp.Salary = Convert.ToInt32(dr[4]);
                emp.Address = Convert.ToString(dr[5]);

                list.Add(emp);

            }
            return list;
        }

        public int CreateEmployee(EmployeeModel obj)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SaveEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpName",obj.EmpName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@Cpassword", obj.CPassword);
            cmd.Parameters.AddWithValue("@Salary", obj.Salary);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            int rowseffected = cmd.ExecuteNonQuery();

            if (rowseffected > 0)

            {
                return 1;
            }
           else
            {
                return 0;
            }
        }

        public EmployeeModel GetEmployeeDetailsById(int EmpId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("selectemployeebyid", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
           

            da.SelectCommand.Parameters.AddWithValue("@EmpId", EmpId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeModel emp = new EmployeeModel();
           

            foreach (DataRow dr in dt.Rows)
            {
                
                emp.EmpID = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.Password = Convert.ToString(dr[2]);
                emp.CPassword = Convert.ToString(dr[3]);
                emp.Salary = Convert.ToInt32(dr[4]);
                emp.Address = Convert.ToString(dr[5]);

              

            }
            return emp;
        }

        

        public int UpdateEmployee(EmployeeModel obj)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("EditEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", obj.EmpID);
            cmd.Parameters.AddWithValue("@EmpName", obj.EmpName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@Cpassword", obj.CPassword);
            cmd.Parameters.AddWithValue("@Salary", obj.Salary);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            int rowseffected = cmd.ExecuteNonQuery();

            if (rowseffected > 0)

            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public int DeleteEmployee(int EmpId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
            
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@EmpId", EmpId);


            int rowseffected = cmd.ExecuteNonQuery();

            if (rowseffected > 0)

            {
                return 1;
            }
            else
            {
                return 0;
            }

        }



    }
}