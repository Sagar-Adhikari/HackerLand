using HackerLand;

var inputQueries = TestQuery.Parse("input.txt");
foreach(var query in inputQueries)
{
  Console.WriteLine(roadsAndLibraries(query.NumberOfCities, query.CostLibrary, query.CostRoad, query.Cities));
}


int roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
{
  var graph = new Graph(n).Initialize(cities);

  int totalCost = 0;

  if(c_lib < c_road)
  {
    totalCost = n * c_lib;
  }
  else
  {
    var islandsAndEdges = graph.GetTotalIslandsAndEdges();
    totalCost = c_lib * islandsAndEdges[0] + c_road * islandsAndEdges[1];
  }

  return totalCost;
}