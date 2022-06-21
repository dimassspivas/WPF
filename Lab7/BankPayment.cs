using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    [Serializable]
    public class BankPayment
    {
        public string Sender { get; set; }
        public string Repicient { get; set; }
        public double Amount { get; set; }
        public string PurposeOfPayment { get; set; }
        public DateTime CreationDate { get; set; }
        public BankPayment() { }
        public BankPayment(string sender, string recipient,double amount, string purposeOfPayment)
        {
            Sender = sender;
            Repicient = recipient;
            Amount = amount;
            PurposeOfPayment = purposeOfPayment;
            CreationDate = DateTime.Now;
        }
    }
}
