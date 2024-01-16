using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFight
{
    internal class Player : Character, IFight
    {
        public Enemy enemy;
        public Player(string name, CharacterClass type) : base(name, type)
        {
        }

        public void Attack()
        {
            Console.WriteLine("Which attack would you like to use?\n");
            Console.WriteLine("1. Cast spell \n" +
                              "2. Hit with your weapon \n" +
                              "3. Fire an arrow");
            var ans = Convert.ToInt32(Console.ReadLine());

            switch (ans)
            {
                case 1:
                    CastSpell(this, enemy);
                    break;
                case 2: 
                    HitWithAxe(this, enemy);
                    break;
                case 3: 
                    ShootArrow(this, enemy);
                    break;
                default:
                    Console.WriteLine($"{ans} is not a valid command, try again");
                    break;
            }
        }

        public void Heal(Player player, Enemy enemy)
        {
            player.type.health = player.type.health + 30;
            string text = $"{Name} drinks a healing potion and heals 30 damage \n";
            Console.WriteLine();
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            
        }

        public void Block(Player player, Enemy enemy)
        {
            string text = $"{Name} braces for the attack from {enemy.Name} \n" +
                          $"{Name} blocks the attack";
            Console.WriteLine();
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
        }

        public void Dodge(Player player, Enemy enemy)
        {
            string text = $"{Name} jumps out of the way of the attack from {enemy.Name} \n";
            Console.WriteLine();
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
        }

        public void CastSpell(Player player, Enemy enemy)
        {
            if (player.type.intelligence < 15)
            {
                player.type.health = player.type.health - 15;
                Console.WriteLine($"{Name} cast fireball");
                Console.WriteLine();
                string text = $"intelligence is to low... \n" +
                              $"{Name} hits themselves for 15 damage and has {player.type.health} hp left \n";
                
                foreach (var letter in text)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }

            }
            else
            {
                enemy.type.health = enemy.type.health - 20;
                string text2 = $"{Name} hits {enemy.Name} for 20 damage \n" +
                               $"{enemy.Name} has {enemy.type.health} hp left";
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
            if (player.type.strength < 15)
            {
                player.type.health = player.type.health - 15;
                Console.WriteLine($"{Name} swings their {player.type.weapon} at {enemy.Name}");
                Console.WriteLine();
                string text = $"{Name} misses and takes an opportunity attack from {enemy.Name} \n" +
                              $"{Name} takes 15 damdage and has {player.type.health} hp left \n";
                
                foreach (var letter in text)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }
            }
            else
            {
                enemy.type.health = enemy.type.health - 20;
                string text2 = $"{Name} swings their {player.type.weapon} at {enemy.Name} \n" +
                               $"{enemy.Name} takes 20 damage and has {enemy.type.health} hp left \n";
                
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
            if (player.type.dexterity < 15)
            {

                player.type.health = player.type.health - 15;
                Console.WriteLine($"{Name} tries to fire an arrow with their {player.type.weapon}...");
                
                string text = $"{Name} trips and falls on their face...\n" +
                              $"{Name} takes 15 damage from the fall and has {player.type.health} hp left \n";
                foreach (var letter in text)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }

            }
            else
            {
                enemy.type.health = enemy.type.health - 20;
                string text2 = $"{Name} fires an arrow from their {player.type.weapon} \n" +
                               $"{enemy.Name} get hit with 20 damage and has {enemy.type.health} hp left";
                Console.WriteLine();
                foreach (var letter in text2)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                }

                
            }
        }
    }
}
