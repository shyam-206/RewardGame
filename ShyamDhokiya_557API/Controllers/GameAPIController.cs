﻿using ShyamDhokiya_557_Model.ViewModel;
using ShyamDhokiya_557_Repository.Repository;
using ShyamDhokiya_557_Repository.Service;
using ShyamDhokiya_557API.JWTAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShyamDhokiya_557API.Controllers
{
    [JwtAuthentication]
    public class GameAPIController : ApiController
    {
        private readonly IUserRepository repo = new UserService();


        [Route("api/GameAPI/GetWalletModelById")]
        [HttpGet]
        public WalletModel GetWalletModelById(int UserId)
        {
            try
            {
                WalletModel walletModel = repo.GetWalletModelById(UserId);
                return walletModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/GameAPI/AddTranaction")]
        [HttpGet]
        public int AddTranaction(int RandomNumber, int UserId)
        {
            try
            {
                int SaveAmount = repo.AddTranaction(RandomNumber, UserId);
                return SaveAmount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/GameAPI/BuyChance")]
        [HttpGet]
        public int BuyChance(int UserId)
        {
            try
            {
                int CheckBuyChnance = repo.BuyChance(UserId);
                return CheckBuyChnance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [Route("api/GameAPI/GetAllTransactionList")]
        [HttpGet]
        public List<TransactionModel> GetAllTransactionList(int UserId)
        {
            try
            {
               /* bool isTokenValid = (bool)Request.Properties["IsTokenValid"];
                if (!isTokenValid)
                {
                    return null;
                }*/
                List<TransactionModel> transactionModelList = repo.GetAllTransactionList(UserId);
                return transactionModelList != null ? transactionModelList : null;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}