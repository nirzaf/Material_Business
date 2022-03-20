using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class UserBusiness:BLLBase
    {
        public List<tbl_User> GetTrainers()
        {
            try
            {
                UserDb UD = new UserDb();
                List<tbl_User> Ls = UD.GetTrainers();
                return Ls;
            }
            catch
            {
                throw;
            }
        }
        public bool CreateUserRequest(tbl_User U, int WorkShopId)
        {
            UserDb UD = new UserDb();
            UD.CreateUserRequest(U, WorkShopId);
            return true;
        }


        public bool ValidateUser(tbl_User U)
        {
            UserDb UD = new UserDb();
            return UD.ValidateUser(U);
        }

        public bool CreateTrainer(tbl_User U)
        {
            UserDb UD = new UserDb();
            return UD.CreateTrainer(U);
        }

        public List<tbl_User> GetStudents()
        {
            try
            {
                UserDb UD = new UserDb();
                List<tbl_User> Ls = UD.GetStudents();
                return Ls;
            }
            catch
            {
                throw;
            }
        }
    }
}
