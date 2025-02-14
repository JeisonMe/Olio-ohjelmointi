using System;
using System.Collections.Generic;

namespace game
{
    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Power { get; set; }
        public int Gold { get; set; }
        public Armor EquippedArmor { get; set; }

        public void Attack(Character target)
        {
            int damage = Power;
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            if (EquippedArmor != null)
            {
                damage -= EquippedArmor.Defense;
                if (damage < 0) damage = 0;
            }

            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    class Knight : Character
    {
        public Weapon EquippedWeapon { get; set; }
        public Potion EquippedPotion { get; set; }

        public Knight()
        {
            Name = "Knight";
            Health = 100;
            Power = 10;
            Gold = 50;
            EquippedWeapon = new Weapon("hand", 5, 10);
        }

        public void UsePotion()
        {
            if (EquippedPotion != null)
            {
                Health += EquippedPotion.HealingAmo;
                Console.WriteLine($"{Name} heal for {EquippedPotion.HealingAmo} HP");
                EquippedPotion = null; // no healing
            }
            else
            {
                Console.WriteLine("No potions");
            }
        }
    }

    class Enemy : Character
    {
        public Enemy(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            Power = attackPower;
        }
    }

    class Weapon
    {
        public string Name { get; }
        public int Damage { get; }
        public int Price { get; }

        public Weapon(string name, int damage, int price)
        {
            Name = name;
            Damage = damage;
            Price = price;
        }
    }

    class Armor
    {
        public string Name { get; }
        public int Defense { get; }
        public int Price { get; }

        public Armor(string name, int defense, int price)
        {
            Name = name;
            Defense = defense;
            Price = price;
        }
    }

    class Potion
    {
        public string Name { get; }
        public int HealingAmo { get; }
        public int Price { get; }

        public Potion(string name, int healingAmount, int price)
        {
            Name = name;
            HealingAmo = healingAmount;
            Price = price;
        }
    }
    class Shop
    {
        public List<Weapon> Weapon { get; }
        public List<Armor> Armor { get; }
        public List<Potion> Potion { get; }

        public Shop()
        {
            Weapon = new List<Weapon>
            {
                new Weapon("Sword", 10, 25)
            };
            Armor = new List<Armor>
            {
                new Armor("Armor", 10, 30)
            };
            Potion = new List<Potion>
            {
                new Potion("Healing", 40, 20)
            };
        }

        public void DisplayItems(Knight knight)
        {
            Console.WriteLine($"Gold: {knight.Gold}");
            Console.WriteLine(" ");

            for (int i = 0; i < Weapon.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Weapon[i].Name} - {Weapon[i].Price} Gold");
            }

            for (int i = 0; i < Armor.Count; i++)
            {
                Console.WriteLine($"{i + 1 + Weapon.Count}. {Armor[i].Name} - {Armor[i].Price} Gold");
            }

            for (int i = 0; i < Potion.Count; i++)
            {
                Console.WriteLine($"{i + 1 + Weapon.Count + Armor.Count}. {Potion[i].Name} - {Potion[i].Price} Gold");
            }
        }

        public void BuyItem(Knight knight, int itemIndex)
        {
            if (itemIndex < 1 || itemIndex > Weapon.Count + Armor.Count + Potion.Count)
            {
                Console.WriteLine("No");
                return;
            }

            if (itemIndex <= Weapon.Count)
            {
                Weapon weapon = Weapon[itemIndex - 1];
                if (knight.Gold >= weapon.Price)
                {
                    knight.Gold -= weapon.Price;
                    knight.EquippedWeapon = weapon;
                    knight.Power += weapon.Damage;
                    Console.WriteLine($"You bought {weapon.Name}");
                }
                else
                {
                    Console.WriteLine("no gold");
                }
            }
            else if (itemIndex <= Weapon.Count + Armor.Count)
            {
                Armor armor = Armor[itemIndex - Weapon.Count - 1];
                if (knight.Gold >= armor.Price)
                {
                    knight.Gold -= armor.Price;
                    knight.EquippedArmor = armor;
                    Console.WriteLine($"You bought {armor.Name}");
                }
                else
                {
                    Console.WriteLine("No gold");
                }
            }
            else
            {
                Potion potion = Potion[itemIndex - Weapon.Count - Armor.Count - 1];
                if (knight.Gold >= potion.Price)
                {
                    knight.Gold -= potion.Price;
                    knight.EquippedPotion = potion;
                    Console.WriteLine($"you bought {potion.Name}");
                }
                else
                {
                    Console.WriteLine("no gold");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            Shop shop = new Shop();
            List<Enemy> enemies = new List<Enemy>
            {
                new Enemy("goblin", 50, 10),
                new Enemy("orc", 80, 15),
                new Enemy("dragon", 150, 20)
            };

            while (true)
            {
                Console.WriteLine("1. Fight enemy");
                Console.WriteLine("2. Visit the shop");
                Console.WriteLine("3. Exit game");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Choose enemy to kill:");
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {enemies[i].Name} (HP: {enemies[i].Health})");
                    }

                    int enemyIndex = int.Parse(Console.ReadLine()) - 1;
                    Enemy enemy = enemies[enemyIndex];

                    while (knight.IsAlive() && enemy.IsAlive())
                    {
                        Console.WriteLine($"\n{knight.Name} HP: {knight.Health} | {enemy.Name} HP: {enemy.Health}");
                        Console.WriteLine(" ");
                        Console.WriteLine("1. Attack");
                        Console.WriteLine("2. Use a potion");
                        string action = Console.ReadLine();

                        if (action == "1")
                        {
                            knight.Attack(enemy);
                            if (enemy.IsAlive())
                            {
                                enemy.Attack(knight);
                            }
                        }
                        else if (action == "2")
                        {
                            knight.UsePotion();
                            if (enemy.IsAlive())
                            {
                                enemy.Attack(knight);
                            }
                        }
                        else
                        {
                            Console.WriteLine("no");
                        }
                    }

                    if (knight.IsAlive())
                    {
                        Console.WriteLine($"You killed the {enemy.Name} and earned 20 gold");
                        knight.Gold += 25;
                    }
                    else
                    {
                        Console.WriteLine("Game over");
                        break;
                    }
                }
                else if (choice == "2")
                {
                    shop.DisplayItems(knight);
                    int itemIndex = int.Parse(Console.ReadLine());
                    shop.BuyItem(knight, itemIndex);
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }
    }
}
