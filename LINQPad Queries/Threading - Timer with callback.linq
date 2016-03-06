<Query Kind="Program" />

public Timer _timer { get; set; }

void Main()
{
	_timer = new Timer( Callback, null, 10000, Timeout.Infinite );

		   Console.WriteLine("Main Thread");
		   Thread.Sleep(1000);
		   
		   _timer.Dispose();
}

// Define other methods and classes here
private void Callback( Object state )
{
   Stopwatch watch = new Stopwatch();

   watch.Start();
   // Long running operation
   Console.WriteLine("Callback");
}