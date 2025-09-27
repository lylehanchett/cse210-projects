using System;

class Program
{
    static void Main(string[] args)
    {
        // Customer 1
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Alice", address1);

        // Products for Order 1
        Product prod1 = new Product("Book", "B101", 12.99, 2);
        Product prod2 = new Product("Pen", "P202", 1.50, 5);
        Product prod5 = new Product("Notebook", "N505", 3.50, 1); // Added item

        // Order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);
        order1.AddProduct(prod5);

        // Customer 2
        Address address2 = new Address("456 King Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob", address2);

        // Products for Order 2
        Product prod3 = new Product("Notebook", "N303", 5.00, 3);
        Product prod4 = new Product("Pencil", "P404", 0.99, 10);

        // Order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        // Customer 3
        Address address3 = new Address("789 Elm St", "Los Angeles", "CA", "USA");
        Customer customer3 = new Customer("Charlie", address3);

        // Products for Order 3
        Product prod6 = new Product("Backpack", "B606", 25.00, 1);
        Product prod7 = new Product("Calculator", "C707", 15.00, 1);
        Product prod8 = new Product("Highlighter", "H808", 2.50, 4);
        Product prod9 = new Product("Eraser", "E909", 1.00, 3);

        // Order 3
        Order order3 = new Order(customer3);
        order3.AddProduct(prod6);
        order3.AddProduct(prod7);
        order3.AddProduct(prod8);
        order3.AddProduct(prod9);

        // Display orders
        Order[] orders = { order1, order2, order3 };

        foreach (Order order in orders)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
            Console.WriteLine("========================================\n");
        }
    }
}
