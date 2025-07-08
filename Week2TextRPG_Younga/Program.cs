using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Week2TextRPG_Younga
{
    internal class Program
    {
        static public Store store = new Store();

        static void Main(string[] args)
        {

            /////
            string input;

            Console.Write("이름을 입력해주세요: ");
            input = Console.ReadLine();

            Player player = new Player(input);

            LoadMainScene(player);
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
                "[아이템 목록]"
                );
            player.DisplayInventory();

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
            ShowItemList(player.Inventory);


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
            }

            LoadEquipmentScene(player);
        }
        static void LoadStoreScene(Player player)
        {
            Console.Clear();
            Console.WriteLine("LoadStoreScene");
        }

        //1, 2, 3번 넘버링 해야해서 ... Item에 넣기도 그렇고 Store에 넣기도 그래서 그냥 개별 메소드로 뺐음.... 고민좀 해봐야할듯
        static void ShowItemList(List<Item> items)
        {
            for (int i = 0; i < items.Count(); i++)
            {
                Console.Write(" - " + (i + 1) + " ");   //숫자 1부터 시작.
                items[i].ToString();
            }
        }
    }
}
