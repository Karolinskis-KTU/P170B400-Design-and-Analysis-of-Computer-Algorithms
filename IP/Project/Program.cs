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

            List<City> cities = new List<City>();
            cities = DataReader.ReadCities(cityPath);
            Console.WriteLine("Succesfuly read file:" + cityPath);
            Console.WriteLine("Number of cities: " + cities.Count);

            List<Route> routes = new List<Route>();
            routes = DataReader.ReadRoutes(routePath);
            Console.WriteLine("Succesfuly read file:" + routePath);
            Console.WriteLine("Number of routes: " + routes.Count);

            GeneticRoute geneticRoute = new GeneticRoute();
            geneticRoute.SetData(cities, routes);

            geneticRoute.Run();

            var plotModel = new PlotModel();
            var lineSeries = new LineSeries();

            foreach (var city in cities)
            {
                var dataPoints = new DataPoint(city.X, city.Y);
                lineSeries.Points.Add(dataPoints);
            }

            plotModel.Series.Add(lineSeries);

            var plotView = new PlotView();
            plotView.Model = plotModel;

            plotView.Size = new Size(720, 720);

            var form = new Form();
            form.Controls.Add(plotView);
            form.ClientSize = new Size(720, 720);

            int counter = 0;

            var worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += (sender, e) =>
            {
                var startTime = DateTime.Now;

                // Generate and update data points continuously until cancellation
                while ( !worker.CancellationPending && DateTime.Now - startTime < TimeSpan.FromSeconds(60) )
                {
                    // base case
                    counter++;
                    if (counter == geneticRoute.generations + 1)
                    {
                        worker.CancelAsync();
                        return;
                    }
                    
                    List<City> currentRoute = geneticRoute.Update();
                    lineSeries.Points.Clear();

                    List<DataPoint> dataPoints = new List<DataPoint>();
                    foreach (var city in currentRoute)
                    {
                        dataPoints.Add(new DataPoint(city.X, city.Y));
                    }
                    
                    // Invoke UI upadate on the main UI thread
                    form.Invoke(new Action(() => {
                        lineSeries.Points.AddRange(dataPoints);

                        // Refresh the plot
                        plotView.InvalidatePlot(true);
                    }));
                }

                // When time limit reached print message with final score
                if (DateTime.Now - startTime > TimeSpan.FromSeconds(60))
                {
                    Console.WriteLine($"Time limit reached.");
                    form.Invoke(new Action(() => {
                        geneticRoute.BestFitness();
                    }));
                }
            };

            // Handle the FormClosing event to stop the background worker
            form.FormClosing += (sender, e) =>
            {
                worker.CancelAsync();
            };

            worker.RunWorkerAsync();


            
            Application.Run(form);
        }

    }
}