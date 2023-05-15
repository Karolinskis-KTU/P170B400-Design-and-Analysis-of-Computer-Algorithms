using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

using Project.Models;

namespace Project
{    class Program
    {
        static void Main(string[] args)
        {
            const string cityPath = "Data/Table2.csv";
            const string routePath = "Data/Table3.csv";

            const string startCity = "Vilnius";
            const int maxTime = 48 * 60 * 60; // 48 hours

            List<City> cities = new List<City>();
            cities = DataReader.ReadCities(cityPath);
            Console.WriteLine("Succesfuly read file:" + cityPath);
            Console.WriteLine("Number of cities: " + cities.Count);

            List<Route> routes = new List<Route>();
            routes = DataReader.ReadRoutes(routePath);
            Console.WriteLine("Succesfuly read file:" + routePath);
            Console.WriteLine("Number of routes: " + routes.Count);

            List<City> optimalRoute = FindOptimalRoute(cities, routes, startCity, maxTime);

            var plotModel = new PlotModel { Title = "Optimal route" };
            var lineSeries = new LineSeries();

            foreach (City city in optimalRoute)
            {
                lineSeries.Points.Add(new DataPoint(city.X, city.Y));
            }

            plotModel.Series.Add(lineSeries);

            var plotView = new PlotView();
            plotView.Model = plotModel;

            plotView.Size = new Size(720, 720);

            var form = new Form();
            form.Controls.Add(plotView);
            form.ClientSize = new Size(720, 720);

            Console.WriteLine("Optimal route:");
            foreach (City city in optimalRoute)
            {
                Console.Write(city.Name + "->");
            }

            Application.Run(form);
        }

        public static List<City> FindOptimalRoute(List<City> cities, List<Route> routes, string startCity, int maxTime)
        {
            List<City> optimalRoute = new List<City>();
            int time = 0;
            HashSet<string> visitedCities = new HashSet<string>();
            string currentCity = startCity;

            while (time < maxTime && visitedCities.Count < cities.Count)
            {
                City optimalCity = null;
                double bestScore = 0;

                foreach (City city in cities)
                {
                    if (city.Name == currentCity && !visitedCities.Contains(city.Name))
                    {
                        if (city.Rating > bestScore)
                        {
                            bestScore = city.Rating;
                            optimalCity = city;
                        }
                    }
                }

                if (optimalCity != null)
                {
                    optimalRoute.Add(optimalCity);
                    visitedCities.Add(optimalCity.Name);

                    foreach (Route route in routes)
                    {
                        if (route.CityFrom == currentCity && !visitedCities.Contains(route.CityTo))
                        {
                            time += route.TimeTaken;
                            currentCity = route.CityTo;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            optimalRoute.Add(optimalRoute[0]);
            return optimalRoute;
        }
    }
}