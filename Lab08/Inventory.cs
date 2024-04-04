namespace Lab08;
public class Inventory
{
    public int meleeWeapon { get; set; }

    public int rangedWeapon {get; set; }
    public int numHealPotions {get; set; }
    public int healPotion {get; } = 5;
    public Inventory()
    {
        meleeWeapon = 6;
        rangedWeapon = 6;
        numHealPotions = 3;
    }
    public void GetWeapons(Monsters monster)
    {
        if (monster.health <= 0)
        {
            if (monster.inventory.meleeWeapon > meleeWeapon)
            {
                meleeWeapon = monster.inventory.meleeWeapon;
            }
            if (monster.inventory.rangedWeapon > rangedWeapon)
            {
                rangedWeapon = monster.inventory.rangedWeapon;
            }
        }
    }
}