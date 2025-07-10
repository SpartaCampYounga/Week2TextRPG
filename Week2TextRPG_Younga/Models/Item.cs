using Week2TextRPG_Younga.Enum;
using Week2TextRPG_Younga.Utility;

namespace Week2TextRPG_Younga.Classes
{
    internal class Item
    {
        private static int nextId = 1;
        private int id;
        private string name;
        private int price;
        private string description;
        private Dictionary<Ability, int> enhancement = new Dictionary<Ability, int>
        {
            { Ability.Attack, 0 },
            { Ability.Defence, 0 }
        };  //공격력+5: Attack(enum) 5(int) 
        private EquipSlot equipSlot;

        public int Id => id;
        public string Name => name;
        public int Price => price;
        public string Description => description;
        public Dictionary<Ability, int> Enhancement => enhancement;
        public EquipSlot EquipSlot => equipSlot;

        public Item(string name, int price, string description, Dictionary<Ability, int> enhancement, EquipSlot equipSlot)
        {
            id = nextId++;
            this.name = name;
            this.price = price;
            this.description = description;
            this.enhancement = enhancement;
            this.equipSlot = equipSlot;
        }

        public override string ToString()
        {
            string enhancementDisplay = "";
            foreach (KeyValuePair<Ability, int> ability in enhancement)
            {
                enhancementDisplay += ability.Key + " + " + ability.Value + " "; //+ "\t|";
            }
            string display =
                FormatUtility.AlignWithPadding(name, 15) + " | " +
                FormatUtility.AlignWithPadding(enhancementDisplay, 25) + "| " +
                FormatUtility.AlignWithPadding(description, 55) + " | ";
            //display += description + "\t|";

            //display = string.Format("{0, 15} | {1, 15} | {2, 30} | ", name, enhancementDisplay, description);

            return display;
        }
    }
}