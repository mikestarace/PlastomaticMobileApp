using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePressureRegulator.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        private string connectionSize;
        public string ConnectionSize
        {
            get { return connectionSize; }
            set
            {
                if (value == "OneFourth")
                {
                    connectionSize = "1/4\"";
                }
                else if (value == "OneHalf")
                {
                    connectionSize = "1/2\"";
                }
                else if (value == "ThreeFourth")
                {
                    connectionSize = "3/4\"";
                }
                else if (value == "OneWhole")
                {
                    connectionSize = "1\"";
                }
                else if (value == "OneOneFourth")
                {
                    connectionSize = "1 1/4\"";
                }
                else if (value == "OneOneHalf")
                {
                    connectionSize = "1 1/2\"";
                }
                else if (value == "TwoWhole")
                {
                    connectionSize = "2\"";
                }
                else if (value == "ThreeWhole")
                {
                    connectionSize = "3\"";
                }
                else
                {
                    connectionSize = value;
                }
            }
        }
        public string BodyMaterial { get; set; }
        public string SealMaterial { get; set; }
        public string ConnectionType { get; set; }
        public string SpigotType { get; set; }
        public string Gauge { get; set; }
        public string Image { get; set; }
    }
}
