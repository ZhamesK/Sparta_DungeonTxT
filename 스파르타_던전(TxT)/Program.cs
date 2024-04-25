using System.ComponentModel;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace 스파르타_던전_TxT_
{
    public class Dungeon
    {
        // 스탯
        public static int action = 0;
        static int level = 1;
        static int atk = 10;
        static int def = 5;
        static int hp = 100;
        public static int gold = 1500;
        static void Main(string[] args)
        {
            startScene();
        }

        // 행동 입력
        static void Action()
        {
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            action = int.Parse(Console.ReadLine());
        }

        //시작 화면
        static void startScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("\n");

            while (action != 1 && action != 2 && action != 3)
            {
                Action();
                if (action == 1)
                {
                    status();
                    break;
                }
                else if (action == 2)
                {
                    inventory();
                    break;
                }
                else if (action == 3)
                {
                    shop();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        //상태 보기
        static void status()
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("\n");

            Console.WriteLine("Lv. " + level);
            Console.WriteLine("Admin (전사)");
            Console.WriteLine("공격력 : " + atk);
            Console.WriteLine("방어력 : " + def);
            Console.WriteLine("체 력 : " + hp);
            Console.WriteLine("Gold : " + gold + " G");
            Console.WriteLine("\n");

            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");

            while (action != 0)
            {
                Action();
                if (action == 0)
                {
                    startScene();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        //인벤토리
        static void inventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n");

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("- {0}\t| ");
            Console.WriteLine("\n");

            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");

            while (action != 0)
            {
                Action();
                if (action == 0)
                {
                    startScene();
                    break;
                }
                else if (action == 1)
                {
                    inventory();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        // 상점
        static void shop()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("\n");

            Console.WriteLine("[보유 골드]");
            Console.WriteLine(gold + " G");
            Console.WriteLine("\n");

            Console.WriteLine("[아이템 목록]");
            Equipment.description();
            Console.WriteLine("\n");

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");

            while (action != 0)
            {
                Action();
                if (action == 0)
                {
                    startScene();
                    break;
                }
                else if (action == 1)
                {
                    Console.Clear();
                    Console.WriteLine("상점 - 아이템 구매");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                    Console.WriteLine("\n");

                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine(gold + " G");
                    Console.WriteLine("\n");

                    Console.WriteLine("[아이템 목록]");
                    Equipment.description();
                    Console.WriteLine("\n");

                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("\n");
                    Equipment.purchase();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }

    /*enum Equips
    {
        noviceArmor = 1,
        ironArmor,
        spartaArmor,
        sword,
        axe,
        spear
    }*/

    //아이템 클라스
    internal class Equipment
    {
        static int item = 0;
        static string[] compare = null;
        static string[] noviceArmor = { "수련자 갑옷", "방어력 +5", "수련에 도움을 주는 갑옷입니다.", "1000 G", "1000" };
        static string[] ironArmor = { "무쇠갑옷", "방어력 +9", "무쇠로 만들어져 튼튼한 갑옷입니다.", "2000 G", "2000" };
        static string[] spartaArmor = { "스파르타의 갑옷", "방어력 +15", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", "3500 G", "2000" };
        static string[] sword = { "낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", "600 G", "600" };
        static string[] axe = { "청동 도끼", "공격력 +5", "어디선가 사용됐던거 같은 도끼입니다.", "1500 G", "1500" };
        static string[] spear = { "스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입닏다.", "2100 G", "2100" };

        public Equipment()
        {

        }

        //아이템 설명
        public static void description()
        {
            if (Dungeon.action == 0 || Dungeon.action == 3)
            {
                if (item == 1)
                {
                    compare = noviceArmor;
                }
                else if (item == 2)
                {
                    compare = ironArmor;
                }
                else if (item == 3)
                {
                    compare = spartaArmor;
                }
                else if (item == 4)
                {
                    compare = sword;
                }
                else if (item == 5)
                {
                    compare = axe;
                }
                else if (item == 6)
                {
                    compare = spear;
                }

                for (int i = 1, item = 1; i < 7; i++, item++)
                {
                    Console.WriteLine("- {0}\t| {1}  | {2}\t|  {3}", compare[0], compare[1], compare[2], compare[3]);
                }
                //Console.WriteLine("- {0}\t| {1}  | {2}\t|  {3}", noviceArmor[0], noviceArmor[1], noviceArmor[2], noviceArmor[3]);
                //Console.WriteLine("- {0}\t| {1}  | {2}\t|  {3}", ironArmor[0], ironArmor[1], ironArmor[2], ironArmor[3]);
                //Console.WriteLine("- {0}\t| {1}  | {2}\t|  {3}", spartaArmor[0], spartaArmor[1], spartaArmor[2], spartaArmor[3]);
                //Console.WriteLine("- {0}\t| {1}  | {2}\t|  {3}", sword[0], sword[1], sword[2], sword[3]);
                //Console.WriteLine("- {0}\t| {1}  | {2}\t|  {3}", axe[0], axe[1], axe[2], axe[3]);
                //Console.WriteLine("- {0}\t| {1}  | {2}\t|  {3}", spear[0], spear[1], spear[2], spear[3]);
            }
            else if (Dungeon.action == 1)
            {
                Console.WriteLine("- 1 {0}\t| {1}  | {2}\t|  {3}", noviceArmor[0], noviceArmor[1], noviceArmor[2], noviceArmor[3]);
                Console.WriteLine("- 2 {0}\t| {1}  | {2}\t|  {3}", ironArmor[0], ironArmor[1], ironArmor[2], ironArmor[3]);
                Console.WriteLine("- 3 {0}\t| {1}  | {2}\t|  {3}", spartaArmor[0], spartaArmor[1], spartaArmor[2], spartaArmor[3]);
                Console.WriteLine("- 4 {0}\t| {1}  | {2}\t|  {3}", sword[0], sword[1], sword[2], sword[3]);
                Console.WriteLine("- 5 {0}\t| {1}  | {2}\t|  {3}", axe[0], axe[1], axe[2], axe[3]);
                Console.WriteLine("- 6 {0}\t| {1}  | {2}\t|  {3}", spear[0], spear[1], spear[2], spear[3]);
            }
        }

        // 구매
        public static void purchase()
        {
            Console.WriteLine("원하는 행동을 입력해주세요.");
            item = int.Parse(Console.ReadLine());

            if (Dungeon.gold > int.Parse(compare[4]))
            {
                compare[3] = "구매완료";
            }
        }
    }
}
