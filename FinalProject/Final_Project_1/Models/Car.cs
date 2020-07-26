using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_1.Models
{
    public class Car
    {
        public string CarID { get; set; }
        public string CarName { get; set; }
        public string CarStatus { get; set; }
        public string CarColor { get; set; }
        public string CarCity { get; set; }
        public string CarVersion { get; set; }
        public string CarSeries { get; set; }
        public int CarYearOfProduction { get; set; }
        public string CarType { get; set; }
        public string CarOrigin { get; set; }
        public double CarPrice { get; set; }
        public string TechID { get; set; }
        public string ProducerID { get; set; }
        public string AdminID { get; set; }

        public string CustomerID { get; set; }
    }
}