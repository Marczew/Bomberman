using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Zabawa_z_instrukcjami_if_else
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }



        private void changeText_Click(object sender, RoutedEventArgs e)
        {
           
            
                if (enableCheckbox.IsChecked == true)
                {
                    if (labelToChange.Text == "Z prawej")
                    {
                        labelToChange.Text = "Z lewej";
                        labelToChange.HorizontalAlignment = HorizontalAlignment.Left;
                    }
                    else
                    {
                        labelToChange.Text = "Z prawej";
                        labelToChange.HorizontalAlignment = HorizontalAlignment.Right;
                    }
                }
                else
                {
                    labelToChange.Text = "Możliwość zmiany tekstu zo tała wyłączona";
                    labelToChange.HorizontalAlignment = HorizontalAlignment.Center;
                }
            
        }
        
    }
}
