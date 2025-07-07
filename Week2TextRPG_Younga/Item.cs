using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga
{
    internal class Item
    {
        private int id;
        private bool IsEquipped;
        private string name;
        private int price;
        private string description;
        private Dictionary<string, int> items;  //string은 추후 Ability enum으로 교체. //Attack(enum) 5(int) 
        //ItemSlot slot //ItemSlot enum 생성할 것.

        public int Id => id;
        public string Name => name;
        public int Price => price;
        public string Description => description;

        public void ToString()
        {

        }
        public void Equip()
        {

        }
        public void Unequip()
        {

        }
    }
}