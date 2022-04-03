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

        //pokedex entries
        public List<Pokemon> Caught = new();
        public List<Pokemon> Party = new()
        {
            new("Pikachu", 25, 5, 35, 90, 55, 40, 50, 50, 112, 14)
            {
                Type = new Element[] { Element.Electric, Element.None },
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" }, { @" |\__/|", @" |    |", @" |  =ϟ|" } }
            }
        };
        public List<Pokemon> Wild = new()
        {
            new("Bulbasaur", 1, 1, 45, 49, 49, 65, 65, 45, 64, 10)
            {
                Type = new Element[] { Element.Grass, Element.Poison },
                Sprite = new string[,] { { @" ,.^--^", @"( ( 0ᴗ0)", @" U-J--J" }, { @" ^--^,.", @"(0( ( ))", @" l-J--J" } }
            },
            new("Squirtle", 4, 1, 44, 48, 65, 50, 64, 43, 63, 9)
            {
                Type = new Element[] { Element.Water, Element.None },
                Sprite = new string[,] { { @"  .--.", @"@( 0ᴗ0)", @"\(/JOO)" }, { @"  .--.", @" (0___)@", @" ((###)/" } }
            },
            new("Charmander", 7, 1, 39, 52, 43, 60, 50, 65, 62, 12)
            {
                Type = new Element[] { Element.Fire, Element.None },
                Sprite = new string[,] { { @"  .--.", @"v( 0ᴗ0)", @"(/Oww\" }, { @"  .--. ", @" (0   )v", @"  /___\)" } }
            },
            new("Caterpie", 10, 1, 45, 30, 35, 20, 20, 45, 39, 10)
            {
                Type = new Element[] { Element.Bug, Element.None },
                Sprite = new string[,] { { @"  .-Y.", @",(_0o0)", @"(((::)" }, { @" .Y-.  ", @"(0_ _),", @" ( (( )" } }
            },
            new("Weedle", 13, 1, 40, 35, 30, 20, 20, 50, 39, 6)
            {
                Type = new Element[] { Element.Bug, Element.Poison },
                Sprite = new string[,] { { @"  .-^.", @",(_0O0)", @"(((::)" }, { @" .^-.  ", @"(0_ _),", @" (((( )" } }
            },
            new("Pidgey", 16, 1, 40, 45, 40, 35, 35, 56, 50, 6)
            {
                Type = new Element[] { Element.Normal, Element.Flying },
                Sprite = new string[,] { { @"  ___", @" / 0▽0", @"|/_Y_Y\" }, { @"   ___", @"  /   \", @" /__/|_\" } }
            },
            new("Pikachu", 25, 1, 35, 55, 40, 50, 50, 90, 112, 14)
            {
                Type = new Element[] { Element.Electric, Element.None },
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" }, { @" |\__/|", @" |    |", @" |  =ϟ|" } }
            },
            new("Diglett", 50, 1, 10, 55, 25, 35, 45, 95, 53, 6)
            {
                Type = new Element[] { Element.Ground, Element.None },
                Sprite = new string[,] { { @"  ___", @" / 0o0\", @"|_._._|" }, { @"   ___", @"  /0   \", @"  |_._._|" } }
            },
            new("Mankey", 56, 1, 40, 80, 35, 35, 45, 70, 61, 7)
            {
                Type = new Element[] { Element.Fighting, Element.None },
                Sprite = new string[,] { { @" ▽^^^▽", @"<O 0⚇0>", @" O^-^O" }, { @"  ▽^^^▽", @" <0    >", @"  O^-^O" } }
            },
            new("Mew", 151, 1, 100, 100, 100, 100, 100, 100, 270, 13)
            {
                Type = new Element[] { Element.Psychic, Element.None },
                Sprite = new string[,] { { @"  ^--^", @"ʔ( 0⌒0)", @"╰(OJJO" }, { @" ^--^", @"(0  _)ʔ", @" /__\ノ" } }
            }
        };

        //local pokemon groups
        public List<Pokemon> route101 = new()
        {
            new("Pidgey", 16, 1, 40, 45, 40, 35, 35, 56, 50, 6)
            {
                Type = new Element[] { Element.Normal, Element.Flying },
                Sprite = new string[,] { { @"  ___", @" / 0▽0", @"|/_Y_Y\" }, { @"   ___", @"  /   \", @" /__/|_\" } }
            },
            new("Mankey", 56, 1, 40, 80, 35, 35, 45, 70, 61, 7)
            {
                Type = new Element[] { Element.Fighting, Element.None },
                Sprite = new string[,] { { @" ▽^^^▽", @"<O 0⚇0>", @" O^-^O" }, { @"  ▽^^^▽", @" <0    >", @"  O^-^O" } }
            },
            new("Squirtle", 4, 1, 44, 48, 65, 50, 64, 43, 63, 9)
            {
                Type = new Element[] { Element.Water, Element.None },
                Sprite = new string[,] { { @"  .--.", @"@( 0ᴗ0)", @"\(/JOO)" }, { @"  .--.", @" (0___)@", @" ((###)/" } }
            },
        };
        public List<Pokemon> viridianforest = new()
        {
            new("Caterpie", 10, 1, 45, 30, 35, 20, 20, 45, 39, 10)
            {
                Type = new Element[] { Element.Bug, Element.None },
                Sprite = new string[,] { { @"  .-Y.", @",(_OoO)", @"(((::)" }, { @" .Y-.  ", @"(O_ _),", @" ( (( )" } }
            },
            new("Weedle", 13, 1, 40, 35, 30, 20, 20, 50, 39, 6)
            {
                Type = new Element[] { Element.Bug, Element.Poison },
                Sprite = new string[,] { { @"  .-^.", @",(_0O0)", @"(((::)" }, { @" .^-.  ", @"(0_ _),", @" (((( )" } }
            },
            new("Pikachu", 25, 1, 35, 55, 40, 50, 50, 90, 112, 14)
            {
                Type = new Element[] { Element.Electric, Element.None },
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" }, { @" |\__/|", @" |    |", @" |  =ϟ|" } }
            },
            new("Bulbasaur", 1, 1, 45, 49, 49, 65, 65, 45, 64, 10)
            {
                Type = new Element[] { Element.Grass, Element.Poison },
                Sprite = new string[,] { { @" ,.^--^", @"( ( 0ᴗ0)", @" U-J--J" }, { @" ^--^,.", @"(0( ( ))", @" l-J--J" } }
            },
        };
        public List<Pokemon> digletttunel = new()
        {
            new("Diglett", 50, 1, 10, 55, 25, 35, 45, 95, 53, 6)
            {
                Type = new Element[] { Element.Ground, Element.None },
                Sprite = new string[,] { { @"  ___", @" / 0o0\", @"|_._._|" }, { @"   ___", @"  /0   \", @"  |_._._|" } }
            },
            new("Charmander", 7, 1, 39, 52, 43, 60, 50, 65, 62, 12)
            {
                Type = new Element[] { Element.Fire, Element.None },
                Sprite = new string[,] { { @"  .--.", @"v( 0ᴗ0)", @"(/Oww\" }, { @"  .--. ", @" (0   )v", @"  /___\)" } }
            },
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