using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandOrderDemo
{
    [Serializable()]
    public class Order: INotifyPropertyChanged
    {
        public Order()
        {
            this.id = new Random().Next(1, 2000000);
            this.customer = "";
            this.price = 0.0;
            this.orderDate = DateTime.Now;
        }
        public Order(string name, double price, DateTime date)
        {
            this.id = new Random().Next(1, 2000000);
            this.customer = name;
            this.price = price;
            this.orderDate = date;
        }
        private int id;
        public int Id {
            get { return id; }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private string customer;
        public string Customer
        {
            get { return this.customer; }
            set
            {
                if (value != this.customer)
                {
                    this.customer = value;
                    OnPropertyChanged("Customer"); 
                }
            }
        }

        private double price;
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value != this.price)
                {
                    this.price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        private DateTime orderDate;
        public DateTime Date
        {
            get { return this.orderDate; }
            set
            {
                if (!value.Equals(this.orderDate))
                {
                    this.orderDate = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public override string ToString()
        {
            return String.Format("[{0}]: {1} -> {2} << {3}", Id, Customer, Price, Date);
        }

    }
}
