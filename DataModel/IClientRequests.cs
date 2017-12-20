using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IClientRequests
    {
        List<OrderClientModel> AllStat(string phone);
        void NewStat(string a1, string a2, int distance, string phone);
        void CancelOrderStat(Guid id);
    }
}
