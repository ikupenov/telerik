namespace NumberMatrix
{
    using System;
    using System.Text;

    public class Matrix<T>
        where T : struct, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        private T[,] matrix;

        public Matrix(int rows, int columns)
        {
            this.matrix = new T[rows, columns];
        }

        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }

        public int GetLength(int dimension)
        {
            return this.matrix.GetLength(dimension);
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetLength(0) != secondMatrix.GetLength(0) ||
                firstMatrix.GetLength(1) != secondMatrix.GetLength(1))
            {
                throw new ArgumentException("Arrays must be the same size");
            }

            var result = new Matrix<T>(firstMatrix.GetLength(0), firstMatrix.GetLength(1));

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    result[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetLength(0) != secondMatrix.GetLength(0) ||
                firstMatrix.GetLength(1) != secondMatrix.GetLength(1))
            {
                throw new ArgumentException("Arrays must be the same size");
            }

            var result = new Matrix<T>(firstMatrix.GetLength(0), firstMatrix.GetLength(1));

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    result[i, j] = (dynamic)firstMatrix[i, j] - (dynamic)secondMatrix[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new ArgumentException("First array's columns must equal second array's rows");
            }

            var result = new Matrix<T>(firstMatrix.GetLength(0), firstMatrix.GetLength(1));

            for (int firstRow = 0; firstRow < firstMatrix.GetLength(0); firstRow++)
            {
                for (int secondCol = 0; secondCol < secondMatrix.GetLength(1); secondCol++)
                {
                    dynamic tempResult = 0;

                    for (int variable = 0; variable < firstMatrix.GetLength(1); variable++)
                    {
                        tempResult += (dynamic)firstMatrix[firstRow, variable] * (dynamic)secondMatrix[variable, secondCol];
                    }

                    result[firstRow, secondCol] = tempResult;
                }
            }

            return result;
        }


        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    builder.Append(this.matrix[i, j] + " ");
                }

                builder.AppendLine();
            }

            return builder.ToString().Trim();
        }
    }
}
