using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Channels;

namespace SimpleFight
{
    internal class Program
    {
        static void Main()
        {
            var Barbarian = new CharacterClass("Barbarian", 20, 2, 5, 200, 100, 0, "GreatAxe");
            var Wizard = new CharacterClass("Wizard", 5, 20, 5, 100, 50, 200, "Staff");
            var Rouge = new CharacterClass("Rouge", 10, 5, 20, 150, 200, 0, "Bow");

            List<CharacterClass> classes = new List<CharacterClass>() {Barbarian, Wizard, Rouge};

            var Sauron = new Enemy("Sauron", Barbarian);
            var astarion = new Enemy("Astarion", Rouge);
            var sarumann = new Enemy("Sarumann", Wizard);

            List<Enemy> enemies = new List<Enemy>(){Sauron, astarion, sarumann};

            var player = CreateCharacter(classes);
            Menu(classes, enemies, player);
        }

        public static void Menu(List<CharacterClass> classList, List<Enemy> enemies, Player player)
        {
            char choice = '0';

            while (choice != '4')
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?"); 
                Console.WriteLine("1. Create Enemy \n" +
                                  "2. Fight random enemy \n" +
                                  "3. Fight specific enemy \n" +
                                  "4. Exit\n");
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        CreateEnemy(classList, enemies);
                        break;
                    case '2':
                        var rndenemy = FightRandom(enemies);
                        Fight(player, rndenemy);
                        break;
                    case '3':
                        var chosen = SelectEnemy(enemies);
                        Fight(player, chosen);
                        break;
                    case '4':
                        Console.WriteLine("Type any key to exit");
                        break;
                    default:
                        Console.WriteLine($"{choice} is not valid command, try again");
                        break;

                }
            }
        }

        public static void Fight(Player player, Enemy enemy)
        {
            player.enemy = enemy;
            enemy.Player = player;
            while (player.type.health > 0 && enemy.type.health > 0)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine($"1. Attack \n" +
                                  $"2. Heal \n" +
                                  $"3. Block \n" +
                                  $"4. Dodge \n");
                var ans = Convert.ToInt32(Console.ReadLine());
               
                switch (ans)
                {
                    case 1: 
                        player.Attack();
                        Console.WriteLine();
                        EnemyChoice(player, enemy);
                        break;
                    case 2: 
                        player.Heal(player, enemy);
                        Console.WriteLine();
                        EnemyChoice(player, enemy);
                        break;
                    case 3: 
                        player.Block(player, enemy);
                        Console.WriteLine();
                        EnemyChoice(player, enemy);
                        break;
                    case 4: 
                        player.Dodge(player,enemy);
                        Console.WriteLine();
                        EnemyChoice(player, enemy);
                        break;
                    default:
                        Console.WriteLine($"{ans} is not a valid command, try again");
                        break;
                }
            }

            if (player.type.health <= 0)
            {
                Console.WriteLine($"{enemy.Name} has killed {player.Name}");
                Console.ReadKey();
            }

            if (enemy.type.health <= 0)
            {
                Console.WriteLine($"{player.Name} has killed {enemy.Name}");
                Console.ReadKey();
            }
         
        }

        public static void EnemyChoice(Player player, Enemy enemy)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 20);
            if (number > 0 && number >=10)
            {
                enemy.Attack();
            }
            else if (number>10 && number <= 13)
            {
                enemy.Heal(player, enemy);
            }
            else if (number > 13 && number <= 16)
            {
                enemy.Block(player, enemy);
            }
            else
            {
                enemy.Dodge(player, enemy);
            }
        }

        public static Player CreateCharacter(List<CharacterClass> list)
        {
            Console.WriteLine("What is the name of your characeter?");
            var name = Console.ReadLine();
            var type = SelectClass(list);

            var newPlayer = new Player(name, type);
            return newPlayer;

        }

        public static void CreateEnemy(List<CharacterClass> list, List<Enemy> list2)
        {
            Console.WriteLine("What is the name of the enemy?");
            var name = Console.ReadLine();
            var type = SelectClass(list);

            var newEnemy = new Enemy(name, type);
            list2.Add(newEnemy);   
        }

        public static CharacterClass SelectClass(List<CharacterClass> list)
        {
            Console.WriteLine("Which class would you like the character to have?");
            foreach (var type in list)
            {
                Console.WriteLine($" - {type.name} \n");
            }
            var choice = Console.ReadLine();
            foreach (var noe in list)
            {
                if (choice.ToLower() == noe.name.ToLower())
                {
                    return noe;
                }
            }

            return null;
        }

        public static Enemy FightRandom(List<Enemy> list)
        {
            Random rnd = new Random();
            int number  = rnd.Next(1, list.Count);
            for (int i =1; i < list.Count; i++)
            {
                if (number == i)
                {
                    return list[i];
                }
            }

            return null;
        }

        public static Enemy SelectEnemy(List<Enemy> list)
        {
            Console.WriteLine("Which enemy do you want to fight?");
            foreach (var thing in list)
            {
                Console.WriteLine($"-{thing.Name} ");
            }
            var ans = Console.ReadLine();
            foreach (var opponent in list)
            {
                if (ans.ToLower() == opponent.Name.ToLower())
                {
                    return opponent;
                }
            }

            return null;
        }
    }
}