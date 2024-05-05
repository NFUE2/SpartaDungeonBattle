using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public class CreationCharater()
    {
        public string name;
        public string job;
        public int jobNumber;

        public void Creation()
        {
            Console.Clear();
            Console.WriteLine("\n스파르타 던전에 오신 여러분 환영합니다.\n"); 
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write(">>");
            name = Console.ReadLine(); //이름 입력

            Console.Clear();
            Console.WriteLine($"\n{name}님 환영합니다.\n");

            Console.WriteLine("┌─────────────────────────────────────────────┐");
            ConsoleUtility.TextHighlights0("  1. 전사    [가장 무난한 밸런스가 좋은 직업]"); //직업 상세 설명
            ConsoleUtility.TextHighlights0("  2. 궁수    [공격력은 높지만 장기전에 불리함]");
            ConsoleUtility.TextHighlights0("  3. 도적    [공격력은 높지만 장기전에 불리함]");
            ConsoleUtility.TextHighlights0("  4. 마법사  [노빠꾸 딜량, 원콤만이 살 길]");
            ConsoleUtility.TextHighlights0("  5. 격투가  [공방일체, 장기전에 좋은 직업]");
            Console.WriteLine("└─────────────────────────────────────────────┘\n");

            int jobChoice = ConsoleUtility.MenuChoice(1, 5, "원하시는 직업을");//선택지를 입력 받음

            switch (jobChoice)
            {
                case 1:
                    job = "전사";
                    jobNumber = 1;
                    Console.WriteLine("\n축하합니다. 전사로 전직하셨습니다.");
                    break;

                case 2:
                    job = "궁수";
                    jobNumber = 2;
                    Console.WriteLine("\n축하합니다. 궁수로 전직하셨습니다.");
                    break;

                case 3:
                    job = "도적";
                    jobNumber = 3;
                    Console.WriteLine("\n축하합니다. 도적으로 전직하셨습니다.");
                    break;

                case 4:
                    job = "마법사";
                    jobNumber = 4;
                    Console.WriteLine("\n축하합니다. 마법사로 전직하셨습니다.");
                    break;

                case 5:
                    job = "격투가";
                    jobNumber = 5;
                    Console.WriteLine("\n축하합니다. 격투가로 전직하셨습니다.");
                    break;
            }
        }
    }
}
