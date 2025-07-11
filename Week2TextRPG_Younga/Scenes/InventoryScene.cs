﻿using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Scenes
{
    internal class InventoryScene : SceneBase, IScene
    {

        public override SceneType SceneType => SceneType.Inventory;
        public InventoryScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;
            Console.Clear();
            SceneManager.Instance.SavePlayer(_player);
            Console.WriteLine("LoadInventoryScene");

            Console.WriteLine(
                "인벤토리\n" +
                "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
                "[아이템 목록]"
                );
            _player.DisplayInventory(false);

            Console.WriteLine(
                "1. 장착 관리\n" +
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, 2);
            switch (input)
            {
                case 1:
                    SceneManager.Instance.SetScene(SceneType.Equipment);
                    break;
                case 0:
                    SceneManager.Instance.SetScene(SceneType.Main);
                    break;
            }
        }
    }
}
