using Newtonsoft.Json;
using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Classes
{
    internal class Player
    {
        private static int nextId = 1;
        [JsonProperty]
        private int id;
        [JsonProperty]
        private int level;
        [JsonProperty]
        private string name;
        [JsonProperty]
        private string job;
        [JsonProperty]
        private int attack;
        [JsonProperty]
        private int defence;
        [JsonProperty]
        private int health;
        [JsonProperty]
        private int gold;
        [JsonProperty]
        private int exp;
        [JsonProperty]
        private List<Item> inventory = new List<Item>();
        [JsonProperty]
        public Dictionary<EquipSlot, Item> equipment = new Dictionary<EquipSlot, Item>();

        [JsonIgnore]
        public int Id => id;
        [JsonIgnore]
        public int Level => level;
        [JsonIgnore]
        public string Name => name;
        [JsonIgnore]
        public string Job => job;
        [JsonIgnore]
        public int Attack => attack;
        [JsonIgnore]
        public int Defence => defence;
        [JsonIgnore]
        public int Health => health;
        [JsonIgnore]
        public int Gold => gold;
        [JsonIgnore]
        public int Exp => exp;
        [JsonIgnore]
        public List<Item> Inventory => inventory;
        public Player(string name)
        {
            id = nextId++;
            level = 1;
            this.name = name;
            job = "전사";
            attack = 10;
            defence = 5;
            health = 100;
            gold = 1500;
            exp = 0;
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
            else Console.Write($"공격력: {attack} (+{totalAttackBonus})\n");
            //방어력
            if (totalDefenseBonus == 0) Console.Write($"방어력: {defence}\n");
            else Console.Write($"방어력: {defence} (+{totalDefenseBonus})\n");
            //체력
            Console.Write($"체력: {health}\n");
            //골드
            Console.Write($"Gold {gold} G\n");
            //경험치
            Console.Write($"Exp {exp}\n");
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
                
                display += equipment.Values.Any(x => x.Id == inventory[i].Id) ? "[E]" : ""; //장착 중이라면 [E]출력
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
            if (equipment.Values.Any(x => x.Id == item.Id))
            {
                int totalAttackBonus = item.Enhancement.TryGetValue(Ability.Attack, out int attackBonus) ? attackBonus : 0;
                int totalDefenseBonus = item.Enhancement.TryGetValue(Ability.Defence, out int defenceBonus) ? defenceBonus : 0;

                //기존 장비 해체 능력치 감소
                attack -= totalAttackBonus;
                defence -= totalDefenseBonus;

                //장착도 해제
                equipment.Remove(item.EquipSlot);
            }
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
            bool isSuccessful;
            if(gold >= 500 && health < 100)
            {
                gold -= 500;
                health = 100;
                isSuccessful = true;
            }
            else
            {
                isSuccessful = false;
            }
            return isSuccessful;
        }

        public void Equip(Item item)
        {
            int totalAttackBonus = item.Enhancement.TryGetValue(Ability.Attack, out int attackBonus) ? attackBonus : 0;
            int totalDefenseBonus = item.Enhancement.TryGetValue(Ability.Defence, out int defenceBonus) ? defenceBonus : 0;

            if (equipment.ContainsKey(item.EquipSlot))      //이미 장착한게 있다!
            {
                if (equipment[item.EquipSlot].Id == item.Id) //이미 같은 것을 장착하고 있다.
                {
                    equipment.Remove(item.EquipSlot);
                    //기존 장비 해체 능력치 감소
                    attack -= totalAttackBonus;
                    defence -= totalDefenseBonus;
                    Console.WriteLine($"{item.Name}을 장착 해제하였습니다..");
                }
                else
                {
                    Item previouseItem = equipment[item.EquipSlot];
                    equipment[item.EquipSlot] = item;

                    //기존장비 해제 아이템 능력치 감소
                    totalAttackBonus -= previouseItem.Enhancement.TryGetValue(Ability.Attack, out attackBonus) ? attackBonus : 0;
                    totalDefenseBonus -= previouseItem.Enhancement.TryGetValue(Ability.Defence, out defenceBonus) ? defenceBonus : 0;

                    //새장비 장착 아이템 능력치 증가
                    attack += totalAttackBonus;
                    defence += totalDefenseBonus;
                    Console.WriteLine($"{previouseItem.Name}을 장착 해제하고 {item.Name}을 장착했습니다.");
                }
            }
            else       //장착 한게 없다!
            {
                equipment.Add(item.EquipSlot, item);
                //새장비 장착 아이템 능력치 증가
                attack += totalAttackBonus;
                defence += totalDefenseBonus;
                Console.WriteLine($"{item.Name}을 장착했습니다.");
            }
        }

        public void Damaged(int damage)
        {
            health -= damage;
        }
        public void EarnGold(int gold)
        {
            this.gold += gold;
        }
        public void EarnExp(int exp)
        {
            this.exp += exp;
            if (this.exp >= 100) LevelUp();
        }
        public void LevelUp()   //일단은 경험치 100마다 레벨업
        {
            exp -= 100;
            level++;
            attack += 1;
            defence += 1;
            Console.WriteLine($"레벨업하여 Lv.{level}이 되었다!" + "\n");
        }
    }
}