using ShyamDhokiya_557_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamDhokiya_557_Repository.Repository
{
    public interface IUserRepository
    {
        WalletModel GetTotalWalletAmount(int UserId);

        int AddTranaction(int RandomNumber,int UserId);

        List<TransactionModel> GetAllList(int UserId);

        bool BuyChance(int UserId);
    }
}
