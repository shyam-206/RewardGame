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
    public class LoginAPIController : ApiController
    {
        private readonly ILoginRepository repo = new LoginService();

        [Route("api/LoginAPI/AddRegister")]
        [HttpPost]
        public bool AddRegister(RegisterModel registerModel)
        {
            try
            {
                bool CheckSaveOrNot = repo.AddRegister(registerModel);
                return CheckSaveOrNot;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("api/LoginAPI/ChechUserExist")]
        [HttpPost]
        public RegisterModel ChechUserExist(LoginModel loginModel)
        {
            try
            {
                RegisterModel IsLoginUserExist = repo.CheckUserExist(loginModel);
                return IsLoginUserExist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}