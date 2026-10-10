using System;

namespace PMS.Models;

public class Order
{
    public readonly DateTime CreatedAt;
    public PaintProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public Order(PaintProduct paintProduct, int quantity)
    {
        CreatedAt = DateTime.Now;
        Product = paintProduct;
        Quantity = quantity;
        TotalPrice = paintProduct.GetFinalPrice() * quantity;
    }

    public string DisplayOrder()
    {
        return $"Product: {Product.DisplayInfo}, Quantity: {Quantity}, Total Price: {TotalPrice}";
    }

    public decimal GetTotalPrice()
    {
        return Math.Round(TotalPrice, 2);
    }
}
