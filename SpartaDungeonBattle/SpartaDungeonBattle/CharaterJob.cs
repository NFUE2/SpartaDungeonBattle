using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public class CharaterJob()
    {
        protected int atk, def, hp;

        public void ChraterStatus()
        {
            Console.WriteLine("공격력 : " + atk);
            Console.WriteLine("방어력 : " + def);
            Console.WriteLine("체  력 : " + hp);
        }
    }

    public class Warrior : CharaterJob // 전사 스텟
    {
        public Warrior()
        {
            atk = 10;
            def = 5;
            hp = 100;
        }
    }

    public class Archer : CharaterJob // 궁수 스텟
    {
        public Archer()
        {
            atk = 13;
            def = 2;
            hp = 75;
        }   
    }

    public class Thief : CharaterJob // 도적 스텟
    {
        public Thief()
        {
            atk = 12;
            def = 3;
            hp = 85;
        }
    }

    public class Magician : CharaterJob //마법사 스텟
    {
        public Magician()
        {
            atk = 20;
            def = 0;
            hp = 60;
        }
    }

    public class Fighter : CharaterJob //격투가 스텟
    {
        public Fighter()
        {
            atk = 8;
            def = 8;
            hp = 120;
        }
    }
    
}
