namespace Lab08;
class Player : Istats
{
    public int health { get; set; }
    public int AC { get; set; }

    public string name {get; set; } = "Player Name";
    public Inventory inventory {get; set; }

    public Player()
    {
        Random rnd = new Random();
        health = rnd.Next(1, 30);
        AC = rnd.Next(1,21);
        System.Console.Write("Enter your name: ");
        name = Console.ReadLine();
        System.Console.WriteLine($"You are {name}, a warrior for king kothardic. HP:{health} AC:{AC}");
        inventory = new Inventory();

    }
    public bool CheckAC(int roll)
    {
        if (AC >= roll)
        {
            System.Console.WriteLine("They didn't hit!");
            return false;
        }
        else
        {
            System.Console.WriteLine("They hit you!");
            return true;
        }
    }

    public void LoseHealth(int dmg)
    {
        health = health - dmg;
        System.Console.WriteLine($"You lost {dmg} HP! You only have {health} HP left!");
    }
    public void UseHealthPotion()
    {
        if (inventory.numHealPotions <= 0)
        {
            System.Console.WriteLine("You don't have any potions! LOOK OUT!");
        }
        else
        {
            health = health + inventory.healPotion;
            inventory.numHealPotions = inventory.numHealPotions - 1;
            System.Console.WriteLine($"You healed up to {health} HP! You have {inventory.numHealPotions} Health Potions left!");
        }
    }
}