namespace OpenMetrc.Scraper.Core.Models;

internal class StateSummary
{
    public StateSummary(string state)
    {
        State = state;
        Sections = [];
    }

    public string State { get; set; }
    public ICollection<Section> Sections { get; set; }
}