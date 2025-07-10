using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Scenes
{
    internal class StatusScene : SceneBase, IScene
    {
        public override SceneType SceneType => SceneType.Status;
        public StatusScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;
            Console.Clear();
            SceneManager.Instance.SavePlayer(_player);
            Console.WriteLine("LoadStatusScene");

            Console.WriteLine(
                "상태보기\n" +
                "캐릭터의 정보가 표시됩니다.\n"
                );

            _player.DisplayPlayerStatus();

            Console.WriteLine(
                "\n" + 
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, 1);
            SceneManager.Instance.SetScene(SceneType.Main);
        }
    }
}
