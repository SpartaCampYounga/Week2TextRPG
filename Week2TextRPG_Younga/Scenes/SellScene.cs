using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;
using static System.Formats.Asn1.AsnWriter;

namespace Week2TextRPG_Younga.Scenes
{
    internal class SellScene : SceneBase, IScene
    {
        public override SceneType SceneType => SceneType.Sell;
        public SellScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadStoreScene");
            Console.WriteLine(
                "상점 - 아이템 판매\n" +
                "아이템을 판매할 수 있습니다.\n\n" +
                "[보유 골드]\n" +
                $"{_player.Gold} G\n\n" +
                "[아이템 목록]"
                );

            _player.DisplayInventory(true);

            Console.WriteLine(
                "\n" +
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, _player.Inventory.Count() + 1);

            if (input == 0)
            {
                SceneManager.Instance.SetScene(SceneType.Store);
            }
            else
            {
                Item selectedItem = _player.Inventory[input - 1];
                _player.SellItem(selectedItem);
            }

            WaitResponse();

            SceneManager.Instance.SetScene(SceneType.Sell);   
        }
    }
}
