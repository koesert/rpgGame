public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Quest? QuestAvailableHere;
    public Monster? MonsterLivingHere;
    public Location? LocationToNorth;
    public Location? LocationToWest;
    public Location? LocationToSouth;
    public Location? LocationToEast;
    public Location(int ID, string Name, string Description, Quest? QuestAvailableHere, Monster? MonsterLivingHere)
    {
        this.ID = ID;
        this.Name = Name;
        this.Description = Description;
        this.QuestAvailableHere = QuestAvailableHere;
        this.MonsterLivingHere = MonsterLivingHere;
        this.LocationToNorth = null;
        this.LocationToWest = null;
        this.LocationToSouth = null;
        this.LocationToEast = null;
    }
}