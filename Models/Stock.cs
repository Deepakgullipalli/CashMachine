using CashMachine.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachine.Models
{
    public class Stock
    {
        public Stock()
        {
            SetPreStock();
        }

        public Dictionary<int,int> CurrentStock { get; set; }

        public void SetPreStock()
        {
            CurrentStock = new Dictionary<int, int>();
            CurrentStock.Add(0,10);
            CurrentStock.Add(1,10);
            CurrentStock.Add(2,10);
            CurrentStock.Add(3,10);
            CurrentStock.Add(4,10);
            CurrentStock.Add(5,10);
        }

        public void Restock()
        {
            SetPreStock();
        }
    }
}
