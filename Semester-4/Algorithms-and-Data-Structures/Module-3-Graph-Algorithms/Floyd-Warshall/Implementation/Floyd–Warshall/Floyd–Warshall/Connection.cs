namespace Floyd_Warshall
{
    using System;
    class Connection
    {
        public int Start { get; private set; }
        public int End { get; private set; }
        public int Length { get; private set; }

        public Connection(int startID, int endID, int length)
        {
            this.Start = startID;
            this.End = endID;
            this.Length = length;
        }
    }
}
