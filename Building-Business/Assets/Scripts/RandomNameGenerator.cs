using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomNameGenerator
{
    private static Random random = new Random();
    private static List<string> names = new List<string> 
    {
        "Bob",
        "Lex",
        "Feli",
        "Brean",
        "Frallan",
        "Max",
        "Mini"
    };
    public static string GenerateRandomName()
    {
        return names[random.Next(0,names.Count - 1)];
    }
}

