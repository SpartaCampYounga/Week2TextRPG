using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga
{
    internal class Player
    {
        private int id;
        private int level;
        private string name; 
        private string job;
        private int attack;
        private int defence;
        private int health;
        private int gold;
        private List<Item> inventory;   //for now, hardcoding

        public int Id => id;
        public int Level => level;
        public string Name => name;
        public string Job => job;
        public int Attack => attack;
        public int Defence => defence;
        public int Health => health;
        public int Gold => gold;
        public List<Item> Inventory => inventory;

        public Player(string name)
        {
            id = 1;
            level = 1;
            this.name = name;
            job = "전사";
            attack = 10;
            defence = 5;
            health = 100;
            gold = 1500;
            inventory = new List<Item>()
            {
                new Item("수련자갑옷", 1000, "수련에 도움을 주는 갑옷입니다.", new Dictionary<Ability, int> { { Ability.Defence, 5 } }, EquipSlot.Armor),
                new Item("무기", 2000, "공격력", new Dictionary<Ability, int> { { Ability.Attack, 9 } }, EquipSlot.Armor),
                new Item("악세서리", 3500, "체력", new Dictionary<Ability, int> { { Ability.Health, 9 } }, EquipSlot.Armor)
            };
            inventory[1].Equip();
        }
        public void DisplayPlayerStatus()
        {
            int totalAttackBonus = 0;
            int totalDefenseBonus = 0;
            int totalHealthBonus = 0;
            foreach (Item item in inventory)
            {
                if (item.IsEquipped)
                {
                    totalAttackBonus += item.Enhancement.TryGetValue(Ability.Attack, out int attackBonus) ? attackBonus : 0;
                    totalDefenseBonus += item.Enhancement.TryGetValue(Ability.Defence, out int defenceBonus) ? defenceBonus : 0;
                    totalHealthBonus += item.Enhancement.TryGetValue(Ability.Health, out int healthBonus) ? healthBonus : 0;
                }
            }

            //기본 정보
            Console.Write(
                $"Lv. {level.ToString("D2")}\n" +
                $"{name} ( {job} )\n");
            //공격력
            if (totalAttackBonus == 0) Console.Write($"공격력: {attack}\n");
            else Console.Write($"공격력: {attack + totalAttackBonus} (+{totalAttackBonus})\n");
            //방어력
            if (totalDefenseBonus == 0) Console.Write($"방어력: {defence}\n");
            else Console.Write($"방어력: {attack + totalDefenseBonus} (+{totalDefenseBonus})\n");
            //체력
            if (totalHealthBonus == 0) Console.Write($"체력: {health}\n");
            else Console.Write($"체력: {health + totalHealthBonus} (+{totalHealthBonus})\n");
            //골드
            Console.Write($"Gold {gold} G\n");

            Console.WriteLine();
        }

        public void DisplayInventory()
        {
            foreach (Item item in inventory)
            {
                Console.Write(" - ");
                item.ToString();
            }

            Console.WriteLine();
        }
        public void PurchaseItem(Item item)
        {
            //아이템 획득 및 골드 소모만!!
            //가능성 여부는 Store에서 구현 예정 
            inventory.Add(item);
            gold -= item.Price; //if 처리 해야함. 0으로 떨어지지 않게.
        }
    }
}

//      미구현 항목들
//        %%----도전 기능
//        %% -Dictionaly ~ItemSlot, Item ~equipment
//        %% -exp : 던전 횟수 카운트
//        %% +void TakeRest()
//        %% +void EnterDungeon(Dungeon dungeon)

//        %%실제 
//        %%----도전 기능
//        %% +void TakeRest()
//        %% +void SellItem(Item item) 상점은 조건 체크 X 하고 무조건 매입
//        %% +void LevelUp()