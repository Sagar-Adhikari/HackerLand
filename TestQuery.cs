namespace HackerLand
{
  public class TestQuery
  {
    public int NumberOfCities { get; set; }
    public int CostLibrary { get; set; }
    public int CostRoad { get; set; }
    public List<List<int>> Cities { get; set; }

    public TestQuery()
    {
      Cities = new List<List<int>>();
    }


    public static List<TestQuery> Parse(string inputFile)
    {
      var result = new List<TestQuery>();
      var inputQueue = new Queue<String>();
      foreach (var line in File.ReadAllLines(inputFile))
        inputQueue.Enqueue(line);

      var totalQueries = int.Parse(inputQueue.Dequeue());
      while (inputQueue.Count > 0)
      {
        var queryParams = inputQueue.Dequeue().Split(' ').Select(int.Parse).ToList();
        
        var testQuery = new TestQuery
        {
          NumberOfCities = queryParams[0],
          CostLibrary = queryParams[2],
          CostRoad = queryParams[3]
        };
        
        // get roads
        for (var i = 0; i < queryParams[1]; i++)
        {
          var road = inputQueue.Dequeue().Split(' ').Select(int.Parse).ToList();
          testQuery.Cities.Add(road);
        }
        result.Add(testQuery);
      }

      return result;
    }
  }
}