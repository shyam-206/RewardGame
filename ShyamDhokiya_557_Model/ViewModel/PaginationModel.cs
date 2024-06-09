using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamDhokiya_557_Model.ViewModel
{
    public class PaginationModel
    {
        public List<TransactionModel> TransactionModelList { get; set; }
        public int CurrentIndex { get; set; }
        public int TotalPage { get; set; }
    }
}
