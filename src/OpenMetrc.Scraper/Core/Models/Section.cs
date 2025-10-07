namespace OpenMetrc.Scraper.Core.Models;

internal class Section
{
    public Section(string name)
    {
        Name = name;
        Endpoints = [];
    }

    public string Name { get; set; }
    public ICollection<string> Endpoints { get; set; }
}