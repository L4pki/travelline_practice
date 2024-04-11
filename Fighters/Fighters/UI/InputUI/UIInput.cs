﻿using Fighters.Models.Armors.AvaliableArmor;
using Fighters.Models.Fighters;
using Fighters.Models.Races.AvaliableRaces;
using Fighters.Models.Weapons.AvaliableWeapon;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.Models.Armors;
using Fighters.UI.OutputUI;
using System;

namespace Fighters.UI.InputUI
{
    public class UIInput : IUIInput
    {
        public string ChooseName()
        {
            while (true)
            {
                Console.WriteLine("Введите имя Воина:\n(До 10 символов) ");
                string NameFighter = Console.ReadLine();
                if (NameFighter == "")
                {
                    return "Безымянный";
                }
                if (NameFighter.Length <= 10)
                {
                    Console.Clear();
                    return NameFighter;
                }
                Console.WriteLine("Имя превышает лимит символов!");
            }
        }
        public IRace ChooseRace()
        {
            Console.Clear();
            Console.WriteLine("Введите номер Воина:\n" +
                "(1) Дворф\n" +
                "(2) Эльфа\n" +
                "(3) Человек\n" +
                "(4) Орк\n" +
                "(5) Рандом\n");
            int numberFighter = 0;
            while (true)
            {
                try
                {
                    numberFighter = int.Parse(Console.ReadLine());
                    if (numberFighter == 5)
                    {
                        Random random = new Random();
                        numberFighter = random.Next(1, 4);
                    }
                }
                catch
                {
                    Console.WriteLine("Вы ввели неккоректные данные!");
                }
                switch (numberFighter)
                {
                    case 1:
                        return new Dworf();
                    case 2:
                        return new Elf();
                    case 3:
                        return new Human();
                    case 4:
                        return new Orc();
                    default:
                        Console.WriteLine("Введите номер Воина!");
                        break;
                }
            }
        }
        public IWeapon ChooseWeapon()
        {
            Console.Clear();
            Console.WriteLine("Введите номер Оружия:\n" +
               "(1) Топоры\n" +
               "(2) Лук\n" +
               "(3) Молот\n" +
               "(4) Ножи\n" +
               "(5) Меч\n" +
               "(6) Кулаки\n" +
               "(7) Рандом\n");
            int numberWeapon = 0;
            while (true)
            {
                try
                {
                    numberWeapon = int.Parse(Console.ReadLine());
                    if (numberWeapon == 7)
                    {
                        Random random = new Random();
                        numberWeapon = random.Next(1, 6);
                    }
                }
                catch
                {
                    Console.WriteLine("Вы ввели неккоректные данные!");
                }
                switch (numberWeapon)
                {
                    case 1:
                        return new Axes();
                    case 2:
                        return new Bow();
                    case 3:
                        return new Hammer();
                    case 4:
                        return new Knifes();
                    case 5:
                        return new Sword();
                    case 6:
                        return new NoWeapon();
                    default:
                        Console.WriteLine("Введите номер Оружия!");
                        break;
                }
            }
        }
        public IArmor ChooseArmor()
        {
            Console.Clear();
            Console.WriteLine("Введите номер Доспеха:\n" +
                "(1) Без доспеха\n" +
                "(2) Легкий доспех\n" +
                "(3) Средний доспех\n" +
                "(4) Тяжелый доспех\n" +
                "(5) Рандом\n");
            int numberArmor = 0;
            while (true)
            {
                try
                {
                    numberArmor = int.Parse(Console.ReadLine());
                    if (numberArmor == 5)
                    {
                        Random random = new Random();
                        numberArmor = random.Next(1, 4);
                    }
                }
                catch
                {
                    Console.WriteLine("Вы ввели неккоректные данные!");
                }
                switch (numberArmor)
                {
                    case 1:
                        return new NoArmor();
                    case 2:
                        return new LightArmor();
                    case 3:
                        return new MediumArmor();
                    case 4:
                        return new HeavyArmor();
                    default:
                        Console.WriteLine("Введите номер Доспеха!");
                        break;
                }
            }
        }
        public Fighter ChooseFighter()
        {
            var Fighter = new Fighter(ChooseName(), ChooseRace(), ChooseWeapon(), ChooseArmor());
            Console.Clear();
            return Fighter;
        }
        public int[] SelectNumberFighters()
        {
            int[] NumFighters = new int[2];
            var UIO = new UIOutput();
            while (true)
            {
                try
                {
                    Console.Write("Введите количество бойцов ");
                    UIO.WriteLine("Красной команды", "red");
                    NumFighters[0] = int.Parse(Console.ReadLine());
                    Console.Write("Введите количество бойцов ");
                    UIO.WriteLine("Синей команды", "Blue");
                    NumFighters[1] = int.Parse(Console.ReadLine());
                    return NumFighters;
                }
                catch
                {
                    Console.WriteLine("Неккоректные данные");
                }
            }
        }
        public IFighter[] ChooseTeam(int NumberFightersOnTeam, bool IsRed, string color)
        {
            var UIO = new UIOutput();
            var UII = new UIInput();
            IFighter[] Team = new IFighter[NumberFightersOnTeam];
            for (int i = 0; i < NumberFightersOnTeam; i++)
            {
                Console.Write($"Введите {i + 1} бойца ");
                UIO.WriteLine($"{color} команды: ", color);
                Team[i] = UII.ChooseFighter();
                Team[i].IsRedTeam = IsRed;
            }
            return Team;
        }
    }
}

