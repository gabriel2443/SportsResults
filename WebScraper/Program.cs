using WebScraper;

var scraper = new Scrapper();
var url = "https://www.basketball-reference.com/boxscores/";

var matchDetails = scraper.GetMatch(url);
bool isRunning = true;
while (isRunning)
{
    foreach (var match in matchDetails)
    {
        Console.WriteLine($"{match.Winner}, {match.WinnerScore}\n {match.Loser}, {match.LoserScore}");
        Console.ReadLine();
    }
}