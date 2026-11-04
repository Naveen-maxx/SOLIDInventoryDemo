using System;
using System.Collections.Generic;
using System.Text;

using SOLIDInventoryDemo.Models;

namespace SOLIDInventoryDemo.Presentation;

public class ConsoleProductOutput
{
    public void DisplayProducts(List<Product> products)
    {
        Console.WriteLine("\n===== PRODUCT INVENTORY =====");

        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        Console.WriteLine(
            "{0,-10} {1,-20} {2,10}",
            "ID", "Product", "Price");

        Console.WriteLine(new string('-', 42));

        foreach (var product in products)
        {
            Console.WriteLine(
                "{0,-10} {1,-20} {2,10:C}",
                product.Id,
                product.Name,
                product.Price);
        }
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
