namespace FallingRocksOOP
{
    using System;
    using System.IO;
    using System.Threading;

    class ProgramMain
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;

            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (CrashExeption)
            {
                int startRow = Console.WindowHeight / 2 - 3;
                int startCol = Console.WindowWidth / 2 - 31;
                Console.Clear();
                
                using ( StreamReader sr = new StreamReader("../../GameOver.txt"))
                { 
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.SetCursorPosition(startCol, startRow);
                        Console.WriteLine(line);
                        startRow++;
                        Thread.Sleep(700);
                    }
                }                            
            }
            
        }
    }
}
