using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga
{
    internal class Item
    {
        private static int nextId = 1;  //TIL
        private int id;
        private bool isEquipped;
        private string name;
        private int price;
        private string description;
        private Dictionary<Ability, int> enhancement = new Dictionary<Ability, int>
        {
            { Ability.Attack, 0 },
            { Ability.Defence, 0 },
            { Ability.Health, 0 }
        };  //공격력+5: Attack(enum) 5(int) 
        private EquipSlot equipSlot;

        public int Id => id;
        public bool IsEquipped => isEquipped;
        public string Name => name;
        public int Price => price;
        public string Description => description;
        public Dictionary<Ability, int> Enhancement => enhancement;
        public EquipSlot EquipSlot => equipSlot;

        public Item(string name, int price, string description, Dictionary<Ability, int> enhancement, EquipSlot equipSlot)
        {
            id = nextId++;
            this.isEquipped = false;
            this.name = name;
            this.price = price;
            this.description = description;
            this.enhancement = enhancement;
            this.equipSlot = equipSlot;
        }

        public void ToString()
        {
            if (isEquipped)
            {
                Console.Write("[E]");
            }
            Console.Write(name + "\t|");

            foreach (KeyValuePair<Ability, int> ability in enhancement)
            {
                Console.Write(ability.Key + " +" + ability.Value + "\t|");
            }
            Console.Write(description + "\t|");
            Console.Write(price + " G\t|\n");
        }
        public void Equip()
        {
            isEquipped = true;
        }
        public void Unequip()
        {
            isEquipped = false;
        }
    }
}