﻿using Week2TextRPG_Younga.Classes;
using Week2TextRPG_Younga.Enum;

namespace Week2TextRPG_Younga.Scenes
{
    internal abstract class SceneBase : IScene
    {
        public abstract SceneType SceneType { get; }

        protected Player _player;

        public SceneBase(Player player)
        {
            _player = player;
        }

        public abstract void LoadScene();

        //min~(max-1)범위의 Integer만 입력 받을 때까지 반복.
        //자주 쓰는 Random.Next(min, max)는 max 미포함인 맥락 맞춰서 헷갈릴 여지 줄이려고 max-1로 설정함.
        protected int GetIntegerRange(int min, int max)
        {
            bool isSuccessful = false;
            int integer;

            do
            {
                string input = Console.ReadLine();
                isSuccessful = int.TryParse(input, out integer) && integer >= min && integer < max;
                //Parse 안되면 && 뒤에 integer 비교 안하고 false 대입함.

                if (!isSuccessful)
                {
                    Console.Write($"{min}~{max - 1} 범위의 숫자만 입력해주세요.\n>>");
                }
            } while (!isSuccessful);
            return integer;
        }
        protected void WaitResponse()
        {
            Console.WriteLine("계속 진행하려면 아무키나 입력하세요...");
            Console.ReadKey();
        }
    }
}
