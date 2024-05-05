using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public class QuestBoard
    {
        int choice;
        string title = "Quest!!";

        PlayerStatus status;
        List<Quest> quests,myquests;

        //Dictionary<Quest, Quest> myquests;

        public QuestBoard(PlayerStatus status, params Quest[] quests)
        {
            this.quests = new List<Quest>();
            this.status = status;
            myquests = status.quests;

            for (int i = 0; i < quests.Length; i++)
                this.quests.Add(quests[i]);
        }

        public void BoardDisplay()
        {
            string[] str = { "1. 의뢰중인 퀘스트 보기", "2. 퀘스트 받기" };

            while (true)
            {
                Console.Clear();
                choice = ConsoleUtility.MenuChoice(title, str,true);

                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        MyQuestDisplay();
                        break;

                    case 2:
                        QuestDisplay();
                        break;
                }
            }
        }

        private void MyQuestDisplay()
        {
            string[] str = new string[myquests.Count];

            for(int i = 0; i < myquests.Count; i++)
                str[i] = $"{i + 1}. {myquests[i].title}"; 

            Console.Clear();
            if(str.Length == 0)
            {
                Console.WriteLine("퀘스트가 존재하지 않습니다.");
                Thread.Sleep(1000);
                return;
            }

            choice = ConsoleUtility.MenuChoice(title, str, true) - 1;

            switch (choice)
            {
                case -1:
                    return;
                default:
                    if(1 == myquests[choice].QuestDisplay())
                    {
                        ref int myGold = ref status.gold;
                        myGold += myquests[choice].reward;
                        myquests.Remove(myquests[choice]);
                    }

                    break;
            }
        }

        private void QuestDisplay()
        {
            string[] str = new string[quests.Count];

            Console.Clear();
            if (str.Length == 0)
            {
                Console.WriteLine("퀘스트가 존재하지 않습니다.");
                Thread.Sleep(1000);
                return;
            }

            for(int i = 0; i < quests.Count; i++)
                str[i] = $"{i + 1}. {quests[i].title}";

            choice = ConsoleUtility.MenuChoice(title, str, true) - 1;

            if (choice == -1) return;

            Console.Clear();
            int choice2 = quests[choice].QuestChoiceDisplay();

            switch(choice2)
            {
                case 1:
                    myquests.Add(quests[choice]);
                    quests.Remove(quests[choice]);
                    break;
                default:
                    return;
            }
        }

        //public Quest Display()
        //{

            //return new Quest();
            //int choice = 0;
            //string msg = "원하시는 퀘스트를 선택해주세요.";
            //string[] list = new string[quests.Count];

            //for (int i = 0; i < quests.Count; i++)
            //    list[i] = $"{i + 1}. {quests[i].title}";

            //while (true)
            //{
            //    Console.Clear();

            //    choice = ConsoleUtility.BattleChoice((bool b) => QuestDisplay(), msg, list);

            //    if(choice < 0 || choice > list.Length)
            //    {
            //        Console.WriteLine("잘못된 입력입니다.");
            //        Thread.Sleep(1000);
            //        continue;
            //    }
            //    choice--;

            //    while(true)
            //    {
            //        Console.Clear();
            //        int choice2 = quests[choice].Display();

            //        switch(choice2)
            //        {
            //            case 1:
            //                Quest q = quests[choice2 - 1];
            //                return q;
            //            case 2:
            //                return null;
            //            default:
            //                Console.WriteLine("잘못된 입력입니다.");
            //                Thread.Sleep(1000);
            //                break;
            //        }
            //    }
            //}
        //}
    }
}
