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
    }
}