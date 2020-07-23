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

        public void output()
        {
            Console.WriteLine(Cus_UserName + "  " + Cus_Password);
        }
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
            strConnection = "server = SE130190; database = Final_Project;User ID= sa; password = wang0944612720";
            return strConnection;
        }



        public static List<Account> AccountList()
        {
            String sql = "SELECT * FROM dbo.Customer_Account; ";
            SqlConnection con = new SqlConnection(getConnectionString());
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr;

            List<Account> list = new List<Account>();
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                /*while (dr.Read() == true)*/ // while dua du lieu len list lien tuc
                if (dr.Read())
                {
                    String GetUserName = dr["Cus_UserName"].ToString();
                    String GetPass = dr["Cus_Password"].ToString();

                    Account account = new Account()
                    {
                        Cus_UserName = GetUserName,
                        Cus_Password = GetPass
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

        // change pass
        public static void UpdateAccount(Account account)
        {
            SqlConnection cnn = new SqlConnection(getConnectionString());
            string SqlUpdate = "Update Customer_Account set [Cus_Password]=@Cus_Password";
            SqlCommand cmd = new SqlCommand(SqlUpdate, cnn);
            cmd.Parameters.AddWithValue("@Cus_Password", account.Cus_Password);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public static void output()
        {
            foreach (Account x in AccountList())
            {
                x.output();
            }
        }
    }

        

}