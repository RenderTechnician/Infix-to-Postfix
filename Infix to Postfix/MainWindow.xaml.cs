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
using System.Text.RegularExpressions;
using System.Collections;

namespace Infix_to_Postfix
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Stack HeldValues = new Stack();
            StringBuilder sb = new StringBuilder();
            string infix_data = Infix.Text;

            // Main For Loop
            for(int i = 0; i < infix_data.Length; i++)
            {
                //Checks for any alphanumerical characters 
             if(Regex.IsMatch(infix_data[i].ToString(),"[a-zA-Z0-9]"))
                {
                    sb.Append(infix_data[i],1);
                }
             //Checks whether value is an addition sign
             else if (Regex.IsMatch(infix_data[i].ToString(), "[*]"))
                {
                    HeldValues.Push(infix_data[i].ToString());
                }
                //Checks whether value is a multiplication sign
                else if (Regex.IsMatch(infix_data[i].ToString(), "[+]"))
                {
                    if(HeldValues.Peek().Equals("*") || HeldValues.Peek().Equals("-"))
                    {
                        sb.Append(HeldValues.Pop());
                        HeldValues.Push(infix_data[i].ToString());
                    }
                    else
                    {
                        HeldValues.Push(infix_data[i].ToString()); 
                    }
                }
                //Checks whether value is a subtraction sign
                else if (Regex.IsMatch(infix_data[i].ToString(), "[-]"))
                {
                    HeldValues.Push(infix_data[i].ToString());
                }
            }

            if(HeldValues != null)
            {
                for (int i = 0; i < HeldValues.Count; i++)
                {
                    sb.Append(HeldValues.Pop());
                }
            }

            Postfix.Text = sb.ToString();
        }
    }
}
