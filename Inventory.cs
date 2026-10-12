namespace cs_foundation_1
{
	public class Inventory
	{
		private readonly List<string> items = new() { "药水", "药水", "药水" };
		private readonly Dictionary<string, int> itemsDic = new() { { "药水", 3 } };
		private readonly int maxCapacity = 10;

		public int Count { get { return items.Count; } }
		public int MaxCapacity { get { return maxCapacity; } }
		public int PotionCount { get { if (itemsDic.TryGetValue("药水", out int result)) return result; else return 0; } }

		public bool AddItem(string itemName)
		{
			if (Count < MaxCapacity)
			{
				items.Add(itemName);
				if (itemsDic.TryGetValue(itemName, out int value))
				{
					itemsDic[itemName]++;
				}
				else
				{
					itemsDic[itemName] = 1;
				}

				return true;
			}
			else return false;
		}
		public bool RemoveItem(string itemName)
		{
			if (itemsDic.TryGetValue(itemName, out int value))
			{
				itemsDic[itemName]--;
				if (itemsDic[itemName] == 0)
				{
					itemsDic.Remove(itemName);
				}
			}

			return items.Remove(itemName);
		}

		public void ShowBag()
		{
			if (Count == 0)
			{
				Console.WriteLine("背包为空");
			}
			else
			{
				Console.WriteLine(" ");
				Console.WriteLine($"背包容量：{Count}/{MaxCapacity}");
				Console.WriteLine("背包当前物品：");

				foreach (var item in itemsDic)
				{
					Console.WriteLine($"{item.Key} * {item.Value}");
				}

			}

		}
	}
}