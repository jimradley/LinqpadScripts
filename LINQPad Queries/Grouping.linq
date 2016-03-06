<Query Kind="Program" />

void Main()
{
	List<ItemToBeGrouped> items = new List<ItemToBeGrouped>();
	
	items.Add(new ItemToBeGrouped {
	Id = 1,
	Name = "Test",
	Value = 12
	});
	
	items.Add(
		new ItemToBeGrouped {
	Id = 1,
	Name = "Test",
	Value = 12
	});
	
	
	items.Add(
	
		new ItemToBeGrouped {
	Id = 2,
	Name = "Test",
	Value = 12
	});
	
	
	var grouped = items.GroupBy(g => g.Id).Dump();
            foreach (var item in grouped)
            {

                var first = item.First();

          
                Console.WriteLine(String.Format("Item {0}, Value, {1}", first.Id, item.Sum(i => i.Value)));

            }
	
	
	
}

// Define other methods and classes here
public class ItemToBeGrouped
{

	public int Id { get; set; }
	
	public string Name { get; set; }
	
	public int Value { get; set; }
	
	
}