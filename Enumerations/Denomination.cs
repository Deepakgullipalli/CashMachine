using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachine.Enumerations
{
    public enum Denomination
    {
        Hundred = 100,
        Fifty = 50,
        Twenty = 20,
        Ten = 10,
        Five = 5,
        One = 1
    }

    public enum CashMachineAction
    {
        W,
        I,
        R,
        Q
    }
}
