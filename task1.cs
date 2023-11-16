using System.ComponentModel.Design;

class MyMatrix
{
    private int[,] matrix;
    private int _rows, _cols;

    public MyMatrix(int rows, int cols, int first_value, int last_value)
    {
        _rows = rows;
        _cols = cols;
        matrix = new int[rows, cols];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(first_value, last_value);
            }
        }
    }

    public int Rows { get => _rows; }
    public int Cols { get => _cols; }
    public int[,] Matrix { get => matrix; }

    public void WriteMatrix()
    {
        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                Console.Write(this.Matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Rows == matrix2.Rows && matrix1.Cols == matrix2.Cols)
        {
            MyMatrix result = new MyMatrix(matrix1.Rows, matrix1.Cols, 0, 0);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }
        else throw new ArgumentException("");
    }

    public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Rows == matrix2.Rows && matrix1.Cols == matrix2.Cols)
        {

            MyMatrix result = new MyMatrix(matrix1.Rows, matrix1.Cols, 0, 0);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Cols; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }
        else throw new ArgumentException("");
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Cols == matrix2.Rows)
        {

            MyMatrix result = new MyMatrix(matrix1.Rows, matrix2.Cols, 0, 0);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Cols; j++)
                {
                    for (int k = 0; k < matrix1.Cols; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }
        else throw new ArgumentException("");
    }

    public static MyMatrix operator *(MyMatrix matrix, int scalar)
    {
        MyMatrix result = new MyMatrix(matrix.Rows, matrix.Cols, 0, 0);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    public static MyMatrix operator *(int scalar, MyMatrix matrix)
    {
        return matrix * scalar;
    }

    public static MyMatrix operator /(MyMatrix matrix, int scalar)
    {
        if (scalar != 0)
        {

            MyMatrix result = new MyMatrix(matrix.Rows, matrix.Cols, 0, 0);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    result[i, j] = matrix[i, j] / scalar;
                }
            }

            return result;
        }
        else throw new DivideByZeroException("");
    }
    public int this[int row, int col]
    {
        get => matrix[row, col];
        set => matrix[row, col] = value;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Enter the number of columns of the first matrix: ");
        int cols1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of rows of the first matrix: ");
        int rows1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns of the second matrix: ");
        int cols2 = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of rows of the second matrix: ");
        int rows2 = int.Parse(Console.ReadLine());

        Console.Write("Enter the minimum value for random numbers for matrix1: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Enter the maximum value for of random numbers for matrix1: ");
        int maxValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter a multiplier:");
        int mult = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the divisor:");
        int div = int.Parse(Console.ReadLine());

        MyMatrix matrix1 = new MyMatrix(rows1, cols1, minValue, maxValue);
        MyMatrix matrix2 = new MyMatrix(rows2, cols2, minValue, maxValue);

        try
        {
            Console.WriteLine("matrix1");
            matrix1.WriteMatrix();
            Console.WriteLine("matrix2");
            matrix2.WriteMatrix();
            (matrix1 + matrix2).WriteMatrix();
            (matrix1 - matrix2).WriteMatrix();
            (matrix1 * matrix2).WriteMatrix();
            (matrix1 * mult).WriteMatrix();
            (matrix1 / div).WriteMatrix();
        }
        catch (ArgumentException) { Console.WriteLine("You cannot add and subtract matrices of different dimensions! Please, try again"); Main(); }
        catch (DivideByZeroException) { Console.WriteLine("You cannot divide by 0! Please try again."); Main(); }
    }
}