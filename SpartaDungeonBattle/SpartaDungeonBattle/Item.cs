using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonBattle
{
    public enum Type
    {
        Potion, 
    }

    public class Item
    {
        public Type type;
        public string name;
        public int itemNumber;
        public int price;

        public void StoreMenu()
        {
            ConsoleUtility.TextHighlights0($"  {itemNumber}.{name}  ({price} G) ");
        }
    }

    public class HpPotion : Item
    {
        public HpPotion()
        {
            name = "HP포션";
            price = 100;
            itemNumber = 1;
        }
    }

    public class MpPotion : Item
    {
        public MpPotion()
        {
            name = "MP포션";
            price = 200;
            itemNumber = 2;
        }
    }

    public class HyperPotion : Item
    {
        public HyperPotion()
        {
            name = "Hyper포션";
            price = 300;
            itemNumber = 3;
        }
    }
}
