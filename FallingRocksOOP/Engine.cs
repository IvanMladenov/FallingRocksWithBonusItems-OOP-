namespace FallingRocksOOP
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using FallingRocksOOP.Exeptions;
    using FallingRocksOOP.Items;

    public class Engine
    {
        private readonly Dwarf dwarf = new Dwarf();

        private readonly IItem[] bonusItems = { new Freeze(), new Bomb(), new Speed() };

        public List<IItem[]> Items = new List<IItem[]>();

        private readonly Random rnd = new Random();

        private int speedControl = 15000;

        private int counter;

        public void Run()
        {
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();
            this.PrintDwarf();
            while (true)
            {
                this.counter++;
                while (Console.KeyAvailable)
                {
                    pressedKey = Console.ReadKey();
                    this.MoveDwarf(pressedKey);
                    this.PrintDwarf();
                }


                if (this.counter % this.speedControl == 0)
                {
                    IItem[] currentLine = this.GenerateLine(Console.WindowWidth / 20);
                    this.Items.Add(currentLine);
                    if (this.Items.Count == Console.WindowHeight + 1)
                    {
                        this.Items.RemoveAt(0);
                    }

                    this.MoveItems();
                    this.CheckForCrash();
                    this.speedControl -= 5;
                }
            }
        }

        private void CheckForCrash()
        {
            if (this.Items.Count == Console.WindowHeight)
            {
                foreach (var rock in this.Items[0])
                {
                    if (rock.Position.X == this.dwarf.Position.X ||
                    rock.Position.X == this.dwarf.Position.X + 1 ||
                    rock.Position.X == this.dwarf.Position.X + 2)
                    {
                        try
                        {
                            rock.Execute();
                        }
                        catch (BombExeption)
                        {
                            this.Items.Clear();
                            Console.Clear();
                        }
                        catch (SpeedExeption)
                        {
                            this.speedControl += 1000;
                        }
                    }
                }
            }

        }

        private void MoveDwarf(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (this.dwarf.Position.X != 0)
                {
                    Console.SetCursorPosition(this.dwarf.Position.X + 2, this.dwarf.Position.Y);
                    Console.Write(" ");
                    this.dwarf.Position = new Position(this.dwarf.Position.X - 1, this.dwarf.Position.Y);
                    this.CheckForCrash();
                }
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                if (this.dwarf.Position.X != Console.WindowWidth - 3)
                {
                    Console.SetCursorPosition(this.dwarf.Position.X, this.dwarf.Position.Y);
                    Console.Write(" ");
                    this.dwarf.Position = new Position(this.dwarf.Position.X + 1, this.dwarf.Position.Y);
                    this.CheckForCrash();
                }
            }
        }

        private IItem[] GenerateLine(int lineLenght)
        {
            IItem[] line = new IItem[lineLenght];

            if (this.counter % 100 == 0)
            {
                int index = rnd.Next(0, this.bonusItems.Length);
                IItem currentBonus = this.bonusItems[index];
                Type type = currentBonus.GetType();
                line[0] = (IItem)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            else
            {
                line[0] = new Rocks();
            }

            for (int i = 1; i < line.Length; i++)
            {
                Thread.Sleep(5);
                Rocks rock = new Rocks();
                line[i] = rock;
            }

            return line;
        }

        private void PrintDwarf()
        {
            Console.SetCursorPosition(this.dwarf.Position.X, this.dwarf.Position.Y);
            Console.ForegroundColor = this.dwarf.Color;
            Console.Write(this.dwarf);
        }

        private void MoveItems()
        {
            foreach (var line in this.Items)
            {
                Console.SetCursorPosition(0, line[0].Position.Y);
                Console.Write(new string(' ', Console.WindowWidth));
                this.PrintDwarf();

                foreach (var item in line)
                {
                    Console.SetCursorPosition(item.Position.X, item.Position.Y);
                    Console.ForegroundColor = item.ForegroundColor;
                    Console.BackgroundColor = item.BackgroundColor;
                    Console.Write(item);
                    Console.BackgroundColor = ConsoleColor.Black;
                    item.Position = new Position(item.Position.X, item.Position.Y + 1);
                }
            }
        }
    }
}
