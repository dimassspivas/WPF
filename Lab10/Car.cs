using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBinding1
{
    public class Car: INotifyPropertyChanged
    {
        private string model;
        public string Model { 
            get => model;
            
            set
            {
                model = value;
                this.UpdateProperty("Model");
            }
        }

        public int YearUtilizy { get; set; }

        private int year;
        public int Year {
            get => year;
            set
            {
                this.year = value;
                this.UpdateProperty("Year");
            } 
        }

        private double velocity;
        public double Velocity {
            get => velocity;
            
            set
            {
                velocity = value;
                UpdateProperty("Velocity");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateProperty(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
