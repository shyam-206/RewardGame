using ShyamDhokiya_557_Model.ViewModel;
using ShyamDhokiya_557_Repository.Repository;
using ShyamDhokiya_557_Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShyamDhokiya_557API.Controllers
{
    public class GameAPIController : ApiController
    {
        private readonly IUserRepository repo = new UserService();

        [Route("api/GameAPI/GetTotalWalletAmount")]
        [HttpGet]
        public WalletModel GetTotalWalletAmount(int UserId)
        {
            try
            {
                WalletModel walletModel = repo.GetTotalWalletAmount(UserId);
                return walletModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("api/GameAPI/AddTranaction")]
        [HttpGet]
        public int AddTranaction(int RandomNumber,int UserId)
        {
            try
            {
                int SaveAmount = repo.AddTranaction(RandomNumber, UserId);
                return SaveAmount;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("api/GameAPI/BuyChance")]
        [HttpGet]
        public bool BuyChance(int UserId)
        {
            try
            {
                bool CheckBuyChnance = repo.BuyChance(UserId);
                return CheckBuyChnance;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("api/GameAPI/GetAllList")]
        [HttpGet]
        public List<TransactionModel> GetAllList(int UserId)
        {
            try
            {
                List<TransactionModel> transactionModelList = repo.GetAllList(UserId);
                return transactionModelList != null ? transactionModelList : null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}