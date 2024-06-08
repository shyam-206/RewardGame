using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamDhokiya_557_Model.ViewModel
{
    public class WalletModel
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public int WalletAmount { get; set; }
        public int TotalEarning { get; set; }
        public int TodayEarning { get; set; }
        public int ChanceLeft { get; set; }
        public List<TransactionModel> List { get; set; }

    }
}
