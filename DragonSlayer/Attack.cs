using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer;
public class Attack
{
    static Game game = new Game();
    public Random random = new Random();


    public Attack()
    {
    }

    string spellCast = null;
    string meleeAttack = null;
    public int Poison { get; set; }
    public int PoisonTicks { get; set; }
    public int Fire { get; set; }
    public int FireTicks { get; set; }
    public int SpellDotTick { get; set; }




    public void CastingSpell(Hero hero)
    {
        //Här kommer all attack loigik för en spellcaster att komma

        double randomDamage = random.Next(100, 151);
        randomDamage = hero.SpellPower + randomDamage;

        int spellDotChance = random.Next(1, 101);
        int spellDotDamage = hero.SpellPower;

        do
        {
            Console.Clear();

            Console.WriteLine("Attack to chose from:");
            Console.WriteLine("1.Fireball");
            Console.WriteLine("2.Ice Shard");
            Console.Write("What spell do you want to cast?: ");
            spellCast = Console.ReadLine();

            if (spellCast != "1" && spellCast != "2")
            {
                Console.WriteLine("Invalid input, try again!");
                Console.ReadKey();
            }
        } while (spellCast != "1" && spellCast != "2");

        Console.Clear();

        if (spellCast == "1")
        {
            Console.WriteLine($"You cast a Fireball against {Dragon.MinionDragons.Name} and did {Convert.ToInt32(randomDamage)} damage");
            Dragon.MinionDragons.Health = Dragon.MinionDragons.Health - Convert.ToInt32(randomDamage);

            if (spellDotChance > 0 && spellDotChance < 17)
            {
                Console.WriteLine($"{Dragon.MinionDragons.Name} got Burn");
                SpellDotTick = 2;
            }

            if (SpellDotTick > 0)
            {
                Console.WriteLine($"{Dragon.MinionDragons.Name} took {spellDotDamage - 35} damage from Burn");
                Dragon.MinionDragons.Health = Dragon.MinionDragons.Health - (spellDotDamage - 35);
                SpellDotTick--;
            }
        }
        else if (spellCast == "2")
        {
            Console.WriteLine($"You cast a Ice Shard against {Dragon.MinionDragons.Name} and did {Convert.ToInt32(randomDamage)} damage");
            Dragon.MinionDragons.Health = Dragon.MinionDragons.Health - Convert.ToInt32(randomDamage);

            if (spellDotChance > 0 && spellDotChance < 17)
            {
                SpellDotTick = 2;
                Console.WriteLine($"{Dragon.MinionDragons.Name} got FrostBite");
            }

            if (SpellDotTick > 0)
            {
                Console.WriteLine($"{Dragon.MinionDragons.Name} and took {spellDotDamage - 35} damage from FrostBite");
                Dragon.MinionDragons.Health = Dragon.MinionDragons.Health - (spellDotDamage - 35);
                SpellDotTick--;
            }
        }

        Console.ReadKey();
    }
    public void CastingSpellAgainstBoss(Hero hero)
    {
        //Här kommer all attack loigik för en spellcaster att komma emot boss
        double randomDamage = random.Next(100, 151);
        randomDamage = hero.SpellPower + randomDamage;

        int spellDotChance = random.Next(1, 101);
        int spellDotDamage = hero.SpellPower;

        do
        {
            Console.Clear();

            Console.WriteLine("Attack to chose from:");
            Console.WriteLine("1.Fireball");
            Console.WriteLine("2.Ice Shard");
            Console.Write("What spell do you want to cast?: ");
            spellCast = Console.ReadLine();

            if (spellCast != "1" && spellCast != "2")
            {
                Console.WriteLine("Invalid input, try again!");
                Console.ReadKey();
            }
        } while (spellCast != "1" && spellCast != "2");

        Console.Clear();

        if (spellCast == "1")
        {
            Console.WriteLine($"You cast a Fireball against {Boss.DragonBoss.Name} and did {Convert.ToInt32(randomDamage)} damage");
            Boss.DragonBoss.Health = Boss.DragonBoss.Health - Convert.ToInt32(randomDamage);

            if (spellDotChance > 0 && spellDotChance < 17)
            {
                Console.WriteLine($"{Boss.DragonBoss.Name} got Burn");
                SpellDotTick = 2;
            }

            if (SpellDotTick > 0)
            {
                Console.WriteLine($"{Boss.DragonBoss.Name} took {spellDotDamage - 35} damage from Burn");
                Boss.DragonBoss.Health = Boss.DragonBoss.Health - (spellDotDamage - 35);
                SpellDotTick--;
            }
        }
        else if (spellCast == "2")
        {
            Console.WriteLine($"You cast a Ice Shard against {Boss.DragonBoss.Name} and did {Convert.ToInt32(randomDamage)} damage");
            Boss.DragonBoss.Health = Boss.DragonBoss.Health - Convert.ToInt32(randomDamage);

            if (spellDotChance > 0 && spellDotChance < 17)
            {
                SpellDotTick = 2;
                Console.WriteLine($"{Boss.DragonBoss.Name} got FrostBite");
            }

            if (SpellDotTick > 0)
            {
                Console.WriteLine($"{Boss.DragonBoss.Name} and took {spellDotDamage - 35} damage from FrostBite");
                Boss.DragonBoss.Health = Boss.DragonBoss.Health - (spellDotDamage - 35);
                SpellDotTick--;
            }
        }

        Console.ReadKey();
    }
    public void MeleeAttack(Hero hero)
    {

        //Här kommer all attack logik från en melee att komma
        double randomDamage = random.Next(100, 151);
        int crittChance = random.Next(1, 101);
        randomDamage = hero.Strength + randomDamage;

        do
        {
            Console.Clear();

            Console.WriteLine("Attack to chose from:");
            Console.WriteLine("1.Slash, slash, slash");
            Console.WriteLine("2.Leap of Faith");
            Console.Write("What attack do you want to attack with?: ");
            meleeAttack = Console.ReadLine();

            if (meleeAttack != "1" && meleeAttack != "2")
            {
                Console.WriteLine("Invalid input, try again!");
                //Låter användaren hinna läsa felmeddelandet om man gjort fel input.
                Console.ReadKey();
            }
        } while (meleeAttack != "1" && meleeAttack != "2");

        Console.Clear();

        if (meleeAttack == "1")
        {
            if (crittChance > 0 && crittChance < 20)
            {
                randomDamage = randomDamage * 1.5;
                Console.WriteLine("Critical hit!");
            }

            Console.WriteLine($"You went up to the {Dragon.MinionDragons.Name} and slashed it 3 times and did {Convert.ToInt32(randomDamage)} damage");
            Dragon.MinionDragons.Health = Dragon.MinionDragons.Health - Convert.ToInt32(randomDamage);
        }
        else if (meleeAttack == "2")
        {
            if (crittChance > 0 && crittChance < 20)
            {
                randomDamage = randomDamage * 1.5;
                Console.WriteLine("Critical hit!");
            }

            Console.WriteLine($"You jumped forward and stabbed {Dragon.MinionDragons.Name} and did {Convert.ToInt32(randomDamage)} damage");
            Dragon.MinionDragons.Health = Dragon.MinionDragons.Health - Convert.ToInt32(randomDamage);
        }

        Console.ReadKey();
    }
    public void MeleeAttackAgainstBoss(Hero hero)
    {
        //Här kommer all attack logik från en melee att komma emot boss
        int crittChance = random.Next(1, 101);
        double randomDamage = random.Next(100, 151);
        randomDamage = hero.Strength + randomDamage;

        do
        {
            Console.Clear();

            Console.WriteLine("Attack to chose from:");
            Console.WriteLine("1.Slash, slash, slash");
            Console.WriteLine("2.Leap of Faith");
            Console.Write("What attack do you want to attack with?: ");
            meleeAttack = Console.ReadLine();

            if (meleeAttack != "1" && meleeAttack != "2")
            {
                Console.WriteLine("Invalid input, try again!");
                //Låter användaren hinna läsa felmeddelandet om man gjort fel input.
                Console.ReadKey();
            }
        } while (meleeAttack != "1" && meleeAttack != "2");

        Console.Clear();

        if (meleeAttack == "1")
        {
            if (crittChance > 0 && crittChance < 20)
            {
                randomDamage = randomDamage * 1.5;
                Console.WriteLine("Critical hit!");
            }

            Console.WriteLine($"You went up to the {Boss.DragonBoss.Name} and slashed it 3 times and did {Convert.ToInt32(randomDamage)} damage");
            Boss.DragonBoss.Health = Boss.DragonBoss.Health - Convert.ToInt32(randomDamage);
        }
        else if (meleeAttack == "2")
        {
            if (crittChance > 0 && crittChance < 20)
            {
                randomDamage = randomDamage * 1.5;
                Console.WriteLine("Critical hit!");
            }

            Console.WriteLine($"You jumped forward and stabbed {Boss.DragonBoss.Name} and did {Convert.ToInt32(randomDamage)} damage");
            Boss.DragonBoss.Health = Boss.DragonBoss.Health - Convert.ToInt32(randomDamage);
        }

        Console.ReadKey();
    }
    public void PoisonDamage(Hero hero)
    {
        // Lägga in logik för poison
        // Lägger in Poison attack som Poisondrakar han en chans att lägga på Hero vid varje försök till attack
        // Minus damage beroende på spellpower för varje poison tick i Max 3 rundor
        Random random = new Random();
        int randomTurn = random.Next(0, 101);
        double randomDamage = random.Next(100, 151);

        if (Dragon.MinionDragons.Name.Contains("Poison"))
            randomDamage = randomDamage + Dragon.MinionDragons.Strength;
        else
            randomDamage = randomDamage + Boss.DragonBoss.Strength;

        Console.WriteLine($"The PoisonDragon spits acid on you and did {Convert.ToInt32(randomDamage)} damage");
        hero.Health = hero.Health - Convert.ToInt32(randomDamage);

        // Här kommer en procent logik för att se om man får Poison eller inte
        // Där det är 17% chans att få det.
        if (randomTurn >= 83)
        {
            int randomPoison = random.Next(1, 4);
            if (randomPoison == 1)
            {
                Console.WriteLine($"You got poisoned for {randomPoison} turn");
                PoisonTicks = 1;
            }
            else if (randomPoison == 2)
            {
                Console.WriteLine($"You got poisoned for {randomPoison} turns");
                PoisonTicks = 2;
            }
            else if (randomPoison == 3)
            {
                Console.WriteLine($"You got poisoned for {randomPoison} turns");
                PoisonTicks = 3;
            }
        }

        // Om det finns Poison tick så slängs "10" in i Poison som Poisondmg
        if (PoisonTicks > 0)
        {
            Console.WriteLine($"You got poisoned and lost 10 Health");
            hero.Health = hero.Health - 10;
            PoisonTicks--;
        }
    }
    public void FireDamage(Hero hero)
    {
        // Lägga in logik för fire
        // Lägger in Burn attack så Firedrakar han en chans att lägga på Hero vid varje försök till attack
        // Minus damage beroende på spellpower för varje burn tick i Max 3 rundor
        Random random = new Random();
        int randomTurn = random.Next(0, 101);
        double randomDamage = random.Next(100, 151);

        if (Dragon.MinionDragons.Name.Contains("Fire"))
            randomDamage = randomDamage + Dragon.MinionDragons.Strength;
        else
            randomDamage = randomDamage + Boss.DragonBoss.Strength;

        Console.WriteLine($"The FireDragon did a huge breath and blew out large Flames of fire on you and did {Convert.ToInt32(randomDamage)} damage");
        hero.Health = hero.Health - Convert.ToInt32(randomDamage);

        // Här kommer en procent logik för att se om man får Burn eller inte
        // Där det är 17% chans att få det.
        if (randomTurn >= 83)
        {
            int randomFire = random.Next(1, 4);
            if (randomFire == 1)
            {
                Console.WriteLine($"You got burn for {randomFire} turn");
                FireTicks = 1;
            }
            else if (randomFire == 2)
            {
                Console.WriteLine($"You got burn for {randomFire} turns");
                FireTicks = 2;
            }
            else if (randomFire == 3)
            {
                Console.WriteLine($"You got burn for {randomFire} turns");
                FireTicks = 3;
            }
        }

        // Om det finns Burn tick så slängs "10" in i Burn som Burndmg
        if (FireTicks > 0)
        {
            Console.WriteLine($"You got burned and lost 10 Health");
            hero.Health = hero.Health - 10;
            FireTicks--;
        }
    }
    public void FrostDamage(Hero hero)
    {
        // Lägga in logik för frost dmg, kanske ha en chans att Hero ska få en stun?
        Random random = new Random();
        double randomDamage = random.Next(100, 151);

        if (Dragon.MinionDragons.Name.Contains("Frost"))
            randomDamage = randomDamage + Dragon.MinionDragons.Strength;
        else
            randomDamage = randomDamage + Boss.DragonBoss.Strength;

        Console.WriteLine($"The FrostDragon blew freezing air and did {Convert.ToInt32(randomDamage)} damage to you");
        hero.Health = hero.Health - Convert.ToInt32(randomDamage);
    }
}
