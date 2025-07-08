using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Week2TextRPG_Younga
{
    internal class Program
    {
        static string path = "D:\\CampWorkspace\\Week2TextRPG_Younga\\Week2TextRPG_Younga";
        static void Main(string[] args)
        {

            CreateJson();
            Store store = new Store();
            store.ItemsForSale = GetJsonFile();
            foreach (var item in store.ItemsForSale)
            {
                item.ToString();
            }

            /////
            string input;

            Console.Write("이름을 입력해주세요: ");
            input = Console.ReadLine();

            Player player = new Player(input);

            LoadMainScene(player);
        }

        static void CreateJson()
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

        public static List<Item> GetJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(path + @"\\allItems.json"));
        }



        //min~(max-1)범위의 Integer만 입력 받을 때까지 반복.
        //자주 쓰는 Random.Next(min, max)는 max 미포함인 맥락 맞춰서 헷갈릴 여지 줄이려고 max-1로 설정함.
        static int GetIntegerRange(int min, int max)
        {
            bool isSuccessful = false;
            int integer;

            do
            {
                string input = Console.ReadLine();
                isSuccessful = int.TryParse(input, out integer) && (integer >= min && integer < max);
                //Parse 안되면 && 뒤에 integer 비교 안하고 false 대입함.

                if (!isSuccessful)
                {
                    Console.Write($"{min}~{max - 1} 범위의 숫자(정수)만 입력해주세요.\n>>");
                }
            } while (!isSuccessful);
            return integer;
        }

        static void LoadMainScene(Player player)
        {
            int input;

            Console.Clear();
            Console.Write(
                "스파르타 마을에 오신 여러분 환영합니다.\n" +
                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n" + "\n" +
                "1. 상태보기\n" +
                "2. 인벤토리\n" +
                "3. 상점\n" + "\n" +
                "원하시는 행동을 입력해주세요.\n>>");

            input = GetIntegerRange(1, 4);

            switch (input)
            {
                case 1:
                    LoadStatusScene(player);
                    break;
                case 2:
                    LoadInventoryScene(player);
                    break;
                case 3:
                    LoadStoreScene(player);
                    break;
            }
        }

        static void LoadStatusScene(Player player)
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadStatusScene");
            Console.WriteLine(
                "상태보기\n" +
                "캐릭터의 정보가 표시됩니다.\n"
                );

            player.DisplayPlayerStatus();

            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, 1);
            LoadMainScene(player);
        }
        static void LoadInventoryScene(Player player)
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadInventoryScene");
            Console.WriteLine(
                "인벤토리\n" +
                "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
                "[아이템 목록]\n"
                );


            Console.WriteLine(
                "1. 장착 관리\n" +
                "0. 나가기\n"
                );
            Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, 2);
            switch (input) { 
                case 1: LoadEquipmentScene(player); break; 
                case 2: LoadMainScene(player); break;
            }
        }
        static void LoadEquipmentScene(Player player)
        {
            Console.Clear();
            Console.WriteLine("LoadEquipmentScene");
        }
        static void LoadStoreScene(Player player)
        {
            Console.Clear();
            Console.WriteLine("LoadStoreScene");
        }
    }
}
