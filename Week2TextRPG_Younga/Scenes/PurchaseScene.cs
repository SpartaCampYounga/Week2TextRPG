﻿using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Scenes
{
    internal class PurchaseScene : SceneBase, IScene
    {
        public override SceneType SceneType => SceneType.Purchase;
        public PurchaseScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;
            Console.Clear();
            SceneManager.Instance.SavePlayer(_player);

            Console.WriteLine("LoadStoreScene");
            Console.WriteLine(
                "상점 - 아이템 구매\n" +
                "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                "[보유 골드]\n" +
                $"{_player.Gold} G\n\n" +
                "[아이템 목록]"
                );
            SceneManager.Instance._store.DisplayItems(true, _player);

            Console.WriteLine(
                "\n" +
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, SceneManager.Instance._store.ItemsForSale.Count() + 1);

            if (input == 0)
            {
                SceneManager.Instance.SetScene(SceneType.Store);
            }
            else
            {
                Item selectedItem = SceneManager.Instance._store.ItemsForSale[input - 1];
                SceneManager.Instance._store.SellToPlayer(_player, selectedItem);
            }

            WaitResponse();

            SceneManager.Instance.SetScene(SceneType.Purchase);   
        }
    }
}
