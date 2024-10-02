﻿namespace PizzaBraz.API.ViewModels.OrderItem
{
    public class CreateOrderItemViewModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
