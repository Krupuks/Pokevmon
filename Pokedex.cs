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

        public List<Pokemon> Wild = new()
        {
            new("Pidgey", "Nrm/Fly", 16, 1, 40, 56, 45, 40, 35, 35, 50, 6)
            {
                Sprite = new string[,] { { @"  ___", @" / 0▽0", @"|/_v_v\" }, { @"  ___", @" /    \", @"/  /| \" } }
            },
            new("Pikachu", "Electric", 25, 1, 35, 90, 55, 40, 50, 50, 112, 14)
            {
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" }, { @" |\__/|", @" |    |", @" |  ϟ |" } }
            },
            new("Diglett", "Ground", 50, 1, 10, 95, 55, 25, 35, 45, 53, 6)
            {
                Sprite = new string[,] { { @"  ___", @" / 0o0\", @"|_._._|" }, { @"  ___", @" /    \", @"|_._._|" } }
            },
            new("Mankey", "Fighting", 56, 1, 40, 70, 80, 35, 35, 45, 61, 7)
            {
                Sprite = new string[,] { { @" ▽^^^▽", @"<o 0⚇0>", @" O^-^O" }, { @" ▽^^^▽", @"<     >", @" -^-^-" } }
            }
        };

        public List<Pokemon> Caught = new()
        {
            new("Pikachu ◓", "Electric", 25, 5, 35, 90, 55, 40, 50, 50, 112, 14)
            {
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" }, { @" |\__/|", @" |    |", @" |  ϟ |" } }
            }
        };

        public bool Catch(Pokemon pokemon)
        {
            Caught.Add(pokemon.Clone());
            return true;
        }
    }
}