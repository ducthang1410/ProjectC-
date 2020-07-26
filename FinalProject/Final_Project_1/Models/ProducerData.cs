using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Project_1.Models
{
    public class ProducerData
    {

        string strConnection;

        public ProducerData()
        {
            this.strConnection = GetConnection();
        }
        public static String GetConnection()
        {
            String c = "server=SE130157;database=Final_Project;uid=se;pwd=123";
            return c;
        }

        public static List<Car> GetAllProducers()
        {
            List<Car> list = new List<Car>();
            string SQL = "select Producer_ID, Producer_Name, Producer_Address from Producer";
            SqlConnection cnn = new SqlConnection(GetConnection());
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cnn.Open();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    dynamic v = new Producer();
                    {
                        v.ProducerID = rd["Producer_ID"].ToString();
                        v.ProducerName = rd["Producer_Name"].ToString();
                        v.CarDescription = rd["Car_Description"].ToString();
                    };
                    list.Add(v);
                }
            }
            return list;
        }

    }
}