namespace cs_foundation_1
{
    public class Player : Character
    {
        public Player(Inventory bag) : base(100f, 20f)
        {
            this.bag = bag;
            Name = "玩家";
        }

        private readonly Inventory bag;

        public int PotionCount => bag.PotionCount;
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"背包容量：{bag.Count}/{bag.MaxCapacity}");
        }

        public float Heal()
        {
            float heal = Math.Min(MaxHealth - Health, 70);
            Health += heal;
            bag.RemoveItem("药水");
            Console.WriteLine(" ");
            Console.WriteLine("玩家使用了一瓶药水！");
            Console.WriteLine($"恢复了{heal}点HP，当前HP：{Health}/{MaxHealth}");
            return heal;
        }

    }
}