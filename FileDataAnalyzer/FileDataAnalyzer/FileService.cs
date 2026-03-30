using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDataAnalyzer
{
    public static class FileService
    {
        /// <summary>
        /// Считывание цифр и чисел в файле
        /// </summary>
        /// <param name="filePath">Путь к нужному файлу</param>
        /// <param name="hasInvalidData">Выходной параметр имеющий значение True, если есть некорректные данные</param>
        /// <returns>Список чисел</returns>
        public static List<double> ReadNumbersFromFile(string filePath, out bool hasInvalidData)
        {
            List<double> numbers = new List<double>();
            hasInvalidData = false;

            // Читает все данные одной строкой
            string content = File.ReadAllText(filePath);

            string[] separators = { " ", "\t", "\r\n", "\r", "\n", ",", ";" };

            // Разбивание текста на отдельные части
            string[] values = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Обрабатывание каждого элемента
            foreach (string value in values)
            {
                // Преобразование строки в число
                if (double.TryParse(value, out double number))
                {
                    numbers.Add(number);
                }
                // Если элемент не пустой и не является числом - фиксирует наличие некорректных данных
                else if (!string.IsNullOrWhiteSpace(value))
                {
                    hasInvalidData = true;
                }
            }

            return numbers;
        }

        /// <summary>
        /// Создание файлов с положительными и отрицательными числами
        /// </summary>
        /// <param name="numbers">Список чисел</param>
        public static void CreateFiles(List<double> numbers)
        {
            // Путь для сохранения файлов (на рабочий стол)
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Выборка только положительных и отрицательных чисел
            List<double> positiveNumbers = numbers.Where(n => n > 0).ToList();
            List<double> negativeNumbers = numbers.Where(n => n < 0).ToList();

            // Сохранение положительных чисел
            if (positiveNumbers.Count > 0)
            {
                string positiveFilePath = Path.Combine(desktopPath, "positive_numbers.txt");
                string positiveContent = string.Join(" ", positiveNumbers);
                File.WriteAllText(positiveFilePath, positiveContent);
                Console.WriteLine("[Готово] Положительные числа сохранены в positive_numbers.txt");
            }
            else
            {
                Console.WriteLine("Положительных чисел нет.");
            }

            // Сохранение отрицательных чисел
            if (negativeNumbers.Count > 0)
            {
                string negativeFilePath = Path.Combine(desktopPath, "negative_numbers.txt");
                string negativeContent = string.Join(" ", negativeNumbers);
                File.WriteAllText(negativeFilePath, negativeContent);
                Console.WriteLine("[Готово] Отрицательные числа сохранены в negative_numbers.txt");
            }
            else
            {
                Console.WriteLine("Отрицательных чисел нет.");
            }
        }
    }
}
