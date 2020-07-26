using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_1.Models
{
    public class RegisterSelling
    {
        public int RegisterID { get; set; }
        public string CarName { get; set; }
        public string CarStatus { get; set; }
        public string CarColor { get; set; }
        public string City { get; set; }
        public string CarVersion { get; set; }
        public string CarSeries { get; set; }
        public string CarYearOfProduction { get; set; }
        public string CarType { get; set; }
        public string CarOrigin { get; set; }
        public double CarPrice { get; set; }
        public string ProducerID { get; set; }
        public string AdminID { get; set; }
    }
}