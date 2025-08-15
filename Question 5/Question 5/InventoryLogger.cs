using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// ---------------------------
// Generic Inventory Logger
// ---------------------------
public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new List<T>();
    private string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
    }

    public List<T> GetAll()
    {
        return new List<T>(_log);
    }

    public void SaveToFile()
    {
        try
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(fs, _log, new JsonSerializerOptions { WriteIndented = true });
            }
            Console.WriteLine($"✅ Data saved successfully to {_filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error saving to file: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("⚠️ File not found. No data loaded.");
                return;
            }

            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                var data = JsonSerializer.Deserialize<List<T>>(fs);
                if (data != null)
                {
                    _log = data;
                    Console.WriteLine($"✅ Data loaded successfully from {_filePath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error loading from file: {ex.Message}");
        }
    }

    public int GetItemCount()
    {
        return _log.Count;
    }

    public void ClearLog()
    {
        _log.Clear();
        Console.WriteLine("🗑️ Log cleared successfully.");
    }
}
