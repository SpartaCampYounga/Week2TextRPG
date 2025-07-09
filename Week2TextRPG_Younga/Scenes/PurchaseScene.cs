using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Week2TextRPG_Younga.Scenes
{
    internal class PurchaseScene : SceneBase, IScene
    {
        public PurchaseScene(Player player) : base(player)
        {
        }

        public override void LoadScene()
        {
            int input;

            Console.Clear();
            Console.WriteLine("LoadStoreScene");
            Console.WriteLine(
                "상점 - 아이템 구매\n" +
                "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                "[보유 골드]\n" +
                $"{_player.Gold} G\n\n" +
                "[아이템 목록]"
                );
            SceneManager.Instance.store.DisplayItems(true, _player);

            Console.WriteLine(
                "0. 나가기\n"
                );
            Console.Write("원하시는 행동을 입력해주세요.\n>>");
            input = GetIntegerRange(0, SceneManager.Instance.store.ItemsForSale.Count() + 1);

            if (input == 0)
            {
                SceneManager.Instance.SetScene(new StoreScene(_player));
            }
            else
            {
                Item selectedItem = SceneManager.Instance.store.ItemsForSale[input - 1];
                SceneManager.Instance.store.SellToPlayer(_player, selectedItem);
            }
            Console.WriteLine("계속 진행하려면 Enter를 입력하세요...");
            Console.Read();

            SceneManager.Instance.SetScene(this);   
            //결제 끝나고 나서는 purchase 씬으로 다시 오는데.. 아래 new Scene을 계속 생성해도 되는건가?
            //SceneManager.Instance.SetScene(new PurchaseScene(_player));
        }
    }
}
