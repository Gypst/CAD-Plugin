namespace SprocketPlugin.UI
{
    using BL;
    using Builder;
    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;

    /// <summary>
    /// Главная форма для создания модели.
    /// </summary>
    public partial class SprocketForm : Form
    {
        #region Fields

        /// <summary>
        /// Параметры модели.
        /// </summary>
        private SprocketParameters _parameters;

        /// <summary>
        /// Словарь с TextBox и соответствующими им именами параметров.
        /// </summary>
        private readonly Dictionary<TextBox, string> _texBoxDictionary;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public SprocketForm()
        {
            InitializeComponent();

            _parameters = new SprocketParameters();

            _texBoxDictionary = new Dictionary<TextBox, string>()
            {
                { OuterDiameterTextBox, nameof(SprocketParameters.OuterDiameter) },
                { InnerDiameterTextBox, nameof(SprocketParameters.InnerDiameter) },
                { ThicknessTextBox,     nameof(SprocketParameters.Thickness) },
                { ToothHeightTextBox,   nameof(SprocketParameters.ToothHeight) },
                { ToothCountTextBox,    nameof(SprocketParameters.ToothCount) },
                { ToothTopRadiusRatioTextBox,    nameof(SprocketParameters.ToothTopRadiusRatio) },
            };

            InitState();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Инициализация всех полей.
        /// </summary>
        private void InitState()
        {
            OuterDiameterTextBox.Text = _parameters.OuterDiameter.ToString();
            InnerDiameterTextBox.Text = _parameters.InnerDiameter.ToString();
            ThicknessTextBox.Text   = _parameters.Thickness.ToString();
            ToothHeightTextBox.Text = _parameters.ToothHeight.ToString();
            ToothCountTextBox.Text  = _parameters.ToothCount.ToString();
            ToothTopRadiusRatioTextBox.Text = _parameters.ToothTopRadiusRatio.ToString();

            ChangeMinMaxToothHeightLabel();
        }

        /// <summary>
        /// Обработчик события покидания поля ввода(TextBox).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextBoxLeave(object sender, EventArgs e)
        {
            if (!_texBoxDictionary.TryGetValue((TextBox)sender, out string parameterName))
            {
                return;
            }

            CheckValueInTextBox((TextBox)sender, parameterName);

            if (parameterName == nameof(SprocketParameters.OuterDiameter))
            {
                ChangeMinMaxToothCountLabel();
                ChangeMinMaxToothHeightLabel();
                ChangeMinMaxInnerDiameterLabel();
            }

            CheckValueInAllTextBox();
        }

        /// <summary>
        /// Изменение отображаемого значения min/max у высоты зуба.
        /// </summary>
        private void ChangeMinMaxToothCountLabel()
        {
            //TODO:
            MinMaxToothCountLabel.Text = "(5 - " + _parameters.MaxToothCount 
                                                 + " шт)";
        }

        /// <summary>
        /// Изменение отображаемого значения min/max у высоты зуба.
        /// </summary>
        private void ChangeMinMaxToothHeightLabel()
        {
            MinMaxToothHeightLabel.Text = "(До " + _parameters.MaxToothHeight 
                                                 + " мм)";
        }

        /// <summary>
        /// Изменение отображаемого значения min/max у внутреннего радиуса.
        /// </summary>
        private void ChangeMinMaxInnerDiameterLabel()
        {
            MinMaxInnerDiameter.Text = "(25 - " + _parameters.MaxInnerDiameter 
                                                + " мм)";
        }

        /// <summary>
        /// Проверка и установка значения из поля ввода.
        /// </summary>
        /// <param name="textBox">Элемент управления <see cref="TextBox">.</param>
        /// <param name="propertyName">Название изменяемого параметра.</param>
        private void CheckValueInTextBox(TextBox textBox, string propertyName)
        {
            try
            {
                errorProvider.SetError(textBox, string.Empty);

                var propertyInfo = typeof(SprocketParameters).
                    GetProperty(propertyName);
                if (propertyName == nameof(SprocketParameters.ToothCount))
                {
                    propertyInfo.SetValue(_parameters,
                        int.Parse(textBox.Text));
                }
                else
                {
                    propertyInfo.SetValue(_parameters, 
                        double.Parse(textBox.Text));
                }
            }
            catch (Exception e)
            {
                errorProvider.SetError(textBox, 
                    e.InnerException != null 
                    ? e.InnerException.Message 
                    : e.Message);
            }
            finally
            {
                SetBuildButtonStatus();
            }
        }

        /// <summary>
        /// Проверка всех значений в полях ввода на валидность.
        /// </summary>
        private void CheckValueInAllTextBox()
        {
            foreach(var pair in _texBoxDictionary)
            {
                CheckValueInTextBox(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Проверка на наличие не валидных данных и включение/выключение кнопки.
        /// </summary>
        private void SetBuildButtonStatus()
        {
            BuildBtn.Enabled = true;

            foreach (var control in _texBoxDictionary.Keys)
            {
                if(errorProvider.GetError(control) != string.Empty)
                {
                    BuildBtn.Enabled = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Построить".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildBtn_Click(object sender, EventArgs e)
        {
            SprocketBuilder builder = new SprocketBuilder(_parameters);
            builder.Build();
        }

        #endregion Methods

    }
}