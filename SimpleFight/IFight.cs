using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFight
{
    internal interface IFight
    {
        public void Attack();
        public void Heal(Player player, Enemy enemy);
        public void Block(Player player, Enemy enemy);
        public void Dodge(Player player, Enemy enemy);
    }
}
