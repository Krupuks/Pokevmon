using System;
namespace Pokevmon
{
    public class Draw
    {
        #region Basic
        static public void HorizontalLine(int posX, int posY, int length, char x)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write(x);
                Console.WriteLine();
            }
        }
        static public void VerticalLine(int posX, int posY, int length, char x)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.Write(x);
                Console.WriteLine();
            }
        }
        static public void Border(int posX1, int posY1, int posX2, int posY2, char x)
        {
            HorizontalLine(posX1, posY1, posX2 - posX1, x);
            VerticalLine(posX1, posY1, posY2 - posY1 + 1, x);
            VerticalLine(posX2, posY1, posY2 - posY1 + 1, x);
            HorizontalLine(posX1, posY2, posX2 - posX1, x);
        }
        #endregion

        #region Pokemon
        private int size = 17; //increase size if more data is needed during display
        private void FullStat(int Full, char x, int pos, int nr)
        {
            Console.SetCursorPosition(8, 5 + size * nr + pos);
            Console.Write(Full);
            for (int i = 0; i < Full / 2; i++)
            {
                Console.SetCursorPosition(12 + i, 5 + size * nr + pos);
                Console.Write(x);
            }
        }
        private void CurrentStat(int Current, char x, int pos, int nr)
        {
            Console.SetCursorPosition(4, 5 + size * nr + pos);
            Console.Write(Current + "/");
            for (int i = 0; i < Current / 2; i++)
            {
                Console.SetCursorPosition(12 + i, 5 + size * nr + pos);
                Console.Write(x);
            }
        }
        public void Stats(Pokemon pokemon, int layer)
        {
            Draw.HorizontalLine(0, size * layer, 25, '-');
            Console.WriteLine($"{pokemon.Name} lvl.{pokemon.Level}\n{pokemon.Type} Type\n\n\nExp to lvl:\n\n\nHP\nSpd\nAtt\nDef\nSpAtt\nSpDef\n\nTotal Basestats: {pokemon.TotalBase}\nAverage Basestats: {pokemon.AverageBase}");

            Sprite(pokemon, 18, 1 + size * layer, pokemon.Color, 0);

            Console.SetCursorPosition(0, 3 + size * layer);
            Console.WriteLine($"{pokemon.CurrentExpTotal}/{pokemon.Exp_Max} exp");
            Console.SetCursorPosition(12, 6 + size * layer);
            Console.WriteLine($"{pokemon.CurrentExp}/{pokemon.Exp_NextLvl}");
            
            ExpBar(pokemon,12, 5 + size * layer);
            FullStat(pokemon.HP_Full, '░', 3, layer);
            CurrentStat((int)pokemon.CurrentHP, '█', 3, layer);
            FullStat(pokemon.Speed_Full, '█', 4, layer);
            FullStat(pokemon.Attack_Full, '█', 5, layer);
            FullStat(pokemon.Defense_Full, '█', 6, layer);
            FullStat(pokemon.SpAttack_Full, '█', 7, layer);
            FullStat(pokemon.SpDefense_Full, '█', 8, layer);

            Draw.HorizontalLine(0, size * (layer + 1), 25, '-');
        }
        public void DexStats(Pokemon pokemon, int layer)
        {
            Draw.HorizontalLine(0, size * layer, 22, '-');
            Console.WriteLine($"{pokemon.Name} nr.{pokemon.Number}\n{pokemon.Type} Type\n\n\n\nHP\nSpd\nAtt\nDef\nSpAtt\nSpDef\n\nTotal Basestats: {pokemon.TotalBase}\nAverage Basestats: {pokemon.AverageBase}");

            Sprite(pokemon, 15, 1 + size * layer, pokemon.Color, 0);

            FullStat(pokemon.HP_Base, '█', 1, layer);
            FullStat(pokemon.Speed_Base, '█', 2, layer);
            FullStat(pokemon.Attack_Base, '█', 3, layer);
            FullStat(pokemon.Defense_Base, '█', 4, layer);
            FullStat(pokemon.SpAttack_Base, '█', 5, layer);
            FullStat(pokemon.SpDefense_Base, '█', 6, layer);

            Draw.HorizontalLine(0, size * (layer + 1), 22, '-');
        }
        private void HealthBar(Pokemon pokemon, int posX, int posY)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('░');
            }

            for (int i = 0; i < pokemon.CurrentHP / (pokemon.HP_Full * 1.0) * 20; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('█');
            }
            Console.ResetColor();
        }
        private void ExpBar(Pokemon pokemon, int posX, int posY)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('▄');
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < pokemon.CurrentExp / (pokemon.Exp_NextLvl * 1.0) * 10; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('▄');
            }
            Console.ResetColor();
        }
        private void Sprite(Pokemon pokemon, int posX, int posY, int color, int perspective)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.WriteLine(pokemon.Sprite[perspective, i]);
            }
            Console.ResetColor();
        }
        public void Battle(Pokemon pokemon, bool isMyPokemon)
        {
            Draw.Border(1, 10, 63, 15, '░');
            Draw.Border(0, 0, 64, 16, '█');
            Console.SetCursorPosition(50, 12);
            Console.Write("press ENTER");
            Console.SetCursorPosition(50, 13);
            Console.Write("to attack");
            if (isMyPokemon)
            {
                Console.SetCursorPosition(40, 6);
                Console.WriteLine($"{pokemon.Name} Lvl.{pokemon.Level}");
                HealthBar(pokemon,40, 7);
                ExpBar(pokemon,50, 8);
                Console.SetCursorPosition(40, 8);
                Console.WriteLine($"{Math.Round(pokemon.CurrentHP)}/{pokemon.HP_Full} Hp");
                Console.SetCursorPosition(50, 9);
                Sprite(pokemon,24, 7, pokemon.Color, 1);
            }
            else
            {
                Console.SetCursorPosition(40, 2);
                Console.WriteLine($"{pokemon.Name} Lvl.{pokemon.Level}");
                HealthBar(pokemon,40, 3);
                Console.SetCursorPosition(40, 4);
                Console.WriteLine($"{Math.Round(pokemon.CurrentHP)}/{pokemon.HP_Full} Hp");
                Sprite(pokemon,6, 3, pokemon.Color, 0);
            }
            Console.SetCursorPosition(3, 12);
        }
        #endregion
    }
}
