using ShyamDhokiya_557_Model.DBContext;
using ShyamDhokiya_557_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamDhokiya_557_Helper.Helper
{
    public class TransactionHelper
    {
        public static List<TransactionModel> ConvertTransactionToTransactionModel(List<Transactions> Transactionlist)
        {
            try
            {
                List<TransactionModel> transactionModelList = new List<TransactionModel>();
                if(Transactionlist != null)
                {
                    foreach(var item in Transactionlist)
                    {
                        TransactionModel transactionModel = new TransactionModel();
                        transactionModel.TransactionId = item.TransactionId;
                        transactionModel.WalletId = (int)item.WalletId;
                        transactionModel.Amount = (int)item.Amount;
                        transactionModel.TotalAmount = (int)item.TotalAmount;
                        transactionModel.IsDebitCredit = (bool)item.IsDebitCredit;
                        transactionModel.Time = item.Time;
                        transactionModelList.Add(transactionModel);
                    }
                }
                return transactionModelList != null ? transactionModelList : null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
