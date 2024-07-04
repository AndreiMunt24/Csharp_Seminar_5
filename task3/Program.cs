// Задайте двумерный массив из целых чисел. Сформируйте новый
// одномерный массив, состоящий из средних арифметических
// значений по строкам двумерного массива.
// Пример
// 2 3 4 3
// 4 3 4 1 => [3 3 5]
// 2 9 5 4

// void Main()
// {
//     int rowCount = ReadInt("Введите количество строк двумерного массива: ");
//     int colCount = ReadInt("Введите количество столбцов двумерного массива: ");

//     int[,] matrix = GenerateMatrix(rowCount, colCount, 0, 9);
//     PrintMatrix(matrix);
//     PrintArray(CalculateAverages(matrix));
// }

// void PrintArray(double[] array)
// {
//     System.Console.WriteLine("[" + string.Join(", ", array) + "]");
//     System.Console.WriteLine();
// }

// double[] CalculateAverages(int[,] matrix)
// {
//     double[] averages = new double[matrix.GetLength(0)];

//     for (int i = 0; i < matrix.GetLength(0); i++)
//     {
//         for (int j = 0; j < matrix.GetLength(1); j++)
//         {
//             averages[i] += matrix[i, j];
//         }

//         averages[i] /= matrix.GetLength(1);
//     }

//     return averages;
// }

// void PrintMatrix(int[,] matrixForPrint)
// {
//     for (int i = 0; i < matrixForPrint.GetLength(0); i++)
//     {
//         for (int j = 0; j < matrixForPrint.GetLength(1); j++)
//         {
//             System.Console.Write(matrixForPrint[i, j] + "\t");
//         }
//         System.Console.WriteLine();
//     }

//     System.Console.WriteLine();
// }

// int[,] GenerateMatrix(int rows, int cols, int minValue, int maxValue)
// {
//     int[,] tempMatrix = new int[rows, cols];
//     Random rand = new Random();

//     for (int i = 0; i < tempMatrix.GetLength(0); i++)
//     {
//         for (int j = 0; j < tempMatrix.GetLength(1); j++)
//         {
//             tempMatrix[i, j] = rand.Next(minValue, maxValue + 1);
//         }
//     }

//     return tempMatrix;
// }

// int ReadInt(string msg)
// {
//     System.Console.Write(msg);
//     return Convert.ToInt32(Console.ReadLine());
// }

// Main();


// рабочая зона


using System;

// Тело класса будет написано студентом. Класс обязан иметь статический метод PrintResult()
class UserInputToCompileForTest
{
    // Печать массива
    public static void PrintArray(int[,] array)
    {
        int rowCount = array.GetLength(0);
        int colCount = array.GetLength(1);

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Обмен первой с последней строкой
    public static int[,] SwapFirstLastRows(int[,] array)
    {
        int rowCount = array.GetLength(0);
        if (rowCount < 2) return array; // Если строк меньше двух, обмен невозможен

        int colCount = array.GetLength(1);

        for (int i = 0; i < colCount; i++)
        {
            int temp = array[0, i];
            array[0, i] = array[rowCount - 1, i];
            array[rowCount - 1, i] = temp;
        }

        return array;
    }

    // Обмен элементами массива
    public static void SwapItems(int[,] array, int i)
    {
        int rowCount = array.GetLength(0);
        int colCount = array.GetLength(1);

        for (int j = 0; j < colCount; j++)
        {
            int temp = array[i, j];
            array[i, j] = array[rowCount - 1 - i, j];
            array[rowCount - 1 - i, j] = temp;
        }
    }

    public static void PrintResult(int[,] numbers)
    {
        Console.WriteLine("Начальный массив:");
        PrintArray(numbers);

        SwapFirstLastRows(numbers);

        Console.WriteLine("Измененный массив:");
        PrintArray(numbers);
    }
}

// Не удаляйте и не меняйте класс Answer!
class Answer
{
    public static void Main(string[] args)
    {
        int[,] numbers;

        if (args.Length >= 1)
        {
            // Предполагается, что строки разделены запятой и пробелом, а элементы внутри строк разделены пробелом
            string[] rows = args[0].Split(',');

            int rowCount = rows.Length;
            int colCount = rows[0].Trim().Split(' ').Length;

            numbers = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] rowElements = rows[i].Trim().Split(' ');

                for (int j = 0; j < colCount; j++)
                {
                    if (int.TryParse(rowElements[j], out int result))
                    {
                        numbers[i, j] = result;
                    }
                    else
                    {
                        Console.WriteLine($"Error parsing element {rowElements[j]} to an integer.");
                        return;
                    }
                }
            }
        }
        else
        {
            // Если аргументов на входе нет, используем примерный массив
            numbers = new int[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12}
            }; 
        }
        UserInputToCompileForTest.PrintResult(numbers);
    }
} 