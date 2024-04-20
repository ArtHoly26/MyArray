using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество строк матрицы:");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов матрицы:");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] mass = new int[rows, cols];

        Random rand = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                mass[i, j] = rand.Next(100); 
            }
        }

        Console.WriteLine("Исходная матрица:");
        Printmass(mass);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        SortColumns(mass);

        stopwatch.Stop();
        TimeSpan sortTime = stopwatch.Elapsed;

        Console.WriteLine("\nОтсортированная матрица:");
        Printmass(mass);

        Console.WriteLine($"\nВремя сортировки: {sortTime.TotalMilliseconds} миллисекунд");
    }

    static void Printmass(int[,] mass)
    {
        int rows = mass.GetLength(0);
        int cols = mass.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(mass[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void SortColumns(int[,] mass)
    {
        int rows = mass.GetLength(0);
        int cols = mass.GetLength(1);

        for (int col = 0; col < cols; col++)
        {
            
            int[] columnValues = new int[rows];
            for (int row = 0; row < rows; row++)
            {
                columnValues[row] = mass[row, col];
            }

            Array.Sort(columnValues);

            for (int row = 0; row < rows; row++)
            {
                mass[row, col] = columnValues[row];
            }
        }
    }
}