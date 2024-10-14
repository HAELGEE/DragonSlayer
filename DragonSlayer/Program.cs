namespace DragonSlayer;

internal class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();

        string choice = null;
        do
        {
            Console.WriteLine("Dragon slayer game");
            Console.WriteLine("1.New Game");
            Console.WriteLine("2.Load Game");
            Console.WriteLine("3.Quit");
            choice = Console.ReadLine();

        } while (choice != "1" && choice != "2" && choice != "3");

        bool loop = true;
        while (loop)
        {
            switch (choice)
            {
                case "1":
                    game.GameLogic();
                    break;

                case "2":
                    LoadGame();
                    break;

                case "3":
                    Console.WriteLine("The game is now closing, See you again!");
                    loop = false;
                    break;
            }
        }
    }
    static public void LoadGame()
    {

    }
}
