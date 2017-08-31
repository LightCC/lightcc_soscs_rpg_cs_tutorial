using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{

    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItems;
        private enum EGameItems
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

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon((int)EGameItems.POINTY_STICK, "Pointy Stick", 1, 1, 2));
            _standardGameItems.Add(new Weapon((int)EGameItems.RUSTY_SWORD, "Rusty Sword", 5, 1, 3));
            _standardGameItems.Add(new GameItem((int)EGameItems.SNAKE_FANG, "Snake fang", 1));
            _standardGameItems.Add(new GameItem((int)EGameItems.SNAKESKIN, "Snakeskin", 2));
            _standardGameItems.Add(new GameItem((int)EGameItems.RAT_TAIL, "Rat tail", 1));
            _standardGameItems.Add(new GameItem((int)EGameItems.RAT_FUR, "Rat fur", 2));
            _standardGameItems.Add(new GameItem((int)EGameItems.SPIDER_FANG, "Spider fang", 1));
            _standardGameItems.Add(new GameItem((int)EGameItems.SPIDER_SILK, "Spider silk", 2));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems
                .FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if(standardItem != null)
            {
                // Found the item in the static list of all items,
                // so return a clone of that item for the game to use
                return standardItem.Clone();
            }
            else
            {
                // The caller asked for an item that doesn't exist!!
                return null;
            }
        }
    }
}
