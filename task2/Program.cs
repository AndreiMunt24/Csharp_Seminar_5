// Задайте двумерный массив. Найдите сумму элементов,
// находящихся на главной диагонали (с индексами (0,0); (1;1) и
// т.д.
// Пример
// 2 3 4 3
// 4 3 4 1 => 2 + 3 + 5 = 10
// 2 9 5 4

void Main()
{
    int rowCount = ReadInt("Введите количество строк двумерного массива: ");
    int colCount = ReadInt("Введите количество столбцов двумерного массива: ");

    int[,] matrix = GenerateMatrix(rowCount, colCount, 0, 9);
    PrintMatrix(matrix);
    System.Console.WriteLine(SumMainDiag(matrix));
}

int SumMainDiag(int[,] matrix)
{
    int sum = 0;
    int countIter = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

    for (int i = 0; i < countIter; i++)
        sum += matrix[i, i];

    return sum;
}

void PrintMatrix(int[,] matrixForPrint)
{
    for (int i = 0; i < matrixForPrint.GetLength(0); i++)
    {
        for (int j = 0; j < matrixForPrint.GetLength(1); j++)
        {
            System.Console.Write(matrixForPrint[i, j] + "\t");
        }
        System.Console.WriteLine();
    }

    System.Console.WriteLine();
}

int[,] GenerateMatrix(int rows, int cols, int minValue, int maxValue)
{
    int[,] tempMatrix = new int[rows, cols];
    Random rand = new Random();

    for (int i = 0; i < tempMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < tempMatrix.GetLength(1); j++)
        {
            tempMatrix[i, j] = rand.Next(minValue, maxValue + 1);
        }
    }

    return tempMatrix;
}



int ReadInt(string msg)
{
    System.Console.Write(msg);
    return Convert.ToInt32(Console.ReadLine());
}

Main();