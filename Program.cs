using CashMachine.Enumerations;
using CashMachine.Models;
using System;

namespace CashMachine
{
    class Program
    {
        private static Stock currentStock;
        static void Main(string[] args)
        {
            bool quitNow = false;
            while (!quitNow)
            {
                Console.Write("Please type your action that you wish to perform.\n");
                string input = Console.ReadLine();
                var action = input[0];

                if (action.ToString() == CashMachineAction.W.ToString())
                {
                    Console.Write($"Performing withdrawal of {input.Substring(2)}.\n");
                    var amount = int.Parse(input.Substring(3));
                    ProcessingWithdrawAction(amount);
                }
                else if (action.ToString() == CashMachineAction.I.ToString())
                {
                    var info = input.Substring(3);
                    ProcessingInfoAction(info);
                }
                else if (action.ToString() == CashMachineAction.R.ToString())
                {
                    ProcessingRestockAction();
                }
                else if (action.ToString() == CashMachineAction.Q.ToString())
                {
                    quitNow = true;
                }
                else
                {
                    Console.Write($"Failure: Invalid Command"); 
                }
            }
            
        }

        public static void ProcessingWithdrawAction(int withdrawalAmount)
        {
            Stock stock = new Stock();
            if (currentStock == null)
                currentStock = stock;
            var amountToDispense = withdrawalAmount;
            int[] notes = new int[] { 100, 50, 20, 10, 5, 1 };
            int[] noteCounter = new int[6];
            for (int i = 0; i < 6; i++)
            {
                if (withdrawalAmount >= notes[i])
                {
                    var reqNotes = withdrawalAmount / notes[i];
                    if (currentStock.CurrentStock[i] != 0 && currentStock.CurrentStock[i] > reqNotes)
                    {
                        noteCounter[i] = reqNotes;
                        currentStock.CurrentStock[i] = currentStock.CurrentStock[i] - reqNotes;
                    }
                    else if (currentStock.CurrentStock[i] != 0 && currentStock.CurrentStock[i] < reqNotes)
                    {
                        noteCounter[i] = currentStock.CurrentStock[i];
                        currentStock.CurrentStock[i] = 0;
                    }
                    withdrawalAmount = withdrawalAmount - noteCounter[i] * notes[i];
                }
            }

            if (withdrawalAmount > 0)
            {
                Console.WriteLine("Failure: insufficient funds.\n");
            }
            else
            {
                Console.WriteLine($"Success : Dispensed {amountToDispense}\n");
                Console.WriteLine("Machine balance :\n");
                for (int i = 0; i < currentStock.CurrentStock.Count; i++)
                {
                    Console.WriteLine("$" + notes[i] + " - "
                               + currentStock.CurrentStock[i]);
                }
            }

        }
        public static void ProcessingInfoAction(string info)
        {
            int[] notes = new int[] { 100, 50, 20, 10, 5, 1 };
            if (currentStock == null)
                currentStock = new Stock();
            var denomArray = info.Split('$');
            foreach (var item in denomArray)
            {
                var index = Array.IndexOf(notes,int.Parse(item.Trim()));
                Console.WriteLine("$" + item.Trim() + " - " + currentStock.CurrentStock[index]);
            }
        }
        public static void ProcessingRestockAction()
        {
            if(currentStock == null)
            {
                currentStock = new Stock();
            }
            else
            {
                currentStock.Restock();
            }
        }
        public static void ProcessingQuitAction()
        {
            Console.WriteLine("Qutting the application");
        }
    }
}
