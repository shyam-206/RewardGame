using ShyamDhokiya_557_Model.DBContext;
using ShyamDhokiya_557_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShyamDhokiya_557_Helper.Helper
{
    public class RegisterHelper
    {
        public static Users ConvertRegsiterModelToUser(RegisterModel registerModel)
        {
            try
            {
                Users user = new Users();
                user.UserId = registerModel.UserId;
                user.Username = registerModel.Username;
                user.Email = registerModel.Email;
                user.Password = registerModel.Password;
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static RegisterModel ConvertUserToRegisterModel(Users user)
        {
            try
            {
                RegisterModel registerModel = new RegisterModel();
               if(user != null)
                {
                    registerModel.UserId = user.UserId;
                    registerModel.Username = user.Username;
                    registerModel.Email = user.Email;
                    registerModel.Password = user.Password;
                }
                return registerModel != null ? registerModel : null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
