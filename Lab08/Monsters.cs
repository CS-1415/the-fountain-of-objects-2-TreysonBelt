namespace Lab08;
public class Monsters : Istats
{
    public int health { get; set; } = 20;
    public int AC { get; set; } = 14;

    public string name {get; } = "monster";
    public Inventory inventory {get; set; }
    public Monsters()
    {
        inventory = new Inventory();
    }
    public bool CheckAC(int roll)
    {
        if (AC >= roll)
        {
            System.Console.WriteLine("You don't hit!");
            return false;
        }
        else
        {
            System.Console.WriteLine("You hit!");
            return true;
        }
    }

    public void LoseHealth(int dmg)
    {
        System.Console.WriteLine($"They took {dmg} damage!");
        health = health - dmg;
    }
}