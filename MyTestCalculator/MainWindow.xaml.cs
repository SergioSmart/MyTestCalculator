using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace MyTestCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            foreach (UIElement element in GroupElements.Children)
            {
                if(element is Button)
                {
                    ((Button)element).Click += OnClickButton;
                }
            }
        }

        private void OnClickButton(object sender, RoutedEventArgs e)
        {        
            try
            {            
                string textButton = ((Button)e.OriginalSource).Content.ToString();


                if (textButton == "C")
                {
                    TextBoxOutput.Clear();
                }
                else if (textButton == "√")
                {
                    TextBoxOutput.Text = Math.Sqrt(Convert.ToDouble(TextBoxOutput.Text)).ToString();
                }
                else if (textButton == "◄")
                {
                    if (TextBoxOutput.Text.Length > 0 && !TextBoxOutput.Text.Contains("Error!"))
                        TextBoxOutput.Text = TextBoxOutput.Text.Remove(TextBoxOutput.Text.Length - 1, 1);
                }
                else if (textButton == "=")
                {
                    TextBoxOutput.Text = new DataTable().Compute(TextBoxOutput.Text, null).ToString().Substring(0, 12);
                }
                else if (textButton == ".")
                {
                    for (int i = 0; i < TextBoxOutput.Text.Length; i++)
                    {
                        
                    }
                }
                else
                    TextBoxOutput.Text += textButton;
            }
            catch
            {
                TextBoxOutput.Text = "Error!";
            }          
        }
    }
}
