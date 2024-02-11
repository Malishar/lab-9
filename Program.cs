using System.Security.Cryptography;

namespace lab_9
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Часть 1");//1 часть
            GeoCoordinates g1 = new GeoCoordinates();//конструктор без параметров
            g1.Show();
            GeoCoordinates g2 = new GeoCoordinates(40, -30);//конструктор с параметрами
            g2.Show();
            GeoCoordinates g3 = new GeoCoordinates(g2);//конструктор копирования
            g3.Show();

            // Создание объектов класса GeoPoint
            GeoCoordinates point1 = new GeoCoordinates(40.00, -70.00);
            GeoCoordinates point2 = new GeoCoordinates(45.0, -80.0);

            // Вывод информации о точках
            Console.WriteLine("Точка 1: Широта = {0}, Долгота = {1}", point1.Latitude, point1.Longitude);
            Console.WriteLine("Точка 2: Широта = {0}, Долгота = {1}", point2.Latitude, point2.Longitude);

            // Вычисление расстояния между точками с использованием статической функции
            double distance1 = GeoCoordinates.CalculateDistance(point1, point2);
            Console.WriteLine("Расстояние между точками с использованием статического метода: {0} км", distance1);

            // Вычисление расстояния между точками с использованием метода класса
            GeoCoordinates calculator = new GeoCoordinates();
            double distance = calculator.CalculateDistanceClass(point1, point2);
            Console.WriteLine("Расстояние между точками с использованием метода класса: {0} km", distance);

            //Подсчёт количества объектов
            Console.WriteLine($"Всего создано {GeoCoordinates.GetCount} объектов\n");

            Console.WriteLine("Часть 2");//2 часть

            GeoCoordinates point3 = new GeoCoordinates(40.0, -70.0);

            //Унарная операция ++
            Console.WriteLine("До увеличения широты и долготы: Широта = {0}, Долгота = {1}", point3.Latitude, point3.Longitude);
            point3++;
            Console.WriteLine("После увеличения ширины и долготы: Широта = {0}, Долгота = {1}", point3.Latitude, point3.Longitude);

            GeoCoordinates point4 = new GeoCoordinates(40.0, -70.0);

            //Унарная операция -
            Console.WriteLine("До смены знаков: Широта = {0}, Долгота = {1}", point4.Latitude, point4.Longitude);
            point4 = -point4;
            Console.WriteLine("После смены знаков: Широта = {0}, Долгота = {1}", point4.Latitude, point4.Longitude);

            //Бинарная операция: на одной параллели
            GeoCoordinates point5 = new GeoCoordinates(40.0, 100.0);
            Console.WriteLine("Точки 3 и 5 на одной параллели? {0}", point3 == point5);

            //Бинарная операция: на разных меридианах
            GeoCoordinates point6 = new GeoCoordinates(45.0, -70.0);
            Console.WriteLine("Точка 3 и 6 на разных меридианах? {0}", point3 != point6);

            GeoCoordinates point7 = new GeoCoordinates(0, 0);
            GeoCoordinates point8 = new GeoCoordinates(45, -70);

            //Операция приведения типа: на экваторе?
            bool isOnEquator = (bool)point7;
            Console.WriteLine("Точка 7 на экваторе? {0}", isOnEquator);

            //Операция приведения типа: какая долгота?
            string longitudeType = point8;
            Console.WriteLine("Долгота точки 8: {0}\n", longitudeType );

            //3 часть
            Console.WriteLine("Часть 3\n");
            Console.WriteLine("Коллекция 1:");
            GeoCoordinatesArray Geo1 = new GeoCoordinatesArray();//конструктор без параметров
            Geo1.Show();
            Geo1.FindClosestPoint();//нахождение расстояния
            Console.WriteLine("");
            Console.WriteLine("Коллекция 2:");
            GeoCoordinatesArray Geo2 = new GeoCoordinatesArray(5, 90, 180);//конструктор с параметрами: раномная генерация
            Geo2.Show();
            Geo2.FindClosestPoint();//нахождение расстояния
            Console.WriteLine("");
            Console.WriteLine("Коллекция 3:");
            GeoCoordinatesArray Geo3 = new GeoCoordinatesArray(3);//конструктор с параметрами: создание вручную
            Geo3.Show();
            Geo3.FindClosestPoint();//нахождение расстояния
            Console.WriteLine("");
            Console.WriteLine("Коллекция 4:");   
            GeoCoordinatesArray Geo4 = new GeoCoordinatesArray(Geo2);//конструктор копирования
            Geo4.Show();
            Geo4.FindClosestPoint();//нахождение расстояния
            Geo2[0] = new GeoCoordinates(80.0, 40.0);//демонстрация глубокого копирования
            Console.WriteLine("");
            Console.WriteLine("Коллекция 2:");
            Geo2.Show();
            Console.WriteLine("");
            Console.WriteLine("Коллекция 4:");
            Geo4.Show();
            Console.WriteLine("");
            try//учёт исключительных ситуаций
            {
                Geo4[100] = new GeoCoordinates(80.0, 40.0);
                Geo4.Show();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("");
            Console.WriteLine($"Всего создано {GeoCoordinatesArray.GetCount} коллекций и {GeoCoordinates.GetCount} объектов");


        }
    }
}