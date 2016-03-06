<Query Kind="Program">
  <Reference Relative="..\..\Dropbox\Downloads\HtmlAgilityPack.dll">C:\Users\James\Dropbox\Downloads\HtmlAgilityPack.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Parallel.dll</Reference>
  <Namespace>HtmlAgilityPack</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

public string GetHTML(string url)
{
  	HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
	var response = String.Empty;
	
	try
	{	        
		using (var reader = new StreamReader(request.GetResponse().GetResponseStream()))
		{
			response = reader.ReadToEnd(); 
		}
	}
	catch (Exception ex)
	{
		
		Console.WriteLine("ERROR following not found " + url);
	}
		
	return response;
}


public void GetAllFilesWithExtension(string location, List<string> response, string fileExtension = "jpg")
{
Console.WriteLine("GETTING FILES FOR " + location);
		using(WebClient client = new WebClient())
		{	
			foreach(var link in response )
			{	
				Console.WriteLine(link);
				if (link.ToUpper().EndsWith("." + fileExtension.ToUpper()))
				{
					try
					{	        
					if (!File.Exists(@"C:\Temp\" + link))
					 client.DownloadFile(location + link, @"C:\Temp\" + link);
					}
					catch (Exception ex)
					{
						Console.WriteLine("location and link not found " + location + " " + link);
					}
				}	
			}
		}
}

public List<string> GetAllChildLinks(List<string> response, string currentUrl)
{
	var childLinks = new List<string>();
		using(WebClient client = new WebClient())
		{	
			foreach(var link in response.Skip(1) )
			{	
				if (link.ToUpper().EndsWith(@"/"))
				{
				childLinks.Add(currentUrl + link);
					//Console.WriteLine("LINK" + " " + currentUrl + link);
				}	
			}
		}
		return childLinks;
}

public List<string> ParseHTML(string htmlToParse)
{

string[] lines = htmlToParse.Split(new string[] { "\n" }, StringSplitOptions.None);

List<string> parsedLines = new List<string>();

foreach (var line in lines)
{

	if (line.Contains("a href="))
	{
	
	var startLength = line.IndexOf(@"a href=""") + 8;
	
	
	var txt = line.Substring(startLength, line.Length - startLength);
	
	startLength = txt.IndexOf(@"""");
	parsedLines.Add(txt.Substring(0, startLength));
	}
}

return parsedLines;
}


void Main()
{
	
	//var startingUrl = @"http://";
	var startingUrl = @"http://typecastexception.com/post/2014/04/20/ASPNET-MVC-and-Identity-20-Understanding-the-Basics.aspx";

	var currentUrl = startingUrl;
	
	var pageContent = GetHTML(currentUrl);

	var parsedHTML = ParseHTML(pageContent);
 
 	GetAllFilesWithExtension( currentUrl, parsedHTML, "JPG");
	var childLinks = GetAllChildLinks(parsedHTML, currentUrl);
	
	do
	{
	
	foreach (var link in childLinks)
	{
			pageContent = GetHTML(link);
		parsedHTML = ParseHTML(pageContent);
		GetAllFilesWithExtension( link, parsedHTML, "JPG");
		childLinks = GetAllChildLinks(parsedHTML, link);
	}
		
	} while (childLinks.Count > 0);
}

public int childLinks { get; set; }


// Define other methods and classes here