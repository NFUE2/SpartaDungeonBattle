using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpartaDungeonBattle
{
    internal class Program
    {
        static string path = Directory.GetCurrentDirectory() + "/save";
        static void Main(string[] args)
        {
            
            CreationCharater creation = new CreationCharater();
            Battle battle = new Battle();
            ConsoleUtility.PrintGameHeader(); //게임 화면 실행
            PlayerStatus status = FileLoad();
            QuestBoard board = new QuestBoard(status, new MonsterKill(ref status));
            Potion potion = new Potion();
            Store store = new Store();

            Console.Clear();

            //creation.Creation(); //캐릭터 생성 실행
            //status.FirstStatus(creation.name, creation.job, creation.jobNumber);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n스파르타 던전에 오신 {status.playerName}님 환영합니다.");
                Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

                Console.WriteLine("┌────────────────────┐");
                ConsoleUtility.TextHighlights0("  1. 상태 보기");
                ConsoleUtility.TextHighlights0("  2. 전투 시작");
                ConsoleUtility.TextHighlights0("  3. 회복 아이템");
                ConsoleUtility.TextHighlights0("  4. 퀘스트");
                ConsoleUtility.TextHighlights0("  5. 상점");
                ConsoleUtility.TextHighlights0("  6. 저장 및 종료");
                ConsoleUtility.TextHighlights0("  7. 저장 초기화");
                Console.WriteLine("└────────────────────┘\n");


                int choice = ConsoleUtility.MenuChoice(1, 7, "원하시는 행동을"); //행동 선택
                switch (choice)
                {
                    case 1: //1번 실행 시 스테이터스(상태 보기) 열람
                        status.Player();
                        break;

                    case 2: //2번 실행 시 전투 시작
                        battle.DungeonBattle(ref status);
                        break;

                    case 3: //3번 실행시 회복 아이템 이동
                        potion.HealPotion(ref status);
                        break;

                    case 4: //4번 실행 시 퀘스트 열람
                        board.BoardDisplay();
                        break;

                    case 5: //5번 실행 시 파일 초기화
                        store.StoreMenu(ref status);
                        break;

                    case 6: //6번 실행 시 파일 저장
                        FileSave(status);
                        Environment.Exit(0);
                        break;

                    case 7: //7번 실행 시 파일 초기화
                        FileReset(ref status);
                        break;
                }
            }

            static void FileReset(ref PlayerStatus status)
            {
                File.Delete(path);
                status = FileLoad();
            }

            static PlayerStatus FileLoad() //파일 불러오기
            {
                PlayerStatus playerStatus;

                if(!File.Exists(path)) //파일이 없음
                {
                    playerStatus = new PlayerStatus();
                    CreationCharater creation = new CreationCharater();
                    creation.Creation();
                    playerStatus.FirstStatus(creation.name, creation.job, creation.jobNumber);
                    FileSave(playerStatus);
                }
                else //파일 있음
                {
                    string json = File.ReadAllText(path);
                    playerStatus = JsonConvert.DeserializeObject<PlayerStatus>(json);
                }

                return playerStatus;
            }
            static void FileSave(PlayerStatus status) //파일저장
            {
                string json = JsonConvert.SerializeObject(status);
                File.WriteAllText(path, json);
            }
        }
    }
}
