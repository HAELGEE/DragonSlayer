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
    private Dragon dragon;
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
            hero = new Hero("Mage", 100, 0, 10, 1);
            
            attack.AttackMenu(hero);
        }
        else if (classChoice == "2")
        {
            classChoice = null;
            hero = new Hero("Warrior", 100, 10, 0, 1);
            attack.AttackMenu(hero);
        }

    }
    public void ShowingHeroStats(Hero hero)
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

    public void ShowingDragonStats(Dragon dragon)
    {
        Console.Write($"Dragon HP:");
        if (dragon.Health > dragon.MaxHealth * 0.6)
            color.ColorGreen(dragon.Health);
        else if (dragon.Health < dragon.MaxHealth * 0.31)
            color.ColorRed(dragon.Health);
        else
            color.ColorYellow(dragon.Health);

        Console.WriteLine();
    }

    public void AttackSimulator(Hero hero)
    {        
        //Här kommer attack simulationen mellan drake och hero komma

        // Kontrollera vilken utav drakarna man möter
        Random random = new Random();
        int randomDragon = 1;
        //random.Next(0, 3);

        if (dragon.Health == 0 || dragon.Name.Contains("null"))
        {
            if (randomDragon == 0)
            {
                dragon = new Dragon("PoisonDragon", 100, 10, 0, hero.Level);
            }
            else if (randomDragon == 1)
            {
                dragon = new Dragon("FireDragon", 100, 0, 10, hero.Level);
            }
            else if (randomDragon == 2)
            {
                dragon = new Dragon("FrostDragon", 100, 10, 0, hero.Level);
            }
        }

        //do
        //{
            Console.Clear();


            ShowingHeroStats(hero);
            ShowingDragonStats(dragon);

            if (hero.Class == "Mage")
                attack.CastingSpell(dragon);
            else if (hero.Class == "Warrior")
                attack.MeleeAttack(dragon);

            if (dragon.Name.Contains("Poison"))
                Console.WriteLine();

            else if (dragon.Name.Contains("Fire"))
                dragon.FireDamage(hero);

            else if (dragon.Name.Contains("Frost"))
                Console.WriteLine();


            if (hero.Health <= 0)
                Console.WriteLine($"You died");
            else if (dragon.Health <= 0)
            {
                hero.Experience += 25;
                Console.WriteLine($"You killed a {dragon.Name}");
                Console.WriteLine($"Gained 25 Experience");
            }

            Console.ReadKey();
        //} while (hero.Health !<= 0 || dragon.Health !<= 0);
    }


}
