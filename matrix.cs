using System;

public class Matrix
{
    private int[,] matrix;

    public Matrix()
    {
        matrix = new int[3, 3];
    }

    public Matrix(int size)
    {
        matrix = new int[size, size];
    }

    public Matrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
    }

    public void SetValue(int row, int col, int value)
    {
        if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            throw new ArgumentOutOfRangeException("Index out of range");
        matrix[row, col] = value;
    }

    public int GetValue(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            throw new ArgumentOutOfRangeException("Index out of range");
        return matrix[row, col];
    }

    public void Display()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void Fill(int minValue = 1, int maxValue = 10)
    {
        Random rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rand.Next(minValue, maxValue + 1);
            }
        }
    }

    public Matrix Add(Matrix other)
    {
        if (matrix.GetLength(0) != other.matrix.GetLength(0) || matrix.GetLength(1) != other.matrix.GetLength(1))
            throw new InvalidOperationException("Mátrixok mérete nem egyezik");

        Matrix result = new Matrix(matrix.GetLength(0), matrix.GetLength(1));

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result.SetValue(i, j, matrix[i, j] + other.matrix[i, j]);
            }
        }

        return result;
    }

    public int RowCount => matrix.GetLength(0);
    public int ColCount => matrix.GetLength(1);
}
