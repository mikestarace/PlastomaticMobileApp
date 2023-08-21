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
        public string ConnectionSize { get; set; }
        public string BodyMaterial { get; set; }
        public string SealMaterial { get; set; }
        public string ConnectionType { get; set; }
        public string SpigotType { get; set; }
        public string Gauge { get; set; }
        public string Image { get; set; }
    }
}
