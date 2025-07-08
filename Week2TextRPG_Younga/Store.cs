using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga
{
    internal class Store
    {
        //private List<Item> itemsForSale;

        public List<Item> ItemsForSale { get; set; }

        public Store()
        {
            ItemsForSale = GetAllItemJsonFile();
        }
        public void DisplayItems(bool isNumbered)
        {
            int index = 1;
            string prefix = " - ";
            foreach (Item item in ItemsForSale)
            {
                prefix = isNumbered ? $" - {index++} " : " - ";
                Console.Write(prefix);
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
        public void SellToPlayer(Player player, Item item)
        {
            bool isOwned = player.Inventory.Any(x => x.Id == item.Id); //TIL
            bool hasEnoughGold = player.Gold >= item.Price;
            if (isOwned)
            {
                Console.WriteLine("이미 구매한 아이템 입니다.");
                return;
            }
            else if (!hasEnoughGold)
            {
                Console.WriteLine("Gold가 부족합니다.");
            }
            else
            {
                player.PurchaseItem(item);
            }
        }


        //Item json파일.
        static string path = "D:\\CampWorkspace\\Week2TextRPG_Younga\\Week2TextRPG_Younga";
        void CreateAllItemJsonFile()
        {
            Item[] allItems =
            {
                new Item("수련자갑옷", 1000, "수련에 도움을 주는 갑옷입니다.", new Dictionary<Ability, int> { { Ability.Defence, 5 } }, EquipSlot.Armor),
                new Item("무쇠갑옷", 2000, "무쇠로 만들어져 튼튼한 갑옷입니다.", new Dictionary<Ability, int> { { Ability.Defence, 9 } }, EquipSlot.Armor),
                new Item("스파르타의 갑옷", 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", new Dictionary<Ability, int> { { Ability.Defence, 9 } }, EquipSlot.Armor),
                new Item("낡은 검", 600, "쉽게 볼 수 있는 낡은 검입니다.", new Dictionary<Ability, int> { { Ability.Attack, 2 } }, EquipSlot.Weapon),
                new Item("청동 도끼", 1500, "어디선가 사용됐던 것 같은 도끼입니다.", new Dictionary<Ability, int> { { Ability.Attack, 5 } }, EquipSlot.Weapon),
                new Item("스파르타의 창", 2500, "스파르타의 전사들이 사용했다는 전설의 창입니다.", new Dictionary<Ability, int> { { Ability.Attack, 7 } }, EquipSlot.Weapon)
            };
            // 파일 생성 후 쓰기
            File.WriteAllText(path + @"\\allItems.json", JsonConvert.SerializeObject(allItems));
            Console.WriteLine($"{allItems}가 저장되었습니다.");
        }
        public static List<Item> GetAllItemJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(path + @"\\allItems.json"));
        }
    }
}
