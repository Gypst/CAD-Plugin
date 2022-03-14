namespace SproocketPlugin.UI
{
    using BL;
    using Builder;
    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;

    /// <summary>
    /// Главная форма для создания модели.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        /// <summary>
        /// Параметры модели.
        /// </summary>
        private SproocketParameters _parameters;

        /// <summary>
        /// Словарь с TextBox и соответствующими им именами параметров.
        /// </summary>
        private readonly Dictionary<TextBox, string> _texBoxDictionary;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _parameters = new SproocketParameters();

            _texBoxDictionary = new Dictionary<TextBox, string>()
            {
                { OuterDiameterTextBox, nameof(SproocketParameters.OuterDiameter) },
                { InnerDiameterTextBox, nameof(SproocketParameters.InnerDiameter) },
                { ThicknessTextBox,     nameof(SproocketParameters.Thickness) },
                { ToothHeightTextBox,   nameof(SproocketParameters.ToothHeight) },
                { ToothCountTextBox,    nameof(SproocketParameters.ToothCount) },
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

            if (parameterName == nameof(SproocketParameters.OuterDiameter))
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
            MinMaxToothCountLabel.Text = "(5 - " + (_parameters.OuterDiameter *
                SproocketParameters.MAX_TOOTH_COUNT_FROM_OUTER_DIAMETER).ToString() + " мм)";
        }

        /// <summary>
        /// Изменение отображаемого значения min/max у высоты зуба.
        /// </summary>
        private void ChangeMinMaxToothHeightLabel()
        {
            MinMaxToothHeightLabel.Text = "(До " + (_parameters.OuterDiameter *
                SproocketParameters.MAX_INNER_FROM_OUTER_DIAMETER_MULTIPLIER).ToString() + " мм)";
        }

        /// <summary>
        /// Изменение отображаемого значения min/max у внутреннего радиуса.
        /// </summary>
        private void ChangeMinMaxInnerDiameterLabel()
        {
            MinMaxInnerDiameter.Text = "(25 - " + (_parameters.OuterDiameter * 
                SproocketParameters.MAX_INNER_FROM_OUTER_DIAMETER_MULTIPLIER)
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

                var propertyInfo = typeof(SproocketParameters).
                    GetProperty(propertyName);
                if (propertyName == nameof(SproocketParameters.ToothCount))
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
                if(e.InnerException != null)
                {
                    errorProvider.SetError(textBox, e.InnerException.Message);
                }
                else
                {
                    errorProvider.SetError(textBox, e.Message);
                }
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
            SproocketBuilder builder = new SproocketBuilder(_parameters);
            builder.Build();
        }

        #endregion Methods

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}