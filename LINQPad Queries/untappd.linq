<Query Kind="Program">
  <Reference>C:\libs\SendGrid.SmtpApi.dll</Reference>
  <Reference>C:\libs\SendGridMail.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.dll</Reference>
  <Namespace>Exceptions</Namespace>
  <Namespace>SendGrid</Namespace>
  <Namespace>SendGrid.SmtpApi</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Mail</Namespace>
</Query>

void Main()
{

	var urls = GetSearchContext();
		
		var searchPhrase = "Magic Rock Brewing by";
		
		foreach (var url in urls)
		{
			string urlContent = GetUrlContent(url.Key);
			
			if (urlContent.Contains(searchPhrase))
			{
				var indStart = urlContent.IndexOf(@"""og:title""");
	 			var trimmedContent = urlContent.Substring(indStart + 36,20);
				var nameOfVenue = trimmedContent.Substring(0,trimmedContent.IndexOf(@""""));
				Console.WriteLine(nameOfVenue);	
	
				var startOfSearchIndex = urlContent.IndexOf(searchPhrase) + searchPhrase.Length;
			
				var trimt = urlContent.Substring(startOfSearchIndex, 2000);
				string checkInDate = trimt.Substring(trimt.IndexOf(@"viewcheckindate"">") + 17, 25);
				Console.WriteLine(checkInDate);
							
				var nameOfDrinkStartIndex = trimt.IndexOf("is drinking") + 30;
				string startOfDrinkName = trimt.Substring(nameOfDrinkStartIndex, 200);
				var startOfNameind = startOfDrinkName.IndexOf(@"""") + 2;			
				var endIndex = startOfDrinkName.Substring(startOfNameind,23).IndexOf(@"<");
				var drinkName = startOfDrinkName.Substring(startOfNameind, endIndex);
				Console.WriteLine(drinkName);
				Console.WriteLine();
				
				var emailContent = drinkName + " checked into " +  nameOfVenue + " on " + checkInDate;
				SendMail(emailContent);
				
			}
		}
	
				Thread.Sleep(43200000); //12 hours
}

public Dictionary<string, string> GetSearchContext()
{
	var searchContext = new Dictionary<string, string>();
	
	searchContext.Add("https://untappd.com/venue/33823", "Magic Rock");  // North Bar
	searchContext.Add("https://untappd.com/venue/1796906", "Magic Rock"); // Bundobust
	searchContext.Add("https://untappd.com/venue/1221765", "Magic Rock");
	searchContext.Add("https://untappd.com/venue/314930", "Magic Rock");
	
	searchContext.Add("https://untappd.com/venue/65013", "Magic Rock");
	
	
	
	return searchContext;
}

public string GetUrlContent(string url)
{

  HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
        webRequest.Method = "POST";
        System.Net.WebClient client = new System.Net.WebClient();
        byte[] data = client.DownloadData(url);
        string html = System.Text.Encoding.UTF8.GetString(data);
		
		return html;
}

public void SendMail(string emailContent)
{


}