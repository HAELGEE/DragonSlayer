namespace DragonSlayer;

internal class Program
{
    public static bool tries = true;
    static void Main(string[] args)
    {
        Game game = new Game();
       
        string choice = null;
        do
        {
            Console.Clear();

            Console.WriteLine("Dragon slayer game");
            Console.WriteLine("1.New Game");
            Console.WriteLine("2.Load Game");
            Console.WriteLine("3.Quit");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bool tries = true;
                    do
                    {
                        Console.Clear();

                        if (tries == false)
                        {
                            string value;
                            do
                            {
                                Console.WriteLine("Do you want to try again?");
                                Console.WriteLine("1.Yes");
                                Console.WriteLine("2.No");
                                value = Console.ReadLine();
                                if (value == "1")
                                {
                                    tries = true;
                                    game.GameLogic();
                                }
                                else
                                    Console.WriteLine("Bye bye");
                                Console.ReadKey();

                            } while (value != "1" && value != "2");
                        }
                        else
                        {
                            tries = false;
                            game.GameLogic();
                        }
                    } while (tries != true);
                    break;

                case "2":
                    LoadGame();
                    break;

                case "3":
                    Console.WriteLine("The game is now closing, See you again!");                    
                    break;
                default:
                    Console.WriteLine("Invalid input, try again!");
                    break;
            }        
        } while (choice != "3");
    }
    static public void LoadGame()
    {

    }
}
