using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sys_analysis
{
    internal class WithdrawMoreThanBalanceExcpetion:Exception
    {
        public WithdrawMoreThanBalanceExcpetion() : base("The Balance is less than the amount") { }
    }
}
