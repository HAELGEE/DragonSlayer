using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer;
class Game
{
    private Hero hero;
    private List<Dragon> dragons;
    private Attack attack = new Attack();

    public void GameLogic()
    {
        string classChoice = null;
        bool loop = true;
        while (loop)
        {
            Console.Clear();

            Console.WriteLine("Classed to chose from:");
            Console.WriteLine("Mage");
            Console.WriteLine("Warrior");
            Console.WriteLine("What class do you want to chose?: ");
            classChoice = Console.ReadLine().ToUpper();

            if (classChoice != "MAGE" && classChoice != "WARRIOR")
            {
                Console.WriteLine("Invalid input, try again!");
                //Bara för att användaren skall kunna hinna läsa Felmeddelandet
                Console.ReadKey();
            }
            else
                break;
        }


        if (classChoice == "MAGE")
        {
            Hero mage = new Hero(100, 0, 10, 1);
            attack.AttackMenu(mage);
        }
        else if (classChoice == "WARRIOR")
        {
            Hero warrior = new Hero(200, 10, 0, 1);
            attack.AttackMenu(warrior);
        }
    }

}
