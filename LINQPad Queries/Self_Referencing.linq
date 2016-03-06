<Query Kind="Program" />

void Main()
{
	foo = 1;
	Thing(foo);
}

public int foo { get; set; }

// Define other methods and classes here
public void Thing(int foo)
{
	foo++;
if (foo != 10)
{
	Console.WriteLine("Still Processing");
		Thing(foo);
			
	}
	
	else
{
Console.WriteLine("DONE");
}

}