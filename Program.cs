using System.Xml.Serialization;

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
        Thread.Sleep(1500);
        Console.WriteLine($"You'll get started off to the first location of the game!\n\n");
        townSquare(player);
    }
    static void Home(Player player)
    {   
        Console.WriteLine($"Alright {player.Name}. You are currently at {player.CurrentLocation.Name}");
        Thread.Sleep(1500);
        Console.WriteLine($"There are no quests or monster at this current location");
        Thread.Sleep(1500);
        Console.WriteLine("From this location, you can only go to TownSquare, so we'll bring you there.");
        townSquare(player);
    }
    static void townSquare(Player player)
    {
        player.CurrentLocation = World.Locations[1];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        if (World.Locations[3].QuestAvailableHere == null && World.Locations[5].QuestAvailableHere == null && World.Locations[7].QuestAvailableHere == null)
        {
            Console.WriteLine("It seems you have visited all locations, and completed all the available quests. The time has come to face the evildoer of this world. Morwen, the howling king, is the one who has been causing mayhem across the locations, by planting monsters. Now that you have defeated them all, its time to end the evildoing.");
            Thread.Sleep(1500);
            Console.WriteLine("You will now visit his castle.");
            morwenscastle(player);
            player.CurrentLocation = World.Locations[1];
            Console.WriteLine("You are back at TownSquare. Now that you have brought the world to peace, you decide to head somewhere else.");
            Console.WriteLine("You have no idea where you are going, or what happens after this, but it seems like you are ready as you have gained the ultimate pride of an outstanding warrior.");
            Console.WriteLine("And that may very well come in handy, cause the world at any time, can still be unpredictable.");
            Environment.Exit(0);
        }
        Thread.Sleep(1500);
        Console.WriteLine($"There are no quests or monsters at this current location, but from this location you can vists plenty other locations!");
        Thread.Sleep(1500);
        Console.WriteLine($"Would you like to go North, South, East or West? Enter the first letter of the wanted direction.");
        string choice = Console.ReadLine();
        if (choice.ToLower() == "n")
        {
            alchemistHut(player);
        }
        else if (choice.ToLower() == "s")
        {
            Home(player);
        }
        else if (choice.ToLower() == "e")
        {
            guardPost(player);
        }
        else if (choice.ToLower() == "w")
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
            Thread.Sleep(1500);
            Console.WriteLine($"For this quest, you have to visit the alchemist's garden, so you will now be moved there.");
            if (alchemistGarden(player))
            {
                player.CurrentLocation = World.Locations[3];
                player.CurrentLocation.QuestAvailableHere = null;
                player.PlayerLevel++;
                Console.WriteLine($"You levelled up! Current level: {player.PlayerLevel}");
                Thread.Sleep(1500);
                Console.WriteLine("You have completed the quest at the alchemist's garden");
                Thread.Sleep(1500);
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
       Thread.Sleep(1500);
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
            Thread.Sleep(1500);
            Console.WriteLine($"{monster.Name} has attacked you for {monster.MaximumDamage} HP, Leaving your HP at {player.CurrentHitPoints}");
            monster.CurrentHitPoints -= player.CurrentWeapon.MaximumDamage;
            if (monster.CurrentHitPoints < 0)
            {
                monster.CurrentHitPoints = 0;
            }
            Thread.Sleep(1500);
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
        player.CurrentLocation = World.Locations[2];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        Thread.Sleep(1500);
        if (World.Locations[7].QuestAvailableHere != null)
        {
            Console.WriteLine($"To complete the quest at the GuardPost, you will have to battle the spiders at the forest, which you can go to from the bridge.");
            Thread.Sleep(1500);
            Console.WriteLine($"So you'll now get brought to the bridge to complete your quest");
            if (Bridge(player))
            {
                player.CurrentLocation = World.Locations[2];
                Console.WriteLine("You have completed the quest at the bridge");
                Thread.Sleep(1500);
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
    static bool Bridge(Player player)
    {
        player.CurrentLocation = World.Locations[7];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        Thread.Sleep(1500);
        Console.WriteLine($"To complete the quest at this location, you will have to battle the spiders at the forest, which you can go to from here.");
        Thread.Sleep(1500);
        Console.WriteLine($"So you'll now get brought to the forest to complete your quest");
        if (Forest(player))
        {
            player.CurrentLocation = World.Locations[7];
            Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
            Console.WriteLine($"After your battle you head back to the GuardPost, as there are no more activities at this current location.");
            player.CurrentLocation.QuestAvailableHere = null;
            player.PlayerLevel++;
            Thread.Sleep(1500);
            Console.WriteLine($"You levelled up! Current level: {player.PlayerLevel}");
            return true;
        }
        else
        {
            player.CurrentLocation = World.Locations[7];
            Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
            Console.WriteLine($"After losing your battle, you will be moved back to Guardpost");
            return false;
        }
    }
    static bool Forest(Player player)
    {
        player.CurrentLocation = World.Locations[8];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        Console.WriteLine($"To complete the quest at the GuardPost, you will have to battle the spiders.\n\n");
        if (Battle(player, player.CurrentLocation.MonsterLivingHere))
        {
            Console.WriteLine("You have won your battle!\nMoving back to the bridge now.\n");
            return true;
        }
       else
        {
            Console.WriteLine("You have lost your battle...\nMoving back to bridge now.\n");
            return false;
        }

    }
    static void farmhouse(Player player)
    {
        player.CurrentLocation = World.Locations[5];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        if (player.CurrentLocation.QuestAvailableHere != null)
        {
            Console.WriteLine($"There's a quest available at this location: {player.CurrentLocation.QuestAvailableHere.Name}: {player.CurrentLocation.QuestAvailableHere.Description}");
            Thread.Sleep(1500);
            Console.WriteLine($"For this quest, you have to visit the farmer's field, so you will now be moved there.");
            if (farmersfield(player))
            {
                player.CurrentLocation = World.Locations[5];
                player.CurrentLocation.QuestAvailableHere = null;
                Console.WriteLine("You have completed the quest at the farmer's field");
                player.PlayerLevel++;
                Thread.Sleep(1500);
                Console.WriteLine($"You levelled up! Current level: {player.PlayerLevel}");
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
    static bool farmersfield(Player player)
    {
        player.CurrentLocation = World.Locations[6];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        Thread.Sleep(1500);
        Console.WriteLine($"To complete the quest at the Farmer's field, you will have to battle the snakes at this location.\n\n");
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
    static void morwenscastle(Player player)
    {
        player.CurrentLocation = World.Locations[9];
        Console.WriteLine($"You have arrived at {player.CurrentLocation.Name}: {player.CurrentLocation.Description}");
        player.CurrentWeapon = World.Weapons[1];
        Console.WriteLine($"You have achieved a new weapon on your quest to save the world: {player.CurrentWeapon.Name}");
        Thread.Sleep(1500);
        Console.WriteLine("Morwen's castle has the head of security protecting it, a fearsome foe with great skills and outstanding damage.");
        Thread.Sleep(1500);
        Console.WriteLine("You will engage in a battle with him, to be able to reach Morwen.");
        if (Battle(player, World.Monsters[3]))
        {
            Console.WriteLine("You have defeated Morwen's security");
            player.CurrentWeapon = World.Weapons[2];
            Console.WriteLine($"At the entrence of the castle, you see a wide variety of items. From those, you steal the most valuable weapon known in the world: {player.CurrentWeapon.Name}, and take a healing item with that.");
            Thread.Sleep(1500);
            Console.WriteLine("You walk upto the highest floor of the castle, where you get to face Morwen.");
            Thread.Sleep(1500);
            Console.WriteLine("As you arrive at his exact doorstep, the world starts to shake. You walk through the door, and there he is. Morwen, a 7 feet tall monster, wielding the biggest blade you have ever seen.");
            Thread.Sleep(1500);
            Monster morwen = World.Monsters[4];
            BossBattle(player, morwen);
            Console.WriteLine("You have defeated Morwen. The people of the world are delighted, and you have brought the world to peace.");
            Console.WriteLine("After your battle, you decide to head towards TownSquare");

        }
    }
    static void BossBattle(Player player, Monster monster)
    {
        bool victory = false;
        bool healing = true;
        Console.WriteLine($"{player.Name}, You are now fighting {monster.Name}");
        Thread.Sleep(1500);
        while (!victory)
        {
            Console.WriteLine($"Your stats:\nCurrent HP: {player.CurrentHitPoints}\nUsing Weapon: {player.CurrentWeapon.Name}\nAttacking Damage: {player.CurrentWeapon.MaximumDamage}\n");
            Thread.Sleep(1500);
            Console.WriteLine($"{monster.Name} stats:\nCurrent HP: {monster.CurrentHitPoints}\nAttacking Damage: {monster.MaximumDamage}\n");
            player.CurrentHitPoints -= monster.MaximumDamage;
            if (player.CurrentHitPoints < 0)
            {
                player.CurrentHitPoints = 1;
            }
            Thread.Sleep(1500);
            Console.WriteLine($"{monster.Name} has attacked you for {monster.MaximumDamage} HP, Leaving your HP at {player.CurrentHitPoints}");
            monster.CurrentHitPoints -= player.CurrentWeapon.MaximumDamage;
            if (monster.CurrentHitPoints < 0)
            {
                monster.CurrentHitPoints = 0;
            }
            Thread.Sleep(1500);
            Console.WriteLine($"In return you attacked {monster.Name} with your {player.CurrentWeapon.Name} for {player.CurrentWeapon.MaximumDamage}. Now {monster.Name} has {monster.CurrentHitPoints} HP left!");
            if (monster.CurrentHitPoints == 0)
            {
                victory = true;
            }
            else if (player.CurrentHitPoints == 0)
            {
                victory = true;
            }
            if (healing)
            {
                Console.WriteLine($"During your battle you realize that your HP is very weak. This is when you decide to use your healing item.");
                Thread.Sleep(1500);
                Item item = new HealingItem("Divine Remedy", 100, 200);
                item.Use();
                Thread.Sleep(1500);
                Console.WriteLine($"But this turns out to be no regular healing item, it appears this item also increases your strength by a huge margin! Your HP and Damage have been doubled!");
                Thread.Sleep(1500);
                Console.WriteLine($"You feel amazing energy bubbling up inside you, as you are ready to take {monster.Name} down.");
                player.CurrentHitPoints = 200;
                player.MaximumHitPoints = 200;
                player.CurrentWeapon.MaximumDamage = 200;
                player.CurrentWeapon.Name = "Excalibur MAX";
                healing = false;
            }
        }
    }
}