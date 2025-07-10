using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;
using Week2TextRPG_Younga.Models;
using Week2TextRPG_Younga.Scenes;

namespace Week2TextRPG_Younga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Console.WriteLine("캐릭터를 생성합니다. (이전에 사용한 캐릭터를 불러오려면 이름을 똑같이 입력해주세요.)");
            Console.Write("이름을 입력해주세요: ");
            input = Console.ReadLine();

            Player player = SceneManager.Instance.LoadPlayer(input);    //파일 찾아서 시도해보고
            if (player == null) //파일 못찾아서 비어있으면 새로 생성
            {
                player = new Player(input);

                Console.WriteLine($"{input}이 생성되었습니다. ");
            }
            else
            {
                Console.WriteLine($"{input}을 불러왔습니다. ");
            }
            SceneBase[] scenes =
                {
                    new MainScene(player),
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
                new Dungeon("쉬운 던전", 5, 1000, 10),
                new Dungeon("일반 던전", 11, 1700, 17),
                new Dungeon("어려운 던전", 17, 2500, 25)
            };
            SceneManager.Instance.InitializeScenes(scenes);
            SceneManager.Instance.InitializeDungeons(dungeons);

            Console.WriteLine("계속 진행하려면 아무키나 입력하세요...");
            Console.ReadKey();

            SceneManager.Instance.SetScene(SceneType.Main);
        }
    }
}
