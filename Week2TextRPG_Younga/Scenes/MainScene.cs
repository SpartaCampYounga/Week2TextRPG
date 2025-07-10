using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Scenes
{
    internal class MainScene : SceneBase, IScene
    {
        public override SceneType SceneType => SceneType.Main;
        public MainScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;
            Console.Clear();
            SceneManager.Instance.SavePlayer(_player);
            Console.WriteLine("LoadMainScene");

            Console.Write(
                "스파르타 마을에 오신 여러분 환영합니다.\n" +
                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n" +
                "\n" +
                "1. 상태보기\n" +
                "2. 인벤토리\n" +
                "3. 상점\n" +
                "4. 던전입장\n" +
                "5. 휴식하기\n" +
                "\n" +
                "원하시는 행동을 입력해주세요.\n>>");

            input = GetIntegerRange(1, 6);

            switch (input)
            {
                case 1:
                    SceneManager.Instance.SetScene(SceneType.Status);
                    break;
                case 2:
                    SceneManager.Instance.SetScene(SceneType.Inventory);
                    break;
                case 3:
                    SceneManager.Instance.SetScene(SceneType.Store);
                    break;
                case 4:
                    SceneManager.Instance.SetScene(SceneType.Dungeon);
                    break;
                case 5:
                    SceneManager.Instance.SetScene(SceneType.Rest);
                    break;
            }
        }
    }
}
