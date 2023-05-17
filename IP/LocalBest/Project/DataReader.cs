using System.IO;

using Project.Models;

namespace Project;

static class DataReader {
    public static List<City> ReadCities(string path) 
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File not found", path);
        }

        List<City> cities = new List<City>();

        using (StreamReader sr = new StreamReader(path))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(',');
                cities.Add( new City (
                    lineSplit[0],               // Name
                    double.Parse(lineSplit[1]), // Rating
                    double.Parse(lineSplit[2]), // X
                    double.Parse(lineSplit[3])  // Y
                ));
            }
        }

        return cities;
    }

    public static List<Route> ReadRoutes(string path)
    {
        if(!File.Exists(path))
        {
            throw new FileNotFoundException("File not found", path);
        }

        List<Route> routes = new List<Route>();

        using (StreamReader sr = new StreamReader(path))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(',');
                routes.Add( new Route (
                    lineSplit[0],               // CityFrom
                    lineSplit[1],               // CityTo
                    int.Parse(lineSplit[2]),    // TimeTaken
                    double.Parse(lineSplit[3])  // Price
                ));
            }
        }

        return routes;
    }    
}
