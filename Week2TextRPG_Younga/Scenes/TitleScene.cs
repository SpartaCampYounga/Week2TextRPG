using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga.Scenes
{
    internal class TitleScene : SceneBase, IScene
    {
        public TitleScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
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
                    SceneManager.Instance.SetScene(new StatusScene(_player));
                    break;
                case 2:
                    SceneManager.Instance.SetScene(new InventoryScene(_player));
                    break;
                case 3:
                    SceneManager.Instance.SetScene(new StoreScene(_player));
                    break;
            }
        }
    }
}
