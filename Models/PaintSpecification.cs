using System;

namespace PMS.Models;

public class PaintSpecification
{
    string Colour { get; set; }
    int SizeInLiters { get; set; }

    public PaintSpecification(string colour, int sizeInLiters)
    {
        Colour = colour;
        SizeInLiters = sizeInLiters;   
    }

    public void DisplaySpecification()
    {
        string spec = $"Colour: {Colour}, Size in Liters: {SizeInLiters}";
        Console.WriteLine(spec);
    }

    public string GetSpecification()
    {
        string spec = $"Colour: {Colour}, Size in Liters: {SizeInLiters}";
        return spec;
    }

}
