namespace Lab08;
public class Room
{
    private string? name {get; }
    public bool effect {get; set; }
    public int identifier {get; set; }
    public string? definition {get; set; }
    public Monsters? monster {get; set; }
    public Room(int num)
    {
        Random rnd = new Random();
        if (num == 1)
        {
            name = "Entrance";
            effect = false;
            identifier = num;
            definition = "“You see light in this room coming from outside the cavern. This is the entrance.";
            monster = null;
        }
        else if (num == 2)
        {
            name = "Fountain of Objects";
            effect = false;
            identifier = num;
            definition = "You hear water dripping in this room. The Fountain of Objects is here!";
            monster = null;
        }
        else if (num == 3)
        {
            name = "Pit";
            effect = false;
            identifier = num;
            definition = "You feel a draft. There is a pit in a nearby room";
            monster = null;
        }
        else if (num == 4)
        {
            monster = rnd.Next(3) switch
            {
                1 => new Amaroks(),
                2 => new Maelstroms(),
                _ => new Monsters()
            };
            name = "Monster";
            effect = false;
            identifier = num;
            definition = $"You hear the growling and groaning of a {monster.name} nearby.";
        }
    }
    public void ClearRoom()
    {
        effect = false;
        identifier = 5;
        definition = "You see dust and rubble from a battle you fought.";
    }
}
