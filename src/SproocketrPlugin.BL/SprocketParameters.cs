namespace SprocketPlugin.BL
{
    using System;

    /// <summary>
    /// Класс, в котором содержатся параметры для построения модели.
    /// </summary>
    public class SprocketParameters
    {
        
        #region Constants

        public const double MIN_OUTER_DIAMETER = 50;
        public const double MAX_OUTER_DIAMETER = 500;

        public const double MIN_INNER_DIAMETER = 25;
        public const double MAX_INNER_DIAMETER = 250;

        public const double MIN_THICKNESS = 5;
        public const double MAX_THICKNESS = 50;

        public const double MIN_TOOTH_TOP_RADIUS_RATIO = 0.2;
        public const double MAX_TOOTH_TOP_RADIUS_RATIO = 0.8;

        public const int MIN_TOOTH_COUNT = 5;
        public const int MAX_TOOTH_COUNT = 30;

        public const double MIN_TOOTH_HEIGHT = 1;
        //Высота зуба не больше 20% от диаметра.
        public const double MAX_TOOTH_HEIGHT_FROM_OUTER_DIAMETER = 0.2;
        //Внутреннее отверстие не больше 90% от внешнего радиуса
        public const double MAX_INNER_FROM_OUTER_DIAMETER_MULTIPLIER = 0.9;
        //Максимальное количество зубьев от внешнего радиуса
        public const double MAX_TOOTH_COUNT_FROM_OUTER_DIAMETER = 0.2;

        #endregion

        #region Fields

        /// <summary>
        /// Внешний диаметр.
        /// </summary>
        private double _outerDiameter;

        /// <summary>
        /// Внутренний диаметр.
        /// </summary>
        private double _innerDiameter;

        /// <summary>
        /// Толщина пластины.
        /// </summary>
        private double _thickness;

        /// <summary>
        /// Колличество зубьев.
        /// </summary>
        private int _toothCount;

        /// <summary>
        /// Высота зуба.
        /// </summary>
        private double _toothHeight;

        /// <summary>
        /// Коэффициент ширины верхнего радиуса от основания зуба
        /// </summary>
        private double _toothTopRadiusRatio;

        #endregion

        #region Properties

        /// <summary>
        /// Максимальный внутренний диаметр цепного колеса при заданных параметрах.
        /// </summary>
        public double MaxInnerDiameter => OuterDiameter * MAX_INNER_FROM_OUTER_DIAMETER_MULTIPLIER;

        /// <summary>
        /// Максимальное количество зубьев цепного колеса при заданных параметрах.
        /// </summary>
        public int MaxToothCount
        {
            get
            {
                var maxCount = Convert.ToInt32(OuterDiameter * MAX_TOOTH_COUNT_FROM_OUTER_DIAMETER);
                if (maxCount > MAX_TOOTH_COUNT)
                {
                    maxCount = MAX_TOOTH_COUNT;
                }
                return maxCount;
            }
        }

        /// <summary>
        /// Максимальная высота зубьев цепного колеса при заданных параметрах.
        /// </summary>
        public double MaxToothHeight => OuterDiameter * MAX_TOOTH_HEIGHT_FROM_OUTER_DIAMETER;


        /// <summary>
        /// Внешний диаметр.
        /// </summary>
        public double OuterDiameter
        {
            get => _outerDiameter;
            set
            {
                if (!ValidateValue(MIN_OUTER_DIAMETER,
                    MAX_OUTER_DIAMETER, value))
                {
                    throw new ArgumentException("Введено неверное "
                        + "значение внешнего диаметра.");
                }

                _outerDiameter = value;
            }
        }

        /// <summary>
        /// Внутренний диаметр.
        /// </summary>
        public double InnerDiameter
        {
            get => _innerDiameter;
            set
            {
                if (!ValidateValue(MIN_INNER_DIAMETER, MaxInnerDiameter, value) 
                    && !ValidateValue(MIN_INNER_DIAMETER, MAX_INNER_DIAMETER, value))
                {
                    throw new ArgumentException("Введено неверное "
                        + "значение внутреннего диаметра.");
                }

                _innerDiameter = value;
            }
        }

        /// <summary>
        /// Толщина пластины.
        /// </summary>
        public double Thickness
        {
            get => _thickness;
            set
            {
                if (!ValidateValue(MIN_THICKNESS,
                    MAX_THICKNESS, value))
                {
                    throw new ArgumentException("Введено неверное "
                        + "значение толщины пластины.");
                }

                _thickness = value;
            }
        }

        /// <summary>
        /// Количество зубьев.
        /// </summary>
        public int ToothCount
        {
            get => _toothCount;
            set
            {
                if (ValidateValue(MIN_TOOTH_COUNT, MaxToothCount, value))
                {
                    _toothCount = value;

                } else
                {
                    throw new ArgumentException("Введено неверное "
                        + "значение количества зубьев.");
                }

            }
        }

        /// <summary>
        /// Высота зуба.
        /// </summary>
        public double ToothHeight
        {
            get => _toothHeight;
            set
            {
                if (!ValidateValue(MIN_TOOTH_HEIGHT, MaxToothHeight, value))
                {
                throw new ArgumentException("Введено неверное "
                        + "значение высоты зуба.");
                }

                _toothHeight = value;
            }
        }

        /// <summary>
        /// Коэффициент ширины верхнего радиуса от основания зуба.
        /// </summary>
        public double ToothTopRadiusRatio
        {
            get => _toothTopRadiusRatio;
            set
            {
                if (!ValidateValue(MIN_TOOTH_TOP_RADIUS_RATIO, MAX_TOOTH_TOP_RADIUS_RATIO, value))
                {
                    throw new ArgumentException("Введено неверное "
                                                + "значение коэффициента ширины верхнего радиуса.");
                }

                _toothTopRadiusRatio = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор по умолчанию, задающий начальные значения параметров.
        /// </summary>
        public SprocketParameters()
        {
            OuterDiameter = 80;
            InnerDiameter = 45;
            Thickness = 12;
            ToothCount = 6;
            ToothHeight = 10;
            ToothTopRadiusRatio = 0.5;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Проверяет значение на корректность.
        /// </summary>
        /// <param name="min">Минимальное значение параметра.</param>
        /// <param name="max">Максимальное значение параметра.</param>
        /// <param name="value">Проверяемое значение.</param>
        /// <returns>Результат проверки.</returns>
        public bool ValidateValue(double min, double max, double value)
        {
            return value <= max && value >= min;
        }

        #endregion
    }
}
