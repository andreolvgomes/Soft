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

namespace Soft.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for TextBoxSearch.xaml
    /// </summary>
    public partial class TextBoxSearch : UserControl
    {
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(TextBoxSearch), new PropertyMetadata("Label"));



        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(TextBoxSearch));



        public TextBoxSearch()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
