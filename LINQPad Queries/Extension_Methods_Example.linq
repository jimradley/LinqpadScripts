<Query Kind="Program" />

static void Main()
{
	string test = "word";
	
	test.Reverse().Dump();
}

public static class Extensions
{
	public static string Reverse(this string wordTo)
	{
		char[] arr = wordTo.ToCharArray();	
		Array.Reverse(arr);
		
		return new string(arr);
	}
}