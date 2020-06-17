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
using System.Windows.Shapes;

namespace MOBILE_IMPIRE
{
    /// <summary>
    /// Логика взаимодействия для PhoneWindow.xaml
    /// </summary>
    public partial class PhoneWindow : Window
    {
        public PhoneWindow(PhoneWindowViewModel mobile)
        {
            InitializeComponent();
            this.DataContext = mobile;
            mobile.AnswerCall += _phoneAnswerCall;
            addButton.Click += clearBoxes;
        }
        
        private void _phoneAnswerCall(string dialedNumder)
        {
            CallMassege.Content = dialedNumder;
        }

        private void clearBoxes(object sender, RoutedEventArgs e)
        {
            PhoneNewContact.Text = null;
            NameNewContact.Text = null;
        }
    }
}
