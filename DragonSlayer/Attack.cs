using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer;
public class Attack
{
    static Game game = new Game();
    public Attack()
    {
    }

    string spellCast = null;
    string meleeAttack = null;
    

    public void AttackMenu(Hero hero)
    {
        string attackmenuChoice = null;
        do
        {
            Console.Clear();
            
            do
            {
                Console.Clear();

                game.ShowingHeroStats(hero);

                Console.WriteLine("== Attack Menu ==");
                Console.WriteLine("1.Attack");
                Console.WriteLine("2.Items");
                Console.WriteLine("3.Run away");
                attackmenuChoice = Console.ReadLine();

                if (attackmenuChoice != "1" && attackmenuChoice != "2" && attackmenuChoice != "3")
                {
                    Console.WriteLine("Invalid input, try again!");
                    Console.ReadKey();
                }

            } while (attackmenuChoice != "1" && attackmenuChoice != "2" && attackmenuChoice != "3");

            switch (attackmenuChoice)
            {
                case "1":
                    game.AttackSimulator(hero);
                    break;

                case "2":
                    string choice = null;
                    do
                    {                        
                        Console.Clear();

                        game.ShowingHeroStats(hero);

                        Console.WriteLine("== INVENTORY ==");
                        Console.WriteLine($"You currently have:");
                        Console.WriteLine($"1.Healing Poitions: {hero.HealingPoitions}");
                        Console.WriteLine();
                        Console.WriteLine($"2.Back");
                        Console.WriteLine();
                        Console.WriteLine("What do you want to use?");
                        choice = Console.ReadLine();

                        if (choice == "1")
                            hero.Healing();
                        else if (choice == "2")
                            break;

                    } while (choice != "1" && choice != "2");
                    break;

                case "3":
                    Console.WriteLine("You ran away like a chicken you are!");
                    Console.ReadLine();
                    break;
            }
        } while (attackmenuChoice != "3");

    }

    public void CastingSpell()
    {
        //Här kommer all attack loigik för en spellcaster att komma
        do
        {
            Console.Clear();

            Console.WriteLine("Attack to chose from:");
            Console.WriteLine("1.Fireball");
            Console.WriteLine("2.Ice Shard");
            Console.Write("What spell do you want to cast?:");
            spellCast = Console.ReadLine();

            if (spellCast != "1" && spellCast != "2")
            {
                Console.WriteLine("Invalid input, try again!");
                Console.ReadKey();
            }
        } while (spellCast != "1" && spellCast != "2");
        if (spellCast == "1")
            Console.WriteLine($"You cast a Fireball against your Enemy");
        else if (spellCast == "2")
            Console.WriteLine($"You cast a Ice Shard agains your Enemy");
    }
    public void MeleeAttack()
    {
        //Här kommer all attack logik från en melee att komma
        do
        {
            Console.Clear();

            Console.WriteLine("Attack to chose from:");
            Console.WriteLine("1.Slash, slash, slash");
            Console.WriteLine("2.Leap of Faith");
            Console.Write("What spell do you want to cast?:");
            meleeAttack = Console.ReadLine();

            if (meleeAttack != "1" && meleeAttack != "2")
            {
                Console.WriteLine("Invalid input, try again!");
                //Låter användaren hinna läsa felmeddelandet om man gjort fel input.
                Console.ReadKey();
            }
        } while (meleeAttack != "1" && meleeAttack != "2");

        if (meleeAttack == "1")
            Console.WriteLine($"You went up to the Dragon and slashed it 3 times.");
        else if (meleeAttack == "2")
            Console.WriteLine($"You jumped forward and stabbed the Dragon");
    }
}
