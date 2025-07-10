using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Scenes
{
    internal interface IScene
    {
        public SceneType SceneType { get; }
        void LoadScene();
    }
}
