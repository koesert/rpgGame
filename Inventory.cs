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
