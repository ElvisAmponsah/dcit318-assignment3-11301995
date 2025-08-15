using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Inventory Management System ===\n");
        
        // Use a file path for saving/loading inventory data
        string inventoryFilePath = "inventory.json";
        var app = new InventoryApp(inventoryFilePath);
        
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=== Menu ===");
            Console.WriteLine("1. Seed Sample Data");
            Console.WriteLine("2. Load Data from File");
            Console.WriteLine("3. Save Data to File");
            Console.WriteLine("4. Display All Items");
            Console.WriteLine("5. Add New Item");
            Console.WriteLine("6. Clear Inventory");
            Console.WriteLine("7. Exit");
            Console.WriteLine("\nEnter your choice (1-7): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    app.SeedSampleData();
                    break;
                    
                case "2":
                    app.LoadData();
                    break;
                    
                case "3":
                    app.SaveData();
                    break;
                    
                case "4":
                    app.PrintAllItems();
                    break;
                    
                case "5":
                    Console.WriteLine("Enter Item ID: ");
                    string? idInput = Console.ReadLine();
                    if (int.TryParse(idInput, out int id))
                    {
                        // Check if ID already exists
                        var existingItems = app.GetAllItems();
                        if (existingItems.Any(item => item.Id == id))
                        {
                            Console.WriteLine("❌ An item with this ID already exists. Please use a different ID.");
                        }
                        else
                        {
                            Console.WriteLine("Enter Item Name: ");
                            string? name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("❌ Item name cannot be empty.");
                                break;
                            }
                            
                            Console.WriteLine("Enter Quantity: ");
                            string? quantityInput = Console.ReadLine();
                            if (int.TryParse(quantityInput, out int quantity))
                            {
                                if (quantity < 0)
                                {
                                    Console.WriteLine("❌ Quantity cannot be negative.");
                                }
                                else
                                {
                                    app.AddCustomItem(id, name, quantity);
                                }
                            }
                            else
                            {
                                Console.WriteLine("❌ Invalid quantity entered.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid ID entered.");
                    }
                    break;
                    
                case "6":
                    Console.WriteLine("Are you sure you want to clear the inventory? (y/n)");
                    string? confirmInput = Console.ReadLine();
                    if (confirmInput?.ToLower() == "y")
                    {
                        app.ClearInventory();
                    }
                    break;
                    
                case "7":
                    exit = true;
                    Console.WriteLine("👋 Goodbye!");
                    break;
                    
                default:
                    Console.WriteLine("❌ Invalid choice. Please select a number between 1 and 7.");
                    break;
            }
        }
    }
}
