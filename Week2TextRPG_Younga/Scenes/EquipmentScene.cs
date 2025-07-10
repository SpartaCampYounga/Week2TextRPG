using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Scenes
{
    internal class EquipmentScene : SceneBase, IScene
    {

        public override SceneType SceneType => SceneType.Equipment;
        public EquipmentScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadEquipmentScene");
            Console.WriteLine(
                "인벤토리 - 장착 관리\n" +
                "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
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
                SceneManager.Instance.SetScene(SceneType.Inventory);
            }
            else
            {
                _player.Equip(_player.Inventory[input - 1]);
                WaitResponse();

                SceneManager.Instance.SetScene(SceneType.Equipment);
            }
        }
    }
}
