using System;
using System.Threading;

namespace Pokevmon
{
    class Program
    {
        static void Main(string[] args)
        {
            Draw draw = new Draw();
            Pokedex pokedex = new Pokedex();
            Pokanics pokanics = new Pokanics();
            string input = "";
            int pageDex = 0;
            int pageParty = 0;
            int WildLvlMin = 2;
            int WildLvlMax = 6;

            //pokedex.caught[0] == pikachu
            pokanics.Heal(pokedex.Caught[0]);

            //-------------GAME-LOOP-------------//
            while (input != "exit" && input != "5")
            {
                Console.WriteLine("SELECTION SCREEN\n1.pokemon\n2.pokedex\n3.pokecenter\n4.battle\n5.exit");
                input = Console.ReadLine();
                Console.Clear();

                //show pokemon party
                if (input == "pokemon" || input == "1")
                {
                    while (input != "exit" && input != "6")
                    {
                        if (pageParty == pokedex.Caught.Count - 2)
                            pageParty--;
                        else if (pageParty == -1)
                            pageParty++;

                        int j = 0;
                        for (int i = pageParty; i < pageParty + 3 && i < pokedex.Caught.Count ; i++)
                        {
                            draw.Stats(pokedex.Caught[i], j);
                            j++;
                        }

                        Console.WriteLine("SELECTION SCREEN\n1.scroll up\n2.scroll down\n3.heal(Potion)\n4.rest(Full Restore)\n5.level(Rare Candy)\n6.exit");
                        input = Console.ReadLine();

                        if (input == "previous" || input == "1")
                        {
                            pageParty--;
                        }
                        else if (input == "next" || input == "2")
                        {
                            pageParty++;
                        }
                        Console.Clear();

                        if (input == "heal" || input == "3")
                            pokanics.DrinkPotion(pokedex.Caught[0]);


                        if (input == "rest" || input == "4")
                            pokanics.Heal(pokedex.Caught[0]);

                        if (input == "level" || input == "5")
                            pokanics.EatRareCandy(pokedex.Caught[0]);
                        Console.Clear();
                    }
                }
                //show all pokemon available in the program
                else if (input == "pokedex" || input == "2")
                {
                    while (input != "exit" && input != "3")
                    {
                        if (pageDex == pokedex.Wild.Count - 2)
                            pageDex--;
                        else if (pageDex == -1)
                            pageDex++;

                        int j = 0;
                        for (int i = pageDex; i < pageDex + 3; i++)
                        {
                            draw.DexStats(pokedex.Wild[i], j);
                            j++;
                        }

                        Console.WriteLine("SELECTION SCREEN\n1.scroll up\n2.scroll down\n3.exit");

                        input = Console.ReadLine();
                        if (input == "previous" || input == "1")
                        {
                            pageDex--;
                        }
                        else if (input == "next" || input == "2")
                        {
                            pageDex++;
                        }
                        Console.Clear();
                    }
                }
                //go to the pokemoncenter to heal your pokemon
                else if (input == "pokecenter" || input == "3")
                {
                    pokanics.Heal(pokedex.Caught[0]);
                    Console.WriteLine("Nurse Joy: your pokemon have been fully restored!");
                    Console.ReadLine();
                    Console.Clear();
                }
                //battle random pokemon with random levels between 1 and 5
                else if (input == "battle" || input == "4")
                {
                    int randomLvl = Random(WildLvlMin, WildLvlMax);
                    int randomPk = Random(0, pokedex.Wild.Count);

                    pokedex.Wild[randomPk].Level = randomLvl;
                    pokanics.Heal(pokedex.Wild[randomPk]);
                    pokanics.Battle(pokedex.Caught[0], pokedex.Wild[randomPk], pokedex);
                }
            }
        }
        //integer randomizer 
        private static int Random(int x, int y)
        {
            Random random = new Random();
            return random.Next(x, y);
        }
    }
}
//VERSION 1.0 (creation)
//menu loop
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

//TO DO'S
//different moves (physical/special) -> class
//move versus type effectiveness -> give pokemons arrays for type and moves aswell
//natures
//evolution

