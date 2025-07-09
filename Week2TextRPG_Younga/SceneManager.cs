using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Week2TextRPG_Younga.Scenes;

namespace Week2TextRPG_Younga
{
    internal class SceneManager
    {
        public Store store { get; private set; }
        public readonly Dictionary<SceneType, SceneBase> _scenes = new Dictionary<SceneType, SceneBase>();
        private SceneManager() 
        { 
            store = new Store();
        }

        private static SceneManager instance;

        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SceneManager();
                }
                return instance;
            }
        }

        private IScene currentScene;
        public void SetScene(SceneType type)
        {
            if (_scenes.ContainsKey(type))
            {
                currentScene = _scenes[type];
                currentScene.LoadScene();
            }
            else
            {
                Console.WriteLine("씬 로드 실패");
                Console.WriteLine("아무키나 입력하면 시작으로 돌아갑니다.");
                Console.ReadKey();
                currentScene.LoadScene();
            }
        }
        public void InitializeScenes(SceneBase[] scenes)
        {
            foreach (SceneBase scene in scenes)
            {
                InitializeScene(scene);
            }
        }

        public void InitializeScene(SceneBase scene)
        {
            _scenes.Add(scene.SceneType, scene);
        }
    }
}
