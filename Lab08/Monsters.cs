namespace Lab08;
class Monsters : Istats
{
    public int health { get; set; } = 20;
    public int AC { get; set; } = 14;

    public string name {get; } = "monster";

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
        health = health - dmg;
    }
}