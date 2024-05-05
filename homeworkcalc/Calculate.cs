using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkcalc
{
    public interface ICalc
    {
        public double result { get; set; }
        public void Sum(int x);
        public void Sub(int x);
        public void Multy(int x);
        public void Divide(int x);
        public void CancelLast();
        event EventHandler<EventArgs> MyEventHandler;
    }
    public class Calculate : ICalc
    {
        public double result { get; set; }
        private Stack<double> lastResult = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;

        public void Divide(int x)
        {
            lastResult.Push(result);
            result /= x;
            MakeOperation();
        }

        public void Multy(int x)
        {
            lastResult.Push(result);
            result *= x;
            MakeOperation();
        }

        public void Sub(int x)
        {
            lastResult.Push(result);
            result -= x;
            MakeOperation();
        }

        public void Sum(int x)
        {
            lastResult.Push(result);
            result += x;
            MakeOperation();
        }
        public void MakeOperation()
        {
            PrintResult();
        }
        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }
        public void CancelLast()
        {
            if (lastResult.TryPop(out double res))
            {
                result = res;
                PrintResult();
            }
        }
    }
}
