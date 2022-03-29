using System;

namespace Pokevmon
{
    public enum Element { None, Normal, Fire, Water, Electric, Grass, Ice, Fighting, Poison, Ground, Flying, Psychic, Bug, Rock, Ghost, Dragon, Steel, Dark, Fairy }
    public class Pokemon
    {
        #region Constructors
        public Pokemon(string name, int number, int level, int hp_base, int attack_base, int defense_base, int spattack_base, int spdefense_base, int speed_base, int exp_base, int color)
        {
            Name = name;
            Number = number;
            Level = level;
            HP_Base = hp_base;
            Attack_Base = attack_base;
            Defense_Base = defense_base;
            SpAttack_Base = spattack_base;
            SpDefense_Base = spdefense_base;
            Speed_Base = speed_base;
            Exp_Base = exp_base;
            Color = color;
        }
        public Pokemon(string name, int number, int level, int hp_base, int attack_base, int defense_base, int spattack_base, int spdefense_base, int speed_base, int exp_base) : this( name, number, level, hp_base, speed_base, attack_base, defense_base, spattack_base, spdefense_base, exp_base,7) { }
        public Pokemon(string name, int number, int level) : this(name, number, level, 10, 10, 10, 10, 10, 10, 50, 7) { }
        public Pokemon(string name, int number) : this(name, number, 1, 10, 10, 10, 10, 10, 10, 50, 7) { }
        public Pokemon() : this("Substitute", 0, 1, 10, 10, 10, 10, 10, 10, 50, 7) { }
        #endregion

        #region General information

        public string Name { get; set; }
        public string[,] Sprite { get; set; }
        public Element[] Type { get; set; }
        public int Number { get; set; }
        public int Color { get; set; }

        #endregion

        #region Static stats

        private int hp_Base;
        private int attack_Base;
        private int defense_Base;
        private int spAttack_Base;
        private int spDefense_Base;
        private int speed_Base;
        private int exp_Base;

        public int Speed_Base { get {return speed_Base; } set { speed_Base = value; } }
        public int SpDefense_Base { get { return spDefense_Base; } set { spDefense_Base = value; } }
        public int SpAttack_Base { get { return spAttack_Base; } set { spAttack_Base = value; } }
        public int Defense_Base { get { return defense_Base; } set { defense_Base = value; } }
        public int Attack_Base { get { return attack_Base; } set { attack_Base = value; } }
        public int HP_Base { get { return hp_Base; } set { hp_Base = value; } }
        public int Exp_Base { get { return exp_Base; } private set { exp_Base = value; } }

        public int TotalBase { get { return HP_Base + Attack_Base + Defense_Base + SpAttack_Base + SpDefense_Base + Speed_Base; } }
        public double AverageBase { get { return Math.Round(TotalBase / 6.0, 1); } }

        #endregion

        #region Relative stats

        public int HP_Full { get { return (HP_Base + 50) * Level / 50 + 10; } }
        public int Attack_Full { get { return Attack_Base * Level / 50 + 5; } }
        public int Defense_Full { get { return Defense_Base * Level / 50 + 5; } }
        public int SpAttack_Full { get { return SpAttack_Base * Level / 50 + 5; } }
        public int SpDefense_Full { get { return SpDefense_Base * Level / 50 + 5; } }
        public int Speed_Full { get { return Speed_Base * Level / 50 + 5; } }
        public int Exp_NextLvl { get { return (int)Math.Pow(Level + 1, 3) - (int)Math.Pow(Level, 3); } }
        public int Exp_Max { get { return (int)Math.Pow(Level, 3); } }

        #endregion

        #region Dynamic stats

        private double currentHP;
        private int currentExp;
        private int level;

        public double CurrentHP { get { return currentHP; } set { currentHP = value; } }
        public int CurrentExp { get { return currentExp; } set { currentExp = value; } }
        public int CurrentExpTotal { get { return currentExp + (int)Math.Pow(Level - 1, 3); } }

        public int Level {
            get { return level;}

            set {
                if (value > 0 && value <= 100)
                    level = value;
            }
        }

        #endregion

        public Pokemon Clone()
        {
            return (Pokemon)this.MemberwiseClone();
        }
    }
}