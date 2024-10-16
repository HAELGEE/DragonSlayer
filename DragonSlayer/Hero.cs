using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DragonSlayer;
public class Hero
{
    Attack attack = new Attack();
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int SpellPower { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int ExperienceCap { get; set; } = 100;
    public int HealingPoitions { get; set; } = 1;
    public int MaxHealth { get; set; }
    public bool tries;

    public Hero(int health, int strength, int spellPower, int level)
    {
        Health = health;
        MaxHealth = 400;
        Strength = strength;
        SpellPower = spellPower;
        Level = level;
    }
    public Hero(string name)
    {
        Name = name;
    }
    

    public void Mage()
    {
        attack.CastingSpell();
    }
    public void Warrior()
    {
        attack.MeleeAttack();
    }

    public void GetHeroNameAndClass()
    {       
        
    }
    public void Healing()
    {
        if (HealingPoitions == 0)
            Console.WriteLine("You currently have 0 HealingPotions.");
        else
        {
            Console.WriteLine("You drank a Healing Poition and gained HP");
            Health += 150;
            //Kontroll ifall Hp på hero blir mer än vad maxhp är, då sätts Hp till Maxhp!
            if (Health > MaxHealth)
                Health = MaxHealth;

            HealingPoitions--;
        }
        Console.ReadKey();
    }

    public void LevelUp()
    {
        ExperienceCap = Level * 100;
    }
}
