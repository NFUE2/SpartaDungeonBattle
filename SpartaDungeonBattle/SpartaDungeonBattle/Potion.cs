using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public class Potion
    {
        PlayerStatus player;

        public void HealPotion(ref PlayerStatus player)
        {
            Console.Clear();
            this.player = player;
            ConsoleUtility.TextHighlights0("\n[회복]");
            Console.Write($"포션을 사용하면 체력 혹은 MP을 회복 할 수 있습니다. ");

            Console.WriteLine("\n┌───────────────────────────────────┐");
            ConsoleUtility.TextHighlights0($"  1. HP포션 ({player.hpPotion}개)");
            Console.WriteLine("     체력을 30 정도 회복시킵니다.\n");
            ConsoleUtility.TextHighlights0($"  2. MP포션 ({player.mpPotion}개)");
            Console.WriteLine("     MP를 30 정도 회복시킵니다.\n");
            ConsoleUtility.TextHighlights0($"  3. Hyper포션 ({player.hyperPotion}개)");
            Console.WriteLine("     체력을 70 정도 회복시킵니다.\n");
            ConsoleUtility.TextHighlights0("  0. 나가기");
            Console.WriteLine("└───────────────────────────────────┘\n");

            int potionChoice = ConsoleUtility.MenuChoice(0, 3, "사용하실 포션을");

            switch (potionChoice)
            {
                case 1: //1번 선택시 체력 회복
                    if (player.hpPotion > 0)
                    {
                        if (player.playerHp >= player.playerMaxHp) //플레이어 현재 체력이 직업의 최대체력보다 높거나 같을 경우 회복하지 않는다.
                        {
                            Console.WriteLine("\n체력이 전부 회복되어 있습니다.");
                            ConsoleUtility.Next();
                        }
                        else
                        {
                            int playerCurHp = player.playerHp;
                            playerCurHp += 30;
                            if (playerCurHp >= player.playerMaxHp)
                            {
                                ConsoleUtility.TextHighlights2($"\n{player.playerName}");
                                Console.WriteLine("님의 체력이 전부 회복되었습니다.");
                                ConsoleUtility.TextHighlights2($"{player.playerHp}/{player.playerMaxHp}");
                                Console.Write(" -> ");
                                ConsoleUtility.TextHighlights3($"{player.playerMaxHp}/{player.playerMaxHp}");
                                player.playerHp = player.playerMaxHp;
                                ConsoleUtility.Next();
                            }
                            else
                            {
                                ConsoleUtility.TextHighlights2($"\n{player.playerName}");
                                Console.WriteLine("님의 체력이 회복되었습니다.");
                                ConsoleUtility.TextHighlights2($"{player.playerHp}/{player.playerMaxHp}");
                                Console.Write(" -> ");
                                ConsoleUtility.TextHighlights3($"{playerCurHp}/{player.playerMaxHp}");
                                player.playerHp = playerCurHp;
                                ConsoleUtility.Next();
                            }
                            player.hpPotion -= 1; //체력 회복 후 포션 개수 감소
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n현재 소지 중인 포션이 없습니다.");
                        ConsoleUtility.Next();
                    }
                    break;

                case 2: //1번 선택시 체력 회복
                    if (player.mpPotion > 0)
                    {
                        if (player.playerMp >= player.maxMp) //플레이어 현재 체력이 직업의 최대체력보다 높거나 같을 경우 회복하지 않는다.
                        {
                            Console.WriteLine("\nMp가 전부 회복되어 있습니다.");
                            ConsoleUtility.Next();
                        }
                        else
                        {
                            int playerCurMp = player.playerMp;
                            playerCurMp += 30;
                            if (playerCurMp >= player.maxMp)
                            {
                                ConsoleUtility.TextHighlights2($"\n{player.playerName}");
                                Console.WriteLine("님의 MP가 전부 회복되었습니다.");
                                ConsoleUtility.TextHighlights2($"{player.playerMp}/{player.maxMp}");
                                Console.Write(" -> ");
                                ConsoleUtility.TextHighlights3($"{player.maxMp}/{player.maxMp}");
                                player.playerMp = player.maxMp;
                                ConsoleUtility.Next();
                            }
                            else
                            {
                                ConsoleUtility.TextHighlights2($"\n{player.playerName}");
                                Console.WriteLine("님의 MP가 회복되었습니다.");
                                ConsoleUtility.TextHighlights2($"{player.playerMp}/{player.maxMp}");
                                Console.Write(" -> ");
                                ConsoleUtility.TextHighlights3($"{playerCurMp}/{player.maxMp}");
                                player.playerMp = playerCurMp;
                                ConsoleUtility.Next();
                            }
                            player.mpPotion -= 1; //체력 회복 후 포션 개수 감소
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n현재 소지 중인 포션이 없습니다.");
                        ConsoleUtility.Next();
                    }
                    break;

                case 3: //1번 선택시 체력 회복
                    if (player.hyperPotion > 0)
                    {
                        if (player.playerHp >= player.playerMaxHp) //플레이어 현재 체력이 직업의 최대체력보다 높거나 같을 경우 회복하지 않는다.
                        {
                            Console.WriteLine("\n체력이 전부 회복되어 있습니다.");
                            ConsoleUtility.Next();
                        }
                        else
                        {
                            int playerCurHp = player.playerHp;
                            playerCurHp += 70;
                            if (playerCurHp >= player.playerMaxHp)
                            {
                                ConsoleUtility.TextHighlights2($"\n{player.playerName}");
                                Console.WriteLine("님의 체력이 전부 회복되었습니다.");
                                ConsoleUtility.TextHighlights2($"{player.playerHp}/{player.playerMaxHp}");
                                Console.Write(" -> ");
                                ConsoleUtility.TextHighlights3($"{player.playerMaxHp}/{player.playerMaxHp}");
                                player.playerHp = player.playerMaxHp;
                                ConsoleUtility.Next();
                            }
                            else
                            {
                                ConsoleUtility.TextHighlights2($"\n{player.playerName}");
                                Console.WriteLine("님의 체력이 회복되었습니다.");
                                ConsoleUtility.TextHighlights2($"{player.playerHp}/{player.playerMaxHp}");
                                Console.Write(" -> ");
                                ConsoleUtility.TextHighlights3($"{playerCurHp}/{player.playerMaxHp}");
                                player.playerHp = playerCurHp;
                                ConsoleUtility.Next();
                            }
                            player.hyperPotion -= 1; //체력 회복 후 포션 개수 감소
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n현재 소지 중인 포션이 없습니다.");
                        ConsoleUtility.Next();
                    }
                    break;

                case 0:
                    return;
            }

        }
        
    }
}
