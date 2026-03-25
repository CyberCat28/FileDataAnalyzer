using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDataAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу с данными:");
            string filePath = Console.ReadLine();

            // Проверка, что пользователь ввёл путь к файлу
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Ошибка: Укажите путь к файлу.");
                ConsoleHelper.Exit();
                return;
            }

            try
            {
                // Вызываем метод для чтения данных
                List<double> numbers = FileService.ReadNumbersFromFile(filePath, out bool hasInvalidData);

                Console.WriteLine("[Информация] Файл успешно загружен.\n");

                if (hasInvalidData)
                {
                    Console.WriteLine("\nПредупреждение: Обнаружены некорректные данные. Они были пропущены.");
                }

                if (new FileInfo(filePath).Length == 0) // Получаем размер файла
                {
                    Console.WriteLine("Ошибка: Файл пуст.");
                    ConsoleHelper.Exit();
                    return;
                }
                else
                {
                    AnalysisService.PrintStatistics(numbers);
                    FileService.CreateFiles(numbers);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка: Файл не найден.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Ошибка: Отсутствуют права на чтение/запись файла.");
            }

            ConsoleHelper.Exit();
        }
    }
}