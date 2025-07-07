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
        private List<Item> inventory;

        public int Id => id;
        public int Level => level;
        public string Name => name;
        public string Job => job;
        public int Attack => attack;
        public int Defence => defence;
        public int Health => health;
        public int Gold => gold;

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

        }
        public void DisplayInventory()
        {

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