using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Week2TextRPG_Younga.Scenes
{
    internal class StoreScene : SceneBase, IScene
    {
        public override SceneType SceneType => SceneType.Store;
        public StoreScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadStoreScene");
            Console.WriteLine(
                "상점\n" +
                "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                "[보유 골드]\n" +
                $"{_player.Gold} G\n\n" +
                "[아이템 목록]"
                );
            SceneManager.Instance.store.DisplayItems(false, _player);


            Console.WriteLine(
                "1. 아이템 구매\n" +
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, 2);

            switch (input)
            {
                case 1: 
                    SceneManager.Instance.SetScene(SceneType.Purchase); 
                    break;
                case 0: 
                    SceneManager.Instance.SetScene(SceneType.Title); 
                    break;
            }
        }
    }
}
