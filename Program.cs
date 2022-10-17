/*
Задайте значение N. Напишите программу, которая выведет все чётные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
N = 5 -> "4, 2"
N = 8 -> "8, 6, 4, 2"
*/

const int limit = -1;
int N = 0;
List<int> evenNumbers = new();

if (!InputControl())
    return;
  
DoWork(N);

PrintResult();

# region methods

bool InputControl()
{
    int tryCount = 3;
    string inputStr;
    bool resInputCheck = false;

    while (!resInputCheck)
    {
        Console.WriteLine($"\r\nЗадайте челое положительное число N. N должно быть больше {limit}. (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        resInputCheck = int.TryParse(inputStr, out N) && N > 0 && N > limit;

        if (!resInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

void DoWork(int number)
{
    if (number == limit)
        return;

    if (number == 0 || number % 2 == 0)
    {
        evenNumbers.Add(number);
    }

    --number;

    DoWork(number);
}

void PrintResult()
{
    string result = string.Empty;

    foreach (var item in evenNumbers)
    {
        result = string.Concat(result, (string.IsNullOrEmpty(result) ? "" : ", "), item);
    }

    Console.WriteLine($"N = {N} => \"{result}\"");
}
#endregion
