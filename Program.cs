using System;
using System.Collections.Generic;

namespace Pokevmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Draw draw = new Draw();
            Pokedex pokedex = new Pokedex();
            Pokanics pokanics = new Pokanics();
            List<Pokemon> Party = pokedex.Party;
            List<Pokemon> Caught = pokedex.Caught;
            List<Pokemon> Wild = pokedex.Wild;
            List<Pokemon> route101 = pokedex.route101;
            List<Pokemon> viridianforest = pokedex.viridianforest;
            List<Pokemon> digletttunel = pokedex.digletttunel;
            pokanics.HealAll(Party);

            //-------------GAME-LOOP-------------//
            while (input != "exit" && input != "q")
            {
                //draw menu and returns input
                input = draw.Menu("SELECTION SCREEN\n1.pokemon\n2.pokebox\n3.pokedex\n4.pokebag\n5.pokecenter\n6.battle\nq.exit");
                switch (input)
                {
                    case "1":
                    case "pokemon":
                        input = draw.ScrollMenu(input, Party, true);
                        break;//show pokemon party
                    case "2":
                    case "pokebox":
                        input = draw.ScrollMenu(input, Caught, false);
                        break;//show pokemon storage
                    case "3":
                    case "pokedex":
                        input = draw.ScrollMenu(input, Wild, false);
                        break;//show all pokemon available in the program
                    case "4":
                    case "pokebag":
                        input = draw.Menu("ERROR: looks like this part hasn't been coded yet!");
                        break;//show items (not coded yet)
                    case "5":
                    case "pokecenter":
                        pokanics.Pokecenter(Party);
                        break;//go to the pokemoncenter to heal your pokemon
                    case "6":
                    case "route101":
                        pokanics.Encounter(2, 5, route101, pokedex);
                        break;//battle random pokemon with random levels between 1 and 5
                    case "7":
                    case "viridianforest":
                    case "viridian forest":
                        pokanics.Encounter(5, 10, viridianforest, pokedex);
                        break;//battle random pokemon with random levels between 5 and 10
                    case "8":
                    case "digletttunnel":
                    case "diglett tunnel":
                        pokanics.Encounter(10, 20, digletttunel, pokedex);
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
//added more Pokemon (10 in total)

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