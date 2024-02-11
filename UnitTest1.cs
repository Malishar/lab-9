using lab_9;
namespace TestGeoCoordinates
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            int expected = 3;

            // Act
            int actual = GeoCoordinates.GetCount;

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            double expected = 45.0;
            GeoCoordinates point = new GeoCoordinates();

            // Act
            point.Latitude = 45.0;
            double actual = point.Latitude;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            GeoCoordinates originalPoint = new GeoCoordinates(45.0, 60.0);

            // Act
            GeoCoordinates copiedPoint = new GeoCoordinates(originalPoint);

            // Assert
            Assert.AreEqual(originalPoint.Latitude, copiedPoint.Latitude);
            Assert.AreEqual(originalPoint.Longitude, copiedPoint.Longitude);
        }
       
        [TestMethod]
        public void TestMethod4()
        {
            // Arrange
            double expected = 989.406;
            GeoCoordinates point1 = new GeoCoordinates(40.0, -70.0);
            GeoCoordinates point2 = new GeoCoordinates(45.0, -80.0);

            // Act
            double actual = GeoCoordinates.CalculateDistance(point1, point2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Arrange
            GeoCoordinates point1 = new GeoCoordinates(0, 0);
            GeoCoordinates point2 = new GeoCoordinates(45, 45);
            double expected = 6671; // Ожидаемое расстояние между точками

            // Act
            double actual = point1.CalculateDistanceClass(point1, point2);

            // Assert
            Assert.AreEqual(expected, actual, 100); // Указываем допустимую погрешность
        }

        [TestMethod]
        public void TestMethod6()
        {
            // Arrange
            GeoCoordinates point = new GeoCoordinates(40.0, -70.0);
            GeoCoordinates expected = new GeoCoordinates(40.01, -69.99);

            // Act
            GeoCoordinates actual = ++point;

            // Assert
            Assert.AreEqual(expected.Latitude, actual.Latitude, 0.001);
            Assert.AreEqual(expected.Longitude, actual.Longitude, 0.001);
        }

        [TestMethod]
        public void TestMethod7()
        {
            // Arrange
            GeoCoordinates point = new GeoCoordinates(40.0, -70.0);
            GeoCoordinates expected = new GeoCoordinates(-40.0, 70.0);

            // Act
            GeoCoordinates actual = -point;

            // Assert
            Assert.AreEqual(expected.Latitude, actual.Latitude, 0.001);
            Assert.AreEqual(expected.Longitude, actual.Longitude, 0.001);
        }

        [TestMethod]
        public void TestMethod8()
        {
            // Arrange
            GeoCoordinates point1 = new GeoCoordinates(40.0, -70.0);
            GeoCoordinates point2 = new GeoCoordinates(40.0, -70.0);
            GeoCoordinates point3 = new GeoCoordinates(45.0, -70.0);

            // Act
            bool isEqual = point1 == point2;
            bool isNotEqual = point1 == point3;

            // Assert
            Assert.IsTrue(isEqual);
            Assert.IsFalse(isNotEqual);
        }

        [TestMethod]
        public void TestMethod9()
        {
            // Arrange
            GeoCoordinates point1 = new GeoCoordinates(40.0, -70.0);
            GeoCoordinates point2 = new GeoCoordinates(40.0, -75.0);

            // Act
            bool result = point1 != point2;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod10()
        {
            // Arrange
            GeoCoordinates point1 = new GeoCoordinates(40.0, -70.0);
            GeoCoordinates point2 = new GeoCoordinates(45.0, -70.0);

            // Act
            bool isNotEqual = point1.Latitude != point2.Latitude;

            // Assert
            Assert.IsTrue(isNotEqual);
        }

        [TestMethod]
        public void TestMethod11()
        {
            // Arrange
            GeoCoordinates equatorPoint = new GeoCoordinates(0.0, -70.0);
            GeoCoordinates nonEquatorPoint = new GeoCoordinates(40.0, -70.0);

            // Act
            bool isEquator = (bool)equatorPoint;
            bool isNonEquator = (bool)nonEquatorPoint;

            // Assert
            Assert.IsTrue(isEquator);
            Assert.IsFalse(isNonEquator);
        }

        [TestMethod]
        public void TestMethod12()
        {
            // Arrange
            GeoCoordinates eastLongitude = new GeoCoordinates(40.0, 70.0);
            GeoCoordinates westLongitude = new GeoCoordinates(40.0, -70.0);
            GeoCoordinates zeroMeridian = new GeoCoordinates(40.0, 0.0);

            // Act
            string eastLongitudeString = eastLongitude;
            string westLongitudeString = westLongitude;
            string zeroMeridianString = zeroMeridian;

            // Assert
            Assert.AreEqual("Восточная долгота", eastLongitudeString);
            Assert.AreEqual("Западная долгота", westLongitudeString);
            Assert.AreEqual("Нулевой меридиан", zeroMeridianString);
        }

        [TestMethod]
        public void TestMethod13()
        {
            // Arrange
            GeoCoordinates point1 = new GeoCoordinates(0, 0);
            GeoCoordinates point2 = new GeoCoordinates(0, 0);
            GeoCoordinates point3 = new GeoCoordinates(45, 45);

            // Act
            bool result1 = point1.Equals(point2);
            bool result2 = point1.Equals(point3);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2); 
        }

        [TestMethod]
        public void TestMethod14()
        {
            // Arrange
            var length = 5;
            var expectedLength = length;

            // Act
            var array = new GeoCoordinatesArray(length, 0, 0);

            // Assert
            Assert.AreEqual(expectedLength, array.Length);
        }

        [TestMethod]
        public void TestMethod15()
        {
            // Arrange
            var expectedCount = GeoCoordinatesArray.GetCount;

            // Act
            var array = new GeoCoordinatesArray();

            // Assert
            Assert.AreEqual(expectedCount + 1, GeoCoordinatesArray.GetCount);
        }

        [TestMethod]
        public void TestMethod16()
        {
            // Arrange
            double value = 200.0;
            var geoLocation = new GeoCoordinates();

            // Act
            geoLocation.Longitude = value;
            double maxValue = 180.0;

            // Assert
            Assert.AreEqual(maxValue, geoLocation.Longitude);
        }

        [TestMethod]
        public void TestMethod17()
        {
            // Arrange
            double value = 100.0;
            var geocoordinate = new GeoCoordinates();

            // Act
            geocoordinate.Latitude = value;
            double maxValue = 90.0;

            // Assert
            Assert.AreEqual(maxValue, geocoordinate.Latitude);
        }

        [TestMethod]
        public void TestMethod18()
        {
            // Arrange
            double value = -200.0;
            var geoLocation = new GeoCoordinates();

            // Act
            geoLocation.Longitude = value;
            double maxValue = -180.0;

            // Assert
            Assert.AreEqual(maxValue, geoLocation.Longitude);
        }

        [TestMethod]
        public void TestMethod19()
        {
            // Arrange
            double value = -100.0;
            var geocoordinate = new GeoCoordinates();

            // Act
            geocoordinate.Latitude = value;
            double maxValue = -90.0;

            // Assert
            Assert.AreEqual(maxValue, geocoordinate.Latitude);
        }

        [TestMethod]
        public void TestMethod20()
        {
            // Arrange
            GeoCoordinatesArray collection = new GeoCoordinatesArray();
            GeoCoordinates expected = new GeoCoordinates(10.0, 20.0);

            // Act
            collection[0] = expected;
            GeoCoordinates actual = collection[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod21()
        {
            // Arrange
            GeoCoordinatesArray collection = new GeoCoordinatesArray();
            bool exception = false;

            // Act
            try
            {
                var temp = collection[1];
            }
            catch (Exception)
            {
                exception = true;
            }

            // Assert
            Assert.IsFalse(exception);
        }

        [TestMethod]
        public void TestMethod22()
        {
            // Arrange
            GeoCoordinatesArray collection = new GeoCoordinatesArray();
            bool exception = false;

            // Act
            try
            {
                collection[100] = new GeoCoordinates(50.0, 60.0);
            }
            catch (Exception)
            {
                exception = true;
            }

            // Assert
            Assert.IsFalse(exception);
        }
    }
}
