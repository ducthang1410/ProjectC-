using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Project_1.Models
{
    public class AccountData
    {
        public static String GetConnection()
        {
            String c = "server=SE130157;database=Final_Project;uid=se;pwd=123";
            return c;
        }
        public static List<Account> AccountList()
        {
            String sql = "SELECT * FROM dbo.Customer_Account; ";
            SqlConnection con = new SqlConnection(GetConnection());
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
                        UserName = GetUserName,
                        Password = GetPass
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

        public bool CheckAccount(string username, string password)
        {
            Account acc = AccountData.AccountList().SingleOrDefault(c => c.UserName.Equals(username)
            && c.Password.Equals(password));
            if (acc == null)
            {
                return false;
            }
            return true;
        }
    }
}