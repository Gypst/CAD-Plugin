namespace SprocketPlugin.Tests
{
    using BL;
    using NUnit.Framework;
    using System.Reflection;

    [TestFixture]
    public class SprocketParametersTest
    {
        [TestCase(50, nameof(SprocketParameters.OuterDiameter), 
            TestName = "Проверка Get и Set для OuterDiameter при" + 
            " значении равному минимальному")]
        [TestCase(100, nameof(SprocketParameters.OuterDiameter), 
            TestName = "Проверка Get и Set для OuterDiameter при" + 
            "значении равному определенному выражению в границах допустимых значений")]
        [TestCase(500, nameof(SprocketParameters.OuterDiameter), 
            TestName = "Проверка Get и Set для OuterDiameter при" + 
            " значении равному максимальному")]
        [TestCase(25, nameof(SprocketParameters.InnerDiameter), 
            TestName = "Проверка Get и Set для InnerDiameter при" + 
            " значении равному минимальному")]
        [TestCase(100, nameof(SprocketParameters.InnerDiameter), 
            TestName = "Проверка Get и Set для InnerDiameter при значении " + 
            "равному определенному выражению в границе допустимых значений")]
        [TestCase(250, nameof(SprocketParameters.InnerDiameter), 
            TestName = "Проверка Get и Set для InnerDiameter при значении " + 
            "равному максимальному")]
        [TestCase(5, nameof(SprocketParameters.Thickness), 
            TestName = "Проверка Get и Set для Thickness при " + 
            "значении равному минимальному")]
        [TestCase(25, nameof(SprocketParameters.Thickness), 
            TestName = "Проверка Get и Set для Thickness при " + 
            "значении равному определенному выражению в границе допустимых значений")]
        [TestCase(50, nameof(SprocketParameters.Thickness), 
            TestName = "Проверка Get и Set для Thickness при " + 
            "значении равному максимальному")]
        [TestCase(1, nameof(SprocketParameters.ToothHeight),
                  TestName = "Проверка Get и Set для ToothHeight при " +
            "значении равному минимальному")]
        [TestCase(10, nameof(SprocketParameters.ToothHeight),
                  TestName = "Проверка Get и Set для ToothHeight при " +
            "значении равному определенному выражению в границе допустимых значений")]
        [TestCase(16, nameof(SprocketParameters.ToothHeight),
                  TestName = "Проверка Get и Set для ToothHeight при " +
            "значении равному максимальному")]
        [TestCase(0.2, nameof(SprocketParameters.ToothTopRadiusRatio),
                  TestName = "Проверка Get и Set для ToothTopRadiusRatio при " +
                             "значении равному минимальному")]
        [TestCase(0.5, nameof(SprocketParameters.ToothTopRadiusRatio),
                  TestName = "Проверка Get и Set для ToothTopRadiusRatio при " +
                             "значении равному определенному выражению в границе допустимых значений")]
        [TestCase(0.8, nameof(SprocketParameters.ToothTopRadiusRatio),
                  TestName = "Проверка Get и Set для ToothTopRadiusRatio при " +
                             "значении равному максимальному")]
        public void AnyParameter_GetSetValue_Success(double expectedValue, string parameterName)
        {
            SprocketParameters sprocketParameters = new SprocketParameters();

            var propertyInfo = typeof(SprocketParameters).
                GetProperty(parameterName);
            propertyInfo.SetValue(sprocketParameters, expectedValue);

            Assert.AreEqual(expectedValue, propertyInfo.GetValue(sprocketParameters));
        }

        [TestCase(5, nameof(SprocketParameters.ToothCount),
                  TestName = "Проверка Get и Set для ToothCount при значении " +
                             "равному граничному минимальному")]
        [TestCase(10, nameof(SprocketParameters.ToothCount),
                  TestName = "Проверка Get и Set для ToothCount при значении " +
                             "равному определенному выражению в границе допустимых значений")]
        [TestCase(30, nameof(SprocketParameters.ToothCount),
                  TestName = "Проверка Get и Set для ToothCount при значении " +
                             "равному граничному максимальному")]
        public void AnyParameter_GetSetValue_Success(int expectedValue, string parameterName)
        {
            SprocketParameters sprocketParameters = new SprocketParameters();
            sprocketParameters.OuterDiameter = 500;

            var propertyInfo = typeof(SprocketParameters).
                GetProperty(parameterName);
            propertyInfo.SetValue(sprocketParameters, expectedValue);

            Assert.AreEqual(expectedValue, propertyInfo.GetValue(sprocketParameters));
        }

        [TestCase(5, nameof(SprocketParameters.OuterDiameter),
            TestName = "Проверка Get и Set для OuterDiameter при" + 
                            " значении меньше минимального")]
        [TestCase(600, nameof(SprocketParameters.OuterDiameter),
                  TestName = "Проверка Get и Set для OuterDiameter при" + 
                             " значении больше максимального")]
        [TestCase(5, nameof(SprocketParameters.InnerDiameter),
            TestName = "Проверка Get и Set для InnerDiameter при" +
            " значении меньше минимального")]
        [TestCase(500, nameof(SprocketParameters.InnerDiameter),
                  TestName = "Проверка Get и Set для InnerDiameter при значении " +
                             "больше максимального")]
        [TestCase(2, nameof(SprocketParameters.Thickness),
            TestName = "Проверка Get и Set для Thickness при " +
            "значении меньше минимального")]
        [TestCase(150, nameof(SprocketParameters.Thickness),
                  TestName = "Проверка Get и Set для Thickness при " +
                             "значении больше максимального")]
        [TestCase(0, nameof(SprocketParameters.ToothHeight),
                  TestName = "Проверка Get и Set для Thickness при " +
                             "значении меньше минимального")]
        [TestCase(100, nameof(SprocketParameters.ToothHeight),
                  TestName = "Проверка Get и Set для Thickness при " +
                             "значении больше максимального")]
        [TestCase(0.1, nameof(SprocketParameters.ToothTopRadiusRatio),
                  TestName = "Проверка Get и Set для ToothTopRadiusRatio при " +
                             "значении меньше минимального")]
        [TestCase(0.9, nameof(SprocketParameters.ToothTopRadiusRatio),
                  TestName = "Проверка Get и Set для ToothTopRadiusRatio при " +
                             "значении больше максимального")]
        public void AnyParameter_SetValue_Failed(double value, string parameterName)
        {
            SprocketParameters sprocketParameters = new SprocketParameters();
            var propertyInfo = typeof(SprocketParameters).
                GetProperty(parameterName);

            Assert.Throws<TargetInvocationException>(() =>
            {
                propertyInfo.SetValue(sprocketParameters, value);
            });
        }

        [TestCase(2, nameof(SprocketParameters.ToothCount),
                  TestName = "Проверка Get и Set для ToothCount при значении " +
                             "равному меньше минимального")]
        [TestCase(150, nameof(SprocketParameters.ToothCount),
                  TestName = "Проверка Get и Set для ToothCount при значении " +
                             "равному больше максимального")]
        public void AnyParameter_SetValue_Failed(int value, string parameterName)
        {
            SprocketParameters sprocketParameters = new SprocketParameters();
            var propertyInfo = typeof(SprocketParameters).
                GetProperty(parameterName);

            Assert.Throws<TargetInvocationException>(() =>
            {
                propertyInfo.SetValue(sprocketParameters, value);
            });
        }

        [TestCase(TestName = "Проверка корректности создания объекта " +
            "используя конструктор по умолчанию")]
        public void Constructor_CorrectCreation_Success()
        {
            var expectedOuterDiameter = 80;
            var expectedInnerDiameter = 45;
            var expectedThickness = 12;
            var expectedToothHeight = 10;
            var expectedToothCount = 6;
            var expectedToothTopRadiusRatio = 0.5;

            SprocketParameters sprocketParameters = new SprocketParameters();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedOuterDiameter, sprocketParameters.OuterDiameter);
                Assert.AreEqual(expectedInnerDiameter, sprocketParameters.InnerDiameter);
                Assert.AreEqual(expectedThickness, sprocketParameters.Thickness);
                Assert.AreEqual(expectedToothCount, sprocketParameters.ToothCount);
                Assert.AreEqual(expectedToothHeight, sprocketParameters.ToothHeight);
                Assert.AreEqual(expectedToothTopRadiusRatio, sprocketParameters.ToothTopRadiusRatio);
            });
        }
    }
}
