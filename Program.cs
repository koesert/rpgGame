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
    static void Home(Player player)
    {   Console.WriteLine($"Alright {player.Name}. You are currently at {player.CurrentLocation.Name}");
        Console.WriteLine($"There are no quests or monster at this current location");
        Console.WriteLine("From this location, you can only go to TownSquare, so we'll bring you there.");
        townSquare(player);
    }
    static void townSquare(Player player)
    {
        player.CurrentLocation = World.Locations[1];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        Console.WriteLine($"There are no quests or monster at this current location, but from this location you can vists plenty other locations!");
        Console.WriteLine($"Would you like to go North, South, East or West? Enter the first letter of the wanted direction.");
        if (Console.ReadLine().ToLower() == "n")
        {
            alchemistHut(player);
        }
        else if (Console.ReadLine().ToLower() == "s")
        {
            Home(player);
        }
        else if (Console.ReadLine().ToLower() == "e")
        {
            guardPost(player);
        }
        else if (Console.ReadLine().ToLower() == "w")
        {
            farmhouse(player);
        }
    }
    static void alchemistHut(Player player)
    {
        player.CurrentLocation = World.Locations[3];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        if (player.CurrentLocation.QuestAvailableHere != null)
        {
            Console.WriteLine($"There's a quest available at this location: {player.CurrentLocation.QuestAvailableHere.Name}: {player.CurrentLocation.QuestAvailableHere.Description}");
            Console.WriteLine($"For this quest, you have to visit the alchemist's garden, so you will now be moved there.");
            if (alchemistGarden(player))
            {
                player.CurrentLocation = World.Locations[3];
                player.CurrentLocation.QuestAvailableHere = null;
                Console.WriteLine("You have completed the quest at the alchemist's garden");
                Console.WriteLine("You can now move to a different location. You'll get brought to TownSquare to pick a new location to visit!");
                townSquare(player);
            }
            else 
            {
                Console.WriteLine("It seems you unfortunately were not strong enough for that battle yet.");
                Console.WriteLine("You will be moved to Home.");
                Home(player);
            }
        }
        else
        {
            Console.WriteLine("The Quest which once was available at this location has already been cleared.\n From here you can only go back to TownSquare, so we'll bring you there.");
            townSquare(player);
        }

    }
    static bool alchemistGarden(Player player)
    {
       player.CurrentLocation = World.Locations[4];
       Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
       Console.WriteLine($"To complete the quest at the Alchemist's Hut, you will have to battle the rats at this location.\n\n");
       if (Battle(player, player.CurrentLocation.MonsterLivingHere))
        {
            Console.WriteLine("You have won your battle!\nMoving back to Alchemist's Hut now.\n");
            return true;
        }
       else
        {
            Console.WriteLine("You have lost your battle...\nMoving back to Alchemist's Hut now.\n");
            return false;
        }
    }
    static bool Battle(Player player, Monster monster)
    {
        bool victory = false;
        Console.WriteLine($"{player.Name}, You are now fighting {monster.Name}");
        while (!victory)
        {
            Console.WriteLine($"Your stats:\nCurrent HP: {player.CurrentHitPoints}\nUsing Weapon: {player.CurrentWeapon.Name}\nAttacking Damage: {player.CurrentWeapon.MaximumDamage}\n");
            Console.WriteLine($"Monster stats:\nCurrent HP: {monster.CurrentHitPoints}\nAttacking Damage: {monster.MaximumDamage}\n");
            player.CurrentHitPoints -= monster.MaximumDamage;
            if (player.CurrentHitPoints < 0)
            {
                player.CurrentHitPoints = 0;
            }
            Console.WriteLine($"{monster.Name} has attacked you for {monster.MaximumDamage} HP, Leaving your HP at {player.CurrentHitPoints}");
            monster.CurrentHitPoints -= player.CurrentWeapon.MaximumDamage;
            if (monster.CurrentHitPoints < 0)
            {
                monster.CurrentHitPoints = 0;
            }
            Console.WriteLine($"In return you attacked {monster.Name} with your {player.CurrentWeapon.Name} for {player.CurrentWeapon.MaximumDamage}. Now {monster.Name} has {monster.CurrentHitPoints} HP left!");
            if (monster.CurrentHitPoints == 0)
            {
                victory = true;
            }
            else if (player.CurrentHitPoints == 0)
            {
                victory = true;
            }
        }
        if (monster.CurrentHitPoints == 0)
        {
            return true; 
        }
        else if (player.CurrentHitPoints == 0)
        {
            return false;
        }
        return false;

    }
    static void guardPost(Player player)
    {

    }
    static void farmhouse(Player player)
    {
        
    }
}