﻿using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quest> _quests = new List<Quest>();

        static QuestFactory()
        {
            // Declare the items needed to complete the quest, and its rewards
            List<ItemQuantity> itemsToComplete = new List<ItemQuantity>
                { new ItemQuantity(EItemID.SNAKE_FANG, 5) };
            List<ItemQuantity> rewardItems = new List<ItemQuantity>
                { new ItemQuantity(EItemID.RUSTY_SWORD, 1) };

            // Create the quest

            _quests.Add(new Quest(EQuestID.CLEAR_HERB_GARDEN,
                "Clear the herb garden",
                "Defeat the snakes in the Herbalists's garden",
                itemsToComplete, 25, 10, rewardItems));
        }

        internal static Quest GetQuestByID(EQuestID id)
        {
            return _quests.FirstOrDefault(quest => quest.ID == id);
        }
    }
}
