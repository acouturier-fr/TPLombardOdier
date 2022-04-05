using DistributeurBoissons.Class;
using DistributeurBoissons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Controllers
{
    public interface IMainView
    {
        public DatabaseContext _context { get; }

        UserController _userController { get; set; }
        MoneyController _moneyController { get; set; }
        WalletController _walletController { get; set; }
        BeverageController _beverageController { get; set; }
        BeverageTypeController _beverageTypeController { get; set; }
        User User { get; set; }
        User Machine { get; set; }

    }
}
