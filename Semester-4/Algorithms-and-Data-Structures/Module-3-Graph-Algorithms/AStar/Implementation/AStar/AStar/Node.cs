namespace AStar
{
    using System;
    using System.Text;
    class Node
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost { get; set; }
        public Node Predecessor { get; set; }
        public MainWindow.States State { get; set; }

    public Node(int x, int y, MainWindow.States state)
        {
            X = x;
            Y = y;
            GCost = HCost = FCost = 0;
            Predecessor = null;
            State = state;
        }
    }
}
