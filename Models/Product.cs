﻿namespace InventoryAPI.Models
{
    public class Product
    {
        public int? id { get; set; }
        public string nombre { get; set; }
        public decimal  precio { get; set; }
        public int cantidad { get; set; }
            
    }
}
