using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_1.Models
{
    public class Technology
    {
        public int TechID { get; set; }
        public int Doors { get; set; }
        public int Chairs { get; set; }
        public string Engine { get; set; }
        public int CylinderCapacity { get; set; }
        public int FuelTankCapacity { get; set; }
        public string CarLead { get; set; }
        public string Fuel { get; set; }
        public string FuelFillingSystem { get; set; }
        public int Consumption { get; set; }
        public string CarID { get; set; }
    }
}