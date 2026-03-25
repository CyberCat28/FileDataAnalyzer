using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileDataAnalyzer
{
    public static class AnalysisService
    {
        /// <summary>
        /// Вывод результата
        /// </summary>
        /// <param name="numbers">Список чисел</param>
        public static void PrintStatistics(List<double> numbers)
        {
            int totalNum = numbers.Count;
            int positiveCount = numbers.Count(n => n > 0);
            int negativeCount = numbers.Count(n => n < 0);
            int zeroCount = numbers.Count(n => n == 0);
            double minNum = numbers.Min();
            double maxNum = numbers.Max();
            double arithmeticMean = numbers.Average();

            Console.WriteLine("--- Результаты анализа ---");
            Console.WriteLine($"Всего чисел: {totalNum}");
            Console.WriteLine($"Минимум: {minNum}\nМаксимум: {maxNum}");
            Console.WriteLine($"Среднее арифметическое: {arithmeticMean}");
            Console.WriteLine($"Положительных: {positiveCount}\nОтрицательных: {negativeCount}");
            Console.WriteLine($"Нулей: {zeroCount}\n");
        }
    }
}