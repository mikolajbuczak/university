namespace NeuralNetwork
{
    using System;
    class Matrix
    {
        #region Random

        static Random random = new Random();

        #endregion

        #region Fields

        /// <summary>
        /// All fileds needed to build a proper matrix
        /// values - a 2D array of decimal numbers that stores all the values in the matrix
        /// rows - number of rows in a matrix
        /// cols - number of columns in a matrix
        /// </summary>
        decimal[,] values = null;
        int rows = 0;
        int cols = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an object of a class Matrix.
        /// Sets the number of rows and columns to 0.
        /// Initializes an empty array of values.
        /// </summary>
        public Matrix() : this(0, 0)
        { 
            
        }

        /// <summary>
        /// Initializes an object of a class Matrix of given size.
        /// Sets all the values in the matrix to 0.
        /// </summary>
        /// <param name="rowsCount">Number of rows</param>
        /// <param name="columnsCount">Number of columns</param>
        public Matrix(int rowsCount, int columnsCount)
        {
            rows = rowsCount;
            cols = columnsCount;
            values = new decimal[rows, cols];
        }

        /// <summary>
        /// Initializes an object of a class Matrix of given size.
        /// Sets all the values in the matrix to given values.
        /// </summary>
        /// <param name="rowsCount">Number of rows</param>
        /// <param name="columnsCount">Number of columns</param>
        /// <param name="initialValue">Value assgined to every value in a matrix.</param>
        public Matrix(int rowsCount, int columnsCount, decimal initialValue) : this(rowsCount, columnsCount)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    values[i, j] = initialValue;
        }


        /// <summary>
        /// Initializes an object of a class Matrix based on the onther object.
        /// Sets the size of a matrix to the size of given matrix. 
        /// Copies all the values from the given matrix.
        /// </summary>
        /// <param name="matrix">Matrix to copy</param>
        public Matrix(Matrix matrix) : this(matrix.rows, matrix.cols)
        {
            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                    this.values[i, j] = matrix.values[i, j];
        }

        /// <summary>
        /// Initializes an object of a class Matrix based on a given array.
        /// If vertical is true, then the constructor:
        /// Sets the number of rows to the length of a given array.
        /// Sets the number of columns to 0.
        /// Else
        /// Sets the number of rows to 0.
        /// Sets the number of columns to the length of a given array.
        /// Copies all values from the given array.
        /// </summary>
        /// <param name="array">Array to trasform into Matrix object</param>
        /// <param name="vertical">Flag for the matrix being vertical or horizontal(vector)</param>
        public Matrix(decimal[] array, bool vertical)
        {
            rows = 0;
            cols = array.Length;
            if (vertical)
            {
                rows = array.Length;
                cols = 0;
            }
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    values[i, j] = array[i];
        }
        

        /// <summary>
        /// Initializes an object of a class Matrix based on a given 2D array.
        /// Sets the number of rows to to the length of a given array in dimension 0.
        /// Sets the number of columns to the length of a given array in dimension 1.
        /// Copies all values from the given array.
        /// </summary>
        /// <param name="array">Array to trasform into Matrix object</param>
        public Matrix(decimal[,] array) : this(array.GetLength(0), array.GetLength(1))
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    values[i, j] = array[i, j];
        }

        #endregion

        #region Operations

        #region Addition

        public void Add(decimal number)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (values[i, j] + number > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (values[i, j] + number < decimal.MinValue) throw new OverflowException("Value too small.");
                    values[i, j] += number;
                }
        }

        public void Add(decimal[,] array)
        {
            if (array.GetLength(0) != rows || array.GetLength(1) != cols)
                throw new ArgumentException($"Expected an array of size ( { rows } , { cols } ).");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (values[i, j] + array[i, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (values[i, j] + array[i, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                    values[i, j] += array[i, j];
                }
        }

        public void Add(Matrix matrix)
        {
            if (matrix.rows != this.rows || matrix.cols != this.cols)
                throw new ArgumentException($"Expected a matrix of size ( { this.rows } , { this.cols } ).");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (this.values[i, j] + matrix.values[i, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (this.values[i, j] + matrix.values[i, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                    this.values[i, j] += matrix.values[i, j];
                }
        }

        #endregion

        #region Substarction

        public void Substract(decimal number)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (values[i, j] - number > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (values[i, j] - number < decimal.MinValue) throw new OverflowException("Value too small.");
                    values[i, j] -= number;
                }
        }

        public void Substract(decimal[,] array)
        {
            if (array.GetLength(0) != rows || array.GetLength(1) != cols)
                throw new ArgumentException($"Expected an array of size ( { rows } , { cols } ).");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (values[i, j] - array[i, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (values[i, j] - array[i, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                    values[i, j] -= array[i, j];
                }
        }

        public void Substract(Matrix matrix)
        {
            if (matrix.rows != this.rows || matrix.cols != this.cols)
                throw new ArgumentException($"Expected a matrix of size ( { this.rows } , { this.cols } ).");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (this.values[i, j] - matrix.values[i, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (this.values[i, j] - matrix.values[i, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                    this.values[i, j] -= matrix.values[i, j];
                }
        }

        #endregion

        #region Multiplication

        public void Multiply(decimal number)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (values[i, j] * number > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (values[i, j] * number < decimal.MinValue) throw new OverflowException("Value too small.");
                    values[i, j] *= number;
                }
        }

        public Matrix Multiply(decimal[] array)
        {
            if(cols != 1) throw new ArgumentException($"Matrix has to be a transposed vector.");
            Matrix matrix = new Matrix(this.rows, array.Length);
            for(int i = 0; i < matrix.rows; i++)
                for(int j = 0; j < matrix.cols; j++)
                {
                    if (this.values[i, 0] * array[j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (this.values[i, 0] * array[j] < decimal.MinValue) throw new OverflowException("Value too small.");
                    matrix.values[i, j] = this.values[i, 0] * array[j];
                }
            return matrix;
        }

        public Matrix Mutliply(decimal[,] array)
        {
            if (cols != array.GetLength(0))
                throw new ArgumentException($"Expected an array with { cols } rows.");
            Matrix matrix = new Matrix(this.rows, array.GetLength(1));
            for (int i = 0; i < this.rows; i++)
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    decimal sum = 0;
                    for (int k = 0; k < this.cols; k++)
                    {
                        if (this.values[i, k] * array[k, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                        if (this.values[i, k] * array[k, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                        if (sum + (this.values[i, k] * array[k, j]) > decimal.MinValue) throw new OverflowException("Value too big.");
                        if (sum + (this.values[i, k] * array[k, j]) < decimal.MinValue) throw new OverflowException("Value too small.");
                        sum += this.values[i, k] * array[k, j];
                    }
                    matrix.values[i, j] = sum;
                }
            return matrix;
        }

        public Matrix Multiply(Matrix matrix)
        {
            if (this.cols != matrix.rows)
                throw new ArgumentException($"Expected a matrix with { this.cols } rows.");
            Matrix result = new Matrix(this.rows, matrix.cols);
            for (int i = 0; i < this.rows; i++)
                for (var j = 0; j < matrix.cols; j++)
                {
                    decimal sum = 0;
                    for (int k = 0; k < this.cols; k++)
                    {
                        if (this.values[i, k] * matrix.values[k, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                        if (this.values[i, k] * matrix.values[k, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                        if (sum + (this.values[i, k] * matrix.values[k, j]) > decimal.MaxValue) throw new OverflowException("Value too big.");
                        if (sum + (this.values[i, k] * matrix.values[k, j]) < decimal.MinValue) throw new OverflowException("Value too small.");
                        sum += this.values[i, k] * matrix.values[k, j];
                    }
                    result.values[i, j] = sum;
                }
            return result;
        }

        #endregion

        #region Power

        public Matrix Power(int power)
        {
            if (rows != cols) throw new ArgumentException("Expected a square matrix.");
            if(power == 0)
            {
                int height = rows;
                int width = cols;
                decimal[,] diagonal = new decimal[height, width];
                for(int i = 0; i < height; i++)
                    for(int j = 0; j < width; j++)
                        diagonal[i, j] = i == j ? 1 : 0;
                return new Matrix(diagonal);
            }
            return this.Multiply(this.Power(power - 1));
        }

        #endregion

        #region Transposition

        public Matrix Transpose()
        {
            Matrix matrix = new Matrix(this.cols, this.rows);

            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                    matrix.values[j, i] = this.values[i, j];

            return matrix;
        }

        #endregion

        #region Hadamard Product

        public void Hadamard(decimal[,] array)
        {
            if (this.rows != array.GetLength(0) || this.cols != array.GetLength(1))
                throw new ArgumentException($"Expected an array of size ({ this.rows }, { this.cols }).");
            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                {
                    if (this.values[i, j] * array[i, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (this.values[i, j] * array[i, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                    this.values[i, j] *= array[i, j];
                }
        }

        public void Hadamard(Matrix matrix)
        {
            if (this.rows != matrix.rows || this.cols != matrix.cols)
                throw new ArgumentException($"Expected a matrix of size ({ this.rows }, { this.cols }).");
            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                {
                    if (this.values[i, j] * matrix.values[i, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                    if (this.values[i, j] * matrix.values[i, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                    this.values[i, j] *= matrix.values[i, j];
                }
        }

        #endregion

        #region Randomization

        public void Randomize()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    values[i, j] = (decimal)random.NextDouble();
        }

        public void Randomize(decimal upperBound)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    values[i, j] = (decimal)random.NextDouble() * upperBound;
        }

        public void Randomize(decimal lowerBound, decimal upperBound)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    values[i, j] = ((decimal)random.NextDouble() * (upperBound - lowerBound)) + lowerBound;
        }

        #endregion

        #region Map

        public void Map(Func<decimal, decimal> function)
        {
            for (int i = 0; i < this.rows; i++)
                for (int j = 0; j < this.cols; j++)
                    values[i, j] = function(values[i, j]);
        }

        #endregion

        #endregion

        #region Static Operations

        #region Addition

        public static Matrix Add(decimal[] a, decimal[] b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException("Cannot add two arrays with different sizes.");
            Matrix newMatrix = new Matrix(1, a.Length);

            for (int i = 0; i < a.Length; i++)
                newMatrix.values[0, i] = a[i] + b[i];
            return newMatrix;
        }

        public static Matrix Add(decimal[,] a, decimal[,] b)
        {
            if(a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new ArgumentException("Cannot add two arrays with different sizes.");

            Matrix matrix = new Matrix(a.GetLength(0), a.GetLength(1));

            for (int i = 0; i < matrix.rows; i++)
                for (int j = 0; j < matrix.cols; j++)
                    matrix.values[i, j] = a[i, j] + b[i, j];
            return matrix;
        }

        public static Matrix Add(Matrix a, Matrix b)
        {
            if (a.rows != b.rows ||
                a.cols != b.cols)
                throw new ArgumentException("Cannot add matricies with different sizes.");

            Matrix newMatrix = new Matrix(a.rows, a.cols);

            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.cols; j++)
                    newMatrix.values[i, j] = a.values[i, j] + b.values[i, j];
            return newMatrix;
        }

        #endregion Addition

        #region Substracion

        public static Matrix Substract(decimal[] a, decimal[] b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException("Cannot substract two arrays with different sizes.");
            Matrix newMatrix = new Matrix(1, a.Length);

            for (int i = 0; i < a.Length; i++)
                newMatrix.values[0, i] = a[i] - b[i];
            return newMatrix;
        }

        public static Matrix Substract(decimal[,] a, decimal[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new ArgumentException("Cannot substract two arrays with different sizes.");

            Matrix matrix = new Matrix(a.GetLength(0), a.GetLength(1));

            for (int i = 0; i < matrix.rows; i++)
                for (int j = 0; j < matrix.cols; j++)
                    matrix.values[i, j] = a[i, j] - b[i, j];
            return matrix;
        }

        public static Matrix Substract(Matrix a, Matrix b)
        {
            if (a.rows != b.rows ||
                a.cols != b.cols)
                throw new ArgumentException("Cannot substract matricies with different sizes.");

            Matrix newMatrix = new Matrix(a.rows, a.cols);

            for (int i = 0; i < a.rows; i++)
                for (int j = 0; j < a.cols; j++)
                    newMatrix.values[i, j] = a.values[i, j] - b.values[i, j];
            return newMatrix;
        }

        #endregion

        #region Multiplication

        public static Matrix Multiply(decimal a, decimal b)
        {
            return new Matrix(1, 1, a * b);
        }

        public static Matrix Multiply(decimal[] array, decimal number)
        {
            Matrix matrix = new Matrix(1, array.Length);
            for (int i = 0; i < matrix.cols; i++)
                matrix.values[i, j] = array[i, j] * number;
            return matrix;
        }

        public static Matrix Multiply(decimal[,] array, decimal number)
        {
            Matrix matrix = new Matrix(array.GetLength(0), array.GetLength(1));
            for (int i = 0; i < matrix.rows; i++)
                for (int j = 0; j < matrix.cols; j++)
                    matrix.values[i, j] = array[i, j] * number;
            return matrix;
        }

        public static Matrix Multiply(Matrix a, Matrix b)
        {
            if (a.cols != b.rows)
                throw new ArgumentException($"Expected a matrix with { a.cols } rows.");
            Matrix result = new Matrix(a.rows, b.cols);
            for (int i = 0; i < a.rows; i++)
                for (var j = 0; j < b.cols; j++)
                {
                    decimal sum = 0;
                    for (int k = 0; k < a.cols; k++)
                    {
                        if (a.values[i, k] * b.values[k, j] > decimal.MaxValue) throw new OverflowException("Value too big.");
                        if (a.values[i, k] * b.values[k, j] < decimal.MinValue) throw new OverflowException("Value too small.");
                        if (sum + (a.values[i, k] * b.values[k, j]) > decimal.MaxValue) throw new OverflowException("Value too big.");
                        if (sum + (a.values[i, k] * b.values[k, j]) < decimal.MinValue) throw new OverflowException("Value too small.");
                        sum += a.values[i, k] * b.values[k, j];
                    }
                    result.values[i, j] = sum;
                }
            return result;
        }

        #endregion

        #region Transposition

        public static Matrix Transpose(Matrix matrix)
        {
            Matrix result = new Matrix(matrix.cols, matrix.rows);

            for (int i = 0; i < matrix.rows; i++)
                for (int j = 0; j < matrix.cols; j++)
                    result.values[j, i] = matrix.values[i, j];

            return result;
        }

        #endregion

        #region Hadamard Product

        public static Matrix Hadamard(decimal[,] a, decimal[,] b)
        {
            if(a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new ArgumentException($"Cannot apply Hadamard product to arrays with different sizes.");
            Matrix matrix = new Matrix(a.GetLength(0), b.GetLength(1));

            for (int i = 0; i < matrix.rows; i++)
                for (int j = 0; j < matrix.cols; j++)
                    matrix.values[i, j] = a[i, j] * b[i, j];

            return matrix;
        }

        public static Matrix Hadamard(Matrix a, Matrix b)
        {
            if (a.rows != b.rows || a.cols != b.cols)
                throw new ArgumentException($"Cannot apply Hadamard product to arrays with different sizes.");
            Matrix matrix = new Matrix(a.rows, a.cols);

            for (int i = 0; i < matrix.rows; i++)
                for (int j = 0; j < matrix.cols; j++)
                    matrix.values[i, j] = a.values[i, j] * b.values[i, j];

            return matrix;
        }

        #endregion

        #region Randomization

        public static Matrix Randomize()
        {
            int rowsCount = random.Next(1, 10);
            int colsCount = random.Next(1, 10);

            Matrix matrix = new Matrix(rowsCount, colsCount);

            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < colsCount; j++)
                    matrix.values[i, j] = (decimal)random.NextDouble();

            return matrix;
        }

        #endregion

        #endregion
    }
}
