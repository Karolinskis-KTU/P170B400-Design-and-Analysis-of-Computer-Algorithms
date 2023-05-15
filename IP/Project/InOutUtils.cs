// using System;
// using System.IO;

// namespace Project
// {
//     class InOutUtils
//     {
//         /// <summary>
//         /// Reads city information from a file
//         /// </summary>
//         /// <param name="path">Path to file to read from</param>
//         /// <returns>Returns a list of all city information</returns>
//         public static List<City> ReadCities(string path)
//         {

//             if (!File.Exists(path))
//             {
//                 throw new FileNotFoundException("File not found", path);
//             }

//             List<City> cityInfos = new List<City>();
//             using (StreamReader sr = new StreamReader(path))
//             {
//                 string? line;
//                 while ((line = sr.ReadLine()) != null)
//                 {
//                     string[] lineSplit = line.Split(',');
//                     cityInfos.Add(new City
//                     (
//                         lineSplit[0],
//                         double.Parse(lineSplit[1]),
//                         double.Parse(lineSplit[2]),
//                         double.Parse(lineSplit[3])
//                     ));
//                 }
//             }

//             return cityInfos;
//         }

//         /// <summary>
//         /// Reads city from to information from a file
//         /// </summary>
//         /// <param name="path">Path to file to read from</param>
//         /// <returns>Returns a list of all city from to information</returns>
//         public static List<Route> ReadRoutes(string path)
//         {
//             if (!File.Exists(path))
//             {
//                 throw new FileNotFoundException("File not found", path);
//             }

//             List<Route> routes = new List<Route>();
//             using (StreamReader sr = new StreamReader(path))
//             {
//                 string? line;
//                 while ((line = sr.ReadLine()) != null)
//                 {
//                     string[] lineSplit = line.Split(',');
//                     routes.Add(new Route
//                     (
//                         lineSplit[0],
//                         lineSplit[1],
//                         int.Parse(lineSplit[2]),
//                         double.Parse(lineSplit[3])
//                     ));
//                 }
//             }

//             return routes;
//         }
//     }
// }