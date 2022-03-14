﻿namespace SproocketPlugin.Tests
{
    using BL;

    using NUnit.Framework;

    using System.Reflection;

    [TestFixture]
    public class SproocketParametersTest
    {
        [TestCase(10, nameof(SproocketParameters.BodyLength), 
            TestName = "Проверка Get и Set для BodyLength при" + 
            " значении равному граничному минимальному")]
        [TestCase(15, nameof(SproocketParameters.BodyLength), 
            TestName = "Проверка Get и Set для BodyLength при" + 
            "значении равному определенному выражению в границе допустимых значений")]
        [TestCase(25, nameof(SproocketParameters.BodyLength), 
            TestName = "Проверка Get и Set для BodyLength при" + 
            " значении равному граничному максимальному")]
        [TestCase(2, nameof(SproocketParameters.BodyDiameter), 
            TestName = "Проверка Get и Set для BodyDiameter при" + 
            " значении равному граничному минимальному")]
        [TestCase(2.5, nameof(SproocketParameters.BodyDiameter), 
            TestName = "Проверка Get и Set для BodyDiameter при значении " + 
            "равному определенному выражению в границе допустимых значений")]
        [TestCase(3, nameof(SproocketParameters.BodyDiameter), 
            TestName = "Проверка Get и Set для BodyDiameter при значении " + 
            "равному граничному максимальному")]
        [TestCase(4, nameof(SproocketParameters.GuidesInnerRibLength), 
            TestName = "Проверка Get и Set для GuidesInnerRibLength при " + 
            "значении равному граничному минимальному")]
        [TestCase(5, nameof(SproocketParameters.GuidesInnerRibLength), 
            TestName = "Проверка Get и Set для GuidesInnerRibLength при " + 
            "значении равному определенному выражению в границе допустимых значений")]
        [TestCase(6, nameof(SproocketParameters.GuidesInnerRibLength), 
            TestName = "Проверка Get и Set для GuidesInnerRibLength при " + 
            "значении равному граничному максимальному")]
        [TestCase(4, nameof(SproocketParameters.NoseLength), 
            TestName = "Проверка Get и Set для NoseLength при значении " + 
            "равному граничному минимальному")]
        [TestCase(6, nameof(SproocketParameters.NoseLength), 
            TestName = "Проверка Get и Set для NoseLength при значении " + 
            "равному определенному выражению в границе допустимых значений")]
        [TestCase(8, nameof(SproocketParameters.NoseLength), 
            TestName = "Проверка Get и Set для NoseLength при значении " + 
            "равному граничному максимальному")]
        [TestCase(3, nameof(SproocketParameters.WingsLength), 
            TestName = "Проверка Get и Set для WingsLength при значении " + 
            "равному граничному минимальному")]
        [TestCase(5, nameof(SproocketParameters.WingsLength), 
            TestName = "Проверка Get и Set для WingsLength при значении " + 
            "равному определенному выражению в границе допустимых значений")]
        [TestCase(7, nameof(SproocketParameters.WingsLength), 
            TestName = "Проверка Get и Set для WingsLength при значении " + 
            "равному граничному максимальному")]
        [TestCase(0.5, nameof(SproocketParameters.WingsWidth),
            TestName = "Проверка Get и Set для WingsWidth при значении " + 
            "равному граничному минимальному")]
        [TestCase(0.7, nameof(SproocketParameters.WingsWidth), 
            TestName = "Проверка Get и Set для WingsWidth при значении " + 
            "равному определенному выражению в границе допустимых значений")]
        [TestCase(1, nameof(SproocketParameters.WingsWidth), 
            TestName = "Проверка Get и Set для WingsWidth при значении " + 
            "равному граничному максимальному")]
        public void AnyParameter_GetSetValue_Success(double expectedValue, string parameterName)
        {
            SproocketParameters rocketParameter = new SproocketParameters();

            var propertyInfo = typeof(SproocketParameters).
                GetProperty(parameterName);
            propertyInfo.SetValue(rocketParameter, expectedValue);

            Assert.AreEqual(expectedValue, propertyInfo.GetValue(rocketParameter));
        }

        [TestCase(9.9, nameof(SproocketParameters.BodyLength), 
            TestName = "Проверка Set для BodyLength при присвоении " + 
            "значения равному меньше минимального возможного")]
        [TestCase(25.1, nameof(SproocketParameters.BodyLength), 
            TestName = "Проверка Set для BodyLength при присвоении " + 
            "значения равному больше максимального возможного")]
        [TestCase(1.9, nameof(SproocketParameters.BodyDiameter), 
            TestName = "Проверка Set для BodyDiameter при присвоении " + 
            "значения равному меньше минимального возможного")]
        [TestCase(3.1, nameof(SproocketParameters.BodyDiameter), 
            TestName = "Проверка Set для BodyDiameter при присвоении " + 
            "значения равному больше максимального возможного")]
        [TestCase(3.9, nameof(SproocketParameters.GuidesInnerRibLength), 
            TestName = "Проверка Set для GuidesInnerRibLength при присвоении " + 
            "значения равному меньше минимального возможного")]
        [TestCase(6.1, nameof(SproocketParameters.GuidesInnerRibLength), 
            TestName = "Проверка Set для GuidesInnerRibLength при присвоении " + 
            "значения равному больше максимального возможного")]
        [TestCase(3.9, nameof(SproocketParameters.NoseLength), 
            TestName = "Проверка Set для NoseLength при присвоении значения " + 
            "равному меньше минимального возможного")]
        [TestCase(8.1, nameof(SproocketParameters.NoseLength), 
            TestName = "Проверка Set для NoseLength при присвоении значения " + 
            "равному больше максимального возможного")]
        [TestCase(2.9, nameof(SproocketParameters.WingsLength), 
            TestName = "Проверка Set для WingsLength при присвоении значения " + 
            "равному меньше минимального возможного")]
        [TestCase(7.1, nameof(SproocketParameters.WingsLength), 
            TestName = "Проверка Set для WingsLength при присвоении значения " + 
            "равному больше максимального возможного")]
        [TestCase(0.3, nameof(SproocketParameters.WingsWidth), 
            TestName = "Проверка Set для WingsWidth при присвоении значения " + 
            "равному меньше минимального возможного")]
        [TestCase(1.1, nameof(SproocketParameters.WingsWidth), 
            TestName = "Проверка Set для WingsWidth при присвоении значения " + 
            "равному больше максимального возможного")]
        public void AnyParameter_SetValue_Failed(double value, string parameterName)
        {
            SproocketParameters rocketParameter = new SproocketParameters();
            var propertyInfo = typeof(SproocketParameters).
                GetProperty(parameterName);

            Assert.Throws<TargetInvocationException>(() =>
            {
                propertyInfo.SetValue(rocketParameter, value);
            });
        }

        [TestCase(TestName = "Проверка корректности создания объекта " +
            "используя конструткор по умолчанию")]
        public void Constructor_CorrectCreation_Success()
        {
            var expectedBodyLength = 20;
            var expectedBodyDiameter = 2.5;
            var expectedGuidesCount = 4;
            var expectedGuidesDepth = 0.25;
            var expectedGuidesInnerRibLength = 5;
            var expectedGuidesOuterRibLength = 2.5;
            var expectedGuidesWidth = 0.5;
            var expectedNoseLength = 6;
            var expectedWingsCount = 4;
            var expectedWingsDepth = 0.25;
            var expectedWingsLength = 4;
            var expectedWingsWidth = 0.625;

            SproocketParameters rocketParameters = new SproocketParameters();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedBodyLength, rocketParameters.BodyLength);
                Assert.AreEqual(expectedBodyDiameter, rocketParameters.BodyDiameter);
                Assert.AreEqual(expectedGuidesCount, rocketParameters.GuidesCount);
                Assert.AreEqual(expectedGuidesDepth, rocketParameters.GuidesDepth);
                Assert.AreEqual(expectedGuidesInnerRibLength, rocketParameters.GuidesInnerRibLength);
                Assert.AreEqual(expectedGuidesOuterRibLength, rocketParameters.GuidesOuterRibLength);
                Assert.AreEqual(expectedGuidesWidth, rocketParameters.GuidesWidth);
                Assert.AreEqual(expectedNoseLength, rocketParameters.NoseLength);
                Assert.AreEqual(expectedWingsCount, rocketParameters.WingsCount);
                Assert.AreEqual(expectedWingsDepth, rocketParameters.WingsDepth);
                Assert.AreEqual(expectedWingsLength, rocketParameters.WingsLength);
                Assert.AreEqual(expectedWingsWidth, rocketParameters.WingsWidth);
            });
        }
    }
}
