using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    internal class ConsoleUtility
    {
        public static int MenuChoice(int min, int max, string work)
        {
            Console.WriteLine($"원하시는 {work} 입력해주세요.");
            Console.Write(">>");
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("");
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                Console.Write(">>");
            }
        }

        public static int BattleChoice(Action<bool> action,string msg, string[] list,bool number =false)
        {
            int choice;

            while(true)
            {
                action(number);

                for(int i = 0; i < list.Length; i++)
                    Console.WriteLine(list[i]);

                Console.WriteLine();

                Console.Write("{0}\n>>", msg);

                if (int.TryParse(Console.ReadLine(), out choice)) return choice;

                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
            }
        }
        public static void PrintGameHeader()
        {
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleUtility.TextHighlights0("       _________                        __               ________                     ____                          ");
            ConsoleUtility.TextHighlights0("      /   _____/______ _____  _______ _/  |_ _____       \\______ \\   __ __   ____    / ___\\   ____   ____    ____   ");
            ConsoleUtility.TextHighlights0("      \\_____  \\ \\____ \\\\__  \\ \\_  __ \\\\   __\\\\__  \\       |    |  \\ |  |  \\ /    \\  / /_/  >_/ __ \\ /  _ \\  /    \\  ");
            ConsoleUtility.TextHighlights0("      /        \\|  |_> >/ __ \\_|  | \\/ |  |   / __ \\_     |    `   \\|  |  /|   |  \\ \\___  / \\  ___/(  <_> )|   |  \\ ");
            ConsoleUtility.TextHighlights0("     /_______  /|   __/(____  /|__|    |__|  (____  /    /_______  /|____/ |___|  //_____/   \\___  >\\____/ |___|  / ");
            ConsoleUtility.TextHighlights0("             \\/ |__|        \\/                    \\/             \\/             \\/               \\/             \\/  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleUtility.TextHighlights0("                                     __________          __     __   .__                                            ");
            ConsoleUtility.TextHighlights0("                                     \\______   \\_____  _/  |_ _/  |_ |  |    ____                                   ");
            ConsoleUtility.TextHighlights0("                                      |    |  _/\\__  \\ \\   __\\\\   __\\|  |  _/ __ \\                                  ");
            ConsoleUtility.TextHighlights0("                                      |    |   \\ / __ \\_|  |   |  |  |  |__\\  ___/                                  ");
            ConsoleUtility.TextHighlights0("                                      |______  /(____  /|__|   |__|  |____/ \\___  >                                 ");
            ConsoleUtility.TextHighlights0("                                             \\/      \\/                         \\/                                  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================================================================================");
            ConsoleUtility.TextHighlights0("                                                PRESS ANYKEY TO START                             ");
            Console.WriteLine("========================================================================================================================");
            Console.ReadKey();
        }
        public static void TextHighlights0(string s1 = "")
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s1);
            Console.ResetColor();
        }
        public static void TextHighlights1(string s1 = "")
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(s1);
            Console.ResetColor();
        }
    }
}

