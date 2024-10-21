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
    private Attack attack = new Attack();

    double dragonsToSlain { get; set; }

    public bool GameWon = false;

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
            hero = new Hero("Mage", 1000, 0, 10, 1);
        }
        else if (classChoice == "2")
        {
            classChoice = null;
            hero = new Hero("Warrior", 1000, 10, 0, 1);
        }


        do
        {
            try
            {
                Console.Clear();

                Console.WriteLine("How many dragons do you want to Slain? (4 is minimum)");
                dragonsToSlain = Convert.ToDouble(Console.ReadLine());
                if (dragonsToSlain < 3)
                {
                    Console.WriteLine("Invalid input. Minimum 4 dragons!");
                    Console.ReadKey();
                }
                else
                    break;

            }
            catch (Exception)
            {
                Console.WriteLine($"Invalid input. You need to enter numbers!");
                Console.ReadKey();
            }
        } while (true);

        AttackMenu();
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

    public void ShowingDragonStats(Dragon Dragon)
    {
        Console.Write($"Dragon HP:");
        if (Dragon.MinionDragons.Health > Dragon.MinionDragons.MaxHealth * 0.6)
            color.ColorGreen(Dragon.MinionDragons.Health);
        else if (Dragon.MinionDragons.Health < Dragon.MinionDragons.MaxHealth * 0.31)
            color.ColorRed(Dragon.MinionDragons.Health);
        else
            color.ColorYellow(Dragon.MinionDragons.Health);
    }
    public void ShowingBossStats(Boss boss)
    {
        Console.Write($"Dragon HP:");
        if (Boss.DragonBoss.Health > Boss.DragonBoss.MaxHealth * 0.6)
            color.ColorGreen(Boss.DragonBoss.Health);
        else if (Boss.DragonBoss.Health < Boss.DragonBoss.MaxHealth * 0.31)
            color.ColorRed(Boss.DragonBoss.Health);
        else
            color.ColorYellow(Boss.DragonBoss.Health);
    }

    public void AttackMenu()
    {
        Dragon.RandomDragon(hero);
        string attackmenuChoice = null;
        bool gameOn = true;
        do
        {
            if (dragonsToSlain == 0)
            {
                Console.Clear();

                Console.WriteLine("All the minion dragons are slained");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine($"BEWARE!");
                Thread.Sleep(500);
                Console.Clear();
                Thread.Sleep(500);
                Console.WriteLine($"BEWARE!");
                Thread.Sleep(500);
                Console.Clear();
                Thread.Sleep(500);
                Console.WriteLine($"BEWARE!");
                Thread.Sleep(500);
                Console.Clear();
                Thread.Sleep(500);
                Console.WriteLine($"BEWARE!");
                Thread.Sleep(500);
                Console.WriteLine($"The boss is approaching");
                Thread.Sleep(2000);

                Boss.BossCreator(hero);

                do
                {
                    if (hero.Health <= 0)
                    {
                        Console.WriteLine("You died, better luck next time");
                        hero.isAlive = false;
                    }
                    else if (Boss.DragonBoss.Health <= 0)
                    {
                        Console.WriteLine($"{Boss.DragonBoss.Name} died, You Won!");
                        gameOn = false;
                    }
                    else
                    {
                        hero.ExperienceCapCheck();
                        hero.CheckLevelUp(hero);
                        Console.Clear();

                        Console.WriteLine(Boss.DragonBoss.Name);
                        ShowingBossStats(Boss.DragonBoss);

                        ShowingHeroStats(hero);

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

                        if (Boss.DragonBoss.Health > 0)
                        {
                            switch (attackmenuChoice)
                            {
                                case "1":

                                    AttackSimulatorBoss(hero);
                                    break;

                                case "2":
                                    string choice = null;
                                    do
                                    {
                                        Console.Clear();

                                        ShowingHeroStats(hero);

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

                                    } while (choice != "2");
                                    break;
                            }
                        }
                        else
                            break;
                    }

                } while (hero.Health != 0 || Boss.DragonBoss.Health != 0);

                break;
            }
            else if (hero.Health <= 0)
            {
                hero.isAlive = false;
                break;
            }
            else if (gameOn == false)
                break;
            else
            {
                do
                {
                    Console.Clear();

                    // Om man har besegrat en drake så skall en ny spawna tills alla drakar är döda
                    // Och om Hero går upp i level skall även drakarna göra det.

                    if (dragonsToSlain > 0)
                    {
                        if (Dragon.MinionDragons.Health <= 0)
                            Dragon.RandomDragon(hero);

                        hero.ExperienceCapCheck();
                        hero.CheckLevelUp(hero);
                        Console.Clear();

                        Console.WriteLine(Dragon.MinionDragons.Name);
                        ShowingDragonStats(Dragon.MinionDragons);
                        Console.WriteLine($"Dragons left to Slain {dragonsToSlain}\n");

                        ShowingHeroStats(hero);

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
                    }
                    else
                        break;

                    if (Dragon.MinionDragons.Health > 0)
                    {
                        switch (attackmenuChoice)
                        {
                            case "1":

                                AttackSimulator(hero);
                                break;

                            case "2":
                                string choice = null;
                                do
                                {
                                    Console.Clear();

                                    ShowingHeroStats(hero);

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

                                } while (choice != "2");
                                break;

                            case "3":
                                Console.WriteLine("You ran away like a chicken you are!");
                                Console.ReadLine();
                                gameOn = false;
                                break;
                        }
                    }
                    else
                        break;

                } while (Dragon.MinionDragons.Health <= 0 || hero.Health <= 0);
                //} while (attackmenuChoice != "1" || attackmenuChoice != "2" || attackmenuChoice != "3");
            }
        } while (attackmenuChoice != "3" || dragonsToSlain != 0 || hero.isAlive == true || gameOn == true);
    }

    public void AttackSimulator(Hero hero)
    {
        //Här kommer attack simulationen mellan drake och hero komma

        Console.Clear();

        ShowingHeroStats(hero);
        ShowingDragonStats(Dragon.MinionDragons);

        // Kontrollerar vilken klass Hero har
        if (hero.Class == "Mage")
            attack.CastingSpell(hero);
        else if (hero.Class == "Warrior")
            attack.MeleeAttack(hero);

        // Om hero har 0 hp ska det sluta
        if (hero.Health <= 0)
        {
            Console.WriteLine($"You died, better luck next time");
            Console.ReadKey();
            hero.isAlive = false;
        }
        // Om drake har 0 hp, gå vidare till nästa drake 
        else if (Dragon.MinionDragons.Health <= 0)
        {
            dragonsToSlain--;
            hero.Experience += 25;
            Console.WriteLine($"You killed a {Dragon.MinionDragons.Name}");
            Console.WriteLine($"Gained 25 Experience");
        }
        else
        {
            // Kontrollerar vilken typ av drake
            if (Dragon.MinionDragons.Name.Contains("Poison"))
                attack.PoisonDamage(hero);

            else if (Dragon.MinionDragons.Name.Contains("Fire"))
                attack.FireDamage(hero);

            else if (Dragon.MinionDragons.Name.Contains("Frost"))
                attack.FrostDamage(hero);
        }

        Console.ReadKey();
    }
    public void AttackSimulatorBoss(Hero hero)
    {
        //Här kommer attack simulationen mellan Boss och Hero komma

        Console.Clear();

        ShowingHeroStats(hero);
        ShowingBossStats(Boss.DragonBoss);


        // Kontrollerar vilken klass Hero har
        if (hero.Class == "Mage")
            attack.CastingSpellAgainstBoss(hero);
        else if (hero.Class == "Warrior")
            attack.MeleeAttackAgainstBoss(hero);

        // Om hero har 0 hp ska det sluta
        if (hero.Health <= 0)
        {
            Console.WriteLine($"You died, better luck next time");
            Console.ReadKey();
            hero.isAlive = false;
        }
        // Om drake har 0 hp, Game WON
        else if (Boss.DragonBoss.Health <= 0)
        {
            GameWon = true;

        }
        else
        {
            // Kontrollerar vilken typ av spell Boss skall använda
            Random random = new Random();
            int randomSpell = random.Next(0, 3);
            if (randomSpell == 0)
                attack.PoisonDamage(hero);

            else if (randomSpell == 1)
                attack.FireDamage(hero);

            else if (randomSpell == 0)
                attack.FrostDamage(hero);
        }

        Console.ReadKey();
    }
}
