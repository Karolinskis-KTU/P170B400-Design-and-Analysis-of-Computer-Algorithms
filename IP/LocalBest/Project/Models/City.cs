namespace Project.Models;

class City
{
    /// <summary>
    /// Name of the city
    /// </summary>
    /// <value></value>
    public string Name { get; set; }
    /// <summary>
    /// Rating of the city
    /// </summary>
    /// <value></value>
    public double Rating { get; set; }
    /// <summary>
    /// X coordinate of the city
    /// </summary>
    /// <value></value>
    public double X { get; set; }
    /// <summary>
    /// Y coordinate of the city
    /// </summary>
    /// <value></value>
    public double Y { get; set; }

    /// <summary>
    /// Intializes a new instance of the <see cref="City"/> class
    /// </summary>
    /// <param name="name">Name of the city</param>
    /// <param name="rating">Rating of the city</param>
    /// <param name="x">X coordinate of the city</param>
    /// <param name="y">Y coordinate of the city</param>
    public City(string name, double rating, double x, double y)
    {
        Name = name;
        Rating = rating;
        X = x;
        Y = y;
    }
}