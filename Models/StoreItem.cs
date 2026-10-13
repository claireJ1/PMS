using System;

namespace PMS.Models;

public class StoreItem
{
    public PaintProduct PaintProduct { get; set; }
    public int Quantity { get; set; }

    public StoreItem(PaintProduct product, int quantity)
    {
        PaintProduct = product;
        Quantity = quantity;
    }
}
