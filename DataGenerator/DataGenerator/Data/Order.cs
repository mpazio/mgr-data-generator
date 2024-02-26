﻿namespace DataGenerator.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Item { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int? LotNumber { get; set; }
    }
}
