namespace Lab08;
class Maelstroms : Monsters, Istats
{
    public new int health { get; set; } = 15;
    public new int AC { get; set; } = 13;
    public new string name {get; } = "Maelstrom";

    public new bool CheckAC(int roll)
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

    public new void LoseHealth(int dmg)
    {
        System.Console.WriteLine($"{name} took {dmg} damage!");
        health = health - dmg;
    }
}