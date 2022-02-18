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
            int levels = int.Parse(Console.ReadLine());
            try
            {
                while (levels < 1)
                {
                    Console.Write("Кол-во уровней должно быть целым и больше 0. Повторите ввод: ");
                    levels = int.Parse(Console.ReadLine());
                }

                //генерирует систему уровней
                List<Level> system = new List<Level>();
                for (int i = 1; i <= levels; i++)
                    system.Add(new Level(i));

                //выводит на экран всю систему для наглядности
                PrintAllValues(system);

                //выводит максимальную сумму в системе
                Console.WriteLine($"\nМаксимальная сумма: {GetMaxSum(system)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Получить максимальную сумму в системе
        /// </summary>
        /// <param name="levelSystem">Система</param>
        /// <returns>Сумма</returns>
        static public double GetMaxSum(List<Level> levelSystem)
        {
            return levelSystem.Select(x => x.ArrayLevel.Max()).Sum();
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
                Console.WriteLine($"[Уровень {index}. Max значение: {el.ArrayLevel.Max()}]: " + string.Join(" ", el.ArrayLevel.Select(x => x).ToList()));
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
                ArrayLevel.Add(new Random().Next(0, 100));
                Thread.Sleep(1);
            }
            return ArrayLevel;
        }
    }
}
