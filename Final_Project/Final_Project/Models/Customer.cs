using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

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
            String sql = "SELECT * FROM Customer_Information; ";
            SqlConnection con = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr;

            List<Customer> list = new List<Customer>();
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read()) // while dua du lieu len list lien tuc
                {
                    String GetName = dr["CusInfor_Name"].ToString();
                    int GetID = int.Parse(dr["CusInfor_ID"].ToString());
                    bool GetGender = bool.Parse( dr["CusInfor_Gender"].ToString());
                    DateTime GetBirthDay = DateTime.Parse(dr["CusInfor_BirthDay"].ToString());
                    String GetEmail = dr["CusInfor_Email"].ToString();
                    String GetAddress = dr["CusInfor_Address"].ToString();
                    String GetPhone = dr["CusInfor_Phone"].ToString();

                    Customer customer = new Customer()
                    {
                        CusInfor_ID=GetID,
                        CusInfor_Name=GetName,
                        CusInfor_Gender=GetGender,
                        CusInfor_Address=GetAddress,
                        CusInfor_BirthDate=GetBirthDay,
                        CusInfor_Email=GetEmail,
                        Cus_Infor_Phone=GetPhone
                    };
                    list.Add(customer);
                }
                else
                {
                    return null;
                }
                dr.Close();
                return list;
            }
            catch (SqlException se)
            {

                throw new Exception(se.Message);
            }
        }
    }
}