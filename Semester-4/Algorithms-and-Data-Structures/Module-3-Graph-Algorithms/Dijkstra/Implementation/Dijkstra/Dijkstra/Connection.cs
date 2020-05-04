namespace Dijkstra
{
    using System;
    class Connection
    {
        public Vertex Start { get; private set; }
        public Vertex End { get; private set; }
        public int Length { get; private set; }

        public Connection(Vertex _start, Vertex _end, int _length)
        {
            this.Start = _start;
            this.End = _end;
            this.Length = _length;
        }
    }
}
