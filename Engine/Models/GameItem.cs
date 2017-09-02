using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public enum EItemID
    {
        POINTY_STICK = 1001,
        RUSTY_SWORD = 1002,
        SNAKE_FANG = 9001,
        SNAKESKIN = 9002,
        RAT_TAIL = 9003,
        RAT_FUR = 9004,
        SPIDER_FANG = 9005,
        SPIDER_SILK = 9006
    }

    public class GameItem
    {
        public EItemID ItemTypeID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public GameItem(EItemID itemTypeID, string name, int price)
        {
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
        }

        public GameItem Clone()
        {
            return new GameItem(ItemTypeID, Name, Price);
        }
    }
}
