using System.Formats.Asn1;

namespace Lab08;
public class Game
{
    public Board? _board {get;}
    public Armaments bow {get; }
    private bool play;
    private Coordinates finder = new Coordinates();
    public Game(string input)
    {
        _board = new Board(input);
        bow = new Armaments();
    }
    public void Run()
    {
        play = true;
        DisplayIntro();
        while(play)
        {
            Console.Clear();
            Display();
            MoveTurn();
            System.Console.Write("Press any key to continue... ");
            Console.ReadKey();
        }
    }
    private void Display()
    {
        System.Console.WriteLine($@"----------------------------------------------------------------------------------
You are in the room at Row {finder.x} and Column {finder.y}).");
        if (_board?.layout?[finder.x, finder.y] == null){ }
        else if (_board.layout[finder.x, finder.y].identifier == 1 || _board.layout[finder.x, finder.y].identifier == 2)
        {
            System.Console.WriteLine(_board.layout[finder.x, finder.y].definition);
        }
        else{ }
        for (int i = finder.x - 1; i <= finder.x + 1; i++)
        {
            for (int j = finder.y - 1; j <= finder.y + 1; j++)
            {
                if (i >= 0 && i < _board?.layout?.GetLength(0) && j >= 0 && j < _board.layout.GetLength(1))
                {
                    if (i == finder.x && j == finder.y) continue;
                    if (_board.layout[i, j] != null && _board.layout[i, j].identifier != 1 && _board.layout[i, j].identifier != 2)
                    {
                        System.Console.WriteLine(_board.layout[i, j].definition);
                    }
                }
            }
        }
        System.Console.WriteLine("What would you like to do? ");
    }
    private void MoveTurn()
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                if (CheckMovements(finder.x - 1, finder.y))
                {
                    finder.x = finder.x - 1;
                    CheckTurn();
                }
                break;
            case ConsoleKey.DownArrow:
                if (CheckMovements(finder.x + 1, finder.y))
                {
                    finder.x = finder.x + 1;
                    CheckTurn();
                }
                break;
            case ConsoleKey.RightArrow:
                if (CheckMovements(finder.x, finder.y + 1))
                {
                    finder.y = finder.y + 1;
                    CheckTurn();
                }
                break;
            case ConsoleKey.LeftArrow:
                if (CheckMovements(finder.x, finder.y - 1))
                {
                    finder.y = finder.y - 1;
                    CheckTurn();
                }
                break;
            case ConsoleKey.E:
                if (_board?.layout?[finder.x, finder.y] == null)
                {
                    
                }
                else if (_board?.layout?[finder.x, finder.y].identifier == 2 && _board.layout[finder.x, finder.y].effect == false)
                {
                    _board.layout[finder.x, finder.y].effect = true;
                    _board.layout[finder.x, finder.y].definition = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
                    System.Console.WriteLine(_board.layout[finder.x, finder.y].definition);
                    _board.layout[0, 0].effect = true;
                }
                else if (_board?.layout?[finder.x, finder.y].identifier == 2 && _board.layout[finder.x, finder.y].effect)
                {
                    System.Console.WriteLine("The fountin is already flowing.");
                }
                else
                {
                    System.Console.WriteLine("You aren't in the room with the Fountain of Objects.");
                }
                break;
            case ConsoleKey.H:
                DisplayHelp();
                break;
            default:
                break;
        }
    }
    private void CheckTurn()
    {
        if (_board?.layout?[finder.x, finder.y] != null)
        {
            
            switch (_board.layout[finder.x, finder.y].identifier)
            {
                case 1:
                    if (_board.layout[0, 0].effect)
                    {
                        System.Console.WriteLine(@"The Fountain of Objects has been reactivated, and you have escaped with your life!
                        You win!");
                        play = false;
                    }
                    break;
                case 3:
                    System.Console.WriteLine(@"You fell in a pit.
                    You died.");
                    play = false;
                    break;
                case 4:
                    Battle();
                    break;
                case 5:
                    Battle();
                    break;
                default:
                    break;
            }
        }
        else
        {
            
        }
    }       
    private void Battle()
    {
        Random rnd = new Random();
        int playernum = rnd.Next(1, 20);
        int enemynum = rnd.Next(1, 20);
        if (bow.arrows > 0)
        {
            // System.Console.WriteLine($"You rolled a {playernum} against the {_board?.layout?[finder.x, finder.y].name}'s {enemynum}");
            if (playernum > enemynum)
            {
                System.Console.WriteLine("You shoot and kill the Amarok!");
                _board!.layout![finder.x, finder.y] = null!;
            }
            else
            {
                System.Console.WriteLine("You were killed by the Amarok.");
                play = false;
            }
        }
        else
        {
            System.Console.WriteLine("You were killed by the Amarok.");
            play = false;
        }
    } 
    private void DisplayHelp()
    {
        System.Console.WriteLine(@$"You will type in the following codes to interact when prompted:
up arrow = move up one.
down arrow = move down one.
right arrow = move right one.
left arrow = move left one.
e = attempt to enable Fountain of Objects *can only be done in the room with it*");
    }
    private static void DisplayIntro()
    {
        System.Console.WriteLine(@$"You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search
of the Fountain of Objects.
Light is visible only in the entrance, and no other light is seen anywhere in the caverns.
You must navigate the Caverns with your other senses.
Find the Fountain of Objects, activate it, and return to the entrance.
Look out for pits. Youwill feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.
Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location
in the caverns. You will be able to hear their growling and groaning in nearby rooms.
Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.
“You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned:
you have a limited supply.");
    }
    private bool CheckMovements(int x, int y)
    {
        if (x >= _board?.layout?.GetLength(0) || x < 0 || y >= _board?.layout?.GetLength(1) || y < 0)
        {
            System.Console.WriteLine("You can't move there!");
            return false;
        }
        else
        {
            return true;
        }
    }
}