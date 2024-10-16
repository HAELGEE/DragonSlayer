using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer;
public class Dragon
{
    public string Name;
    public int Strength;
    public int SpellPower;
    public int Level;
    public int PoisonTicks = 0;
    public int FireTicks = 0;

    public Dragon(string name, int strength, int spellpower, int level)
    {
        Name = name;
        Strength = strength;
        SpellPower = spellpower;
        Level = level;
    }

    public int PoisonDamage(string hero)
    {
        //Lägga in poison attack som drakar han en chans att lägga på Hero vid varje försök till attack
        // -20 för varje poison tick i Max 3 rundor
        Random random = new Random();

        if (random.Next(0, 3) == 0)
            PoisonTicks = 1;
        else if (random.Next(0, 3) == 1)
            PoisonTicks = 2;
        else if (random.Next(0,3) == 2)
            PoisonTicks = 3;

        for (int i = 0; i <= PoisonTicks; i++)
        {

        }

        return 22;
    }
}
