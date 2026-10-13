using System;

namespace PMS.Models;

public class OrderItem
{
    public PaintProduct PaintProduct { get; set; }
    public int Quantity { get; set; }

    public OrderItem(PaintProduct product, int quantity)
    {
        PaintProduct = product;
        Quantity = quantity;
    }

}
