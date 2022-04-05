using DistributeurBoissons.Class;
using DistributeurBoissons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Controllers
{
    public class BeverageController
    {
        public DatabaseContext _dbContext;
        public List<Beverage> _lstBeverages;

        public BeverageController(DatabaseContext context)
        {
            _dbContext = context;
            _lstBeverages = _dbContext.dbSetBeverages.ToList();
        }

        public Beverage CreateBeverage(DateTime expirationDate, BeverageType beverageType)
        {
            Beverage beverage = new Beverage(expirationDate, beverageType);
            beverage.CreateBeverage(_dbContext);
            return beverage;
        }

        public Beverage CreateBeverage(DateTime expirationDate, int idBeverageType)
        {
            Beverage beverage = new Beverage(expirationDate, idBeverageType);
            beverage.CreateBeverage(_dbContext);
            return beverage;
        }

        public void CreateBeverages(DateTime expirationDate, int idBeverageType, int amount)
        {
            for(int i = 0; i < amount; i++)
                CreateBeverage(expirationDate, idBeverageType);
        }

        public void DeleteBeverage(Beverage beverage)
        {
            beverage.DeleteBeverage(_dbContext);
        }

        public void DeleteAllBeverage(int idBeverageType)
        {
            Refresh();
            if (_lstBeverages.Any())
            {
                List<Beverage> beverages = _lstBeverages.Where(x => x.BeverageType.IdBeverageType == idBeverageType).ToList();
                foreach (Beverage beverage in beverages)
                    beverage.DeleteBeverage(_dbContext);
            }
        }

        public void ModifyBeverage(Beverage beverage)
        {
            beverage.ModifyBeverage(_dbContext);
        }

        public void SellBeverage(Beverage beverage)
        {
            beverage.SaleDate = DateTime.Now;
            beverage.ModifyBeverage(_dbContext);
        }

        public int GetUnexpiredBeverageAmount(BeverageType beverageType)
        {
            Refresh();
            return _lstBeverages.Where(x => x.BeverageType == beverageType && x.ExpirationDate > DateTime.UtcNow).Count();
        }
        public int GetExpiredBeverageAmount(BeverageType beverageType)
        {
            Refresh();
            return _lstBeverages.Where(x => x.BeverageType == beverageType && x.ExpirationDate < DateTime.UtcNow).Count();
        }

        public void Refresh()
        {
            _lstBeverages.Clear();
            _lstBeverages = _dbContext.dbSetBeverages.ToList();
        }
    }
}
