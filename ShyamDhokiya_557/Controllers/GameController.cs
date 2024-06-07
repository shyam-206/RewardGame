using Newtonsoft.Json;
using ShyamDhokiya_557.Common;
using ShyamDhokiya_557.CustomFilter;
using ShyamDhokiya_557.Session;
using ShyamDhokiya_557_Model.ViewModel;
using ShyamDhokiya_557_Repository.Repository;
using ShyamDhokiya_557_Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShyamDhokiya_557.Controllers
{
    [CustomAuthenciate]
    public class GameController : Controller
    {
        private readonly IUserRepository repo = new UserService();
        

        public ActionResult WalletPage()
        { 
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ActionResult> TransactionHistoryPage()
        {
            try
            {
                int UserId = SessionHelper.UserId;
                WalletModel walletModel = new WalletModel();
                string res = await WebHelper.HttpRequestResponse($"api/GameAPI/GetTotalWalletAmount?UserId={UserId}");
                walletModel = JsonConvert.DeserializeObject<WalletModel>(res);
                if(walletModel != null && walletModel.WalletId > 0)
                {
                    ViewBag.TotalAmount = walletModel.Balance;
                    ViewBag.ChanceLeft = walletModel.ChanceLeft;
                }

                string res2 = await WebHelper.HttpRequestResponse($"api/GameAPI/GetAllList?UserId={UserId}");
                List<TransactionModel> transactionList = JsonConvert.DeserializeObject<List<TransactionModel>>(res2);
                return View(transactionList);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddAmount(int RandomNumber)
        {
            try
            {
             
                /*int Status = repo.AddTranaction(RandomNumber, SessionHelper.UserId);*/

                string url = $"api/GameAPI/AddTranaction?RandomNumber={RandomNumber}&UserId={SessionHelper.UserId}";
                string res = await WebHelper.HttpRequestResponse(url);
                int Status = JsonConvert.DeserializeObject<int>(res);
                if (Status == -2)
                {
                    return Json(new { status = Status }, JsonRequestBehavior.AllowGet);
                }
                else if (Status == -1)
                {
                    return Json(new { status = Status }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = Status }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<JsonResult> BuyChance()
        {
            try
            {
                /*bool CheckBuyChnance = repo.BuyChance(SessionHelper.UserId);*/
                string url = $"api/GameAPI/BuyChance?UserId={SessionHelper.UserId}";
                string res = await WebHelper.HttpRequestResponse(url);
                bool CheckBuyChnance = JsonConvert.DeserializeObject<bool>(res);
                if (CheckBuyChnance)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}