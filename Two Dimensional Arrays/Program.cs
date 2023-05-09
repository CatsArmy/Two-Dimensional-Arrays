using System.Threading.Channels;

static string Printer(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    string result = " ";
    string nextRow = "\n";
    for (int j = 0; j < numOfRows; j++)
    {
        result += nextRow + nextRow;
        for (int i = 0; i < numOfCollums; i++)
        {
            if (arr[j, i] > 99)
                result += $" {arr[j, i]}|";
            else if (arr[j, i] > 9)
                result += $"  {arr[j, i]}|";
            else
                result += $"   {arr[j, i]}|";
        }
    }
    return result;
}
void PatientPrinter(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    string result = " ";
    string nextRow = "\n";
    for (int j = 0; j < numOfRows; j++)
    {
        result += nextRow + nextRow;
        for (int i = 0; i < numOfCollums; i++)
        {
            if (arr[j, i] > 99)
                result += $" {arr[j, i]}|";
            else if (arr[j, i] > 9)
                result += $"  {arr[j, i]}|";
            else
                result += $"   {arr[j, i]}|";
        }
        Console.Write(result);
        result = "";
        Console.Read();
    }
}
void numArr(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    for (int i = 0; i < numOfCollums; i++)
    {
        for (int j = 0; j < numOfRows; j++)
        {
            arr[j, i] = 1;//(i + 1) * (j + 1);
        }
    }
}

int GetSumOfRows(int[,] arr, int collum = 0)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfRows = 0;
    for (int i = 0; i < numOfRows; i++)
    {
        sumOfRows += arr[i, collum];
    }
    
    return sumOfRows;
}
int GetSumOfCollums(int[,] arr, int row = 0)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfCollums = 0;

    for (int i = 0; i < numOfCollums; i++)
    {
        sumOfCollums += arr[row, i];
    }
    return sumOfCollums;
}
int GetSumOfOuterBorder(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int borderSum = 0;
    for (int i = 0; i < numOfRows; i++)
    {
        if (i == 0 || numOfRows -1 == i)
            borderSum += arr[i, 0] + numOfCollums -1;
        else
            borderSum += arr[0, i] + arr[i, numOfRows -1];
    }
    return borderSum;
    //return arr;

}
int GetSumOfPrimaryDiagonal(int[,] arr)
{
    
    /*  c   c   c   c   c                         
    /////////////////////////r  1   2   2   2   2 /
    //r0//c0|c1|c2|c3|c4|c5|/r  0   1   2   2   2 /
    //r1//c0|c1|c2|c3|c4|c5|/r  0   0   1   2   2 /
    //r2//c0|c1|c2|c3|c4|c5|/r  0   0   0   1   2 /
    //r3//c0|c1|c2|c3|c4|c5|/r  0   0   0   0   1 /
    //////////////////////////                   */ 
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfDiaginal = 0;
    for (int i = 0; i < numOfRows; i++)
    {
        sumOfDiaginal += arr[i, i];
    }
    return sumOfDiaginal;
}
int GetSumOfAbovePrimaryDiagonal(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfAboveDiaginal = 0;
    for (int i = 1; i < numOfRows; i++)
    {
        sumOfAboveDiaginal += arr[i - 1, i];
        arr[i - 1, i]--;
        for (int j = i + 1; j < numOfRows; j++)
        {
            sumOfAboveDiaginal += arr[i - 1, j];
            arr[i - 1, j]--;
        }
    }
    return sumOfAboveDiaginal;
}
int GetSumOfBelowPrimaryDiagonal(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfBelowDiaginal = 0;
    for (int i = 0; i < numOfRows; i++)
    {//          1;              [i, i - 1];
        sumOfBelowDiaginal += arr[i + 1, i];
        for (int j = 0; j  < i -2; j ++)
        {
            sumOfBelowDiaginal += arr[i, j];
        }
    }
    return sumOfBelowDiaginal;
}
int GetSumOfSecondaryDiagonal(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfSecondaryDiaginal = 0;
    for (int i = numOfRows - 1, j = 0; i >= 0; i--, j++)
    {
        sumOfSecondaryDiaginal += arr[i, j];
    }
    return sumOfSecondaryDiaginal;
}
int GetSumOfBelowSecondaryDiagonal(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfBelowSecondaryDiaginal = 0;
    for (int i = 1; i < numOfRows; i++)
    {
        sumOfBelowSecondaryDiaginal += arr[numOfRows - i, i];
        for (int j = i + 1; j < numOfCollums; j++)
        {
            sumOfBelowSecondaryDiaginal += arr[numOfRows - 1, j];
        }
    }
    /*for (int i = numOfRows - 1, j = 1; i >= 0; i--, j++)
    {old
        sumOfBelowSecondaryDiaginal += arr[i, j];s
        for (int k = j + 1; k < numOfRows; k++)
        {
            sumOfBelowSecondaryDiaginal += arr[i, k];
        }
    }*/
    return sumOfBelowSecondaryDiaginal;
}
int GetSumOfAboveSecondaryDiagonal(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfAboveSecondaryDiaginal = 0;
    for (int i = 0; i < numOfRows; i++)
    {
        sumOfAboveSecondaryDiaginal += arr[numOfRows - i - 2, i];
        for (int j = 0; j < i; j++)
        {
            sumOfAboveSecondaryDiaginal += arr[numOfRows - i - 2, j];
        }
    }
    /*for (int i = numOfRows - 2, j = 0; i >= 0; i--, j++)
    {
        sumOfAboveSecondaryDiaginal += arr[i, j];
        for (int k = 0; k < j; k++)
        {
            sumOfAboveSecondaryDiaginal += arr[i, k];
        }
    }*/
    return sumOfAboveSecondaryDiaginal;
}
int GetSumOfPrimaryDiagonalAndAbove(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfDiaginalAndAbove = 0;
    for (int i = 0; i < numOfRows; i++)
    {
        sumOfDiaginalAndAbove += arr[i + 1, i] + arr[i, i];
        for (int j = i + 1; j < numOfRows; j++)
        {
            sumOfDiaginalAndAbove += arr[i - 1, j];
        }
    }
    return sumOfDiaginalAndAbove;
}
int GetSumOfPrimaryDiagonalAndBelow(int[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    int sumOfDiaginalAndBelow = 0;
    for (int i = 0; i < numOfRows; i++)
    {
        sumOfDiaginalAndBelow += arr[i, i + 1] + arr[i, i];
        for (int j = 0; j < i - 2; j++)
        {
            sumOfDiaginalAndBelow += arr[i + 1, j];
        }
    }
    return sumOfDiaginalAndBelow;
}

void Q1()//page 117 ex3
{
    void SumOfRows(int[,] arr)
    {
        int numOfRows = arr.GetLength(0);
        int numOfCollums = arr.GetLength(1);
        int sumOfRows = 0;
        for (int i = 0; i < numOfCollums; i++)
        {
            for (int j = 0; j < numOfRows; j++)
            {
                sumOfRows += arr[j, i];
            }
        }
        Console.WriteLine($"Sum Of Rows: {sumOfRows}");
    }
    void SumOfCollums(int[,] arr)
    {
        int numOfRows = arr.GetLength(0);
        int numOfCollums = arr.GetLength(1);
        int sumOfRows = 0;
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfCollums; j++)
            {
                sumOfRows += arr[i, j];
            }
        }
        Console.WriteLine($"Sum Of Rows: {sumOfRows}");
    }
    
    Console.WriteLine("in put (int)1 number else it will crash ");
    int cube = int.Parse(Console.ReadLine());
    int[,] arr = new int[cube, cube];
    numArr(arr);
    Console.WriteLine(GetSumOfAboveSecondaryDiagonal(arr));
}
void Q2()
{
/*  //////////////////////  /-------\   /-------\ /-------\  /-------\
    //r0\|c0|c1|c2|c3|c4|/  |a|b|b|a|   |a|b|b|a| |a|b|b|a|  |a|b|b|a|
    //r1\|c0|c1|c2|c3|c4|/  |c|c|c|c|   |c|c|c|c| |c|d|d|c|  |c|c|c|c|
    //r2\|c0|c1|c2|c3|c4|/  |c|c|c|c|   |c|c|c|c| |c|d|d|c|  |c|c|c|c|
    //r3\|c0|c1|c2|c3|c4|/  |a|b|b|a|   |a|b|b|a| |a|b|b|a|  |a|b|b|a|
    //////////////////////  \-------/   \-------/ \-------/  \-------/ */
    Console.WriteLine("in put (int)1 number else it will crash ");
    int cube = int.Parse(Console.ReadLine());
    int[,] arr = new int[cube, cube];
    numArr(arr);
    Console.WriteLine(Printer(arr));
    Console.WriteLine(SemetricalSquareMatrix(arr));
    Console.WriteLine(Printer(CreateSemetricalSquareMatrix(arr)));
    Console.WriteLine(SemetricalSquareMatrix(CreateSemetricalSquareMatrix(arr)));
    
    bool SemetricalSquareMatrix(int[,] arr)
    {
        int numOfRows = arr.GetLength(0);
        int numOfCollums = arr.GetLength(1);
        for (int i = 0; i < numOfRows / 2; i++)
        {
            for (int j = 0; j < numOfRows / 2; j++)
            {
                if (arr[i, j] != arr[i, numOfRows - 1 - j] ||
                    arr[i, j] != arr[numOfRows - 1 - i, j] ||
                    arr[i, j] != arr[numOfRows - 1 - i, numOfRows - 1 - j]) 
                {
                    return false; 
                }

            }
        }
        return true;
    }
    int[,] CreateSemetricalSquareMatrix(int[,] arr)
    {
        int numOfRows = arr.GetLength(0);
        int numOfCollums = arr.GetLength(1);

        for (int i = 0; i < numOfRows / 2; i++)
        {
            for (int j = 0; j < numOfRows / 2; j++)
            {
                if (arr[i, j] != arr[i, numOfRows - 1 - j])
                { 
                    arr[i, j] = i + j + 1;
                    arr[i, numOfRows - 1 - j] = i + j + 1;
                }
                if (arr[i, j] != arr[numOfRows - 1 - i, j])
                {
                    arr[numOfRows - 1 - i, j] = i + j + 1;
                    arr[i, j] = i + j + 1;
                }
                if (arr[i, j] != arr[numOfRows - 1 - i, numOfRows - 1 - j])
                {
                    arr[i, j] = i + j + 1;
                    arr[numOfRows - 1 - i, numOfRows - 1 - j] = i + j + 1;
                }

            }
        }

        return arr;
    }
}
void Q3()
{
    Console.WriteLine("input 3 for a normal test otherwise hf with a N x N full of 0's");
    int cube = int.Parse(Console.ReadLine());
    int[,] arr = new int[cube, cube];
    ///note im not gona make something to test this manualy that is bigger then a 3x3
    ///so it 100% will come true if you give it a arr thats bigger then 3 as it would be full of 0's
    ///unlike the one shown in the exmple
    if (cube == 3)
    {
        arr[0, 0] = 2; arr[0, 1] = 9; arr[0, 2] = 4;
        arr[1, 0] = 7; arr[1, 1] = 5; arr[1, 2] = 3;
        arr[2, 0] = 6; arr[2, 1] = 1; arr[2, 2] = 8;
        Console.WriteLine($"Matrix:\n{Printer(arr)}\n");
    }
    else
    {
        for (int i = 0; i < cube; i++)
        {
            for (int j = 0; j < cube; j++)
            {
                Console.WriteLine($"Input value for index[i:{i},j:{j}]");
                arr[i, j] = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine($"Matrix:\n{Printer(arr)}\n");
            }
        }
    }
    Console.WriteLine(magicalCube(arr));

    bool magicalCube(int[,] arr)
    {
        int numOfRows = arr.GetLength(0);
        int numOfCollums = arr.GetLength(1);

        int sumOfPrimeDiagonal = GetSumOfPrimaryDiagonal(arr);
        int sumOfSecondaryDiagonal = GetSumOfSecondaryDiagonal(arr);
        int[] sumOfRows = new int[numOfCollums];
        for (int i = 0; i < numOfCollums; i++)
            sumOfRows[i] = GetSumOfRows(arr, i);
        int[] sumOfCollums = new int[numOfRows];
        for (int i = 0; i < numOfRows; i++)
            sumOfCollums[i] = GetSumOfCollums(arr, i);

        if (sumOfPrimeDiagonal == sumOfSecondaryDiagonal)
        {
            for (int i = 0; i < numOfCollums; i++)
            {
                if (sumOfPrimeDiagonal != sumOfRows[i])
                    return false;
            }
            for (int i = 0; i < numOfRows; i++)
            {
                if (sumOfPrimeDiagonal != sumOfCollums[i])
                    return false;
            }
        }
        else
            return false;
        
        return true;
    }
}

Q3();