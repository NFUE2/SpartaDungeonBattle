using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public  class Store
    {
        PlayerStatus player;
        private List<Item> store;

        public void StoreMenu(ref PlayerStatus player)
        {
            Console.Clear();
            store = new List<Item>();
            store.Add(new HpPotion());
            store.Add(new MpPotion());
            store.Add(new HyperPotion());

            ConsoleUtility.TextHighlights0("\n[상점]");
            Console.WriteLine("필요하신 아이템을 구매할 수 있는 상점입니다.\n");
            ConsoleUtility.TextHighlights3($"[보유 골드 : {player.gold} G]\n");
            ConsoleUtility.TextHighlights0("[아이템 목록]");
            Console.WriteLine("┌─────────────────────────┐");
            for(int i=0; i<store.Count; i++)
            {
                store[i].StoreMenu();
            }
            Console.WriteLine("└─────────────────────────┘\n");

            Console.WriteLine("0. 나가기.\n");
            int menuChoice = ConsoleUtility.MenuChoice(0, 3, "원하시는 상품을");
            switch (menuChoice)
            {
                case 0:
                    return;

                case 1:
                    if(player.gold >= store[0].price)
                    {
                        int curGold = player.gold - store[0].price;
                        Console.WriteLine("\nHP포션 구매를 완료하셨습니다.");
                        Console.WriteLine($"Gold : {player.gold} -> {curGold}");
                        player.gold = curGold;
                        ref int HpPotion = ref player.hpPotion;
                        HpPotion += 1;
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    ConsoleUtility.Next();
                    break;

                case 2:
                    if (player.gold >= store[1].price)
                    {
                        int curGold = player.gold - store[1].price;
                        Console.WriteLine("\nMP포션 구매를 완료하셨습니다.");
                        Console.WriteLine($"Gold : {player.gold} -> {curGold}");
                        player.gold = curGold;
                        ref int MpPotion = ref player.mpPotion;
                        MpPotion += 1;
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    ConsoleUtility.Next();
                    break;

                case 3:
                    if (player.gold >= store[2].price)
                    {
                        int curGold = player.gold - store[2].price;
                        Console.WriteLine("\nHyper포션 구매를 완료하셨습니다.");
                        Console.WriteLine($"Gold : {player.gold} -> {curGold}");
                        player.gold = curGold;
                        ref int HyperPotion = ref player.hyperPotion;
                        HyperPotion += 1;
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    ConsoleUtility.Next();
                    break;
            }
        }
    }
}
