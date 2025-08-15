using System.Collections.Generic;

namespace GraphNetwork.Models
{
    public class Node
    {
        public int Key { get; set; }
        public List<Node> ConnectedTo { get; set; }

        public Node(int key)
        {
            Key = key;
            ConnectedTo = [];
        }

        public Node(int key, List<Node> connectedTo)
        {
            Key = key;
            ConnectedTo = connectedTo;
        }

        public override bool Equals(object? obj) => obj is Node other && Key == other.Key;
        
        public override int GetHashCode() => Key.GetHashCode();

        public void Connect(Node node)
        {
            ConnectedTo.Add(node);
        }

        public void Disconnect(Node node)
        {
            ConnectedTo.Remove(node);
        }

        public bool IsConnectedTo(Node node)
        {
            return ConnectedTo.Contains(node);
        }
    }
}
