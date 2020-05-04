namespace Prim
{
    using System;
    using System.Text;
    class Connection
    {
        public Vertex Start { get; private set; }
        public Vertex End { get; private set; }
        public int Length { get; private set; }

        public Connection(ref Vertex _start, ref Vertex _end, int _length)
        {
            this.Start = _start;
            this.End = _end;
            this.Length = _length;
        }
    }
}
