namespace Dijkstra
{
    using System;
    using System.Text;
    class Vertex
    {
        public int MinimumLength { get; set; }
        public bool Included { get; set; }
        public Vertex ClosestVertex { get; set; }
        public char Name { get; private set; }

        public Vertex(char _name)
        {
            this.Name = _name;
            this.Included = false;
            this.MinimumLength = Int32.MaxValue;
            this.ClosestVertex = null;
        }
    }
}
