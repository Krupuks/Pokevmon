using System;
using System.Threading;

namespace Pokevmon
{
    class Program
    {
        static void Main(string[] args)
        {
            Draw draw = new Draw();
            /*
            0:Black     1:DarkBlue      2:DarkGreen     3:DarkCyan
            4:DarkRed   5:DarkMagenta   6:DarkYellow    7:Gray
            8:DarkGray  9:Blue          10:Green        11:Cyan
            12:Red      13:Magenta      14:Yellow       15:White
            */

            //wild pokémons
            Pokemon pidgey = new("Pidgey", "Nrm/Fly", 16, 5, 40, 56, 45, 40, 35, 35, 50, 6)
            {
                Sprite = new string[/*front*/,/*back*/] { { @"  ___", @" / 0▽0", @"|/_v_v\" }, { @"  ___", @" /    \", @"/  /| \" } }
            };
            Pokemon pikachu = new("Pikachu", "Electric", 25, 5, 35, 90, 55, 40, 50, 50, 112, 14)
            {
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" }, { @" |\__/|", @" |    |", @" |  ϟ |" } }
            };
            Pokemon diglett = new("Diglett", "Ground", 50, 5, 10, 95, 55, 25, 35, 45, 53, 6)
            {
                Sprite = new string[,] { { @"  ___", @" / 0o0\", @"|_._._|" }, { @"  ___", @" /    \", @"|_._._|" } }
            };
            Pokemon mankey = new("Mankey", "Fighting", 56, 5, 40, 70, 80, 35, 35, 45, 61, 7)
            {
                Sprite = new string[,] { { @" ▽^^^▽", @"<o 0⚇0>", @" O^-^O" },{ @" ▽^^^▽", @"<     >", @" -^-^-" } }
            };

            //my pokémon
            Pokemon myPikachu = new("Pikachu ◓", "Electric", 25, 5, 35, 90, 55, 40, 50, 50, 112, 14)
            {
                Sprite = new string[,] { { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" },{ @" |\__/|", @" |    |", @" |  ϟ |" } }
            };

            myPikachu.Heal();

            //game loop
            string input = "";
            while (input != "exit" && input != "5")
            {
                Console.WriteLine("SELECTION SCREEN\n1.pokemon\n2.pokedex\n3.pokecenter\n4.battle\n5.exit");
                input = Console.ReadLine();
                Console.Clear();

                //show pokemon party
                if (input == "pokemon" || input == "1")
                {
                    while (input != "exit" && input != "2")
                    {
                        draw.Stats(myPikachu,0);

                        Console.WriteLine("SELECTION SCREEN\n1.heal(Full Restore)\n2.exit");

                        input = Console.ReadLine();
                        Console.Clear();
                        if (input == "heal" || input == "1")
                            myPikachu.Heal();
                        /*if (input == "")
                            myPikachu.LevelUp();*/
                    }
                    input = "";
                }
                //show all pokemon available in the program
                else if (input == "pokedex" || input == "2")
                {
                    while (input != "exit" && input != "1")
                    {
                        draw.Dex(pidgey, 0);
                        draw.Dex(pikachu, 1);
                        draw.Dex(diglett, 2);
                        //draw.Dex(mankey, 3);

                        Console.WriteLine("SELECTION SCREEN\n1.exit");

                        input = Console.ReadLine();
                        Console.Clear();
                    }
                    input = "";
                }
                //go to the pokemoncenter to heal your pokemon
                else if (input == "pokecenter" || input == "3")
                {
                    myPikachu.Heal();
                    Console.WriteLine("Nurse Joy: your pokemon have been fully restored!");
                    Console.ReadLine();
                    Console.Clear();
                }
                //battle random pokemon with random levels between 1 and 5
                else if (input == "battle" || input == "4")
                {
                    int randomLvl = Random(2, 6);
                    int randomPk = Random(1, 5);
                    switch (randomPk)
                    {
                        case 1:
                            diglett.Level = randomLvl;
                            diglett.Heal();
                            Battle(draw, myPikachu, diglett);
                            break;
                        case 2:
                            pidgey.Level = randomLvl;
                            pidgey.Heal();
                            Battle(draw, myPikachu, pidgey);
                            break;
                        case 3:
                            mankey.Level = randomLvl;
                            mankey.Heal();
                            Battle(draw, myPikachu, mankey);
                            break;
                        case 4:
                            pikachu.Level = randomLvl;
                            pikachu.Heal();
                            Battle(draw, myPikachu, pikachu);
                            break;
                    }
                }
            }
        }

        //code for battling: two pokemons fight untill one faints
        static void Battle(Draw draw, Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1.CurrentHP > 0 && pokemon2.CurrentHP > 0)
            {
                bool firstTurn = true;
                int coinFlip = 0;

                //Visualize battle
                Console.Clear();
                draw.Battle(pokemon1,true);
                draw.Battle(pokemon2,false);
                Console.ReadLine();

                //battle loop
                while (pokemon1.CurrentHP > 0 && pokemon2.CurrentHP > 0)
                {
                    //code will run every 2 turns
                    if (firstTurn == true)
                    {   //speed will determine who will attack first: first pokemon will attack
                        if (pokemon1.Speed_Full > pokemon2.Speed_Full)
                            Attack(pokemon1, pokemon2, true);
                        //speed will determine who will attack first: second pokemon will attack
                        else if (pokemon1.Speed_Full < pokemon2.Speed_Full)
                            Attack(pokemon2, pokemon1, true );
                        // if speed is equal, do a coinflip
                        else
                        {
                            coinFlip = Random(0, 2);
                            if (coinFlip == 0)
                                Attack(pokemon1, pokemon2, true);
                            else if (coinFlip == 1)
                                Attack(pokemon2, pokemon1, true);
                        }
                        Console.Clear();
                        draw.Battle(pokemon1,true);
                        draw.Battle(pokemon2,false);
                        firstTurn = false;
                        Thread.Sleep(500);
                    }
                    //code will run every 2 turns, check if pokemon have fainted yet: if they did, code won't continue
                    else if (firstTurn == false && pokemon1.CurrentHP > 0 && pokemon2.CurrentHP > 0)
                    {
                        //because pokemon1 started in the first turn, pokemon2 will attack
                        if (pokemon1.Speed_Full > pokemon2.Speed_Full)
                            Attack(pokemon2, pokemon1, true);

                        //because pokemon2 started in the first turn, pokemon1 will attack
                        else if (pokemon1.Speed_Full < pokemon2.Speed_Full)
                            Attack(pokemon1, pokemon2, true);
                        //in the second turn, the other pokemon will attack
                        else
                        {
                            if (coinFlip == 0)
                                Attack(pokemon2, pokemon1, true);
                            else if (coinFlip == 1)
                                Attack(pokemon1, pokemon2, true);
                        }
                        //Visualize battle
                        Console.Clear();
                        draw.Battle(pokemon1, true);
                        draw.Battle(pokemon2, false);
                        firstTurn = true;
                        Console.ReadLine();
                    }
                }
                //result = draw
                if (pokemon1.CurrentHP == 0 && pokemon2.CurrentHP == 0)
                {
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"both {pokemon1.Name} and {pokemon2.Name} have fainted");
                    Console.SetCursorPosition(3, 13);
                    Console.Write("THE BATTLE ENDED WITH A DRAW");
                }
                //result = lose
                else if (pokemon1.CurrentHP == 0)
                {
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"{pokemon1.Name} has fainted");
                    Console.SetCursorPosition(3, 13);
                    Console.Write("YOU LOST THE BATTLE");
                }
                //result = win
                else
                {
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"{pokemon2.Name} has fainted");
                    Console.SetCursorPosition(3, 13);
                    Console.Write("YOU WON THE BATTLE");
                    Console.ReadLine();
                    Console.SetCursorPosition(3, 14);
                    Console.Write($"{pokemon1.Name} received {ReceiveExp(pokemon1, pokemon2)} Exp");
                }
                Console.ReadLine();
                Console.Clear();
            }
            // if your pokemons are low, don't start a battle
            else
            {
                Console.WriteLine("Your Pokemon(s) are unable to battle!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        //code for attacking (attacker, defender)
        private static void Attack(Pokemon attacker, Pokemon defender, bool IsPhysical)
        {
            int damage;
            double offset = Random(8, 13) / 10.0;
            double CritChance = Random(0,21);
            int critHit = 1;
            if (CritChance == 20)
            {
                critHit = 2;
            } 
            if (IsPhysical)
                //code for physical attacks
                damage = (int)(2 * offset * critHit * (attacker.Attack_Full / defender.Defense_Full) + 2);
            else
                //code for special attacks
                damage = (int)(2 * offset * critHit * (attacker.SpAttack_Full / defender.SpDefense_Full) + 2);
            defender.ReceiveDmg(damage);

            if (defender.CurrentHP < 0)
            {
                defender.CurrentHP = 0;
            }

        }

        //code for experience calculation (victor, loser)
        private static int ReceiveExp(Pokemon victor, Pokemon loser)
        {
            int exp = loser.Exp_Base * loser.Level;
            victor.ReceiveExp(exp);
            return exp;
        }
        //integer randomizer 
        private static int Random(int x, int y)
        {
            Random random = new Random();
            return random.Next(x, y);
        }
    }
}

//merged attack and sp.attack method
//merged front and back method
//pokedex now show basestats
//average basestats problem is resolved
//reworked constructors
//created seperate class for drawing