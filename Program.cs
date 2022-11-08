using System;

namespace Zametk
{
    public class Programm
    {
        public static bool checKeys(string dk, Dictionary<string, List<bip>> d1)
        {
            if (d1.Keys.Contains(dk))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Main(string[] argrs)
        {
            int pose = 1;
            Dictionary<string, List<bip>> all = new Dictionary<string, List<bip>>();
            MenuMain();
            foreach (var i in StandartZap())
            {
                if (checKeys(i.date, all))
                {
                    all[i.date].Add(i);
                }
                else
                {
                    all.Add(i.date, new List<bip>() { i });
                }
            }
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pose <= 1)
                    {
                        pose++;
                    }
                    else
                    {
                        pose--;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (pose >= 2)
                    {
                        pose--;
                    }
                    else
                    {
                        pose++;
                    }
                }
                Console.Clear();
                MenuMain();
                Console.SetCursorPosition(0, pose);
                Console.Write("->");
                if (key.Key == ConsoleKey.Enter && pose == 1)
                {
                    viewZam(all);
                }
                else if (key.Key == ConsoleKey.Enter && pose == 2)
                {
                    all = Zapis(all);
                    MenuMain();
                }
            }
        }
        static void MenuMain()
        {
            Console.WriteLine("Выбери выбор");
            Console.WriteLine("Заметки или заметки");
            Console.WriteLine("Создай свею шнягу");
        }
        public static Dictionary<string, List<bip>> Zapis(Dictionary<string, List<bip>> d1)
        {
            Console.Clear();
            Console.WriteLine("Введи название своей пометки: ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Что ты хочешь сделать?");
            string description = Console.ReadLine();
            Console.Clear();
            string date = DateTime.Today.ToString().Substring(0, 10);
            Console.WriteLine("А ты не забыл до какого времени её нужно сделать?");
            string deadline = Console.ReadLine();
            Console.Clear();
            bip nw = new bip(name, date, description, deadline);
            if (checKeys(date, d1))
            {
                d1[date].Add(nw);
            }
            else
            {
                d1.Add(date, new List<bip>() { nw });
            }
            return d1;
        }
        public static List<bip> StandartZap()
        {
            List<bip> l1 = new List<bip>();

            l1.Add(new bip("Послшуать музыку и преисполниться в её прогресивности",
                                "07.11.22",
                                "Ну как?",
                                "08.11.22"));

            l1.Add(new bip("Вынеси мусор, пж",
                               "18.02.21",
                               "Когда-нибудь",
                               "21.09.26"));

            l1.Add(new bip("Сбегать за поссылкой",
                                "19.03.23",
                                "Там важные бумажки",
                                "18.03.23"));
            return l1;
        }
        public static void viewZam(Dictionary<string, List<bip>> d1)
        {
            bool flag = false;
            int pose = 1;
            int ct = 0;
            Dictionary<int, bip> d2 = new Dictionary<int, bip>();
            foreach (var k in d1.Keys)
            {
                foreach (var j in d1[k])
                {
                    Console.WriteLine($"  {j.name}");
                    ct++;
                }
            }
            ConsoleKeyInfo key = Console.ReadKey();
            while (!flag)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    flag = true;
                    Console.Clear();
                    MenuMain();
                    break;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pose <= 1)
                    {
                        pose = ct;
                    }
                    else
                    {
                        pose--;
                    }
                 }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (pose >= ct)
                    {
                        pose = 1;
                    }
                    else
                    {
                        pose++;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    printZam(d2[pose], key);
                }
                ct = 0;
                d2.Clear();
                Console.Clear();
                Console.WriteLine("Шняги: ");
                foreach (var k in d1.Keys)
                {
                    foreach (var j in d1[k])
                    {
                        Console.WriteLine($"   {j.name}");
                        ct++;
                        d2.Add(ct, j);
                    }
                }
                Console.SetCursorPosition(0, pose);
                Console.Write("->");
            }
        }
        public static void printZam(bip list, ConsoleKeyInfo key)
        {
            while (key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                Console.Clear();
                Console.WriteLine(list.name);
                Console.WriteLine();
                Console.WriteLine(list.description);
                Console.WriteLine();
                Console.WriteLine("Где-то так: " + list.date);
                Console.WriteLine("Попробуй успеть: " + list.deadline);
            }
        }
    }
}