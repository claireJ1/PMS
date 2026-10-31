using System;
using PMS.Enums;
using PMS.Interfaces;

namespace PMS.Models;

public class PaintProduct : IBuyable
{
    public readonly decimal TaxRate = 0.1m;
    public const decimal DefaultDiscount = 0.05m;

    public int Id { get; set; }
    public string Name { get; set; }
    public Brand Brand { get; set; }
    public PaintType Type { get; set; }
    public PaintSpecification Specification { get; set; }
    public decimal Price { get; set; }

    public PaintProduct(int id, string name, Brand brand, PaintType type, PaintSpecification specification, decimal price)
    {
        Id = id;
        Name = name;
        Brand = brand;
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
        string info = $"Name: {Name}, Brand: {Brand.Name}, Type: {Type}, Paint Specification: {Specification.GetSpecification()}, Price: {Price}";
        Console.WriteLine(info);
    }

    public string GetInfo()
    {
        string info = $"Name: {Name}, Brand: {Brand.Name}, Type: {Type}, Paint Specification: {Specification.GetSpecification()}, Price: {Price}";
        return info;
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
