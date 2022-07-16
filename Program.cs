using System;
using System.Collections.Generic;

namespace Pokevmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Pokanics.Heal(Pokedex.Party);

            //-------------GAME-LOOP-------------//
            while (input != "exit" && input != "q")
            {
                //draw menu and returns input
                input = Draw.Menu("SELECTION SCREEN\n1.pokemon\n2.pokebox\n3.pokedex\n4.pokebag\n5.pokecenter\n6.route 101\n7.viridian forest\n8.diglett tunnel\nq.exit");
                switch (input)
                {
                    case "1":
                    case "pokemon":
                        input = Draw.ScrollMenu(input, Pokedex.Party, true);
                        break;//show pokemon party
                    case "2":
                    case "pokebox":
                        input = Draw.ScrollMenu(input, Pokedex.Caught, true);
                        break;//show pokemon storage
                    case "3":
                    case "pokedex":
                        input = Draw.ScrollMenu(input, Pokedex.Wild, false);
                        break;//show all pokemon available in the program
                    case "4":
                    case "pokebag":
                        input = Draw.Menu("ERROR: looks like this part hasn't been coded yet!");
                        break;//show items (not coded yet)
                    case "5":
                    case "pokecenter":
                        Pokanics.Pokecenter(Pokedex.Party);
                        break;//go to the pokemoncenter to heal your pokemon
                    case "6":
                    case "route101":
                    case "route 101":
                        Pokanics.Encounter(2, 5, Pokedex.route101);
                        break;//battle random pokemon with random levels between 1 and 5
                    case "7":
                    case "viridianforest":
                    case "viridian forest":
                        Pokanics.Encounter(5, 10, Pokedex.viridianforest);
                        break;//battle random pokemon with random levels between 5 and 10
                    case "8":
                    case "digletttunnel":
                    case "diglett tunnel":
                        Pokanics.Encounter(10, 20, Pokedex.digletttunel);
                        break;//battle random pokemon with random levels between 10 and 20
                }
            }
        }
    }
}
//VERSION 1.0 (creation)
//menu loop added
//pokemon class with stats and UI possibilities
//pokedex (list of all pokemon)
//battle and healing system
//level and exp system

//VERSION 1.1 (fixes)
//seperate class for drawing UI
//merged attack and sp.attack method
//merged front and back sprite method
//pokedex now shows basestats instead of fullstats
//average basestats problem resolved
//reworked constructors

//VERSION 1.2 (fixes)
//pokemon can't reach higher levels than 100
//pokemon can't receive exp anymore after lvl100
//pokemon will keep their hp percentage upon leveling
//pokedex now uses pages to navigate
//improved experience formula for leveling

//VERSION 2 (catch em all)
//ability to catch pokemon :)
//wild and caught pokemon are stored in a seperate class (Pokedex)
//mechanics like receivedmg, healing, lvling... are now stored in a seperate class (Pokanics)
//pokedex now scrolls in segments (combined pages and scrolling)

//VERSION 2.1 (fixes)
//pokecenter now heals all your pokemons instead of just one
//implemented a chance formula for catching pokemon
//party and storage for pokemon are now seperate
//added a menu and scrollmenu method to reduce code

//VERSION 2.2 (fixes)
//you can now swap pokemons in party and storage
//the whole party can battle now, when pokemons faint, next in party will continue battling, you can swap pokemons mid-battle

//VERSION 2.3 (fixes)
//reworked main program from if/else if-statements to switch with cases
//added more Pokemon (10 in total now)

//VERSION 2.4 (fixes)
//pokanics and draw classes are now completely static

//TO DO'S
//different moves (physical/special) -> class
//move versus type effectiveness -> give pokemons arrays for types and moves
//natures
//evolution

/*
        else if (input == "heal" || input == "1")
        pokanics.DrinkPotion(pokedex.Party[0]);

    else if (input == "rest" || input == "2")
        pokanics.Heal(pokedex.Party[0]);

    else if (input == "level" || input == "3")
        pokanics.EatRareCandy(pokedex.Party[0]);
*/
//how to get items? find/buy? -> pokemart + money system, then again how to get money? trainers?

//made by Krupuk