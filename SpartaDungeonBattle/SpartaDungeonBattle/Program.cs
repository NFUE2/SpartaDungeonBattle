﻿using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.IO;

namespace SpartaDungeonBattle
{

    public class Program
    {
        static void Main(string[] args)
        {
            CreationCharater creation = new CreationCharater();
            PlayerStatus status = new PlayerStatus();
            Battle battle = new Battle();


            Console.Clear();
            ConsoleUtility.PrintGameHeader(); //
            creation.Creation(); //캐릭터 생성 실행
            status.FirstStatus(creation.name, creation.job, creation.jobNumber);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 {0}님 환영합니다.", creation.name);
                Console.WriteLine("이제 전투를 시작할 수 있습니다.");
                Console.WriteLine();

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 전투 시작");
                Console.WriteLine("3. 저장 및 종료");
                Console.WriteLine("4. 저장 초기화");
                Console.WriteLine();

                int choice1 = ConsoleUtility.MenuChoice(1, 4, "원하시는 행동을"); //행동 선택
                switch (choice1)
                {
                    case 1: //1번 실행 시 스테이터스(상태 보기) 열람

                        Console.WriteLine(status.playerHp);
                        status.Player();
                        break;

                    case 2: //2번 실행 시 전투 시작
                        battle.DungeonBattle(ref status);
                        break;
                }
            }
        }
    }
}
