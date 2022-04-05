using DistributeurBoissons.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Model
{
    public class Wallet
    {
        [Key, Column(Order = 0), ForeignKey("User")]
        public int IdUser  { get; set; }
        [Key, Column(Order = 1), ForeignKey("Money")]
        public int IdMoney { get; set; }
        public int Number { get; set; }
        public virtual User User { get; set; }
        public virtual Money Money { get; set; }

        public Wallet() { }
        public Wallet(User user, Money money, int number = 0)
        {
            IdUser = user.IdUser;
            IdMoney = money.IdMoney;
            Number = number;
            User = user;
            Money = money;
        }

        public void CreateWallet(DatabaseContext context)
        {
            context.dbSetWallets.Add(this);
            context.SaveChanges();
        }

        public void DeleteWallet(DatabaseContext context)
        {
            context.dbSetWallets.Remove(this);
            context.SaveChanges();
        }
        public void ModifyWallet(DatabaseContext context)
        {
            context.dbSetWallets.Where(x => x.IdUser == IdUser && x.IdMoney == IdMoney).FirstOrDefault().Number = Number;
            context.SaveChanges();
        }

    }
}
