using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFight
{
    internal class Character
    {
        public string Name;
        public CharacterClass type;
   public Character(string name, CharacterClass type)
        {
            Name = name;
            this.type = type;
            
        }
    }
}
