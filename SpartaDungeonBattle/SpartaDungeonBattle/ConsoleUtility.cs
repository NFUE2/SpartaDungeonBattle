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

        public static int MenuChoice(string title,string[] str,bool zero =false)
        {
            int choice;
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"{title}\n");

                for(int i = 0; i< str.Length; i++)
                    Console.WriteLine(str[i]);

                if(zero) Console.WriteLine("0. 돌아가기");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

                bool isSuccess = int.TryParse(Console.ReadLine(), out choice);

                if(!isSuccess || (choice == 0 && !zero) || choice > str.Length || choice < 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    continue;
                }

                return choice;
            }
        }
    }
}
