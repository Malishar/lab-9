using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    public class GeoCoordinates
    {
        // Закрытые атрибуты
        private double latitude;
        private double longitude;

        public static int count = 0;

        // Конструктор без параметров
        public GeoCoordinates()
        {
            latitude = 0.0;
            longitude = 0.0;
            count++;
        }

        // Конструктор с параметрами
        public GeoCoordinates(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            count++;
        }

        // Конструктор копирования
        public GeoCoordinates(GeoCoordinates g)
        {
            latitude = g.latitude;
            longitude = g.longitude;
            count++;
        }

        // Свойства для доступа к атрибутам
        public double Latitude
        {
            get { return latitude; }
            set
            {
                if (value < -90)
                    latitude = -90;//минимально допустимое значение для широты
                else if (value > 90)
                    latitude = 90;//максимально допустимое значение для широты
                else
                    latitude = value;
            }
        }

        public double Longitude
        {
            get { return longitude; }
            set
            {
                if (value < -180)
                    longitude = -180;//минимально допустимое значение для долготы
                else if (value > 180)
                    longitude = 180;//максимально допустимое значение для долготы
                else
                    longitude = value;
            }
        }

        public void Show()
        {
            Console.WriteLine($"Широта точки: {latitude:F4}. Долгота точки: {longitude:F4}");
        }

        // Статическая функция для вычисления расстояния между двумя точками
        public static double CalculateDistance(GeoCoordinates point1, GeoCoordinates point2)
        {
            const double R = 6371; // Радиус Земли в км

            double lat1 = point1.Latitude * Math.PI / 180;//Перевод ккординат из градусов в радианы
            double lon1 = point1.Longitude * Math.PI / 180;
            double lat2 = point2.Latitude * Math.PI / 180;
            double lon2 = point2.Longitude * Math.PI / 180;

            double a = Math.Pow(Math.Sin((lat2 - lat1) / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin((lon2 - lon1) / 2), 2);//формула гаверсинуса

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));//угловое расстояние между точками

            return Math.Round(R * c, 3); // Округление до трех знаков после запятой
        }

        // Метод класса для вычисления расстояния между двумя точками
        public double CalculateDistanceClass(GeoCoordinates point1, GeoCoordinates point2)
        {
            const double R = 6371; // Радиус Земли в км

            double lat1 = point1.Latitude * Math.PI / 180;
            double lon1 = point1.Longitude * Math.PI / 180;
            double lat2 = point2.Latitude * Math.PI / 180;
            double lon2 = point2.Longitude * Math.PI / 180;

            double a = Math.Pow(Math.Sin((lat2 - lat1) / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin((lon2 - lon1) / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return Math.Round(R * c, 3); // Округление до трех знаков после запятой
        }

        // Перегрузка бинарной операции ++
        public static GeoCoordinates operator ++(GeoCoordinates point)
        {
            point.latitude += 0.01;//добавление 0,01
            point.longitude += 0.01;
            return point;
        }

        // Перегрузка бинарной операции -
        public static GeoCoordinates operator -(GeoCoordinates point)
        {
            point.latitude = -point.latitude;//смена знака на противоположный
            point.longitude = -point.longitude;
            return point;
        }

        // Перегрузка унарной операции ==
        public static bool operator ==(GeoCoordinates gc1, GeoCoordinates gc2)
        {
            return gc1.latitude == gc2.latitude; //сравнение широты точек
        }

        // Перегрузка унарной операции !=
        public static bool operator !=(GeoCoordinates gc1, GeoCoordinates gc2)
        {
            return gc1.longitude != gc2.longitude; // Проверяем разные меридианы
        }

        // Явная операция приведения типа к bool
        public static explicit operator bool(GeoCoordinates point)
        {
            return point.latitude == 0; // Возвращаем true, если широта равна 0 (точка на экваторе), иначе false
        }

        // Неявная операция приведения типа к string
        public static implicit operator string(GeoCoordinates point)
        {
            if (point.longitude > 0)
                return "Восточная долгота";
            else if (point.longitude < 0)
                return "Западная долгота";
            else
                return "Нулевой меридиан";
        }

        // Статическое свойство для доступа к количеству объектов
        public static int GetCount => count;

        public override bool Equals(object? obj)//метод для сравнения двух объектов реализованного класса 
        { 
            if (obj is not GeoCoordinates) return false;
            if (obj == null) return false;
            return ((GeoCoordinates)obj).latitude == this.latitude && ((GeoCoordinates)obj).longitude == this.longitude;
        }
    }
}

