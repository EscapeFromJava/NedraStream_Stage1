using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main()
        {
            int numberOfLevels = 4;
            Console.WriteLine($"Кол-во уровней: {numberOfLevels}");

            //генерирует систему уровней
            List<Level> system = new List<Level>();
            for (int i = 1; i <= numberOfLevels; i++)
                system.Add(new Level(i));

            //выводит на экран всю систему для наглядности
            PrintAllValues(system);

            //выводит максимальную сумму в системе
            Console.WriteLine($"\nМаксимальная сумма: {GetSum(system)}");

            Console.ReadLine();
        }
        /// <summary>
        /// Получить максимальную сумму в системе
        /// </summary>
        /// <param name="levelSystem">Система</param>
        /// <returns>Сумма</returns>
        static public int GetSum(List<Level> levelSystem)
        {
            Console.Write("Результаты всех маршрутов: ");
            List<int> result = new List<int>();
            int sum = levelSystem.ElementAt(0).ArrayLevel.ElementAt(0);

            for (int i = 0; i < 2; i++)
            {
                sum += levelSystem.ElementAt(1).ArrayLevel.ElementAt(i);
                for (int j = i; j < 2 + i; j++)
                {
                    sum += levelSystem.ElementAt(2).ArrayLevel.ElementAt(j);
                    for (int k = j; k < 2 + j; k++)
                    {
                        sum += levelSystem.ElementAt(3).ArrayLevel.ElementAt(k);
                        Console.Write(sum + " ");
                        result.Add(sum);
                        sum -= levelSystem.ElementAt(3).ArrayLevel.ElementAt(k);
                    }
                    sum -= levelSystem.ElementAt(2).ArrayLevel.ElementAt(j);
                }
                sum -= levelSystem.ElementAt(1).ArrayLevel.ElementAt(i);
            }
            return result.Max();
        }

        /// <summary>
        /// Вывести на экран всю систему для наглядности
        /// </summary>
        /// <param name="levelSystem">Система</param>
        static public void PrintAllValues(List<Level> levelSystem)
        {
            int index = 1;
            foreach (var el in levelSystem)
            {
                Console.WriteLine($"[Уровень {index}]: " + new string(' ', levelSystem.Count - index) + string.Join(" ", el.ArrayLevel.Select(x => x).ToList()));
                index++;
            }
        }
    }
    /// <summary>
    /// Класс "Уровень"
    /// </summary>
    class Level
    {
        /// <summary>
        /// Содержит массив значений, в зависимости от номера уровня
        /// </summary>
        public List<int> ArrayLevel = new List<int>();
        /// <summary>
        /// Содержит номер уровня
        /// </summary>
        private int _numberOfLevel;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="num">Номер уровня</param>
        public Level(int num)
        {
            _numberOfLevel = num;
            ArrayLevel = GetArray();
        }
        /// <summary>
        /// Метод генерации рандомных значений. Задержка Thread.Sleep(1) добалена с целью генерации уникальных значений для каждого цикла
        /// </summary>
        /// <returns>Масси чисел</returns>
        public List<int> GetArray()
        {
            for (int i = 0; i < _numberOfLevel; i++)
            {
                ArrayLevel.Add(new Random().Next(0, 10));
                Thread.Sleep(1);
            }
            return ArrayLevel;
        }
    }
}
