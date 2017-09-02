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

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>
            {
                new Weapon(EItemID.POINTY_STICK, "Pointy Stick", 1, 1, 2),
                new Weapon(EItemID.RUSTY_SWORD, "Rusty Sword", 5, 1, 3),
                new GameItem(EItemID.SNAKE_FANG, "Snake fang", 1),
                new GameItem(EItemID.SNAKESKIN, "Snakeskin", 2),
                new GameItem(EItemID.RAT_TAIL, "Rat tail", 1),
                new GameItem(EItemID.RAT_FUR, "Rat fur", 2),
                new GameItem(EItemID.SPIDER_FANG, "Spider fang", 1),
                new GameItem(EItemID.SPIDER_SILK, "Spider silk", 2)
            };
        }

        public static GameItem CreateGameItem(EItemID eItemID)
        {
            GameItem standardItem = _standardGameItems
                .FirstOrDefault(item => item.ItemTypeID == eItemID);

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
