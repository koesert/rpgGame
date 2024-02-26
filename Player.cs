public class Player
{
    public string Name;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;
    public int CurrentHitPoints;
    public int MaximumHitPoints;
    public int PlayerLevel = 0;
    public Player(string Name, Weapon CurrentWeapon, Location CurrentLocation, int CurrentHitPoints, int MaximumHitPoints)
    {
        this.Name = Name;
        this.CurrentWeapon = CurrentWeapon;
        this.CurrentLocation = CurrentLocation;
        this.CurrentHitPoints = CurrentHitPoints;
        this.MaximumHitPoints = MaximumHitPoints;
    }
}