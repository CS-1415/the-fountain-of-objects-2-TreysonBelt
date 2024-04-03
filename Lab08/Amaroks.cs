namespace Lab08;
class Amaroks : Monsters, Istats
{
    public new int health { get; set; } = 30;
    public new int AC { get; set; } = 16;
    public new string name {get; } = "Amarok";

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
        health = health - dmg;
    }
}