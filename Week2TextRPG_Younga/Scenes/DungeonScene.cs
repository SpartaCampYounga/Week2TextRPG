using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;
using Week2TextRPG_Younga.Models;

namespace Week2TextRPG_Younga.Scenes
{
    internal class DungeonScene : SceneBase, IScene
    {
        public override SceneType SceneType => SceneType.Dungeon;
        public DungeonScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;
            Console.Clear();
            SceneManager.Instance.SavePlayer(_player);
            Console.WriteLine("LoadInventoryScene");

            Console.WriteLine(
                "던전입장\n" +
                $"이곳에서 원하는 던전에 입장할 수 있습니다. (현재 체력: {_player.Health})\n"
                );

            int index = 0;
            foreach (Dungeon dungeon in SceneManager.Instance._dungeons)
            {
                Console.WriteLine(++index + ". " + dungeon);
            }

            Console.WriteLine(
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, SceneManager.Instance._dungeons.Count() + 1);

            if (input == 0)
            {
                SceneManager.Instance.SetScene(SceneType.Main);
            }
            else
            {
                if (SceneManager.Instance._dungeons[input - 1].TryEnter(_player))    //던전 입장 가능 체크
                {
                    SceneManager.Instance._dungeons[input - 1].Rewarded(_player);    //플레이어 rewarded
                }
            }

            WaitResponse();

            SceneManager.Instance.SetScene(SceneType.Dungeon);
        }
    }
}
