using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    internal class Program
    {
        static Random rnd = new Random();
        public static void Main(string[] args)
        {
            
            var collection = new List<Product>();
            for (var i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт" + i,
                    Energy = rnd.Next(10, 500)
                };
                collection.Add(product);
            }

            var result = from item in collection                            //здесь item - это эллемент коллекции
                where item.Energy < 200                                                             //получаем список эллементов меньше 5
                orderby item.Energy                                                                  //упорядочивание
                select item;

            var result2 = collection.Where(item => item.Energy < 200 || item.Energy < 400);               //второй способ сделать то же самое
            
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            var selectCollection = collection.Select(product => product.Energy);
            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }

            var orderByCollection = collection.OrderBy(product => product.Energy).ThenBy(product => product.Name);             //реализация упорядочивания
            foreach (var item in orderByCollection)
            {
                Console.WriteLine(item);
            }

            var groupByCollection = collection.GroupBy(product => product.Energy);                         //упорядочивание по энергии
            foreach (var group in groupByCollection)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item}");
                }

                Console.WriteLine();
            }

            collection.Reverse();                                                                                       //разворачивает список

            var all = collection.All(item => item.Energy == 10);
            
            var array = new int[]{ 1, 2, 3, 4, 5 };
            var array2 = new int[]{ 3, 4, 5, 6};
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            
            var union = array.Union(array2);                                                                //
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }

            var intersect = array.Intersect(array2);                                                       //то, где объединяются два массива
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }

            var sum = array.Sum();
            var min = collection.Min(p => p.Energy);
            var max = collection.Max(p => p.Energy);
            var agregate = array.Aggregate((x, y) => x * y);
            Console.ReadLine();
        }
    }
}