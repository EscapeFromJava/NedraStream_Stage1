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
            Console.Write("Введите кол-во уровней: ");
            int numberOfLevels = int.Parse(Console.ReadLine());

            //генерирует систему уровней
            List<Level> system = new List<Level>();
            for (int i = 1; i <= numberOfLevels; i++)
                system.Add(new Level(i));

            //выводит на экран всю систему для наглядности
            PrintAllValues(system);

            //выводит максимальную сумму
            Console.WriteLine($"Max сумма: " + GetVolume(system));

            Console.ReadLine();
        }
        /// <summary>
        /// Получить максимальную сумму в системе
        /// </summary>
        /// <param name="levelSystem">Система</param>
        /// <returns>Сумма</returns>

        static public int GetVolume(List<Level> levelSystem, int row = 0, int column = 0, int total = 0)
        {
            if (row == levelSystem.Count - 1)
                return total += levelSystem[row].ArrayLevel[column];
            int temp1 = GetVolume(levelSystem, row + 1, column, total + levelSystem[row].ArrayLevel[column]);
            int temp2 = GetVolume(levelSystem, row + 1, column + 1, total + levelSystem[row].ArrayLevel[column]);
            return temp1 >= temp2 ? temp1 : temp2;
        }

        /// <summary>
        /// Вывод на экран всей системы
        /// </summary>
        /// <param name="levelSystem">Система</param>
        static public void PrintAllValues(List<Level> levelSystem)
        {
            int index = 1;
            foreach (var el in levelSystem)
            {
                Console.WriteLine($"[Уровень {index}]: \t" + new string(' ', levelSystem.Count - index) + string.Join(" ", el.ArrayLevel.Select(x => x).ToList()));
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
        /// Массив значений, в зависимости от номера уровня
        /// </summary>
        public List<int> ArrayLevel = new List<int>();
        /// <summary>
        /// Номер уровня
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
                ArrayLevel.Add(new Random().Next(0, 5));
                Thread.Sleep(1);
            }
            return ArrayLevel;
        }
    }
}
