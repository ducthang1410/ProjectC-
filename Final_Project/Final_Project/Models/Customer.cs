using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data.SqlTypes;

namespace Final_Project.Models
{
    public class Customer
    {
        public string CusInfor_Name { get; set; }
        public int CusInfor_ID { get; set; }
        public bool CusInfor_Gender { get; set; }
        public DateTime CusInfor_BirthDate { get; set; }
        public string CusInfor_Email { get; set; }
        public string CusInfor_Address { get; set; }
        public string Cus_Infor_Phone { get; set; }
        
    }

    public class CustomerData : AccountData
    {
        

        public  CustomerData()
        {
            getConnectionString();
        }

        public static List<Customer> CustomersList()
        {
            List<Customer> list = new List<Customer>();
            String sql = "SELECT * FROM Customer_Information; ";
            SqlConnection con = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr ;            
            // đọc => edit 
            try
            {
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    while (dr.Read()) // while dua du lieu len list lien tuc
                    {
                        String GetName = dr["CusInfor_Name"].ToString();
                        int GetID = int.Parse(dr["CusInfor_ID"].ToString());
                        bool GetGender = bool.Parse(dr["CusInfor_Gender"].ToString());
                        DateTime GetBirthDay = DateTime.Parse(dr["CusInfor_BirthDay"].ToString());
                        String GetEmail = dr["CusInfor_Email"].ToString();
                        String GetAddress = dr["CusInfor_Address"].ToString();
                        String GetPhone = dr["CusInfor_Phone"].ToString();

                        Customer customer = new Customer()
                        {
                            CusInfor_ID = GetID,
                            CusInfor_Name = GetName,
                            CusInfor_Gender = GetGender,
                            CusInfor_Address = GetAddress,
                            CusInfor_BirthDate = GetBirthDay,
                            CusInfor_Email = GetEmail,
                            Cus_Infor_Phone = GetPhone
                        };
                        list.Add(customer);
                    }
                }                
                return list;
            }
            catch (SqlException se)
            {

                throw new Exception(se.Message);
            }
        }

        // edit profile
        public static void UpdateCusInfor(Customer customer)
        {
            SqlConnection cnn = new SqlConnection(getConnectionString());
            string SqlUpdate = "Update Customer_Information set [CusInfor_Name]=@CusInfor_Name," +  "[CusInfor_Gender]=@CusInfor_Gender," +
                                                    "[CusInfor_BirthDate]=@CusInfor_BirthDate," + "[CusInfor_Email]=@CusInfor_Email," + "[CusInfor_Address]=@CusInfor_Address,"
                                                    + "[Cus_Infor_Phone]=@Cus_Infor_Phone";
            SqlCommand cmd = new SqlCommand(SqlUpdate, cnn);            
            cmd.Parameters.AddWithValue("@CusInfor_Name", customer.CusInfor_Name);
            cmd.Parameters.AddWithValue("@CusInfor_Gender", customer.CusInfor_Gender);
            cmd.Parameters.AddWithValue("@CusInfor_BirthDate", customer.CusInfor_BirthDate);
            cmd.Parameters.AddWithValue("@CusInfor_Email", customer.CusInfor_Email);
            cmd.Parameters.AddWithValue("@CusInfor_Address", customer.CusInfor_Address);
            cmd.Parameters.AddWithValue("@Cus_Infor_Phone", customer.Cus_Infor_Phone);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        // register
        public static void InsertCusInfor(Customer newcustomer, Account newaccount)
        {
            SqlConnection cnn = new SqlConnection(getConnectionString());
            string SqlInsert = "Insert Customer_Information, Customer_Account values "
                                + "(@Cus_Userame,@Cus_Password,@CusInfor_ID,@CusInfor_Name,@CusInfor_Email)";
            SqlCommand cmd = new SqlCommand(SqlInsert, cnn);
            cmd.Parameters.AddWithValue("@Cus_Username", newaccount.Cus_UserName);
            cmd.Parameters.AddWithValue("@Cus_Password", newaccount.Cus_Password);
            cmd.Parameters.AddWithValue("@CusInfor_ID", newcustomer.CusInfor_ID);
            cmd.Parameters.AddWithValue("@CusInfor_Name", newcustomer.CusInfor_Name);
            cmd.Parameters.AddWithValue("@CusInfor_Email", newcustomer.CusInfor_Email);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch()
            {
                throw new Exception("Error");
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}