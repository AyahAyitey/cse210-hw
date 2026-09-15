using System;

class Program
{
    static void Main(string[] args)
    {
        // --- Order 1: US Customer ---
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse",    "WM-101", 25.99, 2));
        order1.AddProduct(new Product("USB-C Hub",         "UC-204", 39.99, 1));
        order1.AddProduct(new Product("Laptop Stand",      "LS-305", 49.99, 1));

        DisplayOrder(order1);
        Console.WriteLine(new string('-', 40));

        // --- Order 2: International Customer ---
        Address address2 = new Address("10 Downing Street", "London", "England", "UK");
        Customer customer2 = new Customer("James Bond", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "KB-512", 89.99, 1));
        order2.AddProduct(new Product("Monitor Light Bar",   "ML-789", 34.99, 2));

        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Order Total: ${order.GetTotalCost():F2}");
    }
}
