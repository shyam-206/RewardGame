using ShyamDhokiya_557_Model.ViewModel;
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

        [Route("api/LoginAPI/CheckUserExist")]
        [HttpPost]
        public LoginResponse CheckUserExist(LoginModel loginModel)
        {
            try
            {
                RegisterModel IsLoginUserExist = repo.CheckUserExist(loginModel);
                var jwtToken = Authentication.GenerateJWTAuthetication(IsLoginUserExist.Email, "User");
                LoginResponse loginResponse = new LoginResponse();
                loginResponse.RegisterModel = IsLoginUserExist;
                loginResponse.Token = jwtToken;
                return loginResponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}