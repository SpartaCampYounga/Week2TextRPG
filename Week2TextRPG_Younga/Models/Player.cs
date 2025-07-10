using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Classes
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
        private List<Item> inventory = new List<Item>();
        public Dictionary<EquipSlot, Item> equipment = new Dictionary<EquipSlot, Item>();

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

            if (inventory.Count != 0)
            {
                foreach (Item item in inventory)
                {
                    bool isEquipped = equipment.ContainsKey(item.EquipSlot);
                    if (isEquipped)
                    {
                        totalAttackBonus += item.Enhancement.TryGetValue(Ability.Attack, out int attackBonus) ? attackBonus : 0;
                        totalDefenseBonus += item.Enhancement.TryGetValue(Ability.Defence, out int defenceBonus) ? defenceBonus : 0;
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
            //if (totalHealthBonus == 0) Console.Write($"체력: {health}\n");
            //else Console.Write($"체력: {health + totalHealthBonus} (+{totalHealthBonus})\n");
            //골드
            Console.Write($"Gold {gold} G\n");
        }

        public void DisplayInventory(bool isNumbered)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("아무 것도 갖고 있지 않습니다.");
                return;
            }
            int index = 1;
            for (int i = 0; i < inventory.Count(); i++)
            {
                string display = " - ";
                display += isNumbered ? $"{i + 1} " : ""; //numbering 요청 받았다면 숫자 매김
                display += equipment.ContainsValue(inventory[i]) ? "[E]" : ""; //장착 중이라면 [E]출력
                display += inventory[i].ToString();
                Console.WriteLine(display);
            }
        }
        public void PurchaseItem(Item item) //Store SellToPlayer()에서만 호출됨
        {
            //아이템 획득 및 골드 소모만!!
            //가능성 여부는 Store SellToPlayer()에서 체크
            inventory.Add(item);
            gold -= item.Price;
            Console.WriteLine($"{item.Name}을 구매했다! {gold}이 남았다.");
        }
        public void SellItem(Item item)
        {
            int sellPrice = (int)Math.Round(item.Price * 0.8);  //일단 반올림함...
            gold += sellPrice;
            Item itemToRemove = inventory.FirstOrDefault(x => x.Id == item.Id);
            if (itemToRemove != null)
            {
                inventory.Remove(itemToRemove);
                Console.WriteLine($"{itemToRemove.Name}을 {sellPrice} G에 판매하였습니다.");
            }
        }
        public bool TakeRest()
        {
            if(gold >= 500)
            {
                gold -= 500;
                health = 100;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Equip(Item item)
        {
            if (equipment.ContainsKey(item.EquipSlot))      //이미 장착한게 있다!
            {
                if (equipment[item.EquipSlot].Id == item.Id) //이미 같은 것을 장착하고 있다.
                {
                    equipment.Remove(item.EquipSlot);
                    Console.WriteLine($"{item.Name}을 장착 해제하였습니다..");
                }
                else
                {
                    Item previouseItem = equipment[item.EquipSlot];
                    equipment[item.EquipSlot] = item;
                    Console.WriteLine($"{previouseItem.Name}을 장착 해제하고 {item.Name}을 장착했습니다.");
                }
            }
            else       //장착 한게 없다!
            {
                equipment.Add(item.EquipSlot, item);
                Console.WriteLine($"{item.Name}을 장착했습니다.");
            }
        }
    }
}

//      미구현 항목들
//        %%----도전 기능
//        %% -Dictionaly ~ItemSlot, Item ~equipment
//        %% -exp : 던전 횟수 카운트
//        %% +void EnterDungeon(Dungeon dungeon)

//        %% +void LevelUp()