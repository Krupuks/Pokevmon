using System;
using System.Collections.Generic;
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
                critHit = 2;
            if (IsPhysical)
                //code for physical attacks
                damage = (int)(2 * offset * critHit * (attacker.Attack_Full / defender.Defense_Full) + 2);
            else
                //code for special attacks
                damage = (int)(2 * offset * critHit * (attacker.SpAttack_Full / defender.SpDefense_Full) + 2);
            ReceiveDmg(defender, damage);
            if (defender.CurrentHP < 1)
                defender.CurrentHP = 0;
        }
        //code for battling: two pokemons fight untill one faints
        public void Battle(Pokemon myPokemon, Pokemon wildPokemon, Pokedex pokedex)
        {
            Draw draw = new Draw();
            string input;
            if (myPokemon.CurrentHP > 0 && wildPokemon.CurrentHP > 0)
            {
                bool isCaught = false;
                bool fled = false;
                bool firstTurn = true;
                int coinFlip = 0;

                //Visualize battle
                Console.Clear();
                draw.Battle(myPokemon, wildPokemon);

                //battle loop
                while (myPokemon.CurrentHP > 0 && wildPokemon.CurrentHP > 0 && !isCaught && !fled)
                {
                    //code will run every 2 turns
                    if (firstTurn == true)
                    {
                        input = Console.ReadLine();
                        if (input == "fight" || input == "FIGHT")
                        {
                            //speed will determine who will attack first: first pokemon will attack
                            if (myPokemon.Speed_Full > wildPokemon.Speed_Full)
                                Attack(myPokemon, wildPokemon, true);
                            //speed will determine who will attack first: second pokemon will attack
                            else if (myPokemon.Speed_Full < wildPokemon.Speed_Full)
                                Attack(wildPokemon, myPokemon, true);
                            // if speed is equal, do a coinflip
                            else
                            {
                                coinFlip = Random(0, 2);
                                if (coinFlip == 0)
                                    Attack(myPokemon, wildPokemon, true);
                                else if (coinFlip == 1)
                                    Attack(wildPokemon, myPokemon, true);
                            }
                            Console.Clear();
                            draw.Battle(myPokemon, wildPokemon);
                            firstTurn = false;
                            Thread.Sleep(500);
                        }
                        else if (input == "catch" || input == "CATCH")
                        {
                            isCaught = pokedex.Catch(wildPokemon);

                            if (!isCaught)
                            {
                                Console.SetCursorPosition(3, 12);
                                Console.Write($"{wildPokemon.Name} broke free!    ");
                                Console.ReadLine();
                                Console.Clear();
                                draw.Battle(myPokemon, wildPokemon);
                                Thread.Sleep(500);
                                Attack(wildPokemon, myPokemon, true);
                                Console.Clear();
                                draw.Battle(myPokemon, wildPokemon);
                            }
                            else if (isCaught)
                            {
                                wildPokemon.CurrentHP = 0;
                                Console.SetCursorPosition(3, 12);
                                Console.Write($"you succesfully caught {wildPokemon.Name}!");
                                Console.SetCursorPosition(3, 13);
                                Console.Write($"{wildPokemon.Name} has been added to the party");
                            }
                        }
                        else if (input == "pokemon" || input == "POKEMON")
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("which pokemon do you want to use? (1-6)");
                                for (int i = 0; i < pokedex.Party.Count; i++)
                                    Console.WriteLine($"{i + 1}.{pokedex.Party[i].Name}");

                                int a = int.Parse(Console.ReadLine());
                                myPokemon = pokedex.Party[a - 1];
                                if (myPokemon.CurrentHP == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("This pokemon is unable to battle!\nSelect another one");
                                    Console.ReadLine();
                                }
                            } while (myPokemon.CurrentHP == 0);
                            Console.Clear();
                            draw.Battle(myPokemon, wildPokemon);
                            firstTurn = false;
                        }
                        else if (input == "run" || input == "RUN")
                        {
                            wildPokemon.CurrentHP = 0;
                            fled = true;
                        }
                    }
                    //code will run every 2 turns, check if pokemon have fainted yet: if they did, code won't continue
                    else if (firstTurn == false && myPokemon.CurrentHP > 0 && wildPokemon.CurrentHP > 0)
                    {
                        //because myPokemon started in the first turn, wildPokemon will attack
                        if (myPokemon.Speed_Full > wildPokemon.Speed_Full)
                            Attack(wildPokemon, myPokemon, true);
                        //because wildPokemon started in the first turn, myPokemon will attack
                        else if (myPokemon.Speed_Full < wildPokemon.Speed_Full)
                            Attack(myPokemon, wildPokemon, true);
                        //in the second turn, the other pokemon will attack
                        else
                        {
                            if (coinFlip == 0)
                                Attack(wildPokemon, myPokemon, true);
                            else if (coinFlip == 1)
                                Attack(myPokemon, wildPokemon, true);
                        }
                        //Visualize battle
                        Console.Clear();
                        draw.Battle(myPokemon, wildPokemon);
                        firstTurn = true;
                    }
                }
                if (fled)
                {
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"you succesfully escaped!");
                }
                //result = draw
                else if (myPokemon.CurrentHP == 0 && wildPokemon.CurrentHP == 0)
                {
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"both {myPokemon.Name} and {wildPokemon.Name} have fainted");
                    Console.SetCursorPosition(3, 13);
                    Console.Write("THE BATTLE ENDED WITH A DRAW");
                }
                //result = lose
                else if (myPokemon.CurrentHP == 0)
                {
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"{myPokemon.Name} has fainted   ");
                    Console.SetCursorPosition(3, 13);
                    Console.Write("YOU LOST THE BATTLE");
                }
                //result = win
                else if (wildPokemon.CurrentHP == 0 && !isCaught && !fled)
                {
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"{wildPokemon.Name} has fainted   ");
                    Console.SetCursorPosition(3, 13);
                    Console.Write("YOU WON THE BATTLE");
                    Console.ReadLine();
                    Console.SetCursorPosition(3, 14);
                    if (wildPokemon.Level < 100)
                    {
                        Console.Write($"{myPokemon.Name} received {ReceiveExp(myPokemon, wildPokemon)} Exp");
                    }
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
        //code for battling wild pokemon with party
        public void Encounter(int WildLvlMin, int WildLvlMax, List<Pokemon> localPokemon, Pokedex pokedex)
        {
            Pokanics pokanics = new Pokanics();
            int randomLvl = Random(WildLvlMin, WildLvlMax);
            int randomPk = Random(0, localPokemon.Count);
            int knockOut = 0;
            localPokemon[randomPk].Level = randomLvl;
            pokanics.Heal(localPokemon[randomPk]);

            //count how many pokemons have been knocked out
            for (int i = 0; i < pokedex.Party.Count; i++)
            {
                if (pokedex.Party[i].CurrentHP == 0)
                    knockOut++;
            }
            //if all pokemons are knocked out, battle ends
            if (knockOut == pokedex.Party.Count)
            {
                Console.WriteLine("Your Pokemon(s) are unable to battle!");
                Console.ReadLine();
                Console.Clear();
            }
            //if party pokemon faints, next pokemon will take over
            for (int j = 0; j < pokedex.Party.Count; j++)
            {
                for (int i = 0; i < pokedex.Party.Count; i++)
                {
                    if (pokedex.Party[i].CurrentHP > 0)
                    {
                        pokanics.Battle(pokedex.Party[i], localPokemon[randomPk], pokedex);
                    }
                }
            }
            //if wild pokemon faints, battle ends
            for (int i = 0; i < pokedex.Party.Count; i++)
            {
                if (pokedex.Wild[randomPk].CurrentHP == 0)
                {
                    i = pokedex.Party.Count;
                }
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
        public void HealAll(List<Pokemon> list)
        {
            for (int i = 0; i < list.Count; i++)
                Heal(list[i]);
        }
        public void Pokecenter(List<Pokemon> list)
        {
            for (int i = 0; i < list.Count; i++)
                Heal(list[i]);
            Console.WriteLine("Nurse Joy: your pokemon have been fully restored!");
            Console.ReadLine();
            Console.Clear();
        }
        public void DrinkPotion(Pokemon pokemon)
        {
            pokemon.CurrentHP += 20;
            if (pokemon.CurrentHP > pokemon.HP_Full)
                pokemon.CurrentHP = pokemon.HP_Full;
        }
        //swap pokemon in party
        public void Swap(int a, int b, List<Pokemon> list)
        {
            Pokemon temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
        public void Remove(int a, List<Pokemon> list)
        {
            list.Remove(list[a]);
        }
        //integer randomizer 
        private static int Random(int x, int y)
        {
            Random random = new Random();
            return random.Next(x, y);
        }
    }
}
