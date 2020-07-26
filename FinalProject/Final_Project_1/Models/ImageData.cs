using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Project_1.Models
{
    public class ImageData
    {
        string strConnection;

        public ImageData()
        {
            this.strConnection = GetConnection();
        }
        public static String GetConnection()
        {
            String c = "server=SE130157;database=Final_Project_2;uid=se;pwd=123";
            return c;
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
    }
}