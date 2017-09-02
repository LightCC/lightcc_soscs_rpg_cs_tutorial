using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class ItemQuantity
    {
        public EItemID ItemID { get; set; }
        public int Quantity { get; set; }

        public ItemQuantity(EItemID itemID, int quantity)
        {
            ItemID = itemID;
            Quantity = quantity;
        }
    }
}
