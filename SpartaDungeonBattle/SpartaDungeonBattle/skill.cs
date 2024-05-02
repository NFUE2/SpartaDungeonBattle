using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SpartaDungeonBattle
{

    public class Skill()
    {
        Battle battle;
        List<Enemy> enemyList;

        public void SkillList(int jobNumber, int mp) // mp가 충분할 때 직업에 따라 스킬1 발동
        {
            switch (jobNumber)
            {
                case 1: //직업이 전사일때 전사 스킬 발동
                    Warrior warrior = new Warrior();
                    warrior.ChraterSkill();
                    int choice1 = ConsoleUtility.MenuChoice(1, 2, "사용하실 스킬을");
                    switch (choice1)
                    {
                        case 1: // 적 1명에게 200퍼의 데미지
                            if (mp > warrior.skillMp1)
                            {
                                mp -= warrior.skillMp1;
                                int skill_choice1 = battle.PlayerChoiceTarget();
                                battle.PlayerTargetingSkill(enemyList[skill_choice1], warrior.skillName1, 200, 0);
                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }


                            break;
                        case 2: // 적 전체에게 공격력 150% 데미지
                            if (mp > warrior.skillMp2)
                            {
                                mp -= warrior.skillMp2;
                                battle.PlayerZoneSkill(warrior.skillName2, 150, 0);
                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }
                            break;
                    }
                    break;

                case 2: //직업이 궁수일때 궁수 스킬 발동
                    Archer archer = new Archer();
                    archer.ChraterSkill();
                    int choice2 = ConsoleUtility.MenuChoice(1, 2, "사용하실 스킬을");
                    switch (choice2)
                    {
                        case 1: //적 1명에게 공격력 150퍼 데미지(크리티컬 +15%)
                            if (mp > archer.skillMp1)
                            {
                                mp -= archer.skillMp1;
                                int skill_choice2 = battle.PlayerChoiceTarget();
                                battle.PlayerTargetingSkill(enemyList[skill_choice2], archer.skillName1, 150, 15);

                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }
                            break;
                        case 2: // 적 전체에게 공격력 200%의 데미지
                            if (mp > archer.skillMp2)
                            {
                                mp -= archer.skillMp2;
                                

                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }
                            break;
                    }
                    break;

                case 3: //직업이 도적일때 도적 스킬 발동
                    Thief thief = new Thief();
                    thief.ChraterSkill();
                    int choice3 = ConsoleUtility.MenuChoice(1, 2, "사용하실 스킬을");
                    switch (choice3)
                    {
                        case 1: //적 1명에게 공격력 130%의 데미지(크리티컬 +30%) 
                            if (mp > thief.skillMp1)
                            {
                                mp -= thief.skillMp1;
                                int skill_choice3 = battle.PlayerChoiceTarget();
                                battle.PlayerTargetingSkill(enemyList[skill_choice3], thief.skillName1, 130, 30);
                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }
                            break;
                        case 2: // 회피 20% 증가 
                            if (mp > thief.skillMp2)
                            {
                                mp -= thief.skillMp2;

                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }
                            break;
                    }
                    break;

                case 4: //직업이 마법사일때 마법사 스킬1 발동
                    Magician magician = new Magician();
                    magician.ChraterSkill();
                    int choice4 = ConsoleUtility.MenuChoice(1, 2, "사용하실 스킬을");
                    switch (choice4)
                    {
                        case 1: //적 전체에게 500% 데미지
                            if (mp > magician.skillMp1)
                            {
                                mp -= magician.skillMp1;

                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }
                            break;
                        case 2: // mp 회복
                            Console.WriteLine("");
                            break;
                    }
                    break;

                case 5: //직업이 격투가일때 격투가 스킬1 발동
                    Fighter fighter = new Fighter();
                    fighter.ChraterSkill();
                    int choice5 = ConsoleUtility.MenuChoice(1, 2, "사용하실 스킬을");
                    switch (choice5)
                    {
                        case 1: //적 1명에게 300%데미지(크리티컬 +15%)
                            if (mp > fighter.skillMp1)
                            {
                                mp -= fighter.skillMp1;
                                int skill_choice5 = battle.PlayerChoiceTarget();
                                battle.PlayerTargetingSkill(enemyList[skill_choice5], fighter.skillName1, 300, 15);
                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }
                            break;
                        case 2: // 본인의 체력 방어력 상승
                            if (mp > fighter.skillMp2)
                            {
                                mp -= fighter.skillMp2;

                            }
                            else
                            {
                                Console.WriteLine("Mp가 부족하여 스킬을 사용할 수 없습니다.");
                                return;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
