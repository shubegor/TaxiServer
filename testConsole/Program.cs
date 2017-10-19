using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerTaxi.Controllers;
using ServerTaxi.Data.Entity;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminController a = new AdminController();
            User u = new User();
            u.Phone = "13513513";
            u.FIO = "f";
            u.Email = "ff";
            u.Auto = "vfd";
            u.AutoNumber = "fv";
            u.Password = "fdffdf";
            u.RoleId = 2;
            a.NewUser(u);
            Console.ReadKey();
        }
    }
}
