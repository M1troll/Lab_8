using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MOBILE_IMPIRE
{
    public class PhoneWindowViewModel
    {
        public Contact ChoiceContact { get; set; }
        public string Number { get; set; }
        public string NameContact { get; set; }
        public string PhoneContact { get; set; }

        public delegate void AnswerCallHandler(string dialedNumber);
        public event AnswerCallHandler AnswerCall;
        public event CallHandler Call;

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public PhoneWindowViewModel(ISITTelecom mobileOperator)
        {
            mobileOperator.AddPhone(this);
        }

        public void ReceiveCall(string callingNumber, string dialedNumber)
        {
            if (Number.Equals(dialedNumber))
            {
                bool check = Contacts.Any(x => x.Number == callingNumber);
                if (check)
                {
                    var Cont = Contacts.First(x => x.Number == callingNumber);
                    AnswerCall(Cont.Name + " - " + callingNumber);
                }
                else
                {
                    AnswerCall("Неизвестный номер : " + callingNumber);
                }
            }
        }

        private void AddNewContact()
        {
            bool check = !Contacts.Any(x => x.Number == PhoneContact);
            if (NameContact != null && PhoneContact != null && check)
            {
                Contacts.Add(new Contact() { Number = PhoneContact, Name = NameContact });
            }
        }

        public void DialingNumber()
        {
            if (ChoiceContact != null) Call(Number, ChoiceContact.Number);
            AnswerCall("");
        }

        private RelayCommand _Dialingcommand;
        public RelayCommand DialingCommand
        {
            get
            {
                return _Dialingcommand ?? (_Dialingcommand = new RelayCommand(DialingNumber));
            }
        }

        private RelayCommand _addNewContactcommand;
        public RelayCommand AddNewContactCommand
        {
            get
            {
                return _addNewContactcommand ?? (_addNewContactcommand = new RelayCommand(AddNewContact));
            }
        }
    }
}
