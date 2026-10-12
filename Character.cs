namespace cs_foundation_1
{
    public class Character
    {
        public string Name { get; protected set; } = "Character";
        public float MaxHealth { get; protected set; }
        public float Health { get; protected set; }
        public float AttackPower { get; protected set; }

        public Character(float maxHealth, float attackPower)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
            AttackPower = attackPower;
        }

        public virtual void Info()
        {
            Console.WriteLine($"当前角色为：{Name}");
            Console.WriteLine($"血量：{Health}/{MaxHealth}，攻击力：{AttackPower}");
        }

        public void Attack(Character character)
        {
            if (Health > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{Name}发动攻击！");
                Console.WriteLine($"{character.Name}受到{character.Damage(AttackPower + Random.Shared.Next(-3,4))}伤害，剩余血量：{character.Health}/{character.MaxHealth}");
            }

        }
        public float Damage(float attack)
        {
            float damage = Math.Min(Health, attack);
            Health -= damage;
            return damage;
        }
    }
}