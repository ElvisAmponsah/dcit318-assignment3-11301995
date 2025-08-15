using System;
using System.Collections.Generic;

// ---------------------------
// Integration Layer - InventoryApp
// ---------------------------
public class InventoryApp
{
    private InventoryLogger<InventoryItem> _logger;

    public InventoryApp(string filePath)
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    public void SeedSampleData()
    {
        Console.WriteLine("🌱 Seeding sample data...");
        _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now));
        _logger.Add(new InventoryItem(2, "Mouse", 50, DateTime.Now));
        _logger.Add(new InventoryItem(3, "Keyboard", 30, DateTime.Now));
        _logger.Add(new InventoryItem(4, "Monitor", 15, DateTime.Now));
        _logger.Add(new InventoryItem(5, "USB Drive", 100, DateTime.Now));
        Console.WriteLine($"✅ Added {_logger.GetItemCount()} items to inventory.");
    }

    public void SaveData()
    {
        Console.WriteLine("💾 Saving data to file...");
        _logger.SaveToFile();
    }

    public void LoadData()
    {
        Console.WriteLine("📂 Loading data from file...");
        _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
        var items = _logger.GetAll();
        if (items.Count == 0)
        {
            Console.WriteLine("📭 No items found in inventory.");
            return;
        }

        Console.WriteLine($"\n📋 Inventory Items ({items.Count} total):");
        Console.WriteLine(new string('=', 50));
        foreach (var item in items)
        {
            Console.WriteLine($"🆔 ID: {item.Id} | 📦 {item.Name} | 🔢 Quantity: {item.Quantity} | 📅 Added: {item.DateAdded:yyyy-MM-dd HH:mm}");
        }
        Console.WriteLine(new string('=', 50));
    }

    public void AddCustomItem(int id, string name, int quantity)
    {
        _logger.Add(new InventoryItem(id, name, quantity, DateTime.Now));
        Console.WriteLine($"✅ Added new item: {name} (ID: {id}, Quantity: {quantity})");
    }

    public void ClearInventory()
    {
        _logger.ClearLog();
    }
    
    public List<InventoryItem> GetAllItems()
    {
        return _logger.GetAll();
    }
}
