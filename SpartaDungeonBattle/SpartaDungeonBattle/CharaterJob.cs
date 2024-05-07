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
        public int atk, def, hp, maxHp;
        public string skillName1;
        public string skillAbility1;
        public int skillMp1;
        public double persent;
        public int bonus;

        public void ChraterStatus()
        {
            Console.WriteLine("  공격력 : " + atk);
            Console.WriteLine("  방어력 : " + def);
            Console.WriteLine("  체  력 : " + hp);
        }
    }

    public class Warrior : CharaterJob // 전사 스텟
    {
        public Warrior()
        {
            atk = 10;
            def = 5;
            hp = 100;
            maxHp = 100;
            skillName1 = "파워 슬래쉬";
            skillMp1 = 10;
            skillAbility1 = "적 1명에게 공격력 200%의 데미지를 줍니다.(크리티컬 +10%)";
            persent = 2.0;
            bonus = 10;
        }
    }

    public class Archer : CharaterJob // 궁수 스텟
    {
        public Archer()
        {
            atk = 13;
            def = 2;
            hp = 75;
            maxHp = 75;
            skillName1 = "저격";
            skillMp1 = 10;
            skillAbility1 = "적 1명에게 공격력 150%의 데미지를 줍니다. (크리티컬 +25%)";
            persent = 1.5;
            bonus = 25;
        }   
    }

    public class Thief : CharaterJob // 도적 스텟
    {
        public Thief()
        {
            atk = 12;
            def = 3;
            hp = 85;
            maxHp = 85;
            skillName1 = "암살";
            skillMp1 = 20;
            skillAbility1 = "적 1명에게 공격력 200%의 데미지를 줍니다. (크리티컬 +25%)";
            persent = 2.0;
            bonus = 25;
        }
    }

    public class Magician : CharaterJob //마법사 스텟
    {
        public Magician()
        {
            atk = 20;
            def = 0;
            hp = 60;
            maxHp = 60;
            skillName1 = "익스플로전!!";
            skillMp1 = 50;
            skillAbility1 = "적 1명에게 공격력 500%의 데미지를 줍니다.";
            persent = 5.0;
            bonus = 0;
        }
    }

    public class Fighter : CharaterJob //격투가 스텟
    {
        public Fighter()
        {
            atk = 8;
            def = 8;
            hp = 120;
            maxHp = 120;
            skillName1 = "정권!!";
            skillMp1 = 20;
            skillAbility1 = "적 1명에게 공격력 300%의 데미지를 줍니다. (크리티컬 +25%)";
            persent = 3.0;
            bonus = 25;
        }
    }
    
}
