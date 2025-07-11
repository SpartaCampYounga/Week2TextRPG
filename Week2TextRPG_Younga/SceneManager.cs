﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;
using Week2TextRPG_Younga.Models;
using Week2TextRPG_Younga.Scenes;
using Week2TextRPG_Younga.Utility;

namespace Week2TextRPG_Younga
{
    internal class SceneManager
    {
        public Store _store { get; private set; }
        public Dictionary<SceneType, SceneBase> _scenes = new Dictionary<SceneType, SceneBase>();
        public List<Dungeon> _dungeons = new List<Dungeon>();
        private SceneManager() 
        { 
            _store = new Store();
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
        public void InitializeDungeons(Dungeon[] dungeons)
        {
            foreach (Dungeon dungeon in dungeons)
            {
                InitializeDungeon(dungeon);
            }
        }

        public void InitializeDungeon(Dungeon dungeon)
        {
            _dungeons.Add(dungeon);
        }

        public void SavePlayer(Player player)
        {
            JsonSerializerSettings setting = JsonUtility.GetJsonSetting();
            // 파일 생성 후 쓰기
            File.WriteAllText(JsonUtility.path + $@"\\player_{player.Name}.json", JsonConvert.SerializeObject(player,setting));
            Console.WriteLine($"{player.Name}(이)가 저장되었습니다.");
        }
        public Player LoadPlayer(string playerName)
        {
            JsonSerializerSettings setting = JsonUtility.GetJsonSetting();

            Player player = null;
            try
            {
                //JsonConvert.PopulateObject(File.ReadAllText(path + $@"\\player_{playerName}.json"), player);
                player = JsonConvert.DeserializeObject<Player>(File.ReadAllText(JsonUtility.path + $@"\\player_{playerName}.json"), setting);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"{playerName}(은)는 존재하지 않습니다.");
                player = new Player(playerName);

            }
            return player;
        }
    }
}
