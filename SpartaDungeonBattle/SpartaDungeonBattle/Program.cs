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
            //PlayerStatus status = new PlayerStatus();
            Battle battle = new Battle();
            PlayerStatus status = FileLoad();
            QuestBoard board = new QuestBoard(status,new MonsterKill(ref status));

            //creation.Creation(); //캐릭터 생성 실행
            //status.FirstStatus(creation.name, creation.job, creation.jobNumber);

            while (true)
            {
                Console.Clear();
                //Console.WriteLine("스파르타 던전에 오신 {0}님 환영합니다.", creation.name);
                Console.WriteLine("스파르타 던전에 오신 {0}님 환영합니다.", status.playerName);

                Console.WriteLine("이제 전투를 시작할 수 있습니다.");
                Console.WriteLine();

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 전투 시작");
                Console.WriteLine("3. 퀘스트");
                Console.WriteLine("4. 저장 및 종료");
                Console.WriteLine("5. 저장 초기화");
                Console.WriteLine();

                int choice1 = ConsoleUtility.MenuChoice(1, 5, "행동을"); //행동 선택
                switch (choice1)
                {
                    case 1: //1번 실행 시 스테이터스(상태 보기) 열람

                        Console.WriteLine(status.playerHp);
                        //status.Player(creation.name, creation.job, creation.jobNumber);
                        status.Display();
                        break;

                    case 2: //2번 실행 시 전투 시작
                        battle.DungeonBattle(ref status);
                        break;
                    case 3:
                        board.BoardDisplay();
                        break;
                    case 4:
                        FileSave(status);
                        Environment.Exit(0);
                        break;
                    case 5:
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
