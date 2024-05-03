using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public enum State
    {
        Alive,
        Dead
    }
    public class Enemy
    {
        public State state;
        public int level, atk;
        public string name;
        public int hp;
        public void Display()
        {
            ConsoleUtility.TextHighlights1($"Lv.{level} {name} ");

            if (state == State.Alive) ConsoleUtility.TextHighlights1($"HP {hp}");
            else Console.WriteLine($"{state.ToString()}");
        }
    }

    public class Minion : Enemy
    {
        public Minion()
        {
            level = 2;
            name = "미니언";
            hp = 15;
            atk = 5;
            state = State.Alive;
        }
    }
    public class SiegeMinion : Enemy
    {
        public SiegeMinion()
        {
            level = 5;
            name = "대포미니언";
            hp = 25;
            atk = 8;
            state = State.Alive;
        }
    }
    public class HollowWorm : Enemy
    {
        public HollowWorm()
        {
            level = 3;
            name = "공허충";
            hp = 10;
            atk = 9;
            state = State.Alive;
        }
    }
}