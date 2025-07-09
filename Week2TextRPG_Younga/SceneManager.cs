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
        private SceneManager() { store = new Store(); }

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
        public void SetScene(IScene newScene)
        {
            currentScene = newScene;
            currentScene.LoadScene();
        }
    }
}
