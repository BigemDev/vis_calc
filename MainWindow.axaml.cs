using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        private string _currentNumber = "";
        private double _result = 0;
        private string _operation = "";
        private bool _isNewNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Content is string buttonContent)
            {
                if (_isNewNumber)
                {
                    DisplayTextBox.Text = buttonContent;
                    _isNewNumber = false;
                }
                else
                {
                    DisplayTextBox.Text += buttonContent;
                }
                _currentNumber = DisplayTextBox.Text ?? "";
            }
        }

        private void OperatorButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Content is string buttonContent)
            {
                if (!string.IsNullOrEmpty(_currentNumber))
                {
                    if (_result == 0)
                    {
                        _result = double.Parse(_currentNumber);
                    }
                    else
                    {
                        Calculation();
                    }
                }
                _operation = buttonContent;
                _isNewNumber = true;
            }
        }

        private void EqualsButton(object sender, RoutedEventArgs e)
        {
            Calculation();
            _operation = "";
            _isNewNumber = true;
        }

        private void DecimalButton(object sender, RoutedEventArgs e)
        {
            if (DisplayTextBox.Text != null && !DisplayTextBox.Text.Contains("."))
            {
                if (_isNewNumber)
                {
                    DisplayTextBox.Text = "0.";
                    _isNewNumber = false;
                }
                else
                {
                    DisplayTextBox.Text += ".";
                }
                _currentNumber = DisplayTextBox.Text ?? "";
            }
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            DisplayTextBox.Text = "0";
            _currentNumber = "";
            _result = 0;
            _operation = "";
            _isNewNumber = true;
        }

        private void Calculation()
        {
            if (!string.IsNullOrEmpty(_currentNumber))
            {
                double number = double.Parse(_currentNumber);
                switch (_operation)
                {
                    case "+":
                        _result += number;
                        break;
                    case "-":
                        _result -= number;
                        break;
                    case "*":
                        _result *= number;
                        break;
                    case "/":
                        if (number != 0)
                        {
                            _result /= number;
                        }
                        else
                        {
                            DisplayTextBox.Text = "Error";
                            return;
                        }
                        break;
                }
                DisplayTextBox.Text = _result.ToString();
                _currentNumber = "";
            }
        }
    }
}