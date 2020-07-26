using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Project_1.Models
{
    public class ListProductInfo
    {
        string strConnection;

        public ListProductInfo()
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

        public static List<Image> GetAllImages()
        {
            List<Image> list = new List<Image>();
            string SQL = "select Img_ID, Img_Path, Car_ID from dbo_Image";
            SqlConnection cnn = new SqlConnection(GetConnection());
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cnn.Open();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    dynamic u = new Image();
                    {
                        u.ImageID = rd["Image_ID"].ToString();
                        u.ImagePath = rd["Image_Path"].ToString();
                        u.CarID = rd["Car_ID"].ToString();
                    };
                    list.Add(u);
                }
            }
            return list;
        }

        public static Image getImageByCarID(string Id)
        {
            Image img = GetAllImages().SingleOrDefault(i => i.CarID.Equals(Id));
            return img;
        }

        public static List<Technology> GetAllTechnologies()
        {
            List<Technology> list = new List<Technology>();
            string SQL = "select Tech_ID, Doors, Chairs, Engine, Cylinder_Capacity, " +
                    "Fuel_Tank_Capacity, Car_Lead, Fuel, Fuel_Filling_System, Consumption, Car_ID from dbo_Tech";
            SqlConnection cnn = new SqlConnection(GetConnection());
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cnn.Open();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    dynamic u = new Technology();
                    {
                        u.TechID = int.Parse(rd["Tech_ID"].ToString());
                        u.Doors = int.Parse(rd["Doors"].ToString());
                        u.Chairs = int.Parse(rd["Chairs"].ToString());
                        u.Engine = rd["Engine"].ToString();
                        u.CylinderCapacity = int.Parse(rd["Cylinder_Capacity"].ToString());
                        u.FuelTankCapacity = int.Parse(rd["Fuel_Tank_Capacity"].ToString());
                        u.CarLead = rd["Car_Lead"].ToString();
                        u.Fuel = rd["Fuel"].ToString();
                        u.FuelFillingSystem = rd["Fuel_Filling_System"].ToString();
                        u.Consumption = int.Parse(rd["Consumption"].ToString());
                        u.CarID = rd["Car_ID"].ToString();
                    };
                    list.Add(u);
                }
            }
            return list;
        }

        public static Technology getTechonologyByCarID(string Id)
        {
            Technology tech = GetAllTechnologies().SingleOrDefault(t => t.CarID.Equals(Id));
            return tech;
        }
    }
}