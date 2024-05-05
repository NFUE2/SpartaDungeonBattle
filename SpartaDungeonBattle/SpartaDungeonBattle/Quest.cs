using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public enum QuestType
    {
        MonsterKill,
    }

    public abstract class Quest
    {
        public QuestType type;
        public string title, content, condition;
        public int reward; //int가 아니라 아이템이면 좋을듯, 아이템 없으니 골드로만보상
        protected PlayerStatus status;

        string msg = "원하시는 행동을 입력해주세요.";

        //public abstract int Display();
        protected abstract bool SuccessCheck();

        protected abstract void Display();

        public string DisplayFrame()
        {
            Display();
            return $"Quest!!\n\n{title}\n\n{content}\n\n{condition}\n\n-보상-\n{reward}G";
        }

        public int QuestChoiceDisplay()
        {
            return ConsoleUtility.MenuChoice(DisplayFrame(), ["1. 수락", "2. 거절"]);
        }

        public int QuestDisplay()
        {
            if (SuccessCheck())
                return ConsoleUtility.MenuChoice(DisplayFrame(), ["1. 보상 받기", "2. 돌아가기"]);

            else
                return ConsoleUtility.MenuChoice(DisplayFrame(), [], true);
        }

        public int QuestSuccessDisplay()
        {
            return ConsoleUtility.BattleChoice((bool b) => DisplayFrame(), msg, ["1. 보상 받기", "2. 돌아가기"]);
        }
    }

    public class MonsterKill : Quest
    {
        public string target;
        public int start, goals;
        public MonsterKill(ref PlayerStatus status)
        {
            this.status = status;
            type = QuestType.MonsterKill;
            target = new Minion().name;

            if (!status.monsterRecorde.ContainsKey(target))
                status.monsterRecorde.Add(target, 0);

            goals = 1;
            reward = 100;

            title = $"마을을 위협하는 {target} 처치";
            content =
                $"이봐! 마을 근처에 {target}들이 너무 많아졌다고 생각하지 않나?\n" +
                "마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                "모험가인 자네가 좀 처치해주게!";

            Display();
        }

        protected override void Display()
        {
            int count = status.monsterRecorde[target] - start;
            count = count > goals ? goals : count;

            condition = $"- {target} {goals}마리 처치 ({count}/{goals})";
        }

        protected override bool SuccessCheck()
        {
            return status.monsterRecorde[target] - start >= goals;
        }
    }
}