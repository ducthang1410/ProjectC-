using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Final_Project.Models
{
    public class Customerr
    {
        public string CusInfor_Name { get; set; }
        public string CusInfor_ID { get; set; }
        public string CusInfor_Gender { get; set; }
        public string CusInfor_BirthDate { get; set; }
        public string CusInfor_Email { get; set; }
        public string CusInfor_Address { get; set; }
        public string Cus_Infor_Phone { get; set; }
        
    }

    public class CustomerData : Account
    {
        

        public  CustomerData()
        {
            AccountData.getConnectionString();
        }

        public 
    }
}