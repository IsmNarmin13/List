using CustomList;

CustomList<int> customList = new CustomList<int>();

for (int i = 1; i <= 10; i++)
{
    customList.Add(i);
}

Console.WriteLine($"Count: {customList.Count}, Capacity: {customList.Capacity}");

Console.WriteLine("Find: " + customList.Find(x => x > 5));

Console.Write("FindAll: ");
var findAllList = customList.FindAll(x => x % 2 == 0);
foreach (var item in findAllList)
{
    Console.Write(item + " ");
}
Console.WriteLine();

Console.WriteLine("Contains 7: " + customList.Contains(7));
Console.WriteLine("Exists even: " + customList.Exists(x => x % 2 == 0));

Console.WriteLine("Remove 3");
customList.Remove(3);

Console.WriteLine($"Count: {customList.Count}, Capacity: {customList.Capacity}");

Console.ReadLine();