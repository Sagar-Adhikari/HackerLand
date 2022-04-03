using System.Text;

namespace HackerLand
{
  public class Node
  {
    private int _value { get; set; }
    private HashSet<int> _neighbors { get; set; }

    public int Value => _value;
    public HashSet<int> Neighbors => _neighbors;

    public Node(int value)
    {
      _value = value;
      _neighbors = new HashSet<int>();
    }

    public void AddNeighbor(int nodeValue)
    {
      if (!_neighbors.Contains(nodeValue))
        _neighbors.Add(nodeValue);
    }

    public override string ToString()
    {
      var result = new StringBuilder();
      result.Append($"{_value}: [ ");
      foreach (var neighbor in _neighbors)
        result.Append($"{neighbor} ");
      result.Append("]");
      return result.ToString();
    }
  }
}