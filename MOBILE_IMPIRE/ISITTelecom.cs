using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_IMPIRE
{
    public delegate void CallHandler(string callingNumber, string dialedNumber);
    public class ISITTelecom
    {
        public List<PhoneWindowViewModel> Phones { get; } = new List<PhoneWindowViewModel>();
        public event CallHandler Call;
        public void AddPhone(PhoneWindowViewModel phone)
        {
            Phones.Add(phone);
            phone.Call += DialingNumber;
            this.Call += phone.ReceiveCall;
        }
        public void DialingNumber(string callingNumber, string dialedNumber)
        {
            Call(callingNumber, dialedNumber);
        }
    }
}
