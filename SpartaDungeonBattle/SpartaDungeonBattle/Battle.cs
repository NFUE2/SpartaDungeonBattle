using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SpartaDungeonBattle
{
    public class Battle
    {
        PlayerStatus player;
        List<Enemy> enemyList;
        bool win;
        int killCount, playerCurHp;

        public void DungeonBattle(ref PlayerStatus player)
        {
            win = false;
            killCount = 0;
            enemyList = new List<Enemy>();
            this.player = player;
            playerCurHp = player.playerHp;

            Random random = new Random();
            int count = random.Next(4);
            //playerHP = ; //플레이어 체력 기입 필요

            for (int i = 0; i <= count; i++)
            {
                int monster = random.Next(0, 3);

                switch (monster)
                {
                    case 0:
                        enemyList.Add(new Minion());
                        break;
                    case 1:
                        enemyList.Add(new HollowWorm());
                        break;
                    case 2:
                        enemyList.Add(new SiegeMinion());
                        break;
                }
            }

            BattleStart();
        }

        void BattleStart()
        {
            while (true)
            {
                PlayerPhase();
                EnemyPhase();

                if (killCount == enemyList.Count)
                {
                    win = true;
                    break;
                }
                else if(playerCurHp <= 0)
                {
                    break;
                }
            }
            BattleResult();
        }

        void BattleDisplay(bool number = false)
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("  Battle!!\n");

            for (int i = 0; i < enemyList.Count; i++)
            {
                if (number) Console.Write($"  [{i + 1}]");
                enemyList[i].Display();
            }

            Console.WriteLine();

            ConsoleUtility.TextHighlights0("  [내정보]");
            ConsoleUtility.TextHighlights2($"  Lv.{player.lv}  {player.playerName} ( {player.playerJob} )"); //레벨,직업 기입 필요
            ConsoleUtility.TextHighlights2($"  HP {playerCurHp}/{player.playerMaxHp}"); //체력 기입 필요
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────┘\n");
        }

        void PlayerPhase()
        {
            int choice;

            while (true)
            {
                PlayerChoice();

                choice = PlayerChoiceTarget();

                switch (choice)
                {
                    case -1:
                        continue;
                    default:
                        break;
                }

                PlayerAttack(enemyList[choice]);
                break;
            }
        }

        void PlayerChoice()
        {
            Console.Clear();

            int choice;

            string[] arr = { "1.공격" };

            while(true)
            {
                choice = ConsoleUtility.BattleChoice(BattleDisplay, "원하시는 행동을 입력해주세요.", arr);

                switch (choice)
                {
                    case 1:
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        int PlayerChoiceTarget()
        {
            Console.Clear();

            int choice;

            string[] arr = { "0.취소" };


            while (true)
            {
                choice = ConsoleUtility.BattleChoice(BattleDisplay, "대상을 선택해주세요.", arr, true);

                switch (choice)
                {
                    case 0:
                        return -1;
                    default:
                        if((choice > 0 && choice <= enemyList.Count) && enemyList[choice - 1].state != State.Dead) 
                            return choice - 1;

                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        void PlayerAttack(Enemy e)
        {
            int choice;
            Console.Clear();
            Random random = new Random();
            int p = (int)Math.Ceiling((double)player.playerAtk * 0.1); //10% 보정값 올림,플레이어 공격력
            int damage = random.Next(player.playerAtk - p, player.playerAtk + p + 1); //보정값을 추가한 랜덤 공격력
            int hit = random.Next(1, 100); //명중률값 랜덤 생성

            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine($"  {player.playerName}의 공격!\n");
            if (hit > 10) // 명중률 수치가  10을 넘을 경우 데미지 판정 발생
            {
                int critical = random.Next(1, 100); //크리티컬값 랜덤 생성
                if(critical <= 15) // 크리티컬 수치가 15이하일 경우 크리티컬 판정 발생
                {
                    double attack = damage * 1.6;
                    damage = (int)Math.Round(attack);
                    Console.WriteLine($"  Lv.{e.level} {e.name} 을(를) 맞췄습니다. [데미지 : {damage}]『치명타 공격!!』\n"); //치명타 데미지 발생
                }
                else // 크리티컬 판정 불발 시 
                {
                    Console.WriteLine($"  Lv.{e.level} {e.name} 을(를) 맞췄습니다. [데미지 : {damage}]\n"); //데미지 발생
                }
                int curHP = e.hp - damage;
                Console.Write($"  HP {e.hp} -> ");

                if (curHP > 0)
                {
                    e.hp = curHP;
                    Console.WriteLine($"{curHP}");
                }
                else
                {
                    e.state = State.Dead;
                    killCount++;
                    Console.WriteLine($"Dead");

                    if (!player.monsterRecorde.ContainsKey(e.name))
                        player.monsterRecorde.Add(e.name,0);

                    player.monsterRecorde[e.name]++;
                }
            }
            else // 명중률 수치가 10 이하가 나올 시 데미지 발생 안함
            {
                Console.WriteLine($"  Lv.{e.level} {e.name} 을(를) 공격했지만 아무일도 일어나지 않았습니다."); //데미지 발생 안함
            }
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────┘\n");

            string[] arr = { "0.다음" };
            choice = ConsoleUtility.BattleChoice((bool none) => { }, "",arr,false);

            while (true)
            {   
                switch (choice)
                {
                    case 0:
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        void EnemyPhase()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                Console.Clear();
                Enemy e = enemyList[i];

                if (e.state == State.Dead) continue;

                Random random = new Random();//랜덤 클래스 호출
                int dodge = new Random().Next(1, 100); // 회피률값 랜덤 생성
                int p = (int)Math.Ceiling((double)e.atk * 0.1f); //10% 보정값 올림
                int damage = random.Next(e.atk - p, e.atk + p + 1); //보정값을 추가한 랜덤 공격력

                Console.WriteLine("┌──────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine($"  {e.name}의 공격!\n"); // 적의 공격 선언
                if (dodge > 10) //회피 값이 10 이상 나올 시 회피 실패(데미지 판정)
                {
                    int enemyCritical = new Random().Next(1, 100); // 1~100 사이의 수를 크리티컬 값에 저장

                    if (enemyCritical <= 15) // 크리티컬 값이 15 이하인 경우 크리티컬 발생
                    {
                        double enemyAttack = damage * 1.6; //크리티컬이 적용된 데미지
                        damage = (int)Math.Round(enemyAttack); //데미지에 크리티컬 데미지 (반올림해서) 저장
                        Console.WriteLine($"  {player.playerName} 을(를) 맞췄습니다.『치명타 공격!!』[데미지 : {damage}]\n"); //플레이어 및 ,데미지 기입필요
                    }
                    else // 크리티컬 발생 안함
                    {
                        Console.WriteLine($"  {player.playerName} 을(를) 맞췄습니다. [데미지 : {damage}]\n"); //플레이어 및 ,데미지 기입필요
                    }

                    Console.WriteLine($"  Lv.{player.lv} {player.playerName}\n");

                    Console.WriteLine($"  HP {playerCurHp} -> {playerCurHp - damage}"); //캐릭터 hp 필요
                    playerCurHp = playerCurHp - damage;
                }
                else // 회피값이 10이하면 회피 성공 (데미지 발생)
                {
                    Console.WriteLine($"  {player.playerName} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n"); //데미지 발생 안함

                    Console.WriteLine($"  Lv.{player.lv} {player.playerName}\n");
                    Console.WriteLine($"  HP {playerCurHp}"); //캐릭터 hp 필요
                }
                Console.WriteLine("└──────────────────────────────────────────────────────────────────────┘\n");

                if (playerCurHp <= 0) //캐릭터 체력이 0 보다 작을경우
                    return;

                while (true)
                {
                    int choice;

                    Console.Write("0.다음\n>>");

                    if (int.TryParse(Console.ReadLine(), out choice) && choice == 0) break;
                    else Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        void BattleResult()
        {
            Console.Clear();
            Console.WriteLine("┌─────────────────────────────────────────────────────┐");
            Console.WriteLine("  Battle!! - Result\n");

            if (win)
            {
                Console.WriteLine("  Victory\n");
                Console.WriteLine($"  던전에서 몬스터 {killCount}마리를 잡았습니다.\n");

                Console.WriteLine($"  Lv.{player.lv} {player.playerName}"); //레벨과 이름을 넣어야함
                Console.WriteLine($"  Hp {player.playerHp} -> {playerCurHp}");

                ref int hp = ref player.playerHp;
                hp = playerCurHp;
            }
            else
            {
                Console.WriteLine("  You Lose");
                Console.WriteLine("  스파르타 던전 입구로 돌아갑니다.");
            }
            Console.WriteLine("└─────────────────────────────────────────────────────┘\n");

            Console.Write("0.다음\n>>");
            Console.ReadLine();
        }
    }
}