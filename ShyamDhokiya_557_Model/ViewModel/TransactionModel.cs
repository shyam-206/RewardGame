using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamDhokiya_557_Model.ViewModel
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }

        public int WalletId { get; set; }

        public int Amount { get; set; }

        public bool IsDebitCredit { get; set; }

        public DateTime Time { get; set; }

        public int TotalAmount { get; set; }

    }
}
