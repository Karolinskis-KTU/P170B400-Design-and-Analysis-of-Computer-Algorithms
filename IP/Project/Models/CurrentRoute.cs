namespace Project.Models;

class CurrentRoute
{
    /// <summary>
    /// List of city names in the route
    /// </summary>
    /// <value></value>
    public List<string> Cities { get; set; }
    /// <summary>
    /// Fitness of the route
    /// </summary>
    /// <value></value>
    public double Fitness { get; set; }

    /// <summary>
    /// Intializes a new instance of the <see cref="Route"/> class
    /// </summary>
    /// <param name="cities">List of all cities in route</param>
    /// <param name="fitness">Fitness of the route</param>
    public CurrentRoute(List<string> cities, double fitness)
    {
        Cities = cities;
        Fitness = fitness;
    }
}