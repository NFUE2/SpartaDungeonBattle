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
        public string skillName2;
        public int skillMp1;
        public int skillMp2;
        public string skillAbility1;
        public string skillAbility2;

        public void ChraterStatus()
        {
            Console.WriteLine("공격력 : " + atk);
            Console.WriteLine("방어력 : " + def);
            Console.WriteLine("체  력 : " + hp);
        }
        public void ChraterSkill()
        {
            Console.WriteLine($"1. {skillName1}  /  MP : {skillMp1}");
            Console.WriteLine($"{skillAbility1}");
            Console.WriteLine();
            Console.WriteLine($"2. {skillName2}  /  MP : {skillMp2}");
            Console.WriteLine($"{skillAbility2}");
            Console.WriteLine();
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
            skillName1 = "파워 슬래쉬"; //기술1의 이름
            skillName2 = "파워 스트라이크"; // 기술2의 이름
            skillMp1 = 10;
            skillMp2 = 20;
            skillAbility1 = "적 1명에게 공격력 200%의 데미지를 준다";
            skillAbility2 = "적 전체에게 공격력 150%의 데미지를 준다";
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
            skillName1 = "저격"; // 기술1의 이름
            skillMp1 = 10; // 기술1을 사용하는 MP량
            skillName2 = "폭풍의 화살"; // 기술2의 이름
            skillMp2 = 15; // 기술2를 사용하는 MP량
            skillAbility1 = "적 1명에게 공격력 150%의 데미지를 준다. (크리티컬 +10%)";
            skillAbility2 = "적 전체에게 공격력 200%의 데미지를 준다.";
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
            skillName1 = "암살"; // 기술1의 이름
            skillMp1 = 15; // 기술1을 사용하는 MP량
            skillName2 = "은신"; // 기술2의 이름
            skillMp2 = 10; // 기술2를 사용하는 MP량
            skillAbility1 = "적 1명에게 공격력 130%의 데미지를 준다. (크리티컬 +10%, 명중률 +10%)";
            skillAbility2 = "자신의 회피수치를 20퍼 올라간다.";
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
            skillName1 = "익스플로전"; // 기술1의 이름
            skillMp1 = 50; // 기술1을 사용하는 MP량
            skillName2 = "명상"; // 기술2의 이름
            skillMp2 = 0; // 기술2를 사용하는 MP량
            skillAbility1 = "적 전체에게 공격력 500%의 데미지를 준다";
            skillAbility2 = "자신의 mp를 약간 회복시킨다.";
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
            skillName1 = "정권찌르기"; // 기술1의 이름
            skillMp1 = 20; // 기술1을 사용하는 MP량
            skillName2 = "철괴"; // 기술2의 이름
            skillMp2 = 10; // 기술2를 사용하는 MP량
            skillAbility1 = "적 1명에게 공격력 300$의 데미지 (크리티컬 +10%)";
            skillAbility2 = "자신의 체력과 방어력을 50% 증가";
        }
    }
    
}
