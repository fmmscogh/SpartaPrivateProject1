using Project1;
using static System.Formats.Asn1.AsnWriter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections;

namespace Project1
{    
    public class Player
    {
        public int level { get; set; }
        public string name { get; set; }
        public string job { get; set; }
        public int attack { get; set; }
        public int patk {  get; set; }
        public int defense { get; set; }
        public int pdef {  get; set; }
        public int health { get; set; }
        public int money { get; set; }

        public Player(int Lv, string Name, string Job, int atk, int Patk, int def, int Pdef, int hp, int gold)
        {
            level = Lv;
            name = Name;
            job = Job;
            attack = atk;
            patk = Patk;
            defense = def;
            pdef = Pdef;
            health = hp;
            money = gold;
        }
    }

    public class Inven
    {
        public List<Eitem> equipItems;        

        public Inven()
        {
            equipItems = new List<Eitem>();
        }
        public void EIT(Eitem etem)
        {            
            equipItems.Add(etem);
        }       
    }


    public class Eitem
    {        
        public string iEquip {  get; set; }
        public string  iName{ get; set; }
        public string iAbilityType { get; set; }
        public int iAbilityPoint { get; set; }        
        public string iInfomation { get; set; }
        public int iPrice { get; set; }
        public string iSoldout {  get; set; }

        public Eitem(string _iequip, string _iname, string _iabilitytype, int _iabilitypoint, string _iinfomation)
        {
            iEquip = _iequip;
            iName = _iname;
            iAbilityType = _iabilitytype;
            iAbilityPoint = _iabilitypoint;
            iInfomation = _iinfomation;
        }

        public Eitem(string _iequip, string _iname, string _iabilitytype, int _iabilitypoint, string _iinfomation, int _iprice, string _isoldout)
        {
            iEquip = _iequip;
            iName = _iname;
            iAbilityType = _iabilitytype;
            iAbilityPoint = _iabilitypoint;
            iInfomation = _iinfomation;
            iPrice = _iprice;
            iSoldout = _isoldout;
        }        
    }

    public class Store
    {
        public List<Eitem> bsItems;
        public Store()
        {
            bsItems = new List<Eitem>();
        }
        public void SIT(Eitem bsingItem)
        {
            bsItems.Add(bsingItem);
        }        
    }
        

    internal class Program
    {
        public static Player player;
        public static Eitem eitem1;
        public static Eitem eitem2;
        public static Eitem eitem3;
        public static Inven inven;
        public static Store store;
        public static Eitem sitem1;
        public static Eitem sitem2;
        public static Eitem sitem3;
        public static Eitem sitem4;
        public static Eitem sitem5;
        public static Eitem sitem6;

        public static void Main (string[] args)
        {
            player = new Player(1, "Chad", "전사", 10, 0, 5, 0, 100, 1500);
            eitem1 = new Eitem("", "무쇠갑옷", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.");
            eitem2 = new Eitem("", "스파르타의 창", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.");
            eitem3 = new Eitem("", "낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.");
            inven = new Inven();
            inven.EIT(eitem1);
            inven.EIT(eitem2);
            inven.EIT(eitem3);
            sitem1 = new Eitem("", "수련자 갑옷", "방어력", 5, "수련에 도움을 주는 갑옷입니다.", 1000, "구매완료");
            sitem2 = new Eitem("", "무쇠갑옷", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2300, "구매완료");
            sitem3 = new Eitem("", "스파르타의 갑옷", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, "구매완료");
            sitem4 = new Eitem("", "낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600, "구매완료");
            sitem5 = new Eitem("", "청동 도끼", "공격력", 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500, "구매완료");
            sitem6 = new Eitem("", "스파르타의 창", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2500, "구매완료");
            store = new Store();
            store.SIT(sitem1);
            store.SIT(sitem2);
            store.SIT(sitem3);
            store.SIT(sitem4);
            store.SIT(sitem5);
            store.SIT(sitem6);

            while (true)
            {
                mainMenu();
                string input = Console.ReadLine();
                

                if (input == "1")
                {
                    while (true)
                    {
                        playerCondition();
                        string backInput = Console.ReadLine();
                        if (backInput == "0")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            wrongInput();
                        }
                    }                    
                }
                else if (input == "2")
                {
                    inventory();
                    string backInput = Console.ReadLine();                    
                    if (backInput == "0")
                    {
                        Console.Clear();
                    }
                    else if (backInput == "1")
                    {
                        while (true)
                        {
                            inventoryEquipment();
                            string selectNum = Console.ReadLine();
                            int selectNumInput = int.Parse(selectNum);

                            if (selectNumInput == 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (selectNumInput <= inven.equipItems.Count && selectNumInput >= 0)
                            {

                                if (inven.equipItems[selectNumInput - 1].iEquip.Contains("[E]"))
                                {
                                    inven.equipItems[selectNumInput - 1].iEquip = "";
                                    if (inven.equipItems[selectNumInput - 1].iAbilityType == "공격력")
                                    {
                                        player.attack -= inven.equipItems[selectNumInput - 1].iAbilityPoint;
                                        player.patk -= inven.equipItems[selectNumInput - 1].iAbilityPoint;
                                    }
                                    else
                                    {
                                        player.defense -= inven.equipItems[selectNumInput - 1].iAbilityPoint;
                                        player.pdef -= inven.equipItems[selectNumInput - 1].iAbilityPoint;
                                    }                                    
                                }
                                else if (inven.equipItems[selectNumInput - 1].iEquip.Contains(""))
                                {
                                    inven.equipItems[selectNumInput - 1].iEquip = "[E]";
                                    if (inven.equipItems[selectNumInput - 1].iAbilityType == "공격력")
                                    {
                                        player.attack += inven.equipItems[selectNumInput - 1].iAbilityPoint;
                                        player.patk += inven.equipItems[selectNumInput - 1].iAbilityPoint;
                                    }
                                    else
                                    {
                                        player.defense += inven.equipItems[selectNumInput - 1].iAbilityPoint;
                                        player.pdef += inven.equipItems[selectNumInput - 1].iAbilityPoint;
                                    }                                                                    
                                }

                            }
                            else
                            {
                                wrongInput();
                            }

                        }
                    }
                    else
                    {
                        wrongInput();
                        Console.Clear();                        
                    }
                                                                                                                                                                                                                      
                }
                else if (input == "3")
                {

                    storeMenu();
                    string backInput= Console.ReadLine();
                    
                    if (backInput == "0")
                    {
                        Console.Clear();
                    }
                    else if(backInput == "1")
                    {
                        while (true)
                        {
                            storeBuyMenu();

                            string inputKey = Console.ReadLine();
                            int inputKeyInt = int.Parse(inputKey);
                            if (inputKeyInt == 0)
                            {
                                Console.Clear();
                                break;
                            }

                            Eitem invenSame = inven.equipItems.Find(x => x.iName.Equals(store.bsItems[inputKeyInt - 1].iName));

                            if (player.money >= store.bsItems[inputKeyInt - 1].iPrice)
                            {                                
                                if (invenSame != null)
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                    Thread.Sleep(1000);
                                }                                
                                else
                                {
                                    Console.WriteLine("구매를 완료했습니다.");
                                    player.money -= store.bsItems[inputKeyInt - 1].iPrice;
                                    inven.equipItems.Add(store.bsItems[inputKeyInt - 1]);
                                    Thread.Sleep(1000);
                                }
                            }
                            else if (player.money < store.bsItems[inputKeyInt - 1].iPrice)
                            {                                
                                if (invenSame != null)
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                    Thread.Sleep(1000);
                                }
                                else
                                {
                                    Console.WriteLine("Gold 가 부족합니다.");
                                    Thread.Sleep(1000);
                                }
                            }                                                        
                        }                                                                                              
                    }
                }
                else if (input == "4")
                {
                    break;
                }
                else
                {
                    wrongInput();
                    Console.Clear();
                }
            }

        }

        static void mainMenu()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 게임종료");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }

        static void playerCondition()
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. {0}", player.level.ToString("X2"));
            Console.WriteLine("{0} ( {1} )", player.name, player.job);
            Console.Write("공격력 : {0}", player.attack);
            if (player.patk > 0)
            {
                Console.WriteLine(" (+{0})", player.patk);
            }

            if (player.patk == 0)
            {
                Console.WriteLine();
            }
            Console.Write("방어력 : {0}", player.defense);
            if (player.pdef > 0)
            {
                Console.WriteLine(" (+{0})", player.pdef);
            }

            if (player.pdef == 0)
            {
                Console.WriteLine();
            }
            Console.WriteLine("체력 : {0}", player.health);
            Console.WriteLine("Gold : {0} G", player.money);
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }

        static void wrongInput()
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
        }

        static void inventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < inven.equipItems.Count; i++)
            {
                Console.WriteLine($"- {inven.equipItems[i].iEquip}{inven.equipItems[i].iName}      | {inven.equipItems[i].iAbilityType} +{inven.equipItems[i].iAbilityPoint} | {inven.equipItems[i].iInfomation}");
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }

        static void inventoryEquipment()
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < inven.equipItems.Count; i++)
            {
                Console.WriteLine($"- {inven.equipItems[i].iEquip}{inven.equipItems[i].iName}      | {inven.equipItems[i].iAbilityType} +{inven.equipItems[i].iAbilityPoint} | {inven.equipItems[i].iInfomation}");
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("장착하거나 해지하고 싶은 아이템의 번호를 입력하거나 나가기 0번을 눌러주세요.");
            Console.Write(">>");
        }

        static void storeMenu()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", player.money);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < store.bsItems.Count; i++)
            {
                bool soldoutItem = false;
                Console.Write($"- {store.bsItems[i].iName}      | {store.bsItems[i].iAbilityType} +{store.bsItems[i].iAbilityPoint} | {store.bsItems[i].iInfomation}       | ");
                for (int j = 0; j < inven.equipItems.Count; j++)
                {
                    if (store.bsItems[i].iName == inven.equipItems[j].iName)
                    {
                        soldoutItem = true;
                        Console.WriteLine(" {0} ", store.bsItems[i].iSoldout);
                    }

                }

                if (soldoutItem == false)
                {
                    Console.WriteLine(" {0} G", store.bsItems[i].iPrice);
                }

            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }

        static void storeBuyMenu()
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", player.money);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < store.bsItems.Count; i++)
            {
                bool soldoutItem = false;
                string storeListP = $"- {i + 1} {store.bsItems[i].iName}      | {store.bsItems[i].iAbilityType} +{store.bsItems[i].iAbilityPoint} | {store.bsItems[i].iInfomation}       | {store.bsItems[i].iPrice} G ";
                string storeListS = storeListP.Replace($"{store.bsItems[i].iPrice} G ", store.bsItems[i].iSoldout);


                for (int j = 0; j < inven.equipItems.Count; j++)
                {
                    if (store.bsItems[i].iName == inven.equipItems[j].iName)
                    {
                        soldoutItem = true;
                        Console.WriteLine(storeListS);
                    }


                }

                if (soldoutItem == false)
                {
                    Console.WriteLine(storeListP);
                }

            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("구입하고싶은 아이템의 번호를 입력하거나 나가기 0번을 입력해주세요.");
            Console.Write(">>");
        }
    }         
}
