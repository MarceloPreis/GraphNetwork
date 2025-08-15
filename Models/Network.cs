namespace GraphNetwork.Models
{

    public class Network
    {
        private readonly Node[] elements;

        public Network(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than zero.");
            }

            elements = new Node[size];
            for (int i = 0; i < size; i++)
            {
                elements[i] = new Node(i);
            }
        }

        public void Connect(int a, int b)
        {
            CheckIndexes(a, b);

            elements[a].Connect(elements[b]);
            elements[b].Connect(elements[a]);
        }

        public void Disconnect(int a, int b)
        {
            CheckIndexes(a, b);

            elements[a].Disconnect(elements[b]);
            elements[b].Disconnect(elements[a]);
        }

        public bool Query(int a, int b)
        {
            CheckIndexes(a, b);

            return LevelConnection(a, b) > 0;
        }

        public int LevelConnection(int a, int b)
        {
            CheckIndexes(a, b);

            var visited = new List<Node>();
            var queue = new List<Node> { elements[a] };
            var levels = new List<int> { 0 };

            visited.Add(elements[a]);

            while (queue.Count > 0)
            {
                Node current = queue[0];
                int level = levels[0];
                queue.RemoveAt(0);
                levels.RemoveAt(0);

                if (current.Equals(elements[b]))
                    return level;

                foreach (var neighbor in current.ConnectedTo)
                {
                    if (!visited.Contains(neighbor))
                    {

                        queue.Add(neighbor);
                        levels.Add(level + 1);
                        visited.Add(neighbor);
                    }
                }
            }

            return 0;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= elements.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        private void CheckIndexes(int a, int b)
        {
            CheckIndex(a);
            CheckIndex(b);
        }
    }
}