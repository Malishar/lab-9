using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab_9
{
    public class GeoCoordinatesArray
    {
        static Random rnd = new Random();
        GeoCoordinates[] points;
        static int count = 0;
        public static int GetCount => count;//метод для подсчёта созданных коллекций

        public int Length
        {
            get => points.Length;
        }

        public GeoCoordinatesArray()//конструктор без параметров
        {
            int length = rnd.Next(1, 10);//рандоманая длина от 1 до 10
            points = new GeoCoordinates[length];//создание массива такой длины
            for (int i = 0; i < length; i++)
            {
                points[i] = new GeoCoordinates(rnd.NextDouble() * (90 - (-90)) - 90, rnd.NextDouble()*(180 - (-180)) - 180);//рандоманая генерация числе в пределе (-90; 90) и (-180; 180)
            }
            count++;
        }

        public GeoCoordinatesArray(int length, double lat, double lon) 
        {
            points = new GeoCoordinates[length];
            for (int i = 0; i < length; i++)
            {
                points[i] = new GeoCoordinates(rnd.NextDouble() * (90 - (-90)) - 90, rnd.NextDouble() * (180 - (-180)) - 180);
            }
            count++;
        }

        public GeoCoordinatesArray(int length)//конструктор с параметрами вручную
        {
            points = new GeoCoordinates[length]; 
            Console.WriteLine("Введите координаты {0} точек:", length);//вводим координаты точек
            for (int i = 0; i < length; i++)
            {
                Console.Write("Широта точки {0}: ", i + 1);//широта элемента + 1
                double lat = Convert.ToDouble(Console.ReadLine());//считываем введённое значение
                Console.Write("Долгота точки {0}: ", i + 1);//долгота элемента + 1
                double lon = Convert.ToDouble(Console.ReadLine());//считываем введённое значение
                points[i] = new GeoCoordinates(lat, lon); //массив из введённых точек
            }
            count++;
        }

        public GeoCoordinatesArray(GeoCoordinatesArray other)//конструктор копирования
        {
            this.points = new GeoCoordinates[other.Length];
            for (int i = 0; i < other.Length; i++)
                this.points[i] = new GeoCoordinates(other.points[i]);//осуществление глубокого копирования
            count++;
        }

        public GeoCoordinates this[int index]//индексатор для доступа к элементам коллекции
        {
            get
            {   
                if (0 <= index && index < points.Length)
                    return points[index];
                else
                    throw new Exception("Индекс выходит за пределы коллекции");
            }
            set
            {
                if (0 <= index && index < points.Length)
                    points[index] = value;
                else
                    Console.WriteLine("Индекс выходит за пределы коллекции");
            }
        }

        public void FindClosestPoint()
        {
            GeoCoordinates zeroIsland = new GeoCoordinates(0.0, 0.0);//координаты острова "Ноль"
            GeoCoordinates closestPoint = points[0];//расстояние до точки - 1 элемента массива
            double minDistance = GeoCoordinates.CalculateDistance(closestPoint, zeroIsland);//вычисление расстояния
            for (int i = 1; i < points.Length; i++)
            {
                GeoCoordinates currentPoint = points[i];//точка в массива с i индексом
                double distance = GeoCoordinates.CalculateDistance(zeroIsland, currentPoint);//расстояние до ближайшей точки
                if (distance < minDistance)//если вычисленное расстояние меньше ранее минимального, то
                {
                    minDistance = distance;//теперь минимальное расстояние меняется
                    closestPoint = currentPoint;//ближайшая точка меняется
                }
            }
            Console.WriteLine($"Минимальное расстояние до острова Ноль равно {minDistance:F4}. Координаты ближайшей точки равны:");
            closestPoint.Show();
            return;
        }

        public void Show()//метод для печати элементов массива
        {
            for (int i = 0; i < points.Length; i++) 
            {
                points[i].Show();
            }
        }

    }
}
