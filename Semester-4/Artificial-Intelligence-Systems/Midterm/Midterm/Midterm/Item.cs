namespace Midterm
{
    using System;
    class Item
    {
        public double Type { get; private set; }
        public double[] Data { get; private set; }

        public Item(double[] data)
        {
            if (data.Length != 5)
                throw new ArgumentException("Invalid input data.");
            this.Type = data[4];
            this.Data = new double[]{ data[0], data[1], data[2], data[3]};
        }
    }
}
