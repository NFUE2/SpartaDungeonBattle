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

        public int lv = 1; //플레이어의 기본 레벨
        public int gold = 1500; //플레이어의 초기 Gold
        public int playerMp = 50; // 플레이어의 기본 mp
        public int maxMp = 50; // 플레이어의 최대 mp
        public int critical = 0; // 캐릭터의 크리티컬 보너스
        public int dodge = 0; // 캐릭터의 회피 보너스
        public int hit = 0; // 캐릭터의 명중 보너스
        public int bonus = 0; // 캐릭터의 보너스 스텟

        public string playerName; // 플레이어의 이름
        public string playerJob; // 플레이어의 직업
        public int job_Number; // 플레이어의 직업 번호
        public int playerAtk; // 플레이어의 공격력
        public int playerDef; // 플레이어의 방어력
        public int playerHp; // 플레이어의 기본 체력
        public int maxHp; // 플레이어의 최대 체력
        public string skillName1; //플레이어의 스킬1 이름 
        public string skillName2; //플레이어의 스킬2 이름
        public int skillMp1; //플레이어의 스킬1 Mp 소모량
        public int skillMp2; //플레이어의 스킬2 Mp 소모량
        public string skillAbility1; //플레이어의 스킬1 설명
        public string skillAbility2; //플레이어의 스킬2 설명

        public void FirstStatus(string name, string job, int jobNumber)
        {
            Console.Clear();
            Console.WriteLine($"{name}님의 캐릭터의 정보입니다.\n");

            Console.WriteLine("Lv. " + lv);
            Console.WriteLine(name + " ({0})", job);
            Console.WriteLine($"Gold : {gold} G");
            playerName = name; // 플레이어 이름 저장
            job_Number = jobNumber; //직업 번호 저장
            switch (jobNumber) //CreationCharater의 choice1의 값을 받아 직업을 불러온다.
            {
                case 1: //전사 선택 했을 시 전사 스텟 표시
                    Warrior warrior = new Warrior();
                    warrior.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {playerMp}");
                    Console.WriteLine("\n[스킬]");
                    warrior.ChraterSkill();

                    playerJob = "전사";
                    playerAtk = warrior.atk;
                    playerDef = warrior.def;
                    playerHp = warrior.hp;
                    maxHp = warrior.maxHp;
                    skillName1 = warrior.skillName1;
                    skillName2 = warrior.skillName2;
                    skillMp1 = warrior.skillMp1;
                    skillMp2 = warrior.skillMp2;
                    skillAbility1 = warrior.skillAbility1;
                    skillAbility2 = warrior.skillAbility2;
                    break;

                case 2://궁수를 선택 했을 시 궁수 스텟 표시
                    Archer archer = new Archer();
                    archer.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {playerMp}");
                    Console.WriteLine("\n[스킬]");
                    archer.ChraterSkill();

                    playerJob = "궁수";
                    playerAtk = archer.atk;
                    playerDef = archer.def;
                    playerHp = archer.hp;
                    maxHp = archer.maxHp;
                    skillName1 = archer.skillName1;
                    skillName2 = archer.skillName2;
                    skillMp1 = archer.skillMp1;
                    skillMp2 = archer.skillMp2;
                    skillAbility1 = archer.skillAbility1;
                    skillAbility2 = archer.skillAbility2;

                    break;

                case 3://도적을 선택 했을 시 도적 스텟 표시
                    Thief thief = new Thief();
                    thief.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {playerMp}");
                    Console.WriteLine("\n[스킬]");
                    thief.ChraterSkill();
                    
                    playerJob = "도적";
                    playerAtk = thief.atk;
                    playerDef = thief.def;
                    playerHp = thief.hp;
                    maxHp = thief.maxHp;
                    skillName1 = thief.skillName1;
                    skillName2 = thief.skillName2;
                    skillMp1 = thief.skillMp1;
                    skillMp2 = thief.skillMp2;
                    skillAbility1 = thief.skillAbility1;
                    skillAbility2 = thief.skillAbility2;

                    break;

                case 4://마법사 선택 했을 시 도적 스텟 표시
                    Magician magician = new Magician();
                    magician.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {playerMp}");
                    Console.WriteLine("\n[스킬]");
                    magician.ChraterSkill();
                    
                    playerJob = "마법사";
                    playerAtk = magician.atk;
                    playerDef = magician.def;
                    playerHp = magician.hp;
                    maxHp = magician.maxHp;
                    skillName1 = magician.skillName1;
                    skillName2 = magician.skillName2;
                    skillMp1 = magician.skillMp1;
                    skillMp2 = magician.skillMp2;
                    skillAbility1 = magician.skillAbility1;
                    skillAbility2 = magician.skillAbility2;

                    break;

                case 5://격투가 선택 했을 시 도적 스텟 표시
                    Fighter fighter = new Fighter();
                    fighter.ChraterStatus();
                    Console.WriteLine($"마나(MP) : {playerMp}");
                    Console.WriteLine("\n[스킬]");
                    fighter.ChraterSkill();
                    
                    playerJob = "격투가";
                    playerAtk = fighter.atk;
                    playerDef = fighter.def;
                    playerHp = fighter.hp;
                    maxHp = fighter.maxHp;
                    skillName1 = fighter.skillName1;
                    skillName2 = fighter.skillName2;
                    skillMp1 = fighter.skillMp1;
                    skillMp2 = fighter.skillMp2;
                    skillAbility1 = fighter.skillAbility1;
                    skillAbility2 = fighter.skillAbility2;

                    break;
            }

            Console.WriteLine("\n0. 게임 시작하기\n");

            int startChoice = ConsoleUtility.MenuChoice(0, 0, "원하시는 행동을");

            switch (startChoice)
            {
                case 0:
                    return;
            }
        }

        public void Player() //상태보기 메소드
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            Console.WriteLine("Lv. " + lv);
            Console.WriteLine($"{playerName}  ({playerJob})");
            Console.WriteLine($"Gold : {gold} G");
            Console.WriteLine($"공격력 : {playerAtk}");
            Console.WriteLine($"방어력 : {playerDef}");
            Console.WriteLine($"체  력 : {playerHp}");
            Console.WriteLine($"마나(MP) : {playerMp}");

            Console.WriteLine("\n[스킬]");
            Console.WriteLine($"1. {skillName1}  /  MP : {skillMp1}");
            Console.WriteLine($"{skillAbility1}");
            Console.WriteLine();
            Console.WriteLine($"2. {skillName2}  /  MP : {skillMp2}");
            Console.WriteLine($"{skillAbility2}");
            Console.WriteLine();

            Console.WriteLine("\n0. 나가기\n");

            int choice2 = ConsoleUtility.MenuChoice(0, 0, "원하시는 행동을");//나가기 입력 받기 
            switch (choice2)
            {
                case 0:
                    return;
            }
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            
            Console.WriteLine("Lv. " + lv);
            Console.WriteLine(playerName + " ({0})", playerJob);
            Console.WriteLine("공격력 : " + playerAtk);
            Console.WriteLine("방어력 : " + playerDef);
            Console.WriteLine("체  력 : " + playerHp);
            Console.WriteLine("Gold : " + gold + "G");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            int choice2 = ConsoleUtility.MenuChoice(0, 0, "행동을");//나가기 입력 받기 
            switch (choice2)
            {
                case 0:
                    return;
            }
        }
    }
}
