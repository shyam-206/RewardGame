using Newtonsoft.Json;
using ShyamDhokiya_557.Common;
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
    public class LoginController : Controller
    {
        
        public ActionResult Login()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                
                string res = await WebHelper.HttpPostRequestResponse("api/LoginAPI/ChechUserExist", JsonConvert.SerializeObject(loginModel));
                RegisterModel UserExist = JsonConvert.DeserializeObject<RegisterModel>(res);
                if (UserExist != null && UserExist.UserId > 0)
                {
                    SessionHelper.UserId = UserExist.UserId;
                    SessionHelper.Username = UserExist.Username;
                    SessionHelper.Useremail = UserExist.Email;
                    TempData["Login"] = "User Login Successfully";
                    return RedirectToAction("TransactionHistoryPage", "Game");
                }
                else
                {
                    TempData["UserExist"] = "Useremail or password are not match";
                    return View(loginModel);
                }
            }
            else {
                TempData["LoginField"] = "Please Enter all Fields Required";
                return View(loginModel);
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   if(registerModel.Password == registerModel.ConfirmPassword)
                    {
                        
                        string res = await WebHelper.HttpPostRequestResponse("api/LoginAPI/AddRegister", JsonConvert.SerializeObject(registerModel));
                        bool CheckAddUser = JsonConvert.DeserializeObject<bool>(res);
                        if (CheckAddUser)
                        {
                            TempData["register"] = "User Register Successfully";
                            return RedirectToAction("Login");
                        }
                        else{
                            TempData["email"] = "Email is already Exist";
                            ModelState.AddModelError("email", "email already exist");
                            return View(registerModel);
                        }
                    }
                    else
                    {
                        TempData["notSamePasssword"] = "Password must be Same";
                        ModelState.AddModelError("ConfirmPassword", "Confimr Password not be same");
                        return View(registerModel);
                    }
                }
                else
                {
                    TempData["Soemthing"] = "Please Enter All Fields Required";
                    return View(registerModel);
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            TempData["Logout"] = "SuccessFully Logout";
            return RedirectToAction("Login");
        }
    }
}