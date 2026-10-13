using System;

namespace PMS.Models;

public class Order
{
    public readonly DateTime CreatedAt;
    public OrderItem[] OrderItems { get; set; }
    public decimal TotalPrice { get; set; }

    public Order(OrderItem[] orderItems)
    {
        CreatedAt = DateTime.Now;
        OrderItems = orderItems;
        TotalPrice = this.GetTotalPrice();
    }

    public void DisplayOrder()
    {   
        string orderInfo = "";
        foreach (OrderItem item in OrderItems)
        {
            orderInfo += $"Product: {item.PaintProduct.GetInfo()}, Quantity: {item.Quantity}\n";
        }

        orderInfo += $"Order Created At: {CreatedAt}, Total Price: {TotalPrice}";
        Console.WriteLine(orderInfo);
    }

    public decimal GetTotalPrice()
    {   
        decimal total = 0;
        foreach (OrderItem item in OrderItems)
        {
            total += item.PaintProduct.GetFinalPrice() * item.Quantity;
        }
        return total;
    }
}
