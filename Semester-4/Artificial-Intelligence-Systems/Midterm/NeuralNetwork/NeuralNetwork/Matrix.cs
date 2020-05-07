namespace NeuralNetwork
{
    using System;
    using System.Text;

    class Matrix
    {
        private readonly int numberOfRows;
        private readonly int numberOfColumns;
        private double[,] values;

        public enum Orientation
        {
            Horizontal = 1,
            Vertical = 2
        }
        public Matrix(int rowsCount, int columnsCount)
        {
            this.numberOfRows = rowsCount;
            this.numberOfColumns = columnsCount;
            this.values = new double[this.numberOfRows, this.numberOfColumns];
        }

        public Matrix(int rowsCount, int columnsCount, double initialValue)
        {
            this.numberOfRows = rowsCount;
            this.numberOfColumns = columnsCount;
            this.values = new double[this.numberOfRows, this.numberOfColumns];
            for (int i = 0; i < this.numberOfRows; i++)
                for (int j = 0; j < this.numberOfColumns; j++)
                    this.values[i, j] = initialValue;
        }

        public Matrix(double[] data)
        {
            this.numberOfRows = 1;
            this.numberOfColumns = data.Length;
            this.values = new double[this.numberOfRows, this.numberOfColumns];
            for (int i = 0; i < this.numberOfColumns; i++)
                this.values[0, i] = data[i];
        }

        public Matrix(double[] data, Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
            {
                this.numberOfRows = 1;
                this.numberOfColumns = data.Length;

                this.values = new double[this.numberOfRows, this.numberOfColumns];

                for (int i = 0; i < this.numberOfColumns; i++)
                    this.values[0, i] = data[i];
            }
            else
            {
                this.numberOfRows = data.Length;
                this.numberOfColumns = 1;

                this.values = new double[this.numberOfRows, this.numberOfColumns];

                for (int i = 0; i < this.numberOfRows; i++)
                    this.values[i, 0] = data[i];
            }
        }

        public Matrix(double[,] data)
        {
            this.numberOfRows = data.GetLength(0);
            this.numberOfColumns = data.GetLength(1);

            this.values = data;
        }

        public void SetValues(double[,] data)
        {
            if (data.GetLength(0) != this.numberOfRows || data.GetLength(1) != this.numberOfColumns)
                throw new ArgumentException("Incorrect size of an array.");
            this.values = data;
        }

        public void Add(double number)
        {
            for (int i = 0; i < this.numberOfRows; i++)
                for (int j = 0; j < this.numberOfColumns; j++)
                    this.values[i, j] += number;
        }

        public void Add(Matrix matrix)
        {
            if (matrix.numberOfColumns != this.numberOfColumns ||
                matrix.numberOfRows != this.numberOfRows)
                throw new ArgumentException("Cannot add matricies with different sizes.");

            for (int i = 0; i < this.numberOfRows; i++)
                for (int j = 0; j < this.numberOfColumns; j++)
                    this.values[i, j] += matrix.values[i, j];
        }

        public static Matrix Add(Matrix a, Matrix b)
        {
            if (b.numberOfColumns != a.numberOfColumns ||
                b.numberOfRows != a.numberOfRows)
                throw new ArgumentException("Cannot add matricies with different sizes.");

            Matrix newMatrix = new Matrix(a.numberOfRows, a.numberOfColumns);

            for (int i = 0; i < a.numberOfRows; i++)
                for (int j = 0; j < a.numberOfColumns; j++)
                    newMatrix.values[i, j] = a.values[i, j] + b.values[i, j];
            return newMatrix;
        }

        public static Matrix Add(double[] a, double[] b)
        {
            if (b.Length != a.Length)
                throw new ArgumentException("Cannot add matricies with different sizes.");

            Matrix newMatrix = new Matrix(1, a.Length);

            for (int i = 0; i < a.Length; i++)
                newMatrix.values[0, i] = a[i] + b[i];
            return newMatrix;
        }

        public void Subtract(double number)
        {
            for (int i = 0; i < this.numberOfRows; i++)
                for (int j = 0; j < this.numberOfColumns; j++)
                    this.values[i, j] -= number;
        }

        public void Subtract(Matrix matrix)
        {
            if (matrix.numberOfColumns != this.numberOfColumns ||
                matrix.numberOfRows != this.numberOfRows)
                throw new ArgumentException("Cannot add matricies with different sizes.");

            for (int i = 0; i < this.numberOfRows; i++)
                for (int j = 0; j < this.numberOfColumns; j++)
                    this.values[i, j] -= matrix.values[i, j];
        }

        public static Matrix Subtract(Matrix a, Matrix b)
        {
            if (b.numberOfColumns != a.numberOfColumns ||
                b.numberOfRows != a.numberOfRows)
                throw new ArgumentException("Cannot add matricies with different sizes.");

            Matrix newMatrix = new Matrix(a.numberOfRows, a.numberOfColumns);

            for (int i = 0; i < a.numberOfRows; i++)
                for (int j = 0; j < a.numberOfColumns; j++)
                    newMatrix.values[i, j] = a.values[i, j] - b.values[i, j];
            return newMatrix;
        }

        public static Matrix Subtract(double[] a, double[] b)
        {
            if (b.Length != a.Length)
                throw new ArgumentException("Cannot add matricies with different sizes.");

            Matrix newMatrix = new Matrix(1, a.Length);

            for (int i = 0; i < a.Length; i++)
                newMatrix.values[0, i] = a[i] - b[i];
            return newMatrix;
        }

        public void Multiply(double number)
        {
            for (int i = 0; i < numberOfRows; i++)
                for (int j = 0; j < numberOfColumns; j++)
                    this.values[i, j] *= number;
        }

        public void Multiply(Matrix b)
        {
            for (int i = 0; i < this.numberOfRows; i++)
                for (int j = 0; j < b.numberOfColumns; j++)
                    for (int k = 0; k < this.numberOfColumns; k++)
                        this.values[i, j] += this.values[i, k] * b.values[k, j];
        }

        public static Matrix Multiply(Matrix a, Matrix b)
        {
            Matrix newMatrix = new Matrix(a.numberOfRows, b.numberOfColumns);
            for (int i = 0; i < newMatrix.numberOfRows; i++)
                for (int j = 0; j < newMatrix.numberOfColumns; j++)
                    for (int k = 0; k < a.numberOfColumns; k++)
                        newMatrix.values[i, j] += a.values[i, k] * b.values[k, j];

            return newMatrix;
        }

        public static Matrix Transpose(Matrix matrix)
        {
            Matrix newMatrix = new Matrix(matrix.numberOfColumns, matrix.numberOfRows);

            for (int i = 0; i < matrix.numberOfRows; i++)
                for (int j = 0; j < matrix.numberOfColumns; j++)
                    newMatrix.values[j, i] = matrix.values[i, j];
            return newMatrix;
        }

        public void Randomize(Random random)
        {
            for (int i = 0; i < this.numberOfRows; i++)
                for (int j = 0; j < this.numberOfColumns; j++)
                    this.values[i, j] += ((random.NextDouble() * 2) - 1);
        }

        public void Map(Func<double, double> function)
        {
            for(int i = 0; i < this.numberOfRows; i++)
                for(int j = 0; j < this.numberOfColumns; j++)
                {
                    double value = this.values[i, j];
                    this.values[i, j] = function(value);
                }
        }

        public static Matrix Map(Matrix matrix, Func<double, double> function)
        {
            Matrix newMatrix = new Matrix(matrix.numberOfRows, matrix.numberOfColumns);
            for (int i = 0; i < matrix.numberOfRows; i++)
                for (int j = 0; j < matrix.numberOfColumns; j++)
                {
                    double value = matrix.values[i, j];
                    newMatrix.values[i, j] = function(value);
                }
            return newMatrix;
        }

        public double[] ToArray()
        {
            int arraySize = this.numberOfRows * this.numberOfColumns;
            double[] array = new double[arraySize];
            for (int i = 0; i < this.numberOfRows; i++)
                for (int j = 0; j < this.numberOfColumns; j++)
                    array[(i * this.numberOfColumns) + j] = this.values[i, j];
            return array;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for(int i = 0; i < this.numberOfRows; i++)
            {
                for (int j = 0; j < this.numberOfColumns; j++)
                    stringBuilder.Append($"{this.values[i, j]} ");
                stringBuilder.Append('\n');
            }
                
            return stringBuilder.ToString();
        }
    }
}
