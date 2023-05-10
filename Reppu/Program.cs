using System;

namespace Seikkailijanreppu
{
    class belpi
    {
        public class Item
        {
            public string name;
            public double weight;
            public double capacity;
            public override string ToString()
            {
                return name;
            }
        }

        public class Backpack
        {
            public Item[] items = new Item[10];
            public int itemCount;
            public double totalWeight;
            public double totalCapacity;

            public bool Add(Item item)
            {
                if (itemCount >= 10 || totalWeight + item.weight > 30 || totalCapacity + item.capacity > 20)
                    return false;

                items[itemCount++] = item;
                totalWeight += item.weight;
                totalCapacity += item.capacity;
                return true;
            }

            public override string ToString()
            {
                string contents = $"Repussa on seuraavat asiat: ";
                for (int i = 0; i < itemCount; i++)
                {
                    contents += items[i].ToString();
                    if (i < itemCount - 1)
                            contents += ", ";
                }
                return contents;
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                Backpack backpack = new Backpack();

                Item arrow = new Item { name = "Nuoli", weight = 0.1, capacity = 0.05 };
                Item bow = new Item { name = "Jousi", weight = 1, capacity = 4 };
                Item rope = new Item { name = "Köysi", weight = 1, capacity = 1.5 };
                Item water = new Item { name = "Vesi", weight = 2, capacity = 2 };
                Item meal = new Item { name = "Ruoka-annos", weight = 1, capacity = 0.5 };
                Item sword = new Item { name = "Miekka", weight = 5, capacity = 3 };


                while (true)
                {

                    Console.WriteLine("----------------------------------------------");
                    Console.Write(backpack.ToString());
                    Console.WriteLine(" ");
                    Console.WriteLine($"Repussa on tällä hetkellä {backpack.itemCount}/10 tavaraa, {backpack.totalWeight}/30 painoa, {backpack.totalCapacity}/20 tilavuus.");
                    Console.WriteLine("Mitä haluat lisätä?");
                    Console.WriteLine("1. Nuoli");
                    Console.WriteLine("2. Jousi");
                    Console.WriteLine("3. Köysi");
                    Console.WriteLine("4. Vesi");
                    Console.WriteLine("5. Ruoka-annos");
                    Console.WriteLine("6. Miekka");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    Item selectItem = null;

                    switch (choice)
                    {
                        case "1":
                            selectItem = arrow;
                            break;
                        case "2":
                            selectItem = bow;
                            break;
                        case "3":
                            selectItem = rope;
                            break;
                        case "4":
                            selectItem = water;
                            break;
                        case "5":
                            selectItem = meal;
                            break;
                        case "6":
                            selectItem = sword;
                            break;

                    }

                    if (selectItem != null)
                    {
                        if(backpack.Add(selectItem))
                        {
                            Console.Write($"Lisättiin {selectItem.ToString()} reppuun.");
                        }
                        else
                        {
                            Console.WriteLine("EEEEEEIIIIIIIIIII MMEEENNNNNNNEEEE!!!!!!");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

