using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer;
public class Color
{

    public void ColorGreen(int color)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(color);
        Console.ResetColor();
    } 
    public void ColorYellow(int color)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(color);
        Console.ResetColor();
    }
    public void ColorRed(int color)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(color);
        Console.ResetColor();
    } 

}
