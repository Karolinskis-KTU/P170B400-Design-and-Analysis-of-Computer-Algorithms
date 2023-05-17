namespace Project.Models;

class Route
{
    /// <summary>
    /// Name of the city the route starts from
    /// </summary>
    /// <value></value>
    public string CityFrom { get; set; }
    /// <summary>
    /// Name of the city the route ends at
    /// </summary>
    /// <value></value>
    public string CityTo { get; set; }
    /// <summary>
    /// Time taken to travel from <see cref="CityFrom"/> to <see cref="CityTo"/>
    /// </summary>
    /// <value></value>
    public int TimeTaken { get; set; }
    /// <summary>
    /// Price to travel from <see cref="CityFrom"/> to <see cref="CityTo"/>
    /// </summary>
    /// <value></value>
    public double Price { get; set; }

    public Route(string cityFrom, string cityTo, int timeTaken, double price)
    {
        CityFrom = cityFrom;
        CityTo = cityTo;
        TimeTaken = timeTaken;
        Price = price;
    }
}