using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFight
{
    internal class Enemy : Character, IFight
    {
        public Player Player;
        public Enemy(string name, CharacterClass type, Player player) : base(name, type)
        {
            Player = player;
        }

        public Enemy(string name, CharacterClass type) : base(name, type)
        {
        }

        public void Attack()
        {
            Random rnd = new Random();
            int number = rnd.Next(1,4);
            if (number == 1)
            {
                CastSpell(this, Player);
            }
            else if (number == 2)
            {
                HitWithAxe(Player, this);
            }
            else
            {
                ShootArrow(Player, this);
            }
        }

        public void Heal(Player player, Enemy enemy)
        {
            enemy.type.health += 20;
            string text = $"{Name} heals for 20 hp \n" +
                          $"{Name} now has {enemy.type.health} hp \n";
            Console.WriteLine();
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
        }

        public void Block(Player player, Enemy enemy)
        {
            string text = $"{Name} tries to block the attack from {player.Name} \n";
            Console.WriteLine();
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
        }

        public void Dodge(Player player, Enemy enemy)
        {
            string text = $"{Name} tries to roll out of the way from the attack from {player.Name} \n";
            Console.WriteLine();
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
        }

        public void CastSpell(Enemy enemy, Player player)
        {
            if (enemy.type.intelligence > 15)
            {
                enemy.type.health = enemy.type.health - 20;
                Console.WriteLine($"{Name} cast lightningbolt \n");
                string text = $"intelligence is too low... \n" +
                              $"{Name} hits themselves for 20 damage and has {enemy.type.health} hp left \n";
                foreach (var letter in text)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                
            }
            else
            {
                player.type.health = player.type.health - 15;
                string text2 = $"{Name} hits {player.Name} for 15 damage \n" +
                               $"{player.Name} has {player.type.health} hp left \n";
                Console.WriteLine();
                foreach (var letter in text2)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
                
            }
        }
        public void HitWithAxe(Player player, Enemy enemy)
        {
            if (enemy.type.strength < 15)
            {
                enemy.type.health = enemy.type.health - 15;
                Console.WriteLine($"{Name} swings their {enemy.type.weapon} at {player.Name} \n");
                string text = $"{Name} misses and takes an opportunity attack from {player.Name} \n" +
                              $"{Name} takes 15 damage and has {enemy.type.health} hp left \n";
                      
                foreach (var letter in text)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
            }
            else
            {
                player.type.health = player.type.health - 20;
                string text2 = $"{Name} swings their {enemy.type.weapon} at {player.Name} \n" +
                               $"{player.Name} takes 20 damage and has {player.type.health} hp left \n";
                Console.WriteLine();
               

                foreach (var letter in text2)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
            }
        }
        public void ShootArrow(Player player, Enemy enemy)
        {
            if (enemy.type.dexterity < 15)
            {
                Console.WriteLine($"{Name} tries to fire an arrow with their {enemy.type.weapon}...");
                string text = $"{Name} trips and falls on their face...\n" +
                              $"{Name} takes 20 damage from the fall and has {enemy.type.health} hp left \n";
                Console.WriteLine();
                foreach (var letter in text)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }

                enemy.type.health = enemy.type.health - 20;
            }
            else
            {
                string text2 = $"{Name} fires an arrow from their {enemy.type.weapon} \n" +
                               $"{player.Name} get hit with 20 damage and has {player.type.health} hp left \n";
                Console.WriteLine();
                foreach (var letter in text2)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }

                player.type.health = player.type.health - 20;
            }
        }
    }
}
