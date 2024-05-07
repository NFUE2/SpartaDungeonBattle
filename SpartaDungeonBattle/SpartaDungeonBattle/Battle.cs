using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SpartaDungeonBattle
{
    public class Battle
    {
        PlayerStatus player;
        List<Enemy> enemyList;
        bool win;
        int killCount, playerCurHp, playerCurMp;

        public void DungeonBattle(ref PlayerStatus player)
        {
            win = false;
            killCount = 0;
            enemyList = new List<Enemy>();
            this.player = player;
            playerCurHp = player.playerHp;
            playerCurMp = player.playerMp;

            Random random = new Random();
            int count = random.Next(4);

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
            ConsoleUtility.TextHighlights3($"  Lv.{player.lv}  {player.playerName} ( {player.playerJob} )"); //레벨,직업 기입 필요
            ConsoleUtility.TextHighlights3($"  HP {playerCurHp}/{player.playerMaxHp}"); //체력 기입 필요
            ConsoleUtility.TextHighlights3($"  MP {playerCurMp}/{player.maxMp}");
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────┘\n");
        }

        void PlayerPhase()
        {
            int attackChoice;
            int targetChoice;

            while (true)
            {
                attackChoice = PlayerChoice();

                targetChoice = PlayerChoiceTarget();

                switch (targetChoice)
                {
                    case -1:
                        continue;
                    default:
                        break;
                }

                switch (attackChoice)
                {
                    case 1:
                        PlayerAttack(enemyList[targetChoice]);
                        break;
                    case 2:
                        PlayerSkillAttack(enemyList[targetChoice], ref player);
                        playerCurMp -= player.playerS_Mp1;
                        break;
                }
                
                break;
            }
        }

        int PlayerChoice()
        {
            Console.Clear();

            int choice;

            string[] arr = { "1.공격", "2.스킬" };

            while(true)
            {
                choice = ConsoleUtility.BattleChoice(BattleDisplay, "원하시는 행동을 입력해주세요.", arr);

                switch (choice)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
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

        void playerSkillChoice()
        {
            while (true)
            {
                Console.WriteLine();
                player.ChraterSkill();
                Console.WriteLine("  0.취소\n");
                int choice = ConsoleUtility.MenuChoice(0, 1, "원하시는 스킬을");
                switch (choice)
                {
                    case 0:
                        PlayerPhase();
                        break;

                    case 1:
                        if (playerCurMp > player.playerS_Mp1)
                            return;
                        else
                            Console.WriteLine("Mp가 부족합니다.");
                            break;
                }
            }
            
        }

        void PlayerAttack(Enemy e)
        {
            int choice;
            Console.Clear();
            Random random = new Random();
            int p = (int)Math.Ceiling((double)player.playerAtk * 0.1);
            int damage = random.Next(player.playerAtk - p, player.playerAtk + p + 1);
            int hit = random.Next(1, 100); //명중률값 랜덤 생성

            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────┐");
            ConsoleUtility.TextHighlights2($"  {player.playerName}");
            Console.WriteLine("의 공격!\n");
            if (hit > 10) // 명중률 수치가  10을 넘을 경우 데미지 판정 발생
            {
                int critical = random.Next(1, 100);

                if (critical < 15) // 크리티컬 발동 조건에서 스킬 보너스가 가산된다.
                {
                    double attack = damage * 1.6;
                    damage = (int)Math.Round(attack);
                    ConsoleUtility.TextHighlights1($"  Lv.{e.level} {e.name} ");
                    Console.WriteLine($"을(를) 맞췄습니다. [데미지 : {damage}]『치명타 공격!!』\n"); //치명타 데미지 발생
                }
                else // 크리티컬 불발
                {
                    ConsoleUtility.TextHighlights1($"  Lv.{e.level} {e.name} ");
                    Console.WriteLine($"을(를) 맞췄습니다. [데미지 : {damage}]\n"); //데미지 발생
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
                    ConsoleUtility.TextHighlights1($"Dead\n");
                }
            }
            else // 명중률 수치가 10 이하가 나올 시 데미지 발생 안함
            {
                ConsoleUtility.TextHighlights1($"  Lv.{e.level} {e.name} ");
                Console.WriteLine($"을(를) 공격했지만 아무일도 일어나지 않았습니다."); //데미지 발생 안함
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

        void PlayerSkillAttack(Enemy e, ref PlayerStatus player)
        {
            int choice, curMp;
            Console.Clear();
            Random random = new Random();
            int p = (int)Math.Ceiling((double)player.playerAtk * 0.1);
            int damage = random.Next(player.playerAtk - p, player.playerAtk + p + 1);
            double skill_damage = damage * player.skillPersent;
            
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────┐");
            ConsoleUtility.TextHighlights2($"  {player.playerName}");
            Console.Write("의 ");
            ConsoleUtility.TextHighlights0($"{player.playerSN1}!!");

                int critical = random.Next(1, 100);

                if (critical < player.skillBonus + 15) // 크리티컬 발동 조건에서 스킬 보너스가 가산된다.
                {
                    double attack = skill_damage * 1.6;
                    damage = (int)Math.Round(attack);
                    ConsoleUtility.TextHighlights1($"  Lv.{e.level} {e.name} ");
                    Console.WriteLine($"을(를) 맞췄습니다. [데미지 : {damage}]『치명타 공격!!』\n"); //치명타 데미지 발생
                }
                else // 크리티컬 불발
                {
                    damage = (int)Math.Round(skill_damage);
                    ConsoleUtility.TextHighlights1($"  Lv.{e.level} {e.name} ");
                    Console.WriteLine($"을(를) 맞췄습니다. [데미지 : {damage}]\n"); //데미지 발생
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
                    ConsoleUtility.TextHighlights1($"Dead\n");
                }
            
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────┘\n");

            string[] arr = { "0.다음" };
            choice = ConsoleUtility.BattleChoice((bool none) => { }, "", arr, false);

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
                ConsoleUtility.TextHighlights1($"  {e.name}");
                Console.WriteLine("의 공격!\n"); // 적의 공격 선언
                if (dodge > 10) //회피 값이 10 이상 나올 시 회피 실패(데미지 판정)
                {
                    int enemyCritical = new Random().Next(1, 100); // 1~100 사이의 수를 크리티컬 값에 저장

                    if (enemyCritical <= 15) // 크리티컬 값이 15 이하인 경우 크리티컬 발생
                    {
                        double enemyAttack = damage * 1.6; //크리티컬이 적용된 데미지
                        damage = (int)Math.Round(enemyAttack); //데미지에 크리티컬 데미지 (반올림해서) 저장
                        ConsoleUtility.TextHighlights2($"  {player.playerName}");
                        Console.WriteLine($" 을(를) 맞췄습니다. [데미지 : {damage}]『치명타 공격!!』\n"); //플레이어 및 ,데미지 기입필요
                    }
                    else // 크리티컬 발생 안함
                    {
                        ConsoleUtility.TextHighlights2($"  {player.playerName}");
                        Console.WriteLine($" 을(를) 맞췄습니다. [데미지 : {damage}]\n"); //플레이어 및 ,데미지 기입필요
                    }

                    ConsoleUtility.TextHighlights3($"  Lv.{player.lv} {player.playerName}");
                    ConsoleUtility.TextHighlights3($"  HP {playerCurHp} -> {playerCurHp - damage}"); //캐릭터 hp 필요
                    playerCurHp = playerCurHp - damage;
                }
                else // 회피값이 10이하면 회피 성공 (데미지 발생)
                {
                    Console.WriteLine($"  {player.playerName} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n"); //데미지 발생 안함

                    ConsoleUtility.TextHighlights3($"  Lv.{player.lv} {player.playerName}");
                    ConsoleUtility.TextHighlights3($"  HP {playerCurHp}"); //캐릭터 hp 필요
                }
                Console.WriteLine("└──────────────────────────────────────────────────────────────────────┘\n");

                if (playerCurHp <= 0) //캐릭터 체력이 0 보다 작을경우
                {
                    Thread.Sleep(1000);
                    return;
                }

                while (true)
                {
                    int choice;

                    Console.Write("0.다음\n>>");

                    if (int.TryParse(Console.ReadLine(), out choice) && choice == 0) break;
                    else Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        void RewardGold(ref PlayerStatus player)
        {
            int rewardGold = 0;
            int addReward = 0;

            for (int i = 0; i < enemyList.Count; i++) // 잡은 몹에 따라 골드 획득량 증가
            {
                Enemy e = enemyList[i];
                switch (e.enemyNumber)
                {
                    case 1:
                        addReward += 100;
                        break;
                    case 2:
                        addReward += 300;
                        break;
                    case 3:
                        addReward += 150;
                        break;
                }
            }
            rewardGold = addReward;

            ConsoleUtility.TextHighlights2($"  {addReward}");
            Console.WriteLine(" Gold");
            player.gold += rewardGold;
        }

        void RewardPotion(ref PlayerStatus player) // 던전 클리어 후 드랍된 포션
        {
            int rewardHpPotion = 0;
            int rewardMpPotion = 0;
            int rewardHyperPotion = 0;

            for (int j = 0; j < enemyList.Count; j++)
            {
                Random random = new Random();
                int dropItem = random.Next(1, 100);
                int itemType = random.Next(1, 55);
                if (dropItem <= 15) // 15%의 확률로 포션 획득
                {
                    switch (itemType)
                    {
                        case 1:
                        case 2:
                        case 3:
                            rewardHpPotion++;
                            break;
                        case 4:
                            rewardMpPotion++;
                            break;
                        case 5:
                            rewardHyperPotion++;
                            break;
                    }
                }
            }

            if (rewardHpPotion >= 1) //HP포션을 1개 이상 얻었을 시
            {
                Console.WriteLine("  HP포션 - ");
                ConsoleUtility.TextHighlights2($"{rewardHpPotion}");
                player.hpPotion += rewardHpPotion;
            }
            if (rewardMpPotion >= 1) //MP포션을 1개 이상 얻었을 시
            {
                Console.WriteLine("  MP포션 - ");
                ConsoleUtility.TextHighlights2($"{rewardMpPotion}");
                player.mpPotion += rewardMpPotion;
            }
            if (rewardHyperPotion >= 1) //Hyper포션을 1개 이상 얻었을 시
            {
                Console.WriteLine("  Hyper포션 - ");
                ConsoleUtility.TextHighlights2($"{rewardHyperPotion}");
                player.hyperPotion += rewardHyperPotion;
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

                ConsoleUtility.TextHighlights0("  [캐릭터 정보]");
                ConsoleUtility.TextHighlights3($"  Lv.{player.lv} {player.playerName}"); //레벨과 이름을 넣어야함
                ConsoleUtility.TextHighlights3($"  Hp {player.playerHp} -> {playerCurHp}");
                ConsoleUtility.TextHighlights3($"  MP {player.playerMp} -> {playerCurMp}");

                ref int hp = ref player.playerHp;
                hp = playerCurHp;
                ref int mp = ref player.playerMp;
                mp = playerCurMp;

                ConsoleUtility.TextHighlights0("\n  [획득 아이템]");
                RewardGold(ref player);
                RewardPotion(ref player);
            }
            else
            {
                Console.WriteLine("  You Lose\n");
                Console.WriteLine("  스파르타 던전 입구로 돌아갑니다.");
                ref int hp = ref player.playerHp;
                hp = 1;
            }
            Console.WriteLine("└─────────────────────────────────────────────────────┘\n");

            Console.Write("0.다음\n>>");
            Console.ReadLine();
        }
    }
}