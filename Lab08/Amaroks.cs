namespace Lab08;
class Amaroks : Monsters, Istats
{
    public new int health { get; set; } = 30;
    public new int AC { get; set; } = 16;
    public new string name {get; } = "Amarok";
    public new Inventory inventory {get; set; }
    public Amaroks()
    {
        inventory = new Inventory();
        inventory!.meleeWeapon = 12;
        inventory.rangedWeapon = 4;
    }

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