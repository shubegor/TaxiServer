using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IDriverRequests
    {
        List<OrderModel> AllStat(string phone);
        bool TakeOrderStat(Guid id, string phone);
        bool ConfirmOrderStat(Guid id, string phone);
        List<OrderModel> OrdersStat(string phone);


    }
}
