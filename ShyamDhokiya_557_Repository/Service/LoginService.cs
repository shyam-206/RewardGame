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
    public class LoginService : ILoginRepository
    {
        private readonly RewardGame_557Entities _context = new RewardGame_557Entities();

        public bool AddRegister(RegisterModel registerModel)
        {
            try
            {
                Users user = new Users();
                int CheckUserSave = 0;
                if(!_context.Users.Any(m => m.Email == registerModel.Email))
                {
                    user = RegisterHelper.ConvertRegsiterModelToUser(registerModel);
                    Users user1 = _context.Users.Add(user);
                    CheckUserSave = _context.SaveChanges();

                    Wallet wallet = new Wallet
                    {
                        UserId = user1.UserId,
                        Balance = 100,
                        ChanceLeft = 3
                    };
                    _context.Wallet.Add(wallet);
                    CheckUserSave = _context.SaveChanges();

                    Transactions transaction = new Transactions
                    {
                        WalletId = user1.UserId,
                        Amount = 100,
                        TotalAmount = 100,
                        IsDebitCredit = true,
                        Time = DateTime.Now
                    };

                    _context.Transactions.Add(transaction);
                    CheckUserSave = _context.SaveChanges();
                }

                return CheckUserSave > 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public RegisterModel CheckUserExist(LoginModel loginModel)
        {
            try
            {
                Users loginUser = _context.Users.Where(m => m.Email == loginModel.Email && m.Password == loginModel.Password).FirstOrDefault();
                RegisterModel RegisterModel = new RegisterModel();

                if(loginUser != null)
                {
                    RegisterModel = RegisterHelper.ConvertUserToRegisterModel(loginUser);
                }
                return RegisterModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
