using System;
using System.Threading;

namespace Pokevmon
{
    public class Pokanics
    {
        //code for receiving damage (defender, damage)
        public static void ReceiveDmg(Pokemon pokemon, int damage)
        {
            pokemon.CurrentHP -= damage;
        }
        //code for attacking (attacker, defender)
        public static void Attack(Pokemon attacker, Pokemon defender, bool IsPhysical)
        {
            int damage;
            double offset = Random(8, 13) / 10.0;
            double CritChance = Random(0, 21);
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
            ReceiveDmg(defender, damage);

            if (defender.CurrentHP < 0)
            {
                defender.CurrentHP = 0;
            }

        }
        //code for battling: two pokemons fight untill one faints
        public void Battle(Pokemon pokemon1, Pokemon pokemon2, Pokedex pokedex)
        {
            Draw draw = new Draw();
            string input = "";
            if (pokemon1.CurrentHP > 0 && pokemon2.CurrentHP > 0)
            {
                bool isCaught = false;
                bool firstTurn = true;
                int coinFlip = 0;

                //Visualize battle
                Console.Clear();
                draw.Battle(pokemon1, true);
                draw.Battle(pokemon2, false);

                //battle loop
                while (pokemon1.CurrentHP > 0 && pokemon2.CurrentHP > 0 && !isCaught)
                {
                    //code will run every 2 turns
                    if (firstTurn == true)
                    {
                        input = Console.ReadLine();
                        if (input == "catch")
                        {
                            pokedex.Catch(pokemon2);
                            isCaught = true;
                        }
                        if (!isCaught)
                        {
                            //speed will determine who will attack first: first pokemon will attack
                            if (pokemon1.Speed_Full > pokemon2.Speed_Full)
                                Attack(pokemon1, pokemon2, true);
                            //speed will determine who will attack first: second pokemon will attack
                            else if (pokemon1.Speed_Full < pokemon2.Speed_Full)
                                Attack(pokemon2, pokemon1, true);
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
                            draw.Battle(pokemon1, true);
                            draw.Battle(pokemon2, false);
                            firstTurn = false;
                            Thread.Sleep(500);
                        }

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
                    }
                }
                //result = draw
                if (isCaught)
                {
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"you succesfully caught {pokemon2.Name}!");
                    Console.SetCursorPosition(3, 13);
                    Console.Write($"{pokemon2.Name} has been added to the party");
                }
                else if (pokemon1.CurrentHP == 0 && pokemon2.CurrentHP == 0)
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
                    if (pokemon2.Level < 100)
                    {
                        Console.Write($"{pokemon1.Name} received {ReceiveExp(pokemon1, pokemon2)} Exp");
                    }
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
        //code for experience calculation (victor, loser)
        public static int ReceiveExp(Pokemon victor, Pokemon loser)
        {
            int exp = loser.Exp_Base * loser.Level;

            if (victor.Level < 100)
            {
                victor.CurrentExp += exp;
                while (victor.CurrentExp >= victor.Exp_NextLvl)
                {
                    victor.CurrentExp -= victor.Exp_NextLvl;
                    LevelUp(victor);
                }
            }
            return exp;
        }
        //code for leveling
        public static void LevelUp(Pokemon pokemon)
        {
            //up untill lvl 99, pokemon current hp will change relative to percentage
            if (pokemon.Level < 100)
                pokemon.CurrentHP = pokemon.CurrentHP / pokemon.HP_Full * ((pokemon.HP_Base + 50) * (pokemon.Level + 1) / 50 + 10);
            pokemon.Level++;
        }
        public void EatRareCandy(Pokemon pokemon)
        {
            LevelUp(pokemon);
            pokemon.CurrentExp = 0;
        }
        public void Heal(Pokemon pokemon)
        {
            pokemon.CurrentHP = pokemon.HP_Full;
        }
        public void DrinkPotion(Pokemon pokemon)
        {
            pokemon.CurrentHP += 20;
            if (pokemon.CurrentHP > pokemon.HP_Full)
                pokemon.CurrentHP = pokemon.HP_Full;
        }
        private static int Random(int x, int y)
        {
            Random random = new Random();
            return random.Next(x, y);
        }
    }
}
