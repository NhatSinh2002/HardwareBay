﻿namespace HardwareBayAPI.Models.Domain
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
