using System;
using Engine.Models;

namespace Engine.Factories
{
    public static class MonsterFactory
    {

        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster snake = new Monster("Snake", "Snake.png", 4, 4, 5, 1);

                    AddLootItem(snake, EItemID.SNAKE_FANG, 25);
                    AddLootItem(snake, EItemID.SNAKESKIN, 75);

                    return snake;

                case 2:
                    Monster rat = new Monster("Rat", "Rat.png", 5, 5, 5, 1);

                    AddLootItem(rat, EItemID.RAT_TAIL, 25);
                    AddLootItem(rat, EItemID.RAT_FUR, 75);

                    return rat;

                case 3:
                    Monster giantSpider =
                        new Monster("Giant Spider", "GiantSpider.png", 10, 10, 10, 3);

                    AddLootItem(giantSpider, EItemID.SPIDER_FANG, 25);
                    AddLootItem(giantSpider, EItemID.SPIDER_SILK, 75);

                    return giantSpider;

                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
        }

        private static void AddLootItem(Monster monster, EItemID itemID, int percentage)
        {
            if(RandomNumberGenerator.NumberBetween(1,100) <= percentage)
            {
                monster.Inventory.Add(new ItemQuantity(itemID, 1));
            }
        }
    }
}
