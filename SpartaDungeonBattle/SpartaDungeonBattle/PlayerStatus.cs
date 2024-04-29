using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public class PlayerStatus
    {
        CreationCharater creation;
        CharaterJob charater = new CharaterJob();
        public int lv = 1;
        public int gold = 1500;
        

        public void Player(string name, string job, int jobNumber) //상태보기 메소드
        {
            Console.WriteLine();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            Console.WriteLine("Lv. " + lv);
            Console.WriteLine(name + " ({0})", job);
            switch (jobNumber) //CreationCharater의 choice1의 값을 받아 직업을 불러온다.
            {
                case 1: //전사 선택 했을 시 전사 스텟 표시
                    Warrior warrior = new Warrior();
                    warrior.ChraterStatus();
                    break;
                case 2://궁수를 선택 했을 시 궁수 스텟 표시
                    Archer archer = new Archer();
                    archer.ChraterStatus();
                    break;
                case 3://도적을 선택 했을 시 도적 스텟 표시
                    Thief thief = new Thief();
                    thief.ChraterStatus();
                    break;
                case 4://마법사 선택 했을 시 도적 스텟 표시
                    Magician magician = new Magician(); 
                    magician.ChraterStatus();
                    break;
                case 5://격투가 선택 했을 시 도적 스텟 표시
                    Fighter fighter = new Fighter();
                    fighter.ChraterStatus();
                    break;
            }
            Console.WriteLine("Gold : " + gold + "G");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int choice2 = ConsoleUtility.MenuChoice(0, 0);//나가기 입력 받기 
            switch (choice2)
            {
                case 0:
                    //메인 화면으로 이동
                    break;
            }
        }
    }
}
