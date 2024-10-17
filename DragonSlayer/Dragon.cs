using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer;
public class Dragon
{
    public string Name;
    public int Strength;
    public int SpellPower;
    public int Level;
    public int Poison = 0;
    public int PoisonTicks = 0;
    public int Fire = 0;
    public int FireTicks = 0;

    public Dragon(string name, int strength, int spellpower, int level)
    {
        Name = name;
        Strength = strength;
        SpellPower = spellpower;
        Level = level;
    }

    public int PoisonDamage(int hero)
    {
        // Lägga in logik för poison
        // Lägga in poison attack som drakar han en chans att lägga på Hero vid varje försök till attack
        // -20 för varje poison tick i Max 3 rundor
        Random random = new Random();
        int randomTurn = random.Next(0, 101);

        // Här kommer en procent logik för att se om man får Poison eller inte
        // Där det är 17% chans att få det.
        if (randomTurn >= 83)
        {
            int randomPoison = random.Next(0, 3);
            if (randomPoison == 0)
            {
                Console.WriteLine($"You got poisoned for {randomPoison} turn");
                PoisonTicks = 1;
            }
            else if (randomPoison == 1)
            {
                Console.WriteLine($"You got poisoned for {randomPoison} turns");
                PoisonTicks = 2;
            }
            else if (randomPoison == 2)
            {
                Console.WriteLine($"You got poisoned for {randomPoison} turns");
                PoisonTicks = 3;
            }
        }

        // Om det finns Poison tick så slängs "20" in i Poison
        if (PoisonTicks > 0)
            hero = -20;

        // Returnerar Poison, 20 om PoisonTick är större än 0 annars 0
        return hero;
    }

    public int FireDamage(int hero)
    {
        // Lägga in logik för poison
        // Lägga in poison attack som drakar han en chans att lägga på Hero vid varje försök till attack
        // -20 för varje poison tick i Max 3 rundor
        Random random = new Random();
        int randomTurn = random.Next(0, 101);

        // Här kommer en procent logik för att se om man får Poison eller inte
        // Där det är 17% chans att få det.
        if (randomTurn >= 83)
        {
            int randomFire = random.Next(0, 3);
            if (randomFire == 0)
            {
                Console.WriteLine($"You got burn for {randomFire} turn");
                PoisonTicks = 1;
            }
            else if (randomFire == 1)
            {
                Console.WriteLine($"You got burn for {randomFire} turns");
                PoisonTicks = 2;
            }
            else if (randomFire == 2)
            {
                Console.WriteLine($"You got burn for {randomFire} turns");
                PoisonTicks = 3;
            }
        }

        // Om det finns Poison tick så slängs "20" in i Poison
        if (PoisonTicks > 0)
            hero = -20;

        // Returnerar Poison, 20 om PoisonTick är större än 0 annars 0
        return hero;
    }
}
