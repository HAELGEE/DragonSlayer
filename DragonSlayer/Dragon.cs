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
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Strength { get; set; }
    public int SpellPower { get; set; }
    public int Level { get; set; }
    

    public static Dragon _dragon {  get; set; }

    public Dragon(string name, int health, int strength, int spellPower, int level)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        Strength = strength;
        SpellPower = spellPower;
        Level = level;
    }


    public static void RandomDragon(Hero hero)
    {
        Random random = new Random();
        int randomDragon = random.Next(0, 3);

        if (randomDragon == 0)
            _dragon = new Dragon("FrostDragon", 1, 1, 0, hero.Level);
        else if (randomDragon == 1)
            _dragon = new Dragon("FireDragon", 1, 1, 0, hero.Level);
        else if (randomDragon == 2)
            _dragon = new Dragon("PoisonDragon", 1, 1, 0, hero.Level);
    }


    
}
