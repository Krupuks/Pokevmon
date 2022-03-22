using System;

namespace Pokevmon
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            0:Black     1:DarkBlue      2:DarkGreen     3:DarkCyan
            4:DarkRed   5:DarkMagenta   6:DarkYellow    7:Gray
            8:DarkGray  9:Blue          10:Green        11:Cyan
            12:Red      13:Magenta      14:Yellow       15:White
            */

            //wild pokémons
            Pokemon pidgey = new("Pidgey", "Nrm/Fly", 16, 5, 40, 56, 45, 40, 35, 35, 50, 6)
            {
                FrontSprite = new string[] { @"  ___", @" / 0▽0", @"|/_v_v\" },
                BackSprite = new string[] { @"  ___", @" /    \", @"/  /| \" }
            };
            Pokemon pikachu = new("Pikachu", "Electric", 25, 5, 35, 90, 55, 40, 50, 50, 112, 14)
            {
                FrontSprite = new string[] { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" },
                BackSprite = new string[] { @" |\__/|", @" |    |", @" |  ϟ |" }
            };
            Pokemon diglett = new("Diglett", "Ground", 50, 5, 10, 95, 55, 25, 35, 45, 53, 6)
            {
                FrontSprite = new string[] { @"  ___", @" / 0o0\", @"|_._._|" },
                BackSprite = new string[] { @"  ___", @" /    \", @"|_._._|" }
            };
            Pokemon mankey = new("Mankey", "Fighting", 56, 5, 40, 70, 80, 35, 35, 45, 61, 7)
            {
                FrontSprite = new string[] { @" ▽^^^▽", @"<o 0⚇0>", @" O^-^O" },
                BackSprite = new string[] { @" ▽^^^▽", @"<     >", @" -^-^-" }
            };

            //my pokémon
            Pokemon myPikachu = new("Pikachu ◓", "Electric", 25, 5, 35, 90, 55, 40, 50, 50, 112, 14)
            {
                FrontSprite = new string[] { @" |\__/|", @" |๑0ᴥ0|", @"ϟ|JO_O|" },
                BackSprite = new string[] { @" |\__/|", @" |    |", @" |  ϟ |" }
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
                        myPikachu.DrawStats(0);

                        Console.WriteLine("SELECTION SCREEN\n1.heal(Full Restore)\n2.exit");

                        input = Console.ReadLine();
                        Console.Clear();
                        if (input == "heal" || input == "1")
                            myPikachu.Heal();
                    }
                    input = "";
                }
                //show all pokemon available in the program
                else if (input == "pokedex" || input == "2")
                {
                    while (input != "exit" && input != "1")
                    {
                        pidgey.DrawDex(0);
                        pikachu.DrawDex(1);
                        diglett.DrawDex(2);
                        //mankey.DrawDex(3);

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
                    Console.WriteLine("Nurse Joy: you're pokemon have been fully restored!");
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
                            Battle(myPikachu, diglett);
                            break;
                        case 2:
                            pidgey.Level = randomLvl;
                            pidgey.Heal();
                            Battle(myPikachu, pidgey);
                            break;
                        case 3:
                            mankey.Level = randomLvl;
                            mankey.Heal();
                            Battle(myPikachu, mankey);
                            break;
                        case 4:
                            pikachu.Level = randomLvl;
                            pikachu.Heal();
                            Battle(myPikachu, pikachu);
                            break;
                    }
                }
            }
        }

        //code for battling: two pokemons fight untill one faints
        static void Battle(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1.CurrentHP > 0 && pokemon2.CurrentHP > 0)
            {
                bool firstTurn = true;
                int coinFlip = 0;

                //Visualize battle
                Console.Clear();
                pokemon1.DrawBattle(true);
                pokemon2.DrawBattle(false);
                Console.ReadLine();

                //battle loop
                while (pokemon1.CurrentHP > 0 && pokemon2.CurrentHP > 0)
                {
                    //code will run every 2 turns
                    if (firstTurn == true)
                    {   //speed will determine who will attack first: first pokemon will attack
                        if (pokemon1.Speed_Full > pokemon2.Speed_Full)
                            Attack(pokemon1, pokemon2);
                        ////speed will determine who will attack first: second pokemon will attack
                        else if (pokemon1.Speed_Full < pokemon2.Speed_Full)
                            Attack(pokemon2, pokemon1);
                        // if speed is equal, do a coinflip
                        else
                        {
                            coinFlip = Random(0, 2);
                            if (coinFlip == 0)
                                Attack(pokemon1, pokemon2);
                            else if (coinFlip == 1)
                                Attack(pokemon2, pokemon1);
                        }
                        Console.Clear();
                        pokemon1.DrawBattle(true);
                        pokemon2.DrawBattle(false);
                        firstTurn = false;
                        Console.ReadLine();
                    }
                    //code will run every 2 turns, check if pokemon have fainted yet: if they did, code won't continue
                    else if (firstTurn == false && pokemon1.CurrentHP > 0 && pokemon2.CurrentHP > 0)
                    {
                        //because pokemon1 started in the first turn, pokemon2 will attack
                        if (pokemon1.Speed_Full > pokemon2.Speed_Full)
                            Attack(pokemon2, pokemon1);

                        //because pokemon2 started in the first turn, pokemon1 will attack
                        else if (pokemon1.Speed_Full < pokemon2.Speed_Full)
                            Attack(pokemon1, pokemon2);
                        //in the second turn, the other pokemon will attack
                        else
                        {
                            if (coinFlip == 0)
                                Attack(pokemon2, pokemon1);
                            else if (coinFlip == 1)
                                Attack(pokemon1, pokemon2);
                        }
                        //Visualize battle
                        Console.Clear();
                        pokemon1.DrawBattle(true);
                        pokemon2.DrawBattle(false);
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
            // if your pokemons are low, don't start battle
            else
            {
                Console.WriteLine("Your Pokemon(s) are unable to battle!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //code for special attacks (sp.attack, sp.defense) NOT USED (implement different kind of attacks?)
        private static void SpAttack(Pokemon pokemon1, Pokemon pokemon2)
        {
            int damage = Random(1, 3) * 2 * (pokemon1.SpAttack_Full / pokemon2.SpDefense_Full) + 2;
            pokemon2.ReceiveDmg(damage);
            if (pokemon2.CurrentHP < 0)
            {
                pokemon2.CurrentHP = 0;
            }

        }

        //code for physical attacks (attack, defense)
        private static void Attack(Pokemon pokemon1, Pokemon pokemon2)
        {
            int damage = Random(1, 3) * 2 * (pokemon1.Attack_Full / pokemon2.Defense_Full) + 2;
            pokemon2.ReceiveDmg(damage);
            if (pokemon2.CurrentHP < 0)
            {
                pokemon2.CurrentHP = 0;
            }
        }
        //code for experience calculation (victor, defeated)
        private static int ReceiveExp(Pokemon pokemon1, Pokemon pokemon2)
        {
            int exp = pokemon2.Exp_Base * pokemon2.Level;
            pokemon1.ReceiveExp(exp);
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