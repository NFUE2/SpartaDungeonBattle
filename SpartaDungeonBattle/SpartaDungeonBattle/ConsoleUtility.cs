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
        public static void PrintGameHeader() //게임 화면
        {
            ConsoleUtility.TextHighlights0("========================================================================================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleUtility.TextHighlights2("       _________                        __               ________                     ____                          ");
            ConsoleUtility.TextHighlights2("      /   _____/______ _____  _______ _/  |_ _____       \\______ \\   __ __   ____    / ___\\   ____   ____    ____   ");
            ConsoleUtility.TextHighlights2("      \\_____  \\ \\____ \\\\__  \\ \\_  __ \\\\   __\\\\__  \\       |    |  \\ |  |  \\ /    \\  / /_/  >_/ __ \\ /  _ \\  /    \\  ");
            ConsoleUtility.TextHighlights2("      /        \\|  |_> >/ __ \\_|  | \\/ |  |   / __ \\_     |    `   \\|  |  /|   |  \\ \\___  / \\  ___/(  <_> )|   |  \\ ");
            ConsoleUtility.TextHighlights2("     /_______  /|   __/(____  /|__|    |__|  (____  /    /_______  /|____/ |___|  //_____/   \\___  >\\____/ |___|  / ");
            ConsoleUtility.TextHighlights2("             \\/ |__|        \\/                    \\/             \\/             \\/               \\/             \\/  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleUtility.TextHighlights2("                                     __________          __     __   .__                                            ");
            ConsoleUtility.TextHighlights2("                                     \\______   \\_____  _/  |_ _/  |_ |  |    ____                                   ");
            ConsoleUtility.TextHighlights2("                                      |    |  _/\\__  \\ \\   __\\\\   __\\|  |  _/ __ \\                                  ");
            ConsoleUtility.TextHighlights2("                                      |    |   \\ / __ \\_|  |   |  |  |  |__\\  ___/                                  ");
            ConsoleUtility.TextHighlights2("                                      |______  /(____  /|__|   |__|  |____/ \\___  >                                 ");
            ConsoleUtility.TextHighlights2("                                             \\/      \\/                         \\/                                  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleUtility.TextHighlights0("========================================================================================================================");
            ConsoleUtility.TextHighlights2("                                                PRESS ANYKEY TO START                             ");
            ConsoleUtility.TextHighlights0("========================================================================================================================");
            Console.ReadKey();
        }
        public static void TextHighlights0(string s1 = "") //노란색으로 폰트 색상 변경
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s1);
            Console.ResetColor();
        }
        public static void TextHighlights1(string s1 = "") //빨간색으로 폰트 색상 변경
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(s1);
            Console.ResetColor();
        }

        public static void TextHighlights2(string s1 = "") //초록색으로 폰트 색상 변경
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s1);
            Console.ResetColor();
        }

        public static int MenuChoice(int min, int max, string work) //선택지 메소드
        {
            Console.WriteLine($"{work} 입력해주세요.");
            Console.Write(">>");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요");
                Console.Write(">>");
            }
        }

        public static int BattleChoice(Action<bool> action,string msg, string[] list,bool number =false) //전투 시 선택지
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
    }
}
