using System;
using Microsoft.VisualBasic;
using PMS.Enums;
using PMS.Interfaces;

namespace PMS.Models;

public class PaintProduct : IBuyable
{
    public readonly decimal TaxRate = 0.1m;
    public const decimal DefaultDiscount = 0.05m;

    public string Name { get; set; }
    public PaintType Type { get; set; }
    public PaintSpecification Specification { get; set; }
    public decimal Price { get; set; }

    public PaintProduct(string name, PaintType type, PaintSpecification specification, decimal price)
    {
        Name = name;
        Type = type;
        Specification = specification;
        Price = price;
    }

    public decimal GetFinalPrice()
    {

        return Math.Round(Price * (1 - DefaultDiscount) * (1 + TaxRate), 2);
    }

    public void DisplayInfo()
    {
        string info = $"Name: {Name}, Type: {Type}, Paint Specification: {Specification.DisplaySpecification}, Price: {Price}";
        Console.WriteLine(info);
    }

    public decimal GetMaxDiscount(int rate, bool isOverridable)
    {
        decimal maxDiscount = DefaultDiscount;

        if (isOverridable)
        {
            maxDiscount = (rate > (DefaultDiscount * 100)) ? (rate / 100) : DefaultDiscount;
        }

        return maxDiscount;
    }
}
