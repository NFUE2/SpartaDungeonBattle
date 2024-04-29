using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public class Enemy
    {
        protected int level,hp,atk;
        protected string name;

        public void Display()
        {
            Console.WriteLine($"Lv.{level} {name} HP {hp}");
        }
    }

    public class Minion : Enemy
    {
        public Minion()
        {
            level = 2;
            hp = 15;
            atk = 5;
        }
    }
    public class SiegeMinion : Enemy
    {
        public SiegeMinion()
        {
            level = 5;
            hp = 25;
            atk = 8;
        }
    }
    public class HollowWorm : Enemy
    {
        public HollowWorm()
        {
            level = 3;
            hp = 10;
            atk = 9;
        }
    }
}
