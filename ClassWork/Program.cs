using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество строк матрицы:");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов матрицы:");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        Random rand = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(100); 
            }
        }

        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        SortColumns(matrix);

        stopwatch.Stop();
        TimeSpan sortTime = stopwatch.Elapsed;

        Console.WriteLine("\nОтсортированная матрица:");
        PrintMatrix(matrix);

        Console.WriteLine($"\nВремя сортировки: {sortTime.TotalMilliseconds} миллисекунд");
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void SortColumns(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int col = 0; col < cols; col++)
        {
            
            int[] columnValues = new int[rows];
            for (int row = 0; row < rows; row++)
            {
                columnValues[row] = matrix[row, col];
            }

            Array.Sort(columnValues);

            for (int row = 0; row < rows; row++)
            {
                matrix[row, col] = columnValues[row];
            }
        }
    }
}