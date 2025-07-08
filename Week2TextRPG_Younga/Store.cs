using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga
{
    internal class Store
    {
        private List<Item> itemsForSale;

        public List<Item> ItemsForSale { get; set; }

        public void DisplayItems()
        {

        }
        public bool SellToPlayer(Player player, Item item)
        {
            bool isSellable = false;

            return isSellable;
        }
    }
}
