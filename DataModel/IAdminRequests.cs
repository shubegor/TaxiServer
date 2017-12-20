using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IAdminRequests
    {
        bool EditUserStat(UsersModel UpUser, string phone);
        bool DeleteUserStat(string Uphone, string phone);
        List<UsersModel> AllUserStat(string phone);
        List<OrderModel> OrdersStat(string phone);


    }
}
