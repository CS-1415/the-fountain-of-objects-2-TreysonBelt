namespace Lab08;
interface Istats
{
    int health {get; set; }
    int AC {get; set; }
    string name {get; }
    void LoseHealth(int dmg);
    bool CheckAC(int roll);
}