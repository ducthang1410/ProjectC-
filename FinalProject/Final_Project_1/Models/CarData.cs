using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Razor.Generator;

namespace Final_Project_1.Models
{
    public class CarData
    {
        string strConnection;

        public CarData()
        {
            this.strConnection = GetConnection();
        }
        public static String GetConnection()
        {
            String c = "server=SE130157;database=Final_Project_2;uid=se;pwd=123";
            return c;
        }
        public static List<Car> GetAllCars()
        {
            List<Car> list = new List<Car>();
            string SQL = "select Car_ID, Car_Name, Car_Status, Car_Color, City, " +
                    "Car_Version, Car_Series, Car_YearOfProduction, Car_Type, Car_Origin, Car_Price from dbo_Car";
            SqlConnection cnn = new SqlConnection(GetConnection());
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cnn.Open();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    dynamic u = new Car();
                    {
                        u.CarID = rd["Car_ID"].ToString();
                        u.CarName = rd["Car_Name"].ToString();
                        u.CarStatus = rd["Car_Status"].ToString();
                        u.CarColor = rd["Car_Color"].ToString();
                        u.CarCity = rd["City"].ToString();
                        u.CarVersion = rd["Car_Version"].ToString();
                        u.CarYearOfProduction = int.Parse(rd["Car_YearOfProduction"].ToString());
                        u.CarType = rd["Car_Type"].ToString();
                        u.CarOrigin = rd["Car_Origin"].ToString();
                        u.CarPrice = double.Parse(rd["Car_Price"].ToString());
                    };
                    list.Add(u);
                }
            }
            return list;
        }

        public static Car getCarByID(string Id)
        {
            Car car = GetAllCars().SingleOrDefault(c => c.CarID.Equals(Id));
            return car;
        }
        
    }
}