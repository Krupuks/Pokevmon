using System;
using System.Collections.Generic;

namespace Pokevmon
{
    public class Pokedex
    {
        /*
            0:Black     1:DarkBlue      2:DarkGreen     3:DarkCyan
            4:DarkRed   5:DarkMagenta   6:DarkYellow    7:Gray
            8:DarkGray  9:Blue          10:Green        11:Cyan
            12:Red      13:Magenta      14:Yellow       15:White
         */
        public List<Pokemon> Caught = new();
        public List<Pokemon> Party = new()
        {
            new("Pikachu", 25, 5, 35, 90, 55, 40, 50, 50, 112, 14)
            {
                Type = new Element[] { Element.Electric, Element.None },
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" }, { @" |\__/|", @" |    |", @" |  ϟ |" } }
            }
        };
        public List<Pokemon> Wild = new()
        {
            new("Pidgey", 16, 1, 40, 45, 40, 35, 35, 56, 50, 6)
            {
                Type = new Element[] { Element.Normal, Element.Flying },
                Sprite = new string[,] { { @"  ___", @" / 0▽0", @"|/_v_v\" }, { @"  ___", @" /    \", @"/  /| \" } }
            },
            new("Pikachu", 25, 1, 35, 55, 40, 50, 50, 90, 112, 14)
            {
                Type = new Element[] { Element.Electric, Element.None },
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" }, { @" |\__/|", @" |    |", @" |  ϟ |" } }
            },
            new("Diglett", 50, 1, 10, 55, 25, 35, 45, 95, 53, 6)
            {
                Type = new Element[] { Element.Ground, Element.None },
                Sprite = new string[,] { { @"  ___", @" / 0o0\", @"|_._._|" }, { @"  ___", @" /    \", @"|_._._|" } }
            },
            new("Mankey", 56, 1, 40, 80, 35, 35, 45, 70, 61, 7)
            {
                Type = new Element[] { Element.Fighting, Element.None },
                Sprite = new string[,] { { @" ▽^^^▽", @"<o 0⚇0>", @" O^-^O" }, { @" ▽^^^▽", @"<     >", @" -^-^-" } }
            }
        };

        //catch pokemon
        public bool Catch(Pokemon pokemon)
        {
            int catchRateReduction = (int)((10 * pokemon.HP_Full - pokemon.CurrentHP) * 100 / (10 * pokemon.HP_Full));
            if (Random(1, 101 - catchRateReduction) == 100 - catchRateReduction)
            {
                if (Party.Count < 6)
                    Party.Add(pokemon.Clone());
                else
                    Caught.Add(pokemon.Clone());
                return true;
            }
            return false;
        }
        //integer randomizer 
        private static int Random(int x, int y)
        {
            Random random = new Random();
            return random.Next(x, y);
        }
    }
}