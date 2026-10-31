using System;

namespace PMS.Models;

public class PaintStore
{
    public List<StoreItem>StoreItems { get; set; }
    public PaintStore(List<StoreItem> storeItems)
    {
        StoreItems = storeItems;
    }
}
