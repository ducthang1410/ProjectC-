using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Project_1.Models
{
    public class TechnologyData
    {
        string strConnection;

        public TechnologyData()
        {
            this.strConnection = GetConnection();
        }

        public static String GetConnection()
        {
            String c = "server=SE130157;database=Final_Project_2;uid=se;pwd=123";
            return c;
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