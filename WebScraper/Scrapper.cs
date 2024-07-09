using HtmlAgilityPack;
using WebScraper.Models;

namespace WebScraper;

public class Scrapper
{
    public List<MatchDetails> GetMatch(string url)
    {
        {
            List<MatchDetails> matches = new List<MatchDetails>();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var nodes = doc.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[@class='game_summaries']/div/table[@class='teams']/tbody");

            foreach (var node in nodes)
            {
                var match = new MatchDetails
                {
                    Winner = node.SelectSingleNode("tr[@class='winner']/td[1]").InnerText,
                    WinnerScore = Int32.Parse(node.SelectSingleNode("tr[@class='winner']/td[2]").InnerText),
                    Loser = node.SelectSingleNode("tr[@class='loser']/td[1]").InnerText,
                    LoserScore = Int32.Parse(node.SelectSingleNode("tr[@class='loser']/td[2]").InnerText)
                };
                matches.Add(match);
            }
            return matches;
        }
    }
}