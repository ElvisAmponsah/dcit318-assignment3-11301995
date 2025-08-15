using System;

// ---------------------------
// Main Application
// ---------------------------
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Warehouse Management System ===\n");
        
        var manager = new WareHouseManager();
        manager.SeedData();

        Console.WriteLine("=== All Grocery Items ===");
        manager.PrintAllItems(manager.Groceries);

        Console.WriteLine("=== All Electronic Items ===");
        manager.PrintAllItems(manager.Electronics);

        // Try to add duplicate
        Console.WriteLine("=== Testing Duplicate Item Exception ===");
        try
        {
            manager.Electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 12));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Try to remove non-existent item
        Console.WriteLine("\n=== Testing Remove Non-existent Item ===");
        manager.RemoveItemById(manager.Groceries, 99);

        // Try to update with invalid quantity
        Console.WriteLine("\n=== Testing Invalid Quantity Exception ===");
        try
        {
            manager.Groceries.UpdateQuantity(1, -10);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Test stock increase
        Console.WriteLine("\n=== Testing Stock Increase ===");
        manager.IncreaseStock(manager.Electronics, 1, 5);

        // Test stock decrease
        Console.WriteLine("\n=== Testing Stock Decrease ===");
        try
        {
            manager.Electronics.UpdateQuantity(1, 8);
            Console.WriteLine("Stock decreased successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Display final inventory
        Console.WriteLine("\n=== Final Inventory Status ===");
        Console.WriteLine("Grocery Items:");
        manager.PrintAllItems(manager.Groceries);
        
        Console.WriteLine("Electronic Items:");
        manager.PrintAllItems(manager.Electronics);

        Console.WriteLine("\n=== Warehouse Management System Demo Complete ===");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
