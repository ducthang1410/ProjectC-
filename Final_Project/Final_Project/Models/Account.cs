using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Account
    {
        public string Cus_UserName { get; set; }
        public string Cus_Password { get; set; }
        public string CusInfor_ID { get; set; }
        public string CusInfor_Gender { get; set; }
        public string CusInfor_BirthDate { get; set; }
        public string CusInfor_Email { get; set; }
        public string CusInfor_Address { get; set; }
        public string Cus_Infor_Phone { get; set; }
        public string CusInfor_Name { get; set; }

    }

    public class AccountData
    {
        public static string strConnection;
        public AccountData()
        {
            getConnectionString();
        }
        public static string getConnectionString()
        {
            strConnection = "server = SE130190; database = Final_Project; uid = sa; pwd = wang0944612720";
            return strConnection;
        }

        

        public static List<Customer> AccountList()
        {
            String sql = "SELECT * FROM Customer_Account,Customer_Information; ";
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
                    String GetUserName = dr["Cus_UserName"].ToString();
                    String GetPass = dr["Cus_Password"].ToString();
                    String GetID = dr["CusInfor_ID"].ToString();
                    String GetName = dr["CusInfor_Name"].ToString();

                    Customer account = new Customer()
                    {
                        Cus_UserName = GetUserName,
                        Cus_Password = GetPass,
                        CusInfor_ID = GetID,
                        CusInfor_Name = GetName
                    };
                    list.Add(account);
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