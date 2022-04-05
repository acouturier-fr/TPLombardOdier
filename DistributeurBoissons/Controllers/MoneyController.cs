using DistributeurBoissons.Class;
using DistributeurBoissons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Controllers
{
    public enum enumCurrency
    {
        CHF = 1,
        Euro = 2
    }

    public class MoneyController
    {
        public DatabaseContext _dbContext;
        public List<Money> lstMoneys;

        public MoneyController(DatabaseContext context)
        {
            _dbContext = context;
            lstMoneys = _dbContext.dbSetMoney.ToList();
        }

        public Money CreateMoney(decimal value, string image)
        {
            Money money = new Money(value, image);
            money.CreateMoney(_dbContext);
            return money;
        }

        public void DeleteMoney(Money user)
        {
            user.DeleteMoney(_dbContext);
        }

        public void ModifyMoney(Money money, string image, decimal value)
        {
            money.Value = value;
            money.Image = image;
            money.ModifyMoney(_dbContext);
        }

        public List<Money> GetMoneys(int idCurrency)
        {
            return lstMoneys.Where(x => x.IdCurrency == idCurrency).ToList();
        }

        public Money GetMoney(int idMoney)
        {
            return lstMoneys.Where(x => x.IdMoney == idMoney).FirstOrDefault();
        }

    }
}
