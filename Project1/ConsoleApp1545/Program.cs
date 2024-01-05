using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1545
{
    internal class Program : ItemStore
    {
        static void Main(string[] args)
        {
            if (buyitemSelect < store.bsItems.Count)
            {
                if (store.bsItems[buyitemSelect - 1].iName == inven.equipItems[buyitemSelect - 1].iName)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    Thread.Sleep(1000);
                }
            }
            else if (store.bsItems[buyitemSelect - 1].iName != inven.equipItems[buyitemSelect - 1].iName)
            {
                if (store.bsItems[buyitemSelect - 1].iPrice <= player.money)
                {
                    Console.WriteLine("구매를 완료했습니다.");
                    player.money -= store.bsItems[buyitemSelect - 1].iPrice;
                    inven.equipItems.Add(store.bsItems[buyitemSelect - 1]);
                    Thread.Sleep(1000);
                }
                else if (store.bsItems[buyitemSelect - 1].iPrice > player.money)
                {
                    Console.WriteLine("Gold 가 부족합니다.");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }
    }    
}
