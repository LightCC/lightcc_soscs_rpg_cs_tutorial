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
                new Weapon(1001, "Pointy Stick", 1, 1, 1),
                new Weapon(1002, "Rusty Sword", 5, 1, 3),
                new GameItem(9001, "Snake fang", 1),
                new GameItem(9002, "Snakeskin", 2)
            };
            // Alternate: _standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 1));
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
