using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;
using Week2TextRPG_Younga.Models;
using Week2TextRPG_Younga.Scenes;

namespace Week2TextRPG_Younga
{
    internal class Program
    {
        //public static Store store = new Store();

        static void Main(string[] args)
        {
            string input;

            Console.Write("이름을 입력해주세요: ");
            input = Console.ReadLine();

            Player player = new Player(input);
            player.Inventory.Add(SceneManager.Instance._store.ItemsForSale[1]);

            SceneBase[] scenes =
                {
                    new TitleScene(player),
                    new StatusScene(player),
                    new InventoryScene(player),
                    new EquipmentScene(player),
                    new StoreScene(player),
                    new PurchaseScene(player),
                    new RestScene(player),
                    new SellScene(player),
                    new DungeonScene(player)
                };
            Dungeon[] dungeons =
            {
                new Dungeon(DungeonType.Easy, "쉬운 던전", 10, 5, 1000, 10),
                new Dungeon(DungeonType.Normal, "일반 던전", 15, 11, 1700, 17),
                new Dungeon(DungeonType.Hard, "어려운 던전", 20, 17, 2500, 25)
            };
            SceneManager.Instance.InitializeScenes(scenes);
            SceneManager.Instance.InitializeDungeons(dungeons);
            SceneManager.Instance.SetScene(SceneType.Title);
        }
    }
}
