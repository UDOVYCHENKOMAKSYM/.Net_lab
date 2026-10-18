using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Lab3
{
    public partial class MainWindow : Window
    {
        private readonly ToolManager _manager = new ToolManager();

        public MainWindow()
        {
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            InitializeComponent();

            ToolsListBox.ItemsSource = _manager.Tools;
            UpdateTotalWeight();
        }

        // Показ полів залежно від вибраного типу інструмента
        private void ToolTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Подія спрацьовує ще під час InitializeComponent, коли панелей може не бути
            if (HammerFields == null || DrillFields == null) return;

            if (ToolTypeComboBox.SelectedIndex == 0) // Молоток
            {
                HammerFields.Visibility = Visibility.Visible;
                DrillFields.Visibility = Visibility.Collapsed;
            }
            else // Дриль
            {
                HammerFields.Visibility = Visibility.Collapsed;
                DrillFields.Visibility = Visibility.Visible;
            }
        }

        // Створення та додавання об'єктів у ToolManager
        private void AddToolButton_Click(object sender, RoutedEventArgs e)
        {
            string purpose = PurposeTextBox.Text.Trim();
            if (purpose.Length == 0)
            {
                ShowInputError("Введіть призначення інструмента.", PurposeTextBox);
                return;
            }

            if (!TryParseDouble(WeightTextBox.Text, out double weight) || weight <= 0)
            {
                ShowInputError("Вага має бути додатним числом (наприклад, 2,5).", WeightTextBox);
                return;
            }

            if (!int.TryParse(ServiceLifeTextBox.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int serviceLife)
                || serviceLife <= 0)
            {
                ShowInputError("Термін служби має бути цілим числом, більшим за 0.", ServiceLifeTextBox);
                return;
            }

            try
            {
                Tool tool;

                if (ToolTypeComboBox.SelectedIndex == 0)
                {
                    var material = (HandleMaterial)HandleMaterialComboBox.SelectedValue;
                    tool = new Hammer(purpose, weight, serviceLife, material);
                }
                else
                {
                    var chuck = (ChuckType)ChuckTypeComboBox.SelectedValue;
                    tool = new Drill(purpose, weight, serviceLife, chuck);
                }

                _manager.Tools.Add(tool);
                UpdateUI(tool);
                ClearInputs();
            }
            catch (ArgumentException ex)
            {
                // валідація в класі Tool
                MessageBox.Show("Помилка введення даних: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Обробка дій над вибраним інструментом
        private void UseButton_Click(object sender, RoutedEventArgs e) => PerformAction(tool => tool.Use());

        private void SharpenButton_Click(object sender, RoutedEventArgs e) => PerformAction(tool => tool.Sharpen());

        private void RepairButton_Click(object sender, RoutedEventArgs e) => PerformAction(tool => tool.Repair());

        // Виконує дію над вибраним інструментом, оновлює список і показує результат
        private void PerformAction(Func<Tool, string> action)
        {
            var selectedTool = ToolsListBox.SelectedItem as Tool;
            if (selectedTool == null)
            {
                MessageBox.Show("Оберіть інструмент у списку.", "Інструмент не вибрано", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string result = action(selectedTool);
            UpdateUI(selectedTool);
            MessageBox.Show(result, "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Оновлення списку (зберігаючи вибір) та перерахунок загальної ваги
        private void UpdateUI(Tool toolToSelect)
        {
            // Tool не повідомляє про зміни, тому просимо список перемалювати елементи
            ToolsListBox.Items.Refresh();
            ToolsListBox.SelectedItem = toolToSelect;
            ToolsListBox.ScrollIntoView(toolToSelect);

            UpdateTotalWeight();
        }

        private void UpdateTotalWeight()
        {
            double totalWeight = _manager.GetTotalWeightOfToolsNeedingMaintenance();
            TotalWeightTextBlock.Text = totalWeight.ToString("F2") + " кг";
        }

        // Приймає і крапку, і кому як роздільник, незалежно від мови системи
        private static bool TryParseDouble(string text, out double value)
        {
            string normalized = text.Trim().Replace(',', '.');

            return double.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out value)
                && !double.IsNaN(value)
                && !double.IsInfinity(value);
        }

        private void ShowInputError(string message, Control field)
        {
            MessageBox.Show(message, "Некоректні дані", MessageBoxButton.OK, MessageBoxImage.Warning);
            field.Focus();
        }

        private void ClearInputs()
        {
            PurposeTextBox.Clear();
            WeightTextBox.Clear();
            ServiceLifeTextBox.Clear();
            PurposeTextBox.Focus();
        }
    }
}