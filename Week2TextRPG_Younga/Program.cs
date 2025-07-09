using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
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
            player.Inventory.Add(SceneManager.Instance.store.ItemsForSale[1]);

            SceneManager.Instance.SetScene(new TitleScene(player));
        }
    }
}
