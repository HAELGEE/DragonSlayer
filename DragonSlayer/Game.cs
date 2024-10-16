using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DragonSlayer;
class Game
{
    public Color color = new Color();
    private Hero hero;
    private List<Dragon> dragons;
    private Attack attack = new Attack();

    public Game()
    {
    }

    public void GameLogic()
    {
        bool loop = true;
        while (loop)
        {
            Console.Clear();

            Console.WriteLine("What do you want to call your Hero?");
            string name = Console.ReadLine();

            if (name == null || name == "")
            {
                Console.WriteLine("Invalid input, try again");
                Console.ReadKey();
            }
            else
            {
                Hero hero = new Hero(name);
                loop = false;
            }
        }

        string classChoice = null;
        do
        {
            Console.Clear();

            Console.WriteLine("Classed to chose from:");
            Console.WriteLine("1.Mage");
            Console.WriteLine("2.Warrior");
            Console.WriteLine("What class do you want to chose?: ");
            classChoice = Console.ReadLine();

            if (classChoice != "1" && classChoice != "2")
            {
                Console.WriteLine("Invalid input, try again!");
                //Bara för att användaren skall kunna hinna läsa Felmeddelandet
                Console.ReadKey();
            }
            else
                break;

        } while (classChoice != "1" && classChoice != "2");

        if (classChoice == "1")
        {
            classChoice = null;
            Hero mage = new Hero(100, 0, 10, 1);
            attack.AttackMenu(mage);
        }
        else if (classChoice == "2")
        {
            classChoice = null;
            Hero warrior = new Hero(100, 10, 0, 1);            
            attack.AttackMenu(warrior);
        }

    }
    public void ShowingHeroStats()
    {
        Console.Write($"Hero HP:");
        if (hero.Health > hero.MaxHealth * 0.6)
            color.ColorGreen(hero.Health);
        else if (hero.Health < hero.MaxHealth * 0.31)
            color.ColorRed(hero.Health);
        else
            color.ColorYellow(hero.Health);

        Console.WriteLine($"Hero Level: {hero.Level} : Experience: {hero.Experience}/{hero.ExperienceCap}");
        
        Console.WriteLine();
    }

    public void AttackSimulator(Hero hero)
    {
        //Här kommer attack simulationen mellan drake och hero komma

        // Kontrollera vilken utav drakarna man möter
        Random random = new Random();
        int randomDragon = random.Next(0, 3);
        if (randomDragon == 0)
        {
            Dragon Poison = new Dragon("PoisonDragon", 10, 0, hero.Level);
        }
        else if (randomDragon == 1)
        {
            Dragon Fire = new Dragon("FireDragon", 0, 10, hero.Level);

        }
        else if (randomDragon == 2)
        {
            Dragon Frost = new Dragon("FrostDragon", 10, 0, hero.Level);

        }

        Console.Clear();

        ShowingHeroStats();
    }


}
