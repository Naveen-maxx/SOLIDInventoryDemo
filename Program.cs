
using SOLIDInventoryDemo.Presentation;
using SOLIDInventoryDemo.Repositories;
using SOLIDInventoryDemo.Services;

var repository = new InMemoryProductRepository();

var productService = new ProductService(
    repository,
    repository);

var output = new ConsoleProductOutput();

bool running = true;

while (running)
{
    Console.WriteLine("\n===== INVENTORY MANAGEMENT =====");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. List Products");
    Console.WriteLine("3. Exit");

    Console.Write("Enter your choice: ");
    string? choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Enter product name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter product price: ");

                if (!decimal.TryParse(
                    Console.ReadLine(), out decimal price))
                {
                    output.DisplayMessage("Invalid price.");
                    break;
                }

                productService.AddProduct(name ?? "", price);

                output.DisplayMessage("Product added successfully.");
                break;

            case "2":
                var products = productService.GetAllProducts();
                output.DisplayProducts(products);
                break;

            case "3":
                running = false;
                output.DisplayMessage("Application closed.");
                break;

            default:
                output.DisplayMessage("Invalid choice. Try again.");
                break;
        }
    }
    catch (ArgumentException ex)
    {
        output.DisplayMessage($"Error: {ex.Message}");
    }
}
