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
    }
}
