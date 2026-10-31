using System;
using PMS.Enums;

namespace PMS.Models;

public class Order
{
    public readonly DateTime CreatedAt;
    public List<OrderItem> OrderItems { get; set; }
    public decimal TotalPrice { get; set; }

    public Order()
    {
        CreatedAt = DateTime.Now;
        OrderItems = new List<OrderItem>();
        TotalPrice = 0;
    }

    public void AddOrderItem(OrderItem item)
    {
        OrderItems.Add(item);
        TotalPrice = this.GetTotalPrice();
    }

    public void AddOrderItems(List<OrderItem> items)
    {
        OrderItems.AddRange(items);
        TotalPrice = this.GetTotalPrice();
    }

    public void RemoveOrderItem(OrderItem item)
    {
        OrderItems.Remove(item);
        TotalPrice = this.GetTotalPrice();
    }

    public bool ContainsOrderItem(OrderItem item)
    {
        return OrderItems.Contains(item);
    }

    public List<OrderItem> FindProductByName(string productName)
    {
        if (string.IsNullOrEmpty(productName))
        {
            return new List<OrderItem>();
        }
        
        return OrderItems.FindAll(item => item.PaintProduct.Name.Equals(productName, StringComparison.Ordinal));
    }

    // check if the order contains null or empty product names
    public bool HasNullOrEmptyProductNames()
    {
        return OrderItems.Any(item => string.IsNullOrEmpty(item.PaintProduct.Name));
    }

    public PaintProduct? GetMostExpensivePaintProduct()
    {
        if (OrderItems.Count == 0)
        {
            return null;
        }

        OrderItem mostExpensive = OrderItems.OrderByDescending(item => item.PaintProduct.Price).First();

        return mostExpensive.PaintProduct;
    }

    // remove all products with the given productId from the order
    public void RemoveProduct(int productId)
    {
        foreach (var item in OrderItems)
        {
            if (item.PaintProduct.Id == productId)
            {
                OrderItems.Remove(item);
            }
        }

        TotalPrice = this.GetTotalPrice();
    }

    public List<OrderItem> GetPaintProductInPriceRange(decimal min, decimal max)
    {
        return OrderItems.Where(item => item.PaintProduct.Price > min && item.PaintProduct.Price < max).ToList();
    }

    public Dictionary<PaintProduct, decimal> GetTotalPriceOfEachPaintProduct()
    {
        // group the order items by product and calculate the total number of units for each product 
        IEnumerable<OrderItem> grouped = OrderItems.GroupBy(item => item.PaintProduct).Select(group => new OrderItem(group.Key, group.Sum(item => item.Quantity)));

        return grouped.ToDictionary(item => item.PaintProduct, item => item.PaintProduct.GetFinalPrice() * item.Quantity);
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
