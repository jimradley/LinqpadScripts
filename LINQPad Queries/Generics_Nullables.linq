<Query Kind="Program" />

void Main()
{
   var x = Parse(43);
   var y = Parse("test");
   var z = Parse(null);
   
   var t = new Nullable<Int32>();
   var s = String.Empty;
   
   WriteToDebug(212);
   WriteToDebug("test");
   WriteToDebug(t);
   WriteToDebug(s);
}

T WriteToDebug<T>(T val)
{
	if (val == null)
	{
	Console.WriteLine("returning null....");
		return default(T);
	}
	
	Console.WriteLine(val);
	if (val.GetType() == typeof(Int32))
	{
		Console.WriteLine("int");
	}
	
	return val;
}

public dynamic Parse(dynamic val)
{
	if (val == null)
	return null;
	
	if (val.GetType() == typeof(Int32))
	{
		Console.WriteLine("int");
	}
					
	if (val.GetType() == typeof(String))
	{
		Console.WriteLine("string");
	}
	
   try { 
        return val;
   }
   catch { return val;}
}


