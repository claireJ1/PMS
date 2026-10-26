using System;

namespace PMS.Models;

public class PaintStore
{
    public StoreItem[] StoreItems { get; set; }
    public PaintStore(StoreItem[] storeItems)
    {
        StoreItems = storeItems;
    }
}
