using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public class Attack
    {

        public void Damage(int atk)
        {

            Random random = new Random();
            int p = (int)Math.Ceiling((double)atk * 0.1); //플레이어 or 몬스터의 공격력 10% 보정값 올림
            int damage = random.Next(atk - p, atk + p + 1);

        }
        public void Skill1(int jobNumber, int mp, int skillMp) // mp가 충분할 때 직업에 따라 스킬1 발동
        {
            switch (jobNumber)
            {
                case 1: //직업이 전사일때 전사 스킬1 발동
                    if (mp > skillMp) //스킬 사용량의 mp가 플레이어의 mp보다 낮을 경우 사용 가능
                    {
                        mp -= skillMp; //사용한 스킬의 mp만큼 플레이어의 mp를 낮춘다.
                        Damage(mp);//데미지 적용?
                    }
                    else //스킬 사용량의 mp가 플레이어 mp보다 높을 경우
                    {
                        Console.WriteLine("스킬을 사용할 수 없습니다.");
                    }
                    break;

                    // 적 1명에게 200퍼의 데미지
                    break;

                case 2: //직업이 궁수일때 궁수 스킬1 발동
                    //적 1명에게 공격력 150퍼 데미지(크리티컬 +10%)
                    break;

                case 3: //직업이 도적일때 도적 스킬1 발동
                    //적 1명에게 공격력 130%의 데미지(크리티컬 +10%, 명중률+10%) 
                    break;

                case 4: //직업이 마법사일때 마법사 스킬1 발동
                    //적 전체에게 500% 데미지
                    break;

                case 5: //직업이 격투가일때 격투가 스킬1 발동
                    //적 1명에게 300%데미지(크리티컬 +10%)
                    break;
            }
        }

        public void skill2(int jobNumber, int mp) // mp가 충분할 때 직업에 따라 스킬1 발동
        {
            switch (jobNumber)
            {
                case 1: //직업이 전사일때 전사 스킬2 발동
                    //적 전체에게 공격력 150% 데미지
                    break;

                case 2: //직업이 궁수일때 궁수 스킬2 발동
                    //적 전체에게 공격력 200% 데미지
                    break;

                case 3: //직업이 도적일때 도적 스킬2 발동
                    //회피 20퍼증
                    break;

                case 4: //직업이 마법사일때 마법사 스킬2 발동
                    // mp회복
                    break;

                case 5: //직업이 격투가일때 격투가 스킬2 발동
                    // 본인 방어 체력 50%증가
                    break;
            }
        }

        public int CriticalAttack(int damage, ref bool isCritical)
        {
            int critical = new Random().Next(1, 100);
            if(critical <= 15) //크리티컬일때
            {
                isCritical = true;
                double attack = damage * 1.6;
                damage = (int)Math.Round(attack); // attack 값을 반올림
            }
            else
            {
                isCritical = false;
            }

            return damage;
        }

        void Dodge()
        {
            int dodge = new Random().Next(1, 100);
            int plusDodge = 0;
            if (dodge > 11)
            {
                //데미지 들어감
            }
            else
            {
                //회피
            }
        }
        
        
    }
}