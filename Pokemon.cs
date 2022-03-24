using System;
namespace Pokevmon
{
    public class Pokemon
    {
        #region Constructors
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
        public Pokemon(string name, string type, int number, int level, int hp_base, int speed_base, int attack_base, int defense_base, int spattack_base, int spdefense_base, int exp_base) : this( name, type, number, level, hp_base, speed_base, attack_base, defense_base, spattack_base, spdefense_base, exp_base,7) { }
        public Pokemon(string name, string type, int number, int level) : this(name, type, number, level, 10, 10, 10, 10, 10, 10, 50, 7) { }
        public Pokemon(string name, string type, int number) : this(name, type, number, 1, 10, 10, 10, 10, 10, 10, 50, 7) { }
        public Pokemon() : this("Substitute", "No", 0, 1, 10, 10, 10, 10, 10, 10, 50, 7) { }
        #endregion

        #region Pokemon information

        public string Name { get; set; }
        public string[,] Sprite { get; set; }
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

        #region Pokemon full stats

        public int HP_Full { get { return (HP_Base + 50) * Level / 50 + 10; } }
        public int Attack_Full { get { return Attack_Base * Level / 50 + 5; } }
        public int Defense_Full { get { return Defense_Base * Level / 50 + 5; } }
        public int SpAttack_Full { get { return SpAttack_Base * Level / 50 + 5; } }
        public int SpDefense_Full { get { return SpDefense_Base * Level / 50 + 5; } }
        public int Speed_Full { get { return Speed_Base * Level / 50 + 5; } }
        public int Exp_Full { get { return Exp_Base * Level; } }

        #endregion

        #region Pokemon dynamic stats

        private int currentHP;
        private int currentExp;
        private int level;

        public int CurrentHP { get { return currentHP; } set { currentHP = value; } }
        public int CurrentExp { get { return currentExp; } set { currentExp = value; } }

        public int Level {
            get { return level;}

            set {
                if (value <= 100)
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
                CurrentHP = (HP_Full / CurrentHP) * HP_Full;
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
    }
}