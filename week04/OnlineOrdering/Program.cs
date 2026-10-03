using System;

class Program
{
    static void Main(string[] args)
    {
        // First customer and order - USA
        Address address1 = new Address(
            "123 Main Street",
            "Rexburg",
            "Idaho",
            "USA"
        );

        Customer customer1 = new Customer("James Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P1001", 750.00, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P1002", 25.00, 2));
        order1.AddProduct(new Product("Keyboard", "P1003", 45.00, 1));

        // Second customer and order - outside USA
        Address address2 = new Address(
            "25 Independence Avenue",
            "Accra",
            "Greater Accra",
            "Ghana"
        );

        Customer customer2 = new Customer("Daniel Mensah", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "P2001", 60.00, 2));
        order2.AddProduct(new Product("Webcam", "P2002", 80.00, 1));
        order2.AddProduct(new Product("USB Cable", "P2003", 10.00, 3));

        // Display first order
        Console.WriteLine("ORDER 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}");

        Console.WriteLine();
        Console.WriteLine("------------------------------");
        Console.WriteLine();

        // Display second order
        Console.WriteLine("ORDER 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}