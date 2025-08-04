using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // First Order (USA)
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P010", 1.50, 5));

        // Second Order (International)
        Address address2 = new Address("45 King Rd", "London", "Greater London", "UK");
        Customer customer2 = new Customer("Emily Clarke", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N023", 5.25, 3));
        order2.AddProduct(new Product("Headphones", "H999", 45.00, 1));

        // Display Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}\n");

        // Display Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}\n");
    }
}