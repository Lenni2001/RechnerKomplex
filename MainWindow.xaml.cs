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

namespace RechnerKomplex
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void berechnenButton_Click(object sender, RoutedEventArgs e)
        {
            if (!FieldsEmpty())
            {
                //Felder sollten alle parse-fähig sein (siehe unten)
                double a1 = double.Parse(realteil1TextBox.Text);
                double b1 = double.Parse(imagteil1TextBox.Text);
                double a2 = double.Parse(realteil2TextBox.Text);
                double b2 = double.Parse(imagteil2TextBox.Text);

                //Instanz einer komplexen Zahl;
                Complex comp1 = new Complex(a1, b1);
                Complex comp2 = new Complex(a2, b2);

                //char operatorToUse = ' ';
                switch (operatorComboBox.SelectedIndex) //get selected operator
                {
                    case 1:
                        //operatorToUse = '+';
                        SetAnswerComplex(comp1 + comp2);
                        break;
                    case 2:
                        //operatorToUse = '-';
                        SetAnswerComplex(comp1 - comp2);
                        break;
                    case 3:
                        //operatorToUse = '*';
                        SetAnswerComplex(comp1 * comp2);
                        break;
                    case 4:
                        //operatorToUse = '/';
                        SetAnswerComplex(comp1 / comp2);
                        break;

                }

                /* //for using the Calc() method
                 
            if (operatorToUse != ' ')
            {
                Complex comp3 = comp1.Calc(comp2, operatorToUse); //calculates with char of operator to use
                //MessageBox.Show((comp1 / comp2).ToString());

                realteilOutTextBox.Text = comp3.GetA().ToString(); //displays a value in readonly textbox
                imagteilOutTextBox.Text = comp3.GetB().ToString(); //displays b value in readonly textbox
                complexOutAsStringLabel.Content = comp3.ToString(); //displays as string
            }
                */
            }
            else
            {
                MessageBox.Show("Bitte fülle alle Felder aus.", ":("); //error message
            }
        }

        private bool FieldsEmpty() //not the cleanest solution...
        {
            if (realteil1TextBox.Text.Length == 0)
            {
                return true;
            }
            else if (realteil2TextBox.Text.Length == 0)
            {
                return true;
            }
            else if (imagteil1TextBox.Text.Length == 0)
            {
                return true;
            }
            else if (imagteil2TextBox.Text.Length == 0)
            {
                return true;
            }
            else if (operatorComboBox.SelectedIndex == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetAnswerComplex(Complex complex)
        {
            realteilOutTextBox.Text = complex.GetA().ToString(); //displays a value in readonly textbox
            imagteilOutTextBox.Text = complex.GetB().ToString(); //displays b value in readonly textbox
            complexOutAsStringLabel.Content = complex.ToString(); //displays as string
        }

        private void TextBox_OnlyNumberInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            var getText = textBox.Text.Insert(textBox.SelectionStart, e.Text); //get the text from input

            double val;
            e.Handled = !double.TryParse(getText, out val); //check if text is a double :)
        }
    
    }
}
