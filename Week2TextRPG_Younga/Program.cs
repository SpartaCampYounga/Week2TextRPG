namespace Week2TextRPG_Younga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Console.Write("이름을 입력해주세요: ");
            input = Console.ReadLine();

            Player player = new Player(input);

            LoadMainScene(player);

        }




        //min~(max-1)범위의 Integer만 입력 받을 때까지 반복.
        //자주 쓰는 Random.Next(min, max)는 max 미포함인 맥락 맞춰서 헷갈릴 여지 줄이려고 max-1로 설정함.
        static int GetIntegerRange(int min, int max)
        {
            bool isSuccessful = false;
            int integer;

            do
            {
                string input = Console.ReadLine();
                isSuccessful = int.TryParse(input, out integer) && (integer >= min && integer < max);
                //Parse 안되면 && 뒤에 integer 비교 안하고 false 대입함.

                if (!isSuccessful)
                {
                    Console.WriteLine($"{min}~{max - 1} 범위의 숫자(정수)만 입력해주세요.");
                }
            } while (!isSuccessful);
            return integer;
        }

        static void LoadMainScene(Player player)
        {
            Console.Clear();

            int input;

            Console.WriteLine(
                "스파르타 마을에 오신 여러분 환영합니다.\n" +
                "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n" + "\n" +
                "1. 상태보기\n" +
                "2. 인벤토리\n" +
                "3. 상점\n" + "\n" +
                "원하시는 행동을 입력해주세요.");

            input = GetIntegerRange(1, 4);

            switch (input)
            {
                case 1:
                    LoadStatusScene(player);
                    break;
                case 2:
                    LoadInventoryScene(player);
                    break;
                case 3:
                    LoadStoreScene(player);
                    break;
            }
        }

        static void LoadStatusScene(Player player)
        {
            Console.Clear();
            Console.WriteLine("LoadStatusScene");
            Console.WriteLine(
                "상태보기\n" +
                "캐릭터의 정보가 표시됩니다.\n" +
                $"Lv. {player.Level.ToString("D2")}\n" +    //TIL
                $"{player.Name} ( {player.Job} )\n" +
                $"공격력: {player.Attack}\n" +
                $"방어력: {player.Defence}\n" +
                $"체력: {player.Health}\n" +
                $"Gold {player.Gold} G\n"
                );
        }
        static void LoadInventoryScene(Player player)
        {
            Console.Clear();
            Console.WriteLine("LoadInventoryScene");
        }
        static void LoadStoreScene(Player player)
        {
            Console.Clear();
            Console.WriteLine("LoadStoreScene");
        }
    }
}
