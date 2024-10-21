using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer;
public class Boss

{
    public static Boss DragonBoss {  get; set; }

    public Boss(string name, int strength, int spellPower, int health)
    {
        Name = name;
        Strength = strength;
        SpellPower = spellPower;
        Health = health;
        MaxHealth = health;
    }

    public string Name {  get; set; }
    public int Strength {  get; set; }
    public int SpellPower { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }

    public static void BossCreator(Hero hero)
    {
        int strength = 10;
        int spellPower = 10;
        int health = 1000;

        // Ökar statsen på bossen beroende på Hero. Börjar räkningen från att Hero är över level 1
        for (int i = 1; i < hero.Level; i++)
        {
            strength = strength + 3;
            spellPower = spellPower + 3;
            health = health + 130;
        }

        DragonBoss = new Boss("Three Headed Dragon of Doom", strength, spellPower, health);

    }
}
