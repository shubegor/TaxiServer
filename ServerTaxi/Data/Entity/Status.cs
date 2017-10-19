using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTaxi.Data.Entity
{
    public class Status
    {
        public static string Active { get; } = "Активный";
        public static string InProgress { get; } = "Выполняется";
        public static string Done { get; } = "Выполнен";
        public static string Canceled { get; } = "Отменен";
    }
}