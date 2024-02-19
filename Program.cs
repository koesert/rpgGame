class Program
{
    static void Main()
    {
        Start();
    }
    static void Start()
    {
        World.PopulateWeapons();
        World.PopulateMonsters();
        World.PopulateQuests();
        World.PopulateLocations();
        Console.WriteLine("Hi Player, What name should we give your character?");
        Player player = new Player(Console.ReadLine(), World.Weapons[0], World.Locations[0], 100, 100);
        Console.WriteLine($"Alright {player.Name}. You are currently at {player.CurrentLocation.Name} and the weapon you are currently using is the {player.CurrentWeapon.Name}. In this game you can visit many different places and engage in battles to further expend your craft!");
        Console.WriteLine($"You'll get started off to the first location of the game!\n\n\n");
        townSquare(player);
    }
    static void townSquare(Player player)
    {
        player.CurrentLocation = World.Locations[1];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        Console.WriteLine($"There are no quests or monster at this current location, but from this location you can vists plenty other locations!");
        Console.WriteLine($"Would you like to go North, South, East or West? Enter the first letter of the wanted direction.");
    }
}