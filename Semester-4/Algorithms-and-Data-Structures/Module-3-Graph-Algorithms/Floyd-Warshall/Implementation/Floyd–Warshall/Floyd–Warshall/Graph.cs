namespace Floyd_Warshall
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    class Graph
    {
        private List<Vertex> vertecies = new List<Vertex>();
        private List<Connection> connections = new List<Connection>();
        public int VerteciesCount { get; private set; }
        public int ConnectionsCount { get; private set; }

        public Graph()
        {
            VerteciesCount = 0;
            ConnectionsCount = 0;
        }

        public void AddVertex()
        {
            vertecies.Add(new Vertex(VerteciesCount));
            VerteciesCount++;
        }

        public void AddConnection(int idStart, int idEnd, int length)
        {
            if (idStart == idEnd) throw new InvalidOperationException("Invalid connection");

            if (VerteciesCount < idStart) throw new InvalidOperationException($"No vertex \'{idStart}\' in the graph.");

            if (VerteciesCount < idEnd) throw new InvalidOperationException($"No vertex \'{idEnd}\' in the graph.");

            if (FindConnection(idStart, idEnd) != null)
                throw new InvalidOperationException($"Connection \'{idStart}\' -> \'{idEnd}\' already exists.");

            connections.Add(new Connection(idStart, idEnd, length));
            ConnectionsCount++;
        }

        private int GetVertexConnectionsInCount(int vertexID)
        {
            int count = 0;
            foreach (Connection c in connections)
                if (c.Start == vertexID) count++;
            return count;
        }

        private int GetVertexConnectionsOutCount(int vertexID)
        {
            int count = 0;
            foreach (Connection c in connections)
                if (c.End == vertexID) count++;
            return count;
        }

        private Connection FindConnection(int start, int end)
        {
            foreach (Connection c in connections)
                if ((c.Start == start) && (c.End == end))
                    return c;
            return null;
        }

        private bool AreAdjecent(int vertex1, int vertex2)
        {
            return FindConnection(vertex1, vertex2) != null;
        }

        public int[,] FloydWarshall()
        {
            if (VerteciesCount == 0) throw new InvalidOperationException("Graph empty.");
            //if (ConnectionsCount < (VerteciesCount - 1)) throw new InvalidOperationException("Too few connections.");

            int[,] table = new int[VerteciesCount, VerteciesCount];

            SetEveryCellToInfinity(ref table);
            SetDiagonalToZero(ref table);

            foreach (Connection connection in connections)
                table[connection.Start, connection.End] = connection.Length;
            for (int k = 0; k < VerteciesCount; k++)
                for (int i = 0; i < VerteciesCount; i++)
                    for (int j = 0; j < VerteciesCount; j++)
                    {
                        if ((table[i, j] > table[i, k] + table[k, j]) && table[i, k] != Int32.MaxValue && table[k, j] != Int32.MaxValue)
                            table[i, j] = table[i, k] + table[k, j];
                    }

            return table;
        }

        private void SetEveryCellToInfinity(ref int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
                for (int j = 0; j < table.GetLength(1); j++)
                    table[i, j] = Int32.MaxValue;
        } 

        private void SetDiagonalToZero(ref int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
                for (int j = 0; j < table.GetLength(1); j++)
                    if (i == j)
                        table[i, j] = 0;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"Vertecies({VerteciesCount}):\n");
            if (vertecies.Count == 0) stringBuilder.Append("No vertecies.\n");
            foreach (Vertex v in vertecies)
                stringBuilder.Append($"{v.ID} ({GetVertexConnectionsInCount(v.ID)} IN connections; {GetVertexConnectionsOutCount(v.ID)} OUT connections)\n");
            stringBuilder.Append('\n');

            stringBuilder.Append($"Connections({ConnectionsCount}):\n");
            if (connections.Count == 0) stringBuilder.Append("No connections.\n");
            foreach (Connection c in connections)
                stringBuilder.Append($"{c.Start} -> {c.End}, Length: {c.Length}\n");
            stringBuilder.Append('\n');

            return stringBuilder.ToString();
        }
    }
}
