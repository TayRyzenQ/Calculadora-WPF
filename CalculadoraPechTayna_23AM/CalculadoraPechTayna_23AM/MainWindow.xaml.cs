using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraPechTayna_23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                //MessageBox.Show("Un mensaje de click");
                string value = (string)button.Content;  //se obtiene el contenido
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperat(value);
                }
                else if (value == "CE")
                {
                    Screen.Clear();
                }
                else if (value == "C")
                {
                    if (Screen.Text.Length == 1)
                    {
                        Screen.Text = "";
                    }
                    else if (Screen.Text.Length >= 1)
                    {
                        Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);
                    }
                    else
                    {
                        Screen.Clear();
                    }
                }
                else if (value == "=")
                {
                    HandleEquals(Screen.Text);
                }
                /** else if (value == "OB")
                 {
                      Screen.Text.Length - 1;
                 }*/

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }

        /* public string Remove (string value)
         {
             return Screen.Text.Length - (value.Length-1);
         }*/

        public bool IsNumber(string num)
        {
            /* if (double.TryParse(num, out _))
             {

             }    //*/
            return double.TryParse(num, out _);
        }

        //METODOS AUXILIARES
        private void HandleNumbers(string value)
        {
            if (string.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;   //es una forma de concatener los numeros
            }
        }



        private bool IsOperator(string possibleOperator)
        {
            /*if(possibleOperator == "+" || possibleOperator == "-" || possibleOperator == "*" || possibleOperator == "/")
            {
                return true;
            }
            return false;*/

            return possibleOperator == "+" || possibleOperator == "-" || possibleOperator == "*" || possibleOperator == "/";
        }
        private void HandleOperat(string value)
        {
            if (!String.IsNullOrEmpty(Screen.Text) && !ContainstOtherOperator(Screen.Text))
            {
                Screen.Text += value;
            }
        }

        private bool ContainstOtherOperator(string screenContent)
        {
            return screenContent.Contains("+") || screenContent.Contains("-") || screenContent.Contains("*") || screenContent.Contains("/");
        }

        private string FindOperator(string screenContent)
        {
            foreach (char c in screenContent)
            {
                if (IsOperator(c.ToString()))
                {
                    return c.ToString();
                }
            }
            return screenContent;
        }

        private string Suma()
        {
            string[] numbers = Screen.Text.Split("+");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 + n2, 12).ToString();
        }
        private string Resta()
        {
            string[] numbers = Screen.Text.Split("-");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 - n2, 12).ToString();
        }
        private string Multi()
        {
            string[] numbers = Screen.Text.Split("*");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 * n2, 12).ToString();
        }
        private string Div()
        {
            string[] numbers = Screen.Text.Split("/");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 / n2, 12).ToString();
        }

        private void HandleEquals(string screenContect)
        {
            string op = FindOperator(screenContect);
            if (!string.IsNullOrEmpty(op))
            {
                switch (op)
                {
                    case "+":
                        Screen.Text = Suma();
                        break;
                    case "-":
                        Screen.Text = Resta();
                        break;
                    case "*":
                        Screen.Text = Multi();
                        break;
                    case "/":
                        Screen.Text = Div();
                        break;
                }
            }
        }

    }
}
