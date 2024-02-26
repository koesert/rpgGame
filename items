using System;
using System.Collections.Generic;

// Base class for all items
class Item
{
    public string Name { get; set; }
    public int Weight { get; set; }

    public Item(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }

    // Method to use the item
    public virtual void Use()
    {
        Console.WriteLine($"You used the {Name}.");
    }
}

// Subclass for healing items
class HealingItem : Item
{
    public int HealingAmount { get; set; }

    public HealingItem(string name, int weight, int healingAmount) : base(name, weight)
    {
        HealingAmount = healingAmount;
    }

    // Override the Use method for healing items
    public override void Use()
    {
        Console.WriteLine($"You used the {Name} and gained {HealingAmount} health points.");
    }
}

// Subclass for weapons
class Weapon : Item
{
    public int Damage { get; set; }

    public Weapon(string name, int weight, int damage) : base(name, weight)
    {
        Damage = damage;
    }

    // Override the Use method for weapons
    public override void Use()
    {
        Console.WriteLine($"You used the {Name} and dealt {Damage} damage.");
    }
}

// Inventory class to manage items
class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>
        {
            new HealingItem("Health Potion", 1, 20),
            new HealingItem("Apple", 1, 10),
            new Weapon("Sword", 5, 15)
            // Add more items as needed
        };
    }

    // Method to display items in inventory
    public void DisplayItems()
    {
        Console.WriteLine("Items in inventory:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name}");
        }
    }

    // Method to use an item from inventory
    public void UseItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index].Use();
        }
        else
        {
            Console.WriteLine("Invalid item index.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();

        inventory.DisplayItems();

        Console.Write("Choose an item to use: ");
        int choice = Convert.ToInt32(Console.ReadLine()) - 1;

        inventory.UseItem(choice);
    }
}
