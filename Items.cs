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
