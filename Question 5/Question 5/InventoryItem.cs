using System;

// ---------------------------
// Immutable Inventory Record
// ---------------------------
public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;
