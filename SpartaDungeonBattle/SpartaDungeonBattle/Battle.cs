using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SpartaDungeonBattle
{
    public class Battle
    {
        PlayerStatus player;
        List<Enemy> enemyList;
        bool win = false;
        int killCount, playerCurHp;

        public void DungeonBattle(PlayerStatus player)
        {
            enemyList = new List<Enemy>();
            this.player = player;

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
                else if(player.playerHp <= 0)
                {
                    break;
                }
            }
            BattleResult();
        }

        void BattleDisplay(bool number = false)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n");
            

            for (int i = 0; i < enemyList.Count; i++)
            {
                if (number) Console.Write($"{i} ");
                enemyList[i].Display();
            }

            Console.WriteLine();
            playerCurHp = player.playerHp;
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.lv}  {player.playerName}( {player.playerJob} )"); //레벨,직업 기입 필요
            Console.WriteLine($"HP {playerCurHp}/{player.playerHp}\n"); //체력 기입 필요
        }

        void PlayerPhase()
        {
            int choice;

            while (true)
            {
                BattleDisplay();
                Console.WriteLine("1. 공격\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                if (int.TryParse(Console.ReadLine(), out choice) && choice == 1)
                {
                    while (true)
                    {
                        Console.Clear();
                        BattleDisplay(true);

                        Console.WriteLine("대상을 선택해주세요.\n>>");

                        if (int.TryParse(Console.ReadLine(), out choice) && (1 <= choice && choice <= enemyList.Count))
                        {
                            Enemy e = enemyList[choice];
                            if (e.state != State.Dead)
                            {
                                Random random = new Random();
                                int p = (int)Math.Ceiling((double)player.playerAtk * 0.1); //10% 보정값 올림,플레이어 공격력
                                int damage = random.Next(player.playerAtk - p, player.playerAtk  + p + 1); //보정값을 추가한 랜덤 공격력

                                Console.WriteLine($"{player.playerName}의 공격!");//플레이어 이름추가필요
                                Console.WriteLine($"Lv.{e.level} {e.name} 을(를) 맞췄습니다. [데미지 : {damage}]"); //데미지 기입필요

                                int curHP = e.hp - damage;
                                Console.Write($"HP {e.hp} -> {curHP}");

                                if (curHP > 0)
                                {
                                    e.hp = curHP;
                                }
                                else
                                {
                                    Console.Write($"Dead\n");
                                }

                                //e.hp -= damage; 데미지
                                if (e.hp <= 0)
                                {
                                    e.state = State.Dead;
                                    killCount++;
                                }

                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }
            }
        }

        void EnemyPhase()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                Console.Clear();
                Enemy e = enemyList[i];

                Random random = new Random();
                int p = (int)Math.Ceiling((double)player.playerAtk); //10% 보정값 올림
                int damage = random.Next(player.playerAtk - p, player.playerAtk + p + 1); //보정값을 추가한 랜덤 공격력

                Console.WriteLine($"{e.name}의 공격!");
                Console.WriteLine($"{player.playerName} 을(를) 맞췄습니다. [데미지 : {damage}]"); //플레이어 및 ,데미지 기입필요

                Console.WriteLine($"Lv.{e.level} {e.name}");

                playerCurHp = player.playerHp - damage; //캐릭터 hp 계산 필요
                Console.Write($"HP {player.playerHp} -> {playerCurHp}"); //캐릭터 hp 필요


                if (playerCurHp <= 0) //캐릭터 체력이 0 보다 작을경우
                {
                    player.playerHp = 0; //hp 0
                }

                Thread.Sleep(1000);
            }
        }

        void BattleResult()
        {
            Console.WriteLine("Battle!! - Result\n");

            if (win)
            {
                Console.WriteLine("Victory\n");
                Console.WriteLine($"던전에서 몬스터 {killCount}마리를 잡았습니다.");
            }
            else
            {
                Console.WriteLine("You Lose");
            }

            Console.WriteLine($"Lv.{player.lv} {player.playerName}"); //레벨과 이름을 넣어야함
            Console.WriteLine($"Hp {player.playerHp} -> {playerCurHp} \n");


            Console.WriteLine("0.다음\n>>");
            Console.ReadLine();
        }
    }
}