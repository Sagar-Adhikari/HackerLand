using System.Text;

namespace HackerLand
{
  public class Graph
  {
    public Dictionary<int, Node> Nodes { get; set; }

    public Graph(int numNodes)
    {
      Nodes = new Dictionary<int, Node>();
      for (int i = 1; i <= numNodes; i++)
        Nodes.Add(i, new Node(i));
    }

    public override string ToString()
    {
      var result = new StringBuilder();
      result.Append("{\n");
      foreach(var node in Nodes.Values)
        result.Append(node.ToString() + "\n");
      result.Append("}");
      return result.ToString();
    }

    public Graph Initialize(List<List<int>> edges)
    {
      for(int i = 0; i < edges.Count; i++)
      {
        var node1 = Nodes[edges[i][0]];
        node1.AddNeighbor(edges[i][1]);

        var node2 = Nodes[edges[i][1]];
        node2.AddNeighbor(edges[i][0]);
      }
      return this;
    }

    public int[] GetTotalIslandsAndEdges()
    {
      var visited = new HashSet<int>();
      var stack = new Stack<int>();
      int totalIslands = 0;
      int totalEdges = 0;

      while(visited.Count < Nodes.Count)
      {
        var canTraverse = true;
        var unvisitedNodeValue = Nodes.Keys.First(k => !visited.Contains(k));
        totalEdges--;
        stack.Push(unvisitedNodeValue);
        do
        {
          try
          {
            var currentNodeValue = stack.Pop();
            var currentNode = Nodes[currentNodeValue];
            if(visited.Contains(currentNode.Value))
              continue;
            foreach(var neighbor in currentNode.Neighbors)
            {
              if(!visited.Contains(neighbor))
              {
                stack.Push(neighbor);
              }
            }
            visited.Add(currentNode.Value);
            totalEdges++;
          }
          catch
          {
            canTraverse = false;
          }
        } while(canTraverse);
        totalIslands++;
      }
      return new []{totalIslands, totalEdges};
    }
  }
}