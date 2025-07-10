using Week2TextRPG_Younga.Classes;

namespace Week2TextRPG_Younga.Models
{
    internal class Dungeon
    {
        private static int nextId = 1;
        private int id;
        private string name;
        private int requiredDefense;
        private int rewardGold;
        private int rewardExp;
        
        public int Id => id;
        public string Name => name;
        public int RequiredDefense => requiredDefense;
        public int RewardGold => rewardGold;
        public int RewardExp => rewardExp;

        public Dungeon(string name, int requiredDefense, int rewardGold, int rewardExp)
        {
            id = nextId++;
            this.name = name;
            this.requiredDefense = requiredDefense;
            this.rewardGold = rewardGold;
            this.rewardExp = rewardExp;
        }
        public override string ToString()
        {
            return $"{name} \t|" + $"방어력 {requiredDefense} 이상 권장";
        }
        public void DisplayDungeons(bool isNumbered, Dungeon[] dungeons)
        {
            int index = 1;
            string display = "";
            foreach (Dungeon dungeon in dungeons)
            {
                display = isNumbered ? $"{dungeon.Id}. " : "";
                display += dungeon.ToString();
                //display += $"{dungeon.name} \t|" + $"방어력 {dungeon.requiredDefense} 이상 권장";

                Console.WriteLine(display);
            }
        }
        public bool TryEnter(Player player)
        {
            bool isCleared;
            Random random = new Random();
            if (player.Defence < requiredDefense && random.Next(0, 10) < 4)  //던전실패: 방어력이 낮거나, 40퍼 확률
            {
                int damage = player.Health / 2;
                player.Damaged(damage);

                Console.WriteLine($"{name} 클리어에 실패했다. 내 방어력이 너무 낮았을 지도... ");
                Console.WriteLine($"데미지 {damage}를 받았다. (현재 체력: {player.Health})");

                isCleared = false;
            }
            else //성공했을 때
            {
                int damage = 0;
                damage += random.Next(20, 36);    //기본 감소량 20 ~ 35
                if(player.Defence > requiredDefense)
                {
                    damage += random.Next(0, player.Defence - requiredDefense);
                }
                else
                {
                    damage += random.Next(player.Defence - requiredDefense, 0);
                }

                if (player.Health <= damage)  //플레이어 체력 0보다 낮으면 보상 안줄거라서 false 출력.
                {
                    player.Damaged(player.Health);
                    Console.WriteLine("죽었다...");
                    return false;
                }

                player.Damaged(damage);
                Console.WriteLine($"{name} 클리어에 성공했다. 데미지 {damage}를 받았다. (현재 체력: {player.Health})");

                isCleared = true;
            }
            return isCleared;
        }
        public void Rewarded(Player player)
        {
            Random random = new Random();
            int clearGold = rewardGold + random.Next(player.Attack, player.Attack * 2);
            int clearExp = rewardExp + random.Next(player.Attack, player.Attack * 2);
            Console.WriteLine($"{clearGold} G / 경험치 {clearExp} 를 획득했다!");

            player.EarnGold(clearGold);
            player.EarnExp(clearExp);

            player.DisplayPlayerStatus();

        }
    }
}
