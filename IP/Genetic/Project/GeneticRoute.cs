namespace Project;

using Project.Models;

class GeneticRoute
{
    // Settings
    public int populationSize {get;}
    public int generations {get;}
    public double mutationRate {get;}

    static Random random = new Random();

    public static List<City> cities = new List<City>();
    public static List<Route> routes = new List<Route>();

    int currentGeneration = 0;
    List<CurrentRoute> population = new List<CurrentRoute>();

    static List<string> shuffledCityNames;

    CurrentRoute AllTimeBestRoute;

    public GeneticRoute(int populationSize = 50, int generations = 1000, double mutationRate = 0.1)
    {
        // Intialize default values
        this.populationSize = populationSize;
        this.generations = generations;
        this.mutationRate = mutationRate;
    }

    public void SetData(List<City> cities, List<Route> routes)
    {
        GeneticRoute.cities = cities;
        GeneticRoute.routes = routes;

        shuffledCityNames = GetShuffledCityNames();
    }

    public void Run()
    {
        // Create initial population
        population = IntializePopulation(populationSize);
    }

    public List<City> Update()
    {
        Console.WriteLine($"Genetic Route: Generation {currentGeneration + 1} of {generations}");
        population = EvolvePopulation(population, mutationRate);


        if (AllTimeBestRoute == null || AllTimeBestRoute.Fitness < population.OrderBy(r => r.Fitness).Last().Fitness ) {
            AllTimeBestRoute = population.OrderBy(r => r.Fitness).Last();
            AllTimeBestRoute.Cities.Add(AllTimeBestRoute.Cities[0]);
            Console.WriteLine($"Found new best route: {AllTimeBestRoute.Fitness}");
        }

        // FInd best route
        CurrentRoute bestRoute = population.OrderBy(r => r.Fitness).Last();

        // Print best route
        //Console.WriteLine("Best route:");
        List<City> bestRouteCities = new List<City>();
        foreach (string city in bestRoute.Cities)
        {
            var Fullcity = GetCityByName(city);
            bestRouteCities.Add(Fullcity);
        }

        currentGeneration++;
        bestRouteCities.Add(bestRouteCities[0]);
        if(currentGeneration >= generations)
        {

            Console.WriteLine("Best route:");
            foreach (string city in AllTimeBestRoute.Cities)
            {
                City cityObj = GetCityByName(city);
                Console.WriteLine(cityObj.Name);
            }
            // Fitness of the best route
            Console.WriteLine("Fitness: " + AllTimeBestRoute.Fitness);
        }

        
        return bestRouteCities;
    }

    public List<City> BestFitness()
    {
        Console.WriteLine("Best route:");
        Console.WriteLine(String.Join("->", AllTimeBestRoute.Cities));
        // Fitness of the best route
        Console.WriteLine("Fitness: " + AllTimeBestRoute.Fitness);

        List<City> bestRouteCities = new List<City>();
        foreach (string city in AllTimeBestRoute.Cities)
        {
            City cityObj = GetCityByName(city);
            bestRouteCities.Add(cityObj);
        }
        return bestRouteCities;
    }

    static List<CurrentRoute> IntializePopulation(int populationSize)
    {
        List<CurrentRoute> population = new List<CurrentRoute>();

        for (int i = 0; i < populationSize; i++)
        {
            List<string> cities = new List<string>(shuffledCityNames);
            double fitness = CalculateFitness(cities);
            CurrentRoute route = new CurrentRoute(cities, fitness);
            population.Add(route);
        }

        return population;
    }

    static List<string> GetShuffledCityNames()
    {
        List<string> shuffledCities = cities.Select(c => c.Name).ToList();
        shuffledCities = Utilities.ShuffleList(shuffledCities);
        return shuffledCities;
    }

    static double CalculateFitness(List<string> cities)
    {
        double fitness = 0;
        HashSet<string> visitedCities = new HashSet<string>();
        int totalTravelTime = 0;

        for (int i = 0; i < cities.Count - 1; i++)
        {
            string cityA = cities[i];
            string cityB = cities[i + 1];
            visitedCities.Add(cityA);

            // Find route from cityA to cityB
            var route = routes.FirstOrDefault(r => (r.CityFrom == cityA && r.CityTo == cityB) || (r.CityFrom == cityB && r.CityTo == cityA));
            if (route != default)
            {
                City cityAObject = GetCityByName(cityA);
                if (cityAObject != default)
                {
                    fitness += cityAObject.Rating;
                    totalTravelTime += route.TimeTaken;
                }
                else
                {
                    Console.WriteLine($"City object not found: {cityA}");
                }
            }
            // else
            // {
            //     Console.WriteLine($"Route not found between {cityA} and {cityB}");
            // }
        }

        string lastCity = cities.Last();
        visitedCities.Add(lastCity);

        // Calculate fitness and total travel time for the last city to the first city
        var returnTrip = routes.FirstOrDefault(r => (r.CityFrom == lastCity && r.CityTo == cities[0]) || (r.CityFrom == cities[0] && r.CityTo == lastCity));
        if (returnTrip != default)
        {
            totalTravelTime += returnTrip.TimeTaken;
        }
        // else
        // {
        //     Console.WriteLine($"Return route not found between {lastCity} and {cities[0]}");
        // }

        // Check if total travel time exceeds 48 hours
        if (totalTravelTime > 48 * 60 * 60)
        {
            fitness = 0; // Set fitness to 0 if time constraint is violated
        }

        return fitness;
    }

    static City GetCityByName(string name)
    {
        City city = cities.FirstOrDefault(c => c.Name == name);

        if (city == null) 
        {
            throw new Exception($"City not found: {name}");
        }

        return cities.FirstOrDefault(c => c.Name == name);
    }

    private static List<CurrentRoute> EvolvePopulation(List<CurrentRoute> population, double mutationRate)
    {
        List<CurrentRoute> nextGeneration = new List<CurrentRoute>();

        // Selection and crossover
        for (int i = 0; i < population.Count; i++)
        {
            CurrentRoute parent1 = Selection(population);
            CurrentRoute parent2 = Selection(population);
            CurrentRoute offspring = Crossover(parent1, parent2);
            nextGeneration.Add(offspring);
        }

        // Mutation
        for (int i = 0; i < nextGeneration.Count; i++)
        {
            Mutate(nextGeneration[i], mutationRate);
        }

        return nextGeneration;
    }

    static CurrentRoute Selection(List<CurrentRoute> population)
    {
        int tournamentSize = 5;
        return TournamentSelection(population, tournamentSize);

        // // Select random individual from population
        // int index = random.Next(population.Count);
        // return population[index];
    }

    private static CurrentRoute TournamentSelection(List<CurrentRoute> population, int tournamentSize)
    {
        // Randomly select individuals from the population to participate in the tournament
        List<CurrentRoute> tournamentParticapants = new List<CurrentRoute>();
        for (int i = 0; i < tournamentSize; i++)
        {
            int randomIndex = random.Next(population.Count);
            tournamentParticapants.Add(population[randomIndex]);
        }

        // Find the best individual among the tournament participants
        CurrentRoute bestIndividual = tournamentParticapants.OrderBy(r => r.Fitness).Last();
        return bestIndividual;
    }

    static CurrentRoute Crossover(CurrentRoute parent1, CurrentRoute parent2)
    {
        // Select random part from one parent and fill the rest with the other parent
        int crossoverPoint = random.Next(1, parent1.Cities.Count - 1);
        List<string> offspringCities = parent1.Cities.Take(crossoverPoint).ToList();

        foreach (string city in parent2.Cities)
        {
            if (!offspringCities.Contains(city))
            {
                offspringCities.Add(city);
            }
        }

        double fitness = CalculateFitness(offspringCities);
        return new CurrentRoute(offspringCities, fitness);
    }

    static void Mutate(CurrentRoute route, double mutationRate)
    {
        // Change city order with a probability of mutationRate
        for (int i = 0; i < route.Cities.Count; i++)
        {
            if (random.NextDouble() < mutationRate)
            {
                int j = random.Next(route.Cities.Count);
                SwapCities(route.Cities, i, j);
            }
        }

        route.Fitness = CalculateFitness(route.Cities);
    }

    static void SwapCities(List<string> cities, int i, int j)
    {
        string temp = cities[i];
        cities[i] = cities[j];
        cities[j] = temp;
    }
}