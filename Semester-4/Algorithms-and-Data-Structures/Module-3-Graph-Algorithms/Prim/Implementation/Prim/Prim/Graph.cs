﻿namespace Prim
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

        public void AddVertex(char name)
        {
            if(FindVertex(name) != null) throw new InvalidOperationException($"Vertex \'{name}\' already exists.");
            vertecies.Add(new Vertex(name));
            VerteciesCount++;
        }

        public void AddConnection(char startName, char endName, int length)
        {
            if (startName == endName) throw new InvalidOperationException("Invalid connection");

            if (length < 1) throw new ArgumentOutOfRangeException("Invalid length of the connection.");

            Vertex start = FindVertex(startName);
            if(start == null) throw new InvalidOperationException($"No vertex \'{startName}\' in the graph.");

            Vertex end = FindVertex(endName);
            if(end == null) throw new InvalidOperationException($"No vertex \'{endName}\' in the graph.");

            if(FindConnection(start, end) != null)
                throw new InvalidOperationException($"Connection \'{start.Name}\' -> \'{end.Name}\' already exists.");

            connections.Add(new Connection(ref start, ref end, length));
            ConnectionsCount++;
        }

        private Vertex FindVertex(char name)
        {
            foreach (Vertex v in vertecies)
                if (v.Name == name)
                    return v;
            return null;
        }

        private int GetVertexConnectionsCount(Vertex vertex)
        {
            int count = 0;
            foreach (Connection c in connections)
                if (c.Start == vertex || c.End == vertex) count++;
            return count;
        }

        private Connection FindConnection(Vertex start, Vertex end)
        {
            foreach (Connection c in connections)
                if (((c.Start == start) && (c.End == end)) ||
                    ((c.End == start) && (c.Start == end)))
                    return c;
            return null;
        }

        private bool AreAdjecent(Vertex vertex1, Vertex vertex2)
        {
            return !(FindConnection(vertex1, vertex2) == null);
        }

        public int Prim()
        {
            if (VerteciesCount == 0) throw new InvalidOperationException("Graph empty.");
            if (VerteciesCount == 1) throw new InvalidOperationException("Too few verticies.");
            if (ConnectionsCount < (VerteciesCount - 1)) throw new InvalidOperationException("Too few connections.");

            Vertex currentVertex = vertecies[0];
            int minimumLength = 0;

            int connectionsDone = 0;

            List<Vertex> activeVertecies = new List<Vertex>();

            currentVertex.MinimumLength = 0;
            currentVertex.Included = true;
            while (true)
            {
                if (connectionsDone == VerteciesCount - 1) return minimumLength;
                foreach(Vertex vertex in vertecies)
                {
                    if(vertex != currentVertex && !vertex.Included && AreAdjecent(currentVertex, vertex))
                    {
                        Connection connection = FindConnection(currentVertex, vertex);
                        if (connection.Length < vertex.MinimumLength)
                        {
                            vertex.MinimumLength = connection.Length;
                            vertex.ClosestVertex = currentVertex;
                            if (!activeVertecies.Contains(vertex)) activeVertecies.Add(vertex);
                        }
                    }
                }

                if(activeVertecies.Count == 0) throw new InvalidOperationException("Graph not connected.");
                Vertex lowestCost = activeVertecies[0];
                foreach(Vertex vertex in activeVertecies)
                    if (vertex.MinimumLength < lowestCost.MinimumLength)
                        lowestCost = vertex;

                lowestCost.Included = true;
                minimumLength += lowestCost.MinimumLength;
                connectionsDone++;
                activeVertecies.Remove(lowestCost);
                currentVertex = lowestCost;
            }

            return minimumLength;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"Vertecies({VerteciesCount}):\n");
            if (vertecies.Count == 0) stringBuilder.Append("No vertecies.\n");
            foreach (Vertex v in vertecies)
                stringBuilder.Append($"{v.Name} ({GetVertexConnectionsCount(v)} connections)\n");
            stringBuilder.Append('\n');

            stringBuilder.Append($"Connections({ConnectionsCount}):\n");
            if (connections.Count == 0) stringBuilder.Append("No connections.\n");
            foreach (Connection c in connections)
                stringBuilder.Append($"{c.Start.Name} -> {c.End.Name}, Length: {c.Length}\n");
            stringBuilder.Append('\n');

            return stringBuilder.ToString();
        }
    }
}
