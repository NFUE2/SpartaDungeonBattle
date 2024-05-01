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
        public int atk, def, hp, maxHp; // 각 캐릭터의 기본 스텟 [공격력, 방어력, 체력]
        public int maxMP = 50;
        public int mp = 50; // 캐릭터의 기본 MP
        public int critical = 0; // 캐릭터의 기본 크리티컬
        public int dodge = 0; // 캐릭터의 기본 회피률

        public string[,] skill = new string[2,4]; // 스킬 내용은 [스킬명 / MP / 스킬에 적용되는 %(퍼센트) / 추가 %]로 적용된다.
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
            Console.WriteLine($"1. {skill[0, 0]}  /  MP : {skill[0, 1]}");
            Console.WriteLine($"{skillAbility1}");
            Console.WriteLine();
            Console.WriteLine($"2. {skill[0, 0]}  /  MP : {skill[0, 1]}");
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
            skill[0, 0] = "파워 슬래쉬"; //기술1의 이름
            skill[0, 1] = "10"; // 기술1을 사용하는 MP량
            skill[0, 2] = "200"; // 기술1의 퍼센트
            skill[0, 3] = "0"; //기술1의 보너스 스텟
            skill[1, 0] = "파워 스트라이크"; // 기술2의 이름
            skill[1, 1] = "15"; // 기술2를 사용하는 MP량
            skill[1, 2] = "150"; // 기술2의 퍼센트
            skill[1, 3] = "0"; //기술2의 보너스 스텟
            skillAbility1 = "적 1명에게 공격력 200%의 데미지를 준다";
            skillAbility2 = "적 전체에게 공격력 150%의 데미지를 준다";
        }


    }

    public class Archer : CharaterJob // 궁수 스텟
    {
        public Archer()
        {
            atk = 15;
            def = 2;
            hp = 75;
            maxHp = 75;
            skill[0, 0] = "저격"; // 기술1의 이름
            skill[0, 1] = "10"; // 기술1을 사용하는 MP량
            skill[0, 2] = "150"; // 기술1의 퍼센트
            skill[0, 3] = "10"; // 기술1의 보너스 스텟
            skill[1, 0] = "폭풍의 화살"; // 기술2의 이름
            skill[1, 1] = "15"; // 기술2를 사용하는 MP량
            skill[1, 2] = "150"; // 기술2의 퍼센트
            skill[1, 3] = "0"; // 기술2의 보너스 스텟
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
            skill[0, 0] = "암살"; // 기술1의 이름
            skill[0, 1] = "15"; // 기술1을 사용하는 MP량
            skill[0, 2] = "130"; // 기술1의 퍼센트
            skill[0, 3] = "20"; // 기술1의 보너스 스텟
            skill[1, 0] = "은신"; // 기술2의 이름
            skill[1, 1] = "10"; // 기술2를 사용하는 MP량
            skill[1, 2] = "0"; // 기술2의 퍼센트
            skill[1, 3] = "20"; // 기술2의 보너스 스텟
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
            skill[0, 0] = "익스플로전"; // 기술1의 이름
            skill[0, 1] = "50"; // 기술1을 사용하는 MP량
            skill[0, 2] = "500"; // 기술1의 퍼센트
            skill[0, 3] = "0"; // 기술1의 보너스 스텟
            skill[1, 0] = "명상"; // 기술2의 이름
            skill[1, 1] = "0"; // 기술2를 사용하는 MP량
            skill[1, 2] = "0"; // 기술2의 퍼센트
            skill[1, 3] = "10"; // 기술2의 보너스 스텟
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
            skill[0, 0] = "정권찌르기"; // 기술1의 이름
            skill[0, 1] = "20"; // 기술1을 사용하는 MP량
            skill[0, 2] = "300"; // 기술1의 퍼센트
            skill[0, 3] = "10"; // 기술1의 보너스 스텟
            skill[1, 0] = "철괴"; // 기술2의 이름
            skill[1, 1] = "10"; // 기술2를 사용하는 MP량
            skill[1, 2] = "0"; // 기술2의 퍼센트
            skill[1, 3] = "20"; // 기술2의 보너스 스텟
            skillAbility1 = "적 1명에게 공격력 300$의 데미지 (크리티컬 +10%)";
            skillAbility2 = "자신의 체력과 방어력을 50% 증가";
        }
    }
    
}
