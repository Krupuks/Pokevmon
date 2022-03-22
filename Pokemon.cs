using System;
namespace Pokevmon
{
    public class Pokemon
    {
        public Pokemon()
        {
            Name = "Substitute";
            Type = "None";
            Number = 0;
            Level = 1;
            Speed_Base = 10;
            SpDefense_Base = 10;
            SpAttack_Base = 10;
            Defense_Base = 10;
            Attack_Base = 10;
            HP_Base = 10;
            Exp_Base = 50;
            Color = 15;
        }
        public Pokemon(string name, string type, int number)
        {
            Name = name;
            Type = type;
            Number = number;
            Level = 1;
            Speed_Base = 10;
            SpDefense_Base = 10;
            SpAttack_Base = 10;
            Defense_Base = 10;
            Attack_Base = 10;
            HP_Base = 10;
            Exp_Base = 50;
            Color = 15;
        }
        public Pokemon(string name, string type, int number, int level)
        {
            Name = name;
            Type = type;
            Number = number;
            Level = level;

            HP_Base = 10;
            Speed_Base = 10;
            Attack_Base = 10;
            Defense_Base = 10;
            SpAttack_Base = 10;
            SpDefense_Base = 10;
            Exp_Base = 50;
            Color = 15;
        }
        public Pokemon(string name, string type, int number, int level, int hp_base, int speed_base, int attack_base, int defense_base, int spattack_base, int spdefense_base, int exp_base)
        {
            Name = name;
            Type = type;
            Number = number;
            Level = level;
            HP_Base = hp_base;
            Speed_Base = speed_base;
            Attack_Base = attack_base;
            Defense_Base = defense_base;
            SpAttack_Base = spattack_base;
            SpDefense_Base = spdefense_base;
            Exp_Base = exp_base;
            Color = 15;
        }
        public Pokemon(string name, string type, int number, int level, int hp_base, int speed_base, int attack_base, int defense_base, int spattack_base, int spdefense_base, int exp_base, int color)
        {
            Name = name;
            Type = type;
            Number = number;
            Level = level;
            HP_Base = hp_base;
            Speed_Base = speed_base;
            Attack_Base = attack_base;
            Defense_Base = defense_base;
            SpAttack_Base = spattack_base;
            SpDefense_Base = spdefense_base;
            Exp_Base = exp_base;

            Color = color;
        }

        #region Pokemon information

        public string Name { get; set; }
        public string[] FrontSprite { get; set; }
        public string[] BackSprite { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public int Color { get; set; }

        #endregion

        #region Pokemon base stats

        private int hp_Base;
        private int attack_Base;
        private int defense_Base;
        private int spAttack_Base;
        private int spDefense_Base;
        private int speed_Base;
        private int exp_Base;

        private int Speed_Base { get { return speed_Base; } set { speed_Base = value; } }
        private int SpDefense_Base { get { return spDefense_Base; } set { spDefense_Base = value; } }
        private int SpAttack_Base { get { return spAttack_Base; } set { spAttack_Base = value; } }
        private int Defense_Base { get { return defense_Base; } set { defense_Base = value; } }
        private int Attack_Base { get { return attack_Base; } set { attack_Base = value; } }
        private int HP_Base { get { return hp_Base; } set { hp_Base = value; } }
        public int Exp_Base { get { return exp_Base; } private set { exp_Base = value; } }

        public int TotalBase { get { return HP_Base + Attack_Base + Defense_Base + SpAttack_Base + SpDefense_Base + Speed_Base; } }
        public double AverageBase { get { return Math.Round(HP_Base + Attack_Base + Defense_Base + SpAttack_Base + SpDefense_Base + Speed_Base / 6.0, 1); } }

        #endregion

        #region Pokemon full stats

        public int HP_Full { get { return (HP_Base + 50) * Level / 50 + 10; } }
        public int Attack_Full { get { return Attack_Base * Level / 50 + 5; } }
        public int Defense_Full { get { return Defense_Base * Level / 50 + 5; } }
        public int SpAttack_Full { get { return SpAttack_Base * Level / 50 + 5; } }
        public int SpDefense_Full { get { return SpDefense_Base * Level / 50 + 5; } }
        public int Speed_Full { get { return Speed_Base * Level / 50 + 5; } }
        public int Exp_Full { get { return Exp_Base * Level; } }

        #endregion

        #region Pokemon independant stats

        private int currentHP;
        private int currentExp;
        private int level;

        public int CurrentHP { get { return currentHP; } set { currentHP = value; } }
        public int CurrentExp { get { return currentExp; } set { currentExp = value; } }
        public int Level
        {
            get { return level; }
            set
            {
                if (value > 0 && value <= 100)
                {
                    level = value;
                }
            }
        }

        #endregion

        #region Actions

        public void LevelUp()
        {
            Level++;
            if (Level <= 100)
            {
                Heal();
            }
        }
        public void Heal()
        {
            CurrentHP = HP_Full;
        }
        public void ReceiveDmg(int damage)
        {
            CurrentHP -= damage;
        }
        public void ReceiveExp(int exp)
        {
            CurrentExp += exp;
            if (CurrentExp >= Exp_Full)
            {
                CurrentExp = 0;
                LevelUp();
            }
        }

        #endregion

        #region DrawUI
        int size = 16;
        private void DrawHorizontalLine(int posX, int posY, int length, char x)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write(x);
                Console.WriteLine();
            }
        }
        private void DrawVerticalLine(int posX, int posY, int length, char x)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.Write(x);
                Console.WriteLine();
            }
        }
        private void DrawBorder(int posX1, int posY1, int posX2, int posY2, char x)
        {
            DrawHorizontalLine(posX1, posY1, posX2 - posX1, x);
            DrawVerticalLine(posX1, posY1, posY2 - posY1 + 1, x);
            DrawVerticalLine(posX2, posY1, posY2 - posY1 + 1, x);
            DrawHorizontalLine(posX1, posY2, posX2 - posX1, x);
        }

        private void DrawStatFull(int Full, char x, int pos, int nr)
        {
            Console.SetCursorPosition(8, 5 + size * nr + pos);
            Console.Write(Full);
            for (int i = 0; i < Full / 2; i++)
            {
                Console.SetCursorPosition(12 + i, 5 + size * nr + pos);
                Console.Write(x);
            }
        }
        private void DrawStatCurrent(int Current, char x, int pos, int nr)
        {
            Console.SetCursorPosition(4, 5 + size * nr + pos);
            Console.Write(Current + "/");
            for (int i = 0; i < Current / 2; i++)
            {
                Console.SetCursorPosition(12 + i, 5 + size * nr + pos);
                Console.Write(x);
            }
        }
        public void DrawStats(int layer)
        {
            DrawHorizontalLine(0, size * layer, 25, '-');
            Console.WriteLine($"{Name} lvl.{Level}\n{Type} Type\n\nExp\n\n\nHP\nSpd\nAtt\nDef\nSpAtt\nSpDef\n\nTotal: {TotalBase}\nAverage: {AverageBase}");

            DrawFrontSprite(17, 1 + size * layer, Color);

            Console.SetCursorPosition(0, 5 + size * layer);
            Console.WriteLine($"{CurrentExp}/{Exp_Full}");
            DrawExpBar(12, 5 + size * layer);
            DrawStatFull(HP_Full, '░', 2, layer);
            DrawStatCurrent(currentHP, '█', 2, layer);
            DrawStatFull(Speed_Full, '█', 3, layer);
            DrawStatFull(Attack_Full, '█', 4, layer);
            DrawStatFull(Defense_Full, '█', 5, layer);
            DrawStatFull(SpAttack_Full, '█', 6, layer);
            DrawStatFull(SpDefense_Full, '█', 7, layer);

            DrawHorizontalLine(0, size * (layer + 1), 25, '-');
        }
        public void DrawDex(int layer)
        {
            DrawHorizontalLine(0, size * layer, 22, '-');
            Console.WriteLine($"{Name} nr.{Number}\n{Type} Type\n\n\n\nHP\nSpd\nAtt\nDef\nSpAtt\nSpDef\n\nTotal: {TotalBase}\nAverage: {AverageBase}");

            DrawFrontSprite(15, 1 + size * layer, Color);

            DrawStatFull(HP_Full, '█', 1, layer);
            DrawStatFull(Speed_Full, '█', 2, layer);
            DrawStatFull(Attack_Full, '█', 3, layer);
            DrawStatFull(Defense_Full, '█', 4, layer);
            DrawStatFull(SpAttack_Full, '█', 5, layer);
            DrawStatFull(SpDefense_Full, '█', 6, layer);

            DrawHorizontalLine(0, size * (layer + 1), 22, '-');
        }

        private void DrawHealthBar(int posX, int posY)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('░');
            }

            for (int i = 0; i < CurrentHP / (HP_Full * 1.0) * 20; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('█');
            }
            Console.ResetColor();
        }

        private void DrawExpBar(int posX, int posY)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('▄');
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < CurrentExp / (Exp_Full * 1.0) * 10; i++)
            {
                Console.SetCursorPosition(posX + i, posY);
                Console.Write('▄');
            }
            Console.ResetColor();
        }

        private void DrawFrontSprite(int posX, int posY, int color)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.WriteLine(FrontSprite[i]);
            }
            Console.ResetColor();
        }
        private void DrawBackSprite(int posX, int posY, int color)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.WriteLine(BackSprite[i]);
            }
            Console.ResetColor();
        }
        public void DrawBattle(bool myPokemon)
        {
            DrawBorder(1, 10, 63, 15, '░');
            DrawBorder(0, 0, 64, 16, '█');
            Console.SetCursorPosition(50, 12);
            Console.Write("press ENTER");
            Console.SetCursorPosition(50, 13);
            Console.Write("to advance");
            if (myPokemon)
            {
                Console.SetCursorPosition(40, 6);
                Console.WriteLine($"{Name} Lvl.{Level}");
                DrawHealthBar(40, 7);
                DrawExpBar(50, 8);
                Console.SetCursorPosition(40, 8);
                Console.WriteLine($"{CurrentHP}/{HP_Full} Hp");
                Console.SetCursorPosition(50, 9);
                DrawBackSprite(24, 7, Color);
            }
            else
            {
                Console.SetCursorPosition(40, 2);
                Console.WriteLine($"{Name} Lvl.{Level}");
                DrawHealthBar(40, 3);
                Console.SetCursorPosition(40, 4);
                Console.WriteLine($"{CurrentHP}/{HP_Full} Hp");
                DrawFrontSprite(6, 3, Color);
            }

            Console.SetCursorPosition(3, 12);
        }
        #endregion
    }
}