using PMS.Enums;
using PMS.Models;

class Program
{
    static void Main(string[] args)
    {
        Brand dulux = new Brand("Dulux");
        Brand wattyl = new Brand("Wattyl");
        Brand haymes = new Brand("Haymes Paint");

        // Create multiple paint products
        PaintProduct product1 = new PaintProduct(1, "Premium Paint", dulux, PaintType.SemiGloss, new PaintSpecification("Red", 5), 20.0m);
        PaintProduct product2 = new PaintProduct(2, "Standard Paint", wattyl, PaintType.Matte, new PaintSpecification("Blue", 3), 15.0m);
        PaintProduct product3 = new PaintProduct(3, "Economy Paint", haymes, PaintType.Glossy, new PaintSpecification("Green", 2), 10.0m);
        PaintProduct product4 = new PaintProduct(4, "Luxury Paint", dulux, PaintType.Gloss, new PaintSpecification("Yellow", 4), 25.0m);
        PaintProduct product5 = new PaintProduct(5, "Basic Paint", haymes, PaintType.BaseCoat, new PaintSpecification("White", 1), 5.0m);
        
        // Display information for each product
        Console.WriteLine("Paint Products Information:");
        product1.DisplayInfo();
        product2.DisplayInfo();
        product3.DisplayInfo();
        product4.DisplayInfo();
        product5.DisplayInfo();
        Console.WriteLine();

        // Create an order with multiple order items
        OrderItem orderItem1 = new OrderItem(product1, 2);
        OrderItem orderItem2 = new OrderItem(product3, 3); 
        OrderItem orderItem3 = new OrderItem(product4, 1);

        Order order = new Order();
        order.AddOrderItem(orderItem1);
        order.AddOrderItem(orderItem2);
        order.AddOrderItem(orderItem3);

        // Display order information
        Console.WriteLine("Order Information:");
        order.DisplayOrder();
    }
}