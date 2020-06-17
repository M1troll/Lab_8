using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MOBILE_IMPIRE
{
    public class MainWindowViewModel: Window
    {
        public ISITTelecom mobileOperator = new ISITTelecom();             
        public string NumberNewClient { get; set; }

        private RelayCommand _addNewClientcommand;
        public RelayCommand AddNewClientCommand
        {
            get
            {
                return _addNewClientcommand ?? (_addNewClientcommand = new RelayCommand(AddNewClient));
            }
        }
        private void AddNewClient()
        {
            if (NumberNewClient != null)
            {
                bool check = !mobileOperator.Phones.Any(x => x.Number == NumberNewClient);
                if (check)
                {
                    PhoneWindowViewModel mobile = new PhoneWindowViewModel(mobileOperator)
                    {
                        Number = NumberNewClient
                    };
                    PhoneWindow phoneView = new PhoneWindow(mobile);
                    phoneView.Show();
                }
            }
        }
    }
}
