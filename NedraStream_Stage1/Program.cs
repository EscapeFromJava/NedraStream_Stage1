using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Stage1
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
        /// <param name="level">Ряд</param>
        /// <param name="volume">Колонка</param>
        /// <param name="sum"></param>
        /// <returns></returns>
        static public int GetVolume(List<Level> levelSystem, int level = 0, int volume = 0, int sum = 0)
        {
            if (level == levelSystem.Count - 1)
                return sum += levelSystem[level].ArrayLevel[volume];
            var temp = new int[] 
            { 
                (GetVolume(levelSystem, level + 1, volume, sum + levelSystem[level].ArrayLevel[volume])),
                (GetVolume(levelSystem, level + 1, volume + 1, sum + levelSystem[level].ArrayLevel[volume]))
            };
            return temp.Max();
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
