using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Week2TextRPG_Younga
{
    internal class Program
    {
        public static Store store = new Store();

        static void Main(string[] args)
        {

            /////
            string input;

            Console.Write("이름을 입력해주세요: ");
            input = Console.ReadLine();

            Player player = new Player(input);
            player.Inventory.Add(store.ItemsForSale[1]);

            LoadMainScene(player);
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
                "[아이템 목록]"
                );
            player.DisplayInventory(false);

            Console.WriteLine(
                "1. 장착 관리\n" +
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, 2);
            switch (input) { 
                case 1: LoadEquipmentScene(player); break; 
                case 0: LoadMainScene(player); break;
            }
        }
        static void LoadEquipmentScene(Player player)
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadEquipmentScene");
            Console.WriteLine(
                "인벤토리 - 장착 관리\n" +
                "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
                "[아이템 목록]"
                );
            player.DisplayInventory(true);
            //ShowItemList(player.Inventory, true);


            Console.WriteLine(
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, player.Inventory.Count() + 1);

            if (input == 0) 
            { 
                LoadInventoryScene(player); 
            }
            else
            {
                if (player.Inventory[input - 1].IsEquipped)
                    player.Inventory[input - 1].Unequip();
                else
                    player.Inventory[input - 1].Equip();

                LoadEquipmentScene(player);
            }
        }
        static void LoadStoreScene(Player player)
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadStoreScene");
            Console.WriteLine(
                "상점\n" +
                "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                "[보유 골드]\n" +
                $"{player.Gold} G\n\n" +
                "[아이템 목록]"
                );
            store.DisplayItems(false);


            Console.WriteLine(
                "1. 아이템 구매\n" +
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, 2);

            switch (input)
            {
                case 1: LoadPurchaseScene(player); break;
                case 0: LoadMainScene(player); break;
            }
        }
        static void LoadPurchaseScene(Player player)
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadStoreScene");
            Console.WriteLine(
                "상점 - 아이템 구매\n" +
                "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                "[보유 골드]\n" +
                $"{player.Gold} G\n\n" +
                "[아이템 목록]"
                );
            store.DisplayItems(true);

            Console.WriteLine(
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, store.ItemsForSale.Count() + 1);

            if (input == 0)
            {
                LoadStoreScene(player);
            }
            else
            {
                store.SellToPlayer(player, store.ItemsForSale[input - 1]);
            }
            Console.WriteLine("계속 진행하려면 Enter를 입력하세요...");
            Console.Read();
            LoadPurchaseScene(player);
        }
    }
}
