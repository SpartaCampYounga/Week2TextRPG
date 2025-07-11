using Newtonsoft.Json;
using Week2TextRPG_Younga.Enum;
using Week2TextRPG_Younga.Utility;

namespace Week2TextRPG_Younga.Classes
{
    internal class Store
    {
        public List<Item> ItemsForSale { get; set; }

        public Store()
        {
            CreateAllItemJsonFile();
            ItemsForSale = GetStoreItemListFromJsonFile();
        }
        public void DisplayItems(bool isNumbered, Player player)
        {
            int index = 1;
            string display = "";
            foreach (Item item in ItemsForSale)
            {
                display = isNumbered ? $" - {index++} " : " - ";
                display += item.ToString().Replace("[E]", "");


                bool isOwned = player.Inventory.Any(x => x.Name == item.Name);
                display += isOwned
                    ? FormatUtility.AlignWithPadding("판매완료",10) : FormatUtility.AlignWithPadding($"{item.Price} G", 10);
                display += " | ";
                Console.WriteLine(display);
            }
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
        //static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\") + "\\Jsons";
        void CreateAllItemJsonFile()
        {
            Item[] allItems =
            {
                new Item(1, "수련자갑옷", 1000, "수련에 도움을 주는 갑옷입니다.", new Dictionary<Ability, int> { { Ability.Defence, 5 } }, EquipSlot.Armor),
                new Item(2, "무쇠갑옷", 2000, "무쇠로 만들어져 튼튼한 갑옷입니다.", new Dictionary<Ability, int> { { Ability.Defence, 9 } }, EquipSlot.Armor),
                new Item(3, "스파르타의 갑옷", 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", new Dictionary<Ability, int> { { Ability.Defence, 15 } }, EquipSlot.Armor),
                new Item(4, "낡은 검", 600, "쉽게 볼 수 있는 낡은 검입니다.", new Dictionary<Ability, int> { { Ability.Attack, 3 } }, EquipSlot.Weapon),
                new Item(5, "청동 도끼", 1500, "어디선가 사용됐던 것 같은 도끼입니다.", new Dictionary<Ability, int> { { Ability.Attack, 5 } }, EquipSlot.Weapon),
                new Item(6, "스파르타의 창", 2500, "스파르타의 전사들이 사용했다는 전설의 창입니다.", new Dictionary<Ability, int> { { Ability.Attack, 7 } }, EquipSlot.Weapon),
                //New Items!
                new Item(7, "수련자투구", 800, "수련자를 위한 머리에 쓰는 투구입니다.", new Dictionary<Ability, int> { { Ability.Defence, 3 } }, EquipSlot.Helmet),
                new Item(8, "무쇠투구", 1700, "무겁지만 튼튼합니다.", new Dictionary<Ability, int> { { Ability.Defence, 5 } }, EquipSlot.Helmet),
                new Item(9, "스파르타의 투구", 2500, "스파르타의 전사들을 상징합니다.", new Dictionary<Ability, int> { { Ability.Defence, 9 } }, EquipSlot.Helmet),
                new Item(10, "낡은 신발", 400, "불편하지만 발을 보호합니다.", new Dictionary<Ability, int> { { Ability.Defence, 1 } }, EquipSlot.Boots),
                new Item(11, "가죽 신발", 1000, "튼튼하고 편안합니다.", new Dictionary<Ability, int> { { Ability.Defence, 3 } }, EquipSlot.Boots),
                new Item(12, "반지", 1200, "어떤 염원이 담겼습니다. 공격력과 방어력이 상승합니다.", new Dictionary<Ability, int> { { Ability.Attack, 1 }, { Ability.Defence, 1 } }, EquipSlot.Accessory),
                new Item(13, "스파르타의 방패", 4000, "스파르타 전사들이 사용했다는 전설의 방패입니다.", new Dictionary<Ability, int> { { Ability.Defence, 20 } }, EquipSlot.Shield)
            };
            // 파일 생성 후 쓰기
            File.WriteAllText(JsonUtility.path + @"\\StoreItems.json", JsonConvert.SerializeObject(allItems));
            Console.WriteLine($"{allItems}가 저장되었습니다.");
        }
        public static List<Item> GetStoreItemListFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(JsonUtility.path + @"\\StoreItems.json"));
        }
    }
}
