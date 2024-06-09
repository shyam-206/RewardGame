using ShyamDhokiya_557_Helper.Helper;
using ShyamDhokiya_557_Model.DBContext;
using ShyamDhokiya_557_Model.ViewModel;
using ShyamDhokiya_557_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamDhokiya_557_Repository.Service
{
    public class UserService : IUserRepository
    {
        private readonly RewardGame_557Entities _context = new RewardGame_557Entities();

        public int AddTranaction(int RandomNumber, int UserId)
        {
            try
            {
                int SaveAmountOrNot = 0;
                int TodayTotalTransactionAmount = GetTodayTotalTransactionAmount(UserId);
                Wallet wallet = _context.Wallet.FirstOrDefault(m => m.UserId == UserId);
                if (wallet.ChanceLeft <= 0)
                {
                    SaveAmountOrNot = -2; // not chance left
                    return SaveAmountOrNot;
                }
                else if (TodayTotalTransactionAmount + RandomNumber > 500)
                {
                    SaveAmountOrNot = -1;
                    wallet.ChanceLeft = wallet.ChanceLeft - 1;
                    _context.SaveChanges();
                    return SaveAmountOrNot;
                }
                else
                {
                    wallet.Balance = wallet.Balance + RandomNumber;
                    wallet.ChanceLeft = wallet.ChanceLeft - 1;
                    _context.SaveChanges();

                    Transactions transaction = new Transactions
                    {
                        WalletId = UserId,
                        Amount = RandomNumber,
                        IsDebitCredit = true,
                        TotalAmount = wallet.Balance,
                        Time = DateTime.Now
                    };

                    _context.Transactions.Add(transaction);
                    _context.SaveChanges();
                    SaveAmountOrNot = 1;
                }


                return SaveAmountOrNot;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int BuyChance(int UserId)
        {
            try
            {
                int BuyChance = 0;
                Wallet wallet = _context.Wallet.FirstOrDefault(m => m.UserId == UserId);

                if (wallet.Balance < 20 && wallet.Balance >= 0)
                {
                    BuyChance = -1; //insufficient balance
                    return BuyChance;
                }
                if (wallet != null && wallet.WalletId > 0 && wallet.Balance > 0 && wallet.ChanceLeft == 0)
                {
                    wallet.Balance = wallet.Balance - 20;
                    wallet.ChanceLeft = wallet.ChanceLeft + 1;
                    _context.SaveChanges();

                    Transactions transactions = new Transactions
                    {
                        WalletId = UserId,
                        Amount = 20,
                        IsDebitCredit = false,
                        TotalAmount = wallet.Balance,
                        Time = DateTime.Now
                    };
                    _context.Transactions.Add(transactions);
                    _context.SaveChanges();
                    BuyChance = 1;
                }
                return BuyChance;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TransactionModel> GetAllTransactionList(int UserId)
        {
            try
            {
                List<TransactionModel> list = new List<TransactionModel>();
                List<Transactions> transactions = _context.Transactions.Where(m => m.Wallet.UserId == UserId).OrderByDescending(m => m.TransactionId).ToList();
                if (transactions != null)
                {
                    list = TransactionHelper.ConvertTransactionToTransactionModel(transactions);
                }
                return list != null ? list : null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public WalletModel GetWalletModelById(int UserId)
        {
            try
            {
                Wallet wallet = new Wallet();
                wallet = _context.Wallet.Where(m => m.UserId == UserId).FirstOrDefault();
                WalletModel walletModel = new WalletModel();
                if (wallet != null)
                {
                    walletModel.WalletId = wallet.WalletId;
                    walletModel.UserId = (int)wallet.UserId;
                    walletModel.WalletAmount = (int)wallet.Balance;
                    walletModel.TotalEarning = GetTotalEarningAmount(UserId);
                    walletModel.TodayEarning = GetTodayTotalTransactionAmount(UserId);
                    walletModel.ChanceLeft = (int)wallet.ChanceLeft;
                }


                return walletModel != null ? walletModel : null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetTodayTotalTransactionAmount(int UserId)
        {
            try
            {
                var today = DateTime.Now;
                int TodayTotalTransactionAmount = 0;
                List<Transactions> list = _context.Transactions.Where(m => m.WalletId == UserId && m.Time.Day == today.Day && m.Time.Month == today.Month && m.Time.Year == today.Year && m.IsDebitCredit == true).ToList();
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        TodayTotalTransactionAmount = (int)(TodayTotalTransactionAmount + item.Amount);
                    }
                }
                return TodayTotalTransactionAmount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetTotalEarningAmount(int UserId)
        {
            try
            {
                int TotalEarningAmount = 0;
                List<Transactions> transactions = _context.Transactions.Where(m => m.WalletId == UserId && m.IsDebitCredit == true).ToList();
                if (transactions != null)
                {
                    foreach (var transaction in transactions)
                    {
                        TotalEarningAmount += (int)transaction.Amount;
                    }
                }
                return TotalEarningAmount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
