using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{

  public class Array
    {
        public delegate void ArrayHandler(Array sender, ArrayEventArgs e);
        public event ArrayHandler PercantageChange;
        public double[] arr;
        public int Length{ get; }
        public Array(int length, ArrayHandler percantageChange)
        {
            Length = length;
            PercantageChange += percantageChange; 
            Init(length);

        }

        private void Init(int length)
        {
            arr = new double[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next(-1000, 1000);
            }
        }
        public double Sum()
        {
            double res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                PercantageChange(this, new ArrayEventArgs(i + 1));
                res += arr[i];

            }
            return res;
        }
        public async Task<double> SumAsync()
        {
            double res = 0;
            await Task.Run(() => {
                for (int i = 0; i < arr.Length; i++)
                {
                    PercantageChange(this, new ArrayEventArgs(i + 1));
                    res += arr[i];

                }
                
            });
            return res;

        }
        public void Sort()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                PercantageChange(this, new ArrayEventArgs(i + 1));
                for (int j = 1; j < arr.Length-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        double temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                    
                }
            }
        }
        public async void SortAsync()
        {
            await Task.Run(() => {
                for (int i = 0; i < arr.Length; i++)
                {
                    PercantageChange(this, new ArrayEventArgs(i + 1));
                    for (int j = 1; j < arr.Length - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            double temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }

                    }
                }
            });
            
        }
        public async void SortDescAsync()
        {
            await Task.Run(() => {
                for (int i = 0; i < arr.Length; i++)
                {
                    PercantageChange(this, new ArrayEventArgs(i + 1));
                    for (int j = 1; j < arr.Length - 1; j++)
                    {
                        if (arr[j] < arr[j + 1])
                        {
                            double temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }

                    }
                }
            });

        }
        public void SortDesc()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                PercantageChange(this, new ArrayEventArgs(i + 1));
                for (int j = 1; j < arr.Length - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        double temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

                }
            }
        }
        public double Max()
        {
            double max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                PercantageChange(this, new ArrayEventArgs(i + 1));
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            return max;
        }
        public double Min()
        {
            double min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                PercantageChange(this, new ArrayEventArgs(i + 1));
                if (min > arr[i])
                {
                    min = arr[i];
                    
                }
                
            }
            return min;
        }


    }
    public class ArrayEventArgs
    {
        public int Iteration { get; }
        public ArrayEventArgs(int iteration)
        {
            Iteration = iteration;
        }
    }
}
