using DistributeurBoissons.Class;
using DistributeurBoissons.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Controllers
{
    public class BeverageTypeController
    {
        private DatabaseContext _dbContext;
        private List<BeverageType> _lstBeverageTypes;

        public BeverageTypeController(DatabaseContext context)
        {
            _dbContext = context;
            _lstBeverageTypes = _dbContext.dbSetBeverageTypes.ToList();
        }

        public BeverageType CreateBeverageType(decimal price, string name)
        {
            BeverageType beverageType = new BeverageType(name, price);
            beverageType.CreateBeverageType(_dbContext);
            return beverageType;
        }

        public void DeleteBeverageType(BeverageType beverageType)
        {
            beverageType.DeleteBeverageType(_dbContext);
        }

        public void ModifyBeverageType(BeverageType beverageType, decimal price, string name)
        {
            beverageType.Name = name;
            beverageType.Price = price;
            beverageType.ModifyBeverageType(_dbContext);
        }

        public BeverageType GetBeverageType(int idBeverageType)
        {
            Refresh();
            return _lstBeverageTypes.Where(x => x.IdBeverageType == idBeverageType).FirstOrDefault();
        }

        public List<BeverageType> GetAllBeverageTypes()
        {
            Refresh();
            return _lstBeverageTypes;
        }

        public void Refresh()
        {
            _lstBeverageTypes.Clear();
            _lstBeverageTypes = _dbContext.dbSetBeverageTypes.ToList();
        }

    }
}
