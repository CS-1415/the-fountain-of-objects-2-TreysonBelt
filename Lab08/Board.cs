using System.Dynamic;

namespace Lab08;
public class Board
{
    public Room[,]? layout;
    public Board(string input)
    {
        // For placements, think of Random
        if (input == "small" || input == "Small")
        {
            layout = new Room[4, 4];
            layout[0, 0] = new Room(1);
            layout[2, 0] = new Room(2);
            layout[1, 3] = new Room(3);
            GetMonsters();
        }
        else if (input == "medium" || input == "Medium")
        {
            layout = new Room[6, 6];
            layout[0, 0] = new Room(1);
            layout[2, 3] = new Room(2);
            layout[4, 1] = new Room(3);
            layout[5, 3] = new Room(3);
            GetMonsters();
        }
        else if (input == "large" || input == "Large")
        {
            layout = new Room[8, 8];
            layout[0, 0] = new Room(1);
            layout[6, 4] = new Room(2);
            layout[4, 1] = new Room(3);
            layout[2, 6] = new Room(3);
            GetMonsters();
        }
        else
        {
            System.Console.WriteLine("Invalid input, please try again.");
        }
    }
    private void GetMonsters()
    {
        
        Random rnd = new Random();
        for (int x = 0; x < layout!.GetLength(0); x++)
        {
            for (int y = 0; y < layout.GetLength(1); y++)
            {
                if (layout[x, y] == null)
                {
                    if (rnd.Next(101) >= 75)
                    {
                        layout[x,y] = new Room(4);
                    }
                }
            }
        }
    }
}