using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpartaDungeonBattle
{
    public class PlayerStatus
    {
        CreationCharater creation = new CreationCharater();
        CharaterJob charater = new CharaterJob();
        public int lv = 1;
        public int gold = 1500;
        public int playerMp = 50; //Mp 적용 (선택사항5)

        public string playerName;
        public string playerJob;
        public int job_Number;
        public int playerAtk;
        public int playerDef;
        public int playerHp;
        
        public void FirstStatus(string name, string job, int jobNumber)
        {
            Console.Clear();
            Console.WriteLine($"{name}님의 캐릭터의 정보입니다.\n");

            Console.WriteLine("Lv. " + lv);
            Console.WriteLine(name + " ({0})", job);
            Console.WriteLine("Gold : " + gold + " G");
            playerName = name; // 플레이어 이름 저장
            job_Number = jobNumber; //직업 번호 저장
            switch (jobNumber) //CreationCharater의 choice1의 값을 받아 직업을 불러온다.
            {
                case 1: //전사 선택 했을 시 전사 스텟 표시
                    Warrior warrior = new Warrior();
                    warrior.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    playerJob = "전사";
                    playerAtk = warrior.atk;
                    playerDef = warrior.def;
                    playerHp = warrior.hp;
                    Console.WriteLine("\n[스킬]");
                    warrior.ChraterSkill();
                    break;

                case 2://궁수를 선택 했을 시 궁수 스텟 표시
                    Archer archer = new Archer();
                    archer.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    playerJob = "궁수";
                    playerAtk = archer.atk;
                    playerDef = archer.def;
                    playerHp = archer.hp;
                    Console.WriteLine("\n[스킬]");
                    archer.ChraterSkill();
                    break;

                case 3://도적을 선택 했을 시 도적 스텟 표시
                    Thief thief = new Thief();
                    thief.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    playerJob = "도적";
                    playerAtk = thief.atk;
                    playerDef = thief.def;
                    playerHp = thief.hp;
                    Console.WriteLine("\n[스킬]");
                    thief.ChraterSkill();
                    break;

                case 4://마법사 선택 했을 시 도적 스텟 표시
                    Magician magician = new Magician();
                    magician.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    playerJob = "마법사";
                    playerAtk = magician.atk;
                    playerDef = magician.def;
                    playerHp = magician.hp;
                    Console.WriteLine("\n[스킬]");
                    magician.ChraterSkill();
                    break;

                case 5://격투가 선택 했을 시 도적 스텟 표시
                    Fighter fighter = new Fighter();
                    fighter.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    playerJob = "격투가";
                    playerAtk = fighter.atk;
                    playerDef = fighter.def;
                    playerHp = fighter.hp;
                    Console.WriteLine("\n[스킬]");
                    fighter.ChraterSkill();
                    break;
            }

            Console.WriteLine("\n0. 게임 시작하기\n");

            int startChoice = ConsoleUtility.MenuChoice(0, 0, "행동을");

            switch (startChoice)
            {
                case 0:
                    return;
            }
        }

        public void Player(string name, string job, int jobNumber) //상태보기 메소드
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            Console.WriteLine("Lv. " + lv);
            Console.WriteLine(name + " ({0})", job);
            playerName = name; // 플레이어 이름 저장
            Console.WriteLine("Gold : " + gold + " G");
            switch (jobNumber) //CreationCharater의 choice1의 값을 받아 직업을 불러온다.
            {
                case 1: //전사 선택 했을 시 전사 스텟 표시
                    Warrior warrior = new Warrior();
                    warrior.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    Console.WriteLine("\n[스킬]");
                    warrior.ChraterSkill();
                    break;

                case 2://궁수를 선택 했을 시 궁수 스텟 표시
                    Archer archer = new Archer();
                    archer.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    Console.WriteLine("\n[스킬]");
                    archer.ChraterSkill();
                    
                    break;
                case 3://도적을 선택 했을 시 도적 스텟 표시
                    Thief thief = new Thief();
                    thief.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    Console.WriteLine("\n[스킬]");
                    thief.ChraterSkill();
                    break;
                case 4://마법사 선택 했을 시 도적 스텟 표시
                    Magician magician = new Magician(); 
                    magician.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    Console.WriteLine("\n[스킬]");
                    magician.ChraterSkill();
                    break;
                case 5://격투가 선택 했을 시 도적 스텟 표시
                    Fighter fighter = new Fighter();
                    fighter.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {charater.mp}");
                    Console.WriteLine("\n[스킬]");
                    fighter.ChraterSkill();
                    break;
            }
            
            Console.WriteLine("0. 나가기");


            int choice2 = ConsoleUtility.MenuChoice(0, 0, "행동을");//나가기 입력 받기 
            switch (choice2)
            {
                case 0:
                    return;
            }
        }
    }
}
