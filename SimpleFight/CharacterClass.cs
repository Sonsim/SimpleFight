using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFight
{
    internal class CharacterClass
    {
        internal string name;
        internal int strength;
        internal int intelligence;
        internal int dexterity;
        internal int health;
        internal int stamina;
        internal int mana;
        internal string weapon;

        public CharacterClass(string name, int strength, int intelligence, int dexterity, int health, int stamina, int mana, string weapon)
        {
            this.name = name;
            this.strength = strength;
            this.intelligence = intelligence;
            this.dexterity = dexterity;
            this.health = health;
            this.stamina = stamina;
            this.mana = mana;
            this.weapon = weapon;
        }
    }
}
