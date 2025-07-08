using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        private List<Item> inventory = new List<Item>();   //for now, hardcoding

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
        }
        public void DisplayPlayerStatus()
        {
            int totalAttackBonus = 0;
            int totalDefenseBonus = 0;
            int totalHealthBonus = 0;

            if (inventory.Count != 0)
            {
                foreach (Item item in inventory)
                {
                    if (item.IsEquipped)
                    {
                        totalAttackBonus += item.Enhancement.TryGetValue(Ability.Attack, out int attackBonus) ? attackBonus : 0;
                        totalDefenseBonus += item.Enhancement.TryGetValue(Ability.Defence, out int defenceBonus) ? defenceBonus : 0;
                        totalHealthBonus += item.Enhancement.TryGetValue(Ability.Health, out int healthBonus) ? healthBonus : 0;
                    }
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

        public void DisplayInventory(bool isNumbered)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("아무 것도 갖고 있지 않습니다.");
                return;
            }
            int index = 1;
            string prefix = " - ";
            foreach (Item item in inventory)
            {
                prefix = isNumbered ? $" - {index++} " : " - ";
                Console.Write(prefix);
                Console.WriteLine(item);
                //Replace();
            }

            Console.WriteLine();
        }
        public void PurchaseItem(Item item) //Store SellToPlayer()에서만 호출됨
        {
            //아이템 획득 및 골드 소모만!!
            //가능성 여부는 Store SellToPlayer()에서 체크
            inventory.Add(item);
            gold -= item.Price;
            Console.WriteLine($"{item.Name}을 구매했다! {gold}이 남았다.");
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