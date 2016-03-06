<Query Kind="Program" />

void Main()
{
	var workingDirectory = new DirectoryInfo(Environment.CurrentDirectory);
	
	Func<int, string> read = id => 
	{
	var path = Path.Combine(workingDirectory.FullName, id + ".txt");
	
	return File.ReadAllText(path);
	
	};
}

