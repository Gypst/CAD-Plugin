namespace SproocketPlugin.Tests
{
    using BL;
    using NUnit.Framework;
    using System.Reflection;

    [TestFixture]
    public class SproocketParametersTest
    {
        [TestCase(50, nameof(SproocketParameters.OuterDiameter), 
            TestName = "Проверка Get и Set для OuterDiameter при" + 
            " значении равному минимальному")]
        [TestCase(100, nameof(SproocketParameters.OuterDiameter), 
            TestName = "Проверка Get и Set для OuterDiameter при" + 
            "значении равному определенному выражению в границах допустимых значений")]
        [TestCase(500, nameof(SproocketParameters.OuterDiameter), 
            TestName = "Проверка Get и Set для OuterDiameter при" + 
            " значении равному максимальному")]
        [TestCase(25, nameof(SproocketParameters.InnerDiameter), 
            TestName = "Проверка Get и Set для InnerDiameter при" + 
            " значении равному минимальному")]
        [TestCase(100, nameof(SproocketParameters.InnerDiameter), 
            TestName = "Проверка Get и Set для InnerDiameter при значении " + 
            "равному определенному выражению в границе допустимых значений")]
        [TestCase(250, nameof(SproocketParameters.InnerDiameter), 
            TestName = "Проверка Get и Set для InnerDiameter при значении " + 
            "равному максимальному")]
        [TestCase(5, nameof(SproocketParameters.Thickness), 
            TestName = "Проверка Get и Set для Thickness при " + 
            "значении равному минимальному")]
        [TestCase(25, nameof(SproocketParameters.Thickness), 
            TestName = "Проверка Get и Set для Thickness при " + 
            "значении равному определенному выражению в границе допустимых значений")]
        [TestCase(50, nameof(SproocketParameters.Thickness), 
            TestName = "Проверка Get и Set для Thickness при " + 
            "значении равному максимальному")]
        [TestCase(5, nameof(SproocketParameters.ToothCount), 
            TestName = "Проверка Get и Set для ToothCount при значении " + 
            "равному граничному минимальному")]
        [TestCase(50, nameof(SproocketParameters.ToothCount), 
            TestName = "Проверка Get и Set для ToothCount при значении " + 
            "равному определенному выражению в границе допустимых значений")]
        [TestCase(80, nameof(SproocketParameters.ToothCount), 
            TestName = "Проверка Get и Set для ToothCount при значении " + 
            "равному граничному максимальному")]
        public void AnyParameter_GetSetValue_Success(double expectedValue, string parameterName)
        {
            SproocketParameters sprocketParameters = new SproocketParameters();

            var propertyInfo = typeof(SproocketParameters).
                GetProperty(parameterName);
            propertyInfo.SetValue(sprocketParameters, expectedValue);

            Assert.AreEqual(expectedValue, propertyInfo.GetValue(sprocketParameters));
        }

        [TestCase(5, nameof(SproocketParameters.OuterDiameter),
            TestName = "Проверка Get и Set для OuterDiameter при" + 
                            " значении меньше минимального")]
        [TestCase(600, nameof(SproocketParameters.OuterDiameter),
                  TestName = "Проверка Get и Set для OuterDiameter при" + 
                             " значении больше максимального")]
        [TestCase(5, nameof(SproocketParameters.InnerDiameter),
            TestName = "Проверка Get и Set для InnerDiameter при" +
            " значении меньше минимального")]
        [TestCase(350, nameof(SproocketParameters.InnerDiameter),
                  TestName = "Проверка Get и Set для InnerDiameter при значении " +
                             "больше максимального")]
        [TestCase(2, nameof(SproocketParameters.Thickness),
            TestName = "Проверка Get и Set для Thickness при " +
            "значении меньше минимального")]
        [TestCase(150, nameof(SproocketParameters.Thickness),
                  TestName = "Проверка Get и Set для Thickness при " +
                             "значении больше максимального")]
        [TestCase(2, nameof(SproocketParameters.ToothCount),
            TestName = "Проверка Get и Set для ToothCount при значении " +
                            "равному меньше минимального")]
        [TestCase(150, nameof(SproocketParameters.ToothCount),
                  TestName = "Проверка Get и Set для ToothCount при значении " +
                             "равному больше максимального")]
        public void AnyParameter_SetValue_Failed(double value, string parameterName)
        {
            SproocketParameters sprocketParameters = new SproocketParameters();
            var propertyInfo = typeof(SproocketParameters).
                GetProperty(parameterName);

            Assert.Throws<TargetInvocationException>(() =>
            {
                propertyInfo.SetValue(sprocketParameters, value);
            });
        }

        [TestCase(TestName = "Проверка корректности создания объекта " +
            "используя конструткор по умолчанию")]
        public void Constructor_CorrectCreation_Success()
        {
            var expectedOuterDiameter = 80;
            var expectedInnerDiameter = 45;
            var expectedThickness = 12;
            var expectedToothCount = 6;
            var expectedToothHeight = 10;

            SproocketParameters sprocketParameters = new SproocketParameters();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedOuterDiameter, sprocketParameters.OuterDiameter);
                Assert.AreEqual(expectedInnerDiameter, sprocketParameters.InnerDiameter);
                Assert.AreEqual(expectedThickness, sprocketParameters.Thickness);
                Assert.AreEqual(expectedToothCount, sprocketParameters.ToothCount);
                Assert.AreEqual(expectedToothHeight, sprocketParameters.ToothHeight);
            });
        }
    }
}
