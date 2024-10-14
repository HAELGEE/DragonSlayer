using System;
using System.Collections.Generic;
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

    public Dragon(string name, int strength, int spellpower, int level)
    {
        Name = name;
        Strength = strength;
        SpellPower = spellpower;
        Level = level;
    }
}
