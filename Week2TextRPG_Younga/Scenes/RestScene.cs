using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga.Scenes
{
    internal class RestScene : SceneBase, IScene
    {
        public override SceneType SceneType => SceneType.Rest;

        public RestScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadRestScene");
            Console.WriteLine(
                "휴식하기\n" +
                $"500 G을 내면 체력을 회복할 수 있습니다. (현재 체력: {_player.Health} 보유 골드 : {_player.Gold})"
                );

            Console.WriteLine(
                "\n" +
                "1. 휴식하기\n" +
                "0. 나가기\n" +
                "\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, 2);

            switch (input)
            {
                case 1:
                    if(_player.TakeRest())
                    {
                        Console.WriteLine($"500골드를 소모하여 체력이 회복되었습니다. (현재 체력: {_player.Health} 보유 골드 : {_player.Gold})");
                    }
                    WaitResponse();
                    SceneManager.Instance.SetScene(SceneType.Rest);
                    break;
                case 0:
                    SceneManager.Instance.SetScene(SceneType.Title);
                    break;
            }
        }
    }
}
