

namespace cs_foundation_1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory bag = new();


            bool flag = true;
            while(flag)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("请选择操作：");
                Console.WriteLine("1. 开始游戏");
                Console.WriteLine("2. 查看背包");
                Console.WriteLine("0. 退出游戏");

                string? input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.Write("请输入非空目标数字：");
                    input = Console.ReadLine();
                }
                if (input != "1" && input != "2" && input != "0")
                {
                    Console.Write("请输入正确的数字");
                    continue;
                }
                switch (input)
                {
                    case "1":
                        GameStart(bag);
                        Console.WriteLine("按任意键返回...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Bag(bag);
                        break;
                    case "0":
                        flag = false;
                        continue;
                    default: break;
                }
                 
            }

            

        }
        
        static void GameStart(Inventory bag)
        {
            Player player = new (bag);
            Enemy enemy = new ();
            Status status = new();
            int round = 1;
            string chose = "Start";
            bool run = false;
            while (player.Health > 0 && enemy.Health > 0 && !run)
            {

                if (round == 1)
                {
                    Console.WriteLine("==========战斗开始==========");
                }
                else
                {
                    Console.WriteLine($"==========第{round}回合==========");
                }

                Console.WriteLine($"玩家：战士      HP：{player.Health}/{player.MaxHealth}");
                Console.WriteLine($"敌人：哥布林    HP：{enemy.Health}/{enemy.MaxHealth}");
                Console.WriteLine("请选择操作：");
                Console.WriteLine("1. 普通攻击");
                Console.WriteLine("2. 使用药水");
                Console.WriteLine("3. 查看状态");
                Console.WriteLine("0. 逃跑");
                Console.WriteLine(" ");


                string input = ReadNonEmptyString("请输入：");

                if (input != "1" && input != "2" && input != "3" && input != "0")
                {
                    Console.Write("请输入正确的数字");
                    continue;
                }

                chose = input;
                switch (chose)
                {
                    case "1":
                        player.Attack(enemy);
                        enemy.Attack(player);
                        round++;
                        break;
                    case "2":
                        if (player.PotionCount > 0)
                        {
                            player.Heal();
                            enemy.Attack(player);
                            round++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("当前无药水！");
                            break;
                        }
                    case "3":
                        status.Show(player, enemy);
                        Console.WriteLine(" ");
                        Console.WriteLine("按任意键退出状态...");
                        Console.ReadKey();
                        break;
                    case "0":
                        run = true;
                        Console.WriteLine(" ");
                        Console.WriteLine("游戏结束，你跑了");
                        continue;
                    default:
                        break;

                }
            }
            if (player.Health <= 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("游戏结束，你输了");
            }
            else if (enemy.Health <= 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("游戏结束，你赢了");
            }
        }

        static void Bag(Inventory bag)
        {
            bool bagMode = true;
            while (bagMode)
            {
                Console.WriteLine("==========玩家背包==========");
                Console.WriteLine(" ");
                Console.WriteLine($"背包容量：{bag.Count}/{bag.MaxCapacity}");
                Console.WriteLine(" ");


                Console.WriteLine(" ");
                Console.Write("请选择操作：");
                Console.WriteLine(" ");
                Console.WriteLine("1. 添加物品");
                Console.WriteLine("2. 移除物品");
                Console.WriteLine("3. 查看背包");
                Console.WriteLine("0. 退出");

                string? input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.Write("请输入非空目标数字：");
                    input = Console.ReadLine();
                }
                if (input != "1" && input != "2" && input != "3" && input != "0")
                {
                    Console.Write("请输入正确的数字");
                    continue;
                }

                
                switch (input)
                {
                    case "1":                        
                        string itemName = ReadNonEmptyString("输入添加的物品名：");
                        
                        if (bag.AddItem(itemName))
                        {
                            Console.WriteLine($"成功添加{itemName}");
                        }
                        else
                        {
                            Console.WriteLine("背包已满");
                        }

                        break;

                    case "2":
                        itemName = ReadNonEmptyString("输入删除的物品名：");

                        if (bag.RemoveItem(itemName))
                        {
                            Console.WriteLine($"成功删除一个{itemName}");
                        }
                        else
                        {
                            Console.WriteLine($"背包内无{itemName}");
                        }
                                  
                        break;
                        
                    case "3":
                        bag.ShowBag();
                        Console.WriteLine("按任意键退出展示...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "0":
                        bagMode = false;
                        continue;
                    default:
                        break;

                }

            }
            

        }

        static string ReadNonEmptyString(string prompt)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("输入不能为空，请重新输入：");
                input = Console.ReadLine();
            }
            return input;
        }
    }


     


    



    public class Status
    {

        public void Show(Player player,Enemy enemy)
        {
            
            Console.WriteLine("玩家状态：");
            Console.WriteLine($"血量：{player.Health}/{player.MaxHealth}，攻击力：{player.AttackPower}，剩余药水：{player.PotionCount}");
            Console.WriteLine(" ");
            Console.WriteLine("敌人状态：");
            Console.WriteLine($"血量：{enemy.Health}/{enemy.MaxHealth}，攻击力：{enemy.AttackPower}");

        }
    }

   
   
}
