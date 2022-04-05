using DistributeurBoissons.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Model
{
    public class Beverage
    {
        [Key]
        public int IdBeverage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? SaleDate { get; set; }

        public int IdBeverageType { get; set; }
        public virtual BeverageType BeverageType { get; set; }

        public Beverage() { }

        public Beverage(DateTime expirationDate, int idBeverageType )
        {
            ExpirationDate = expirationDate;
            IdBeverageType = idBeverageType;
        }

        public Beverage(DateTime expirationDate, BeverageType beverageType)
        {
            ExpirationDate = expirationDate;
            IdBeverageType = beverageType.IdBeverageType;
        }

        public void CreateBeverage(DatabaseContext context)
        {
            context.dbSetBeverages.Add(this);
            context.SaveChanges();
        }

        public void DeleteBeverage(DatabaseContext context)
        {
            context.dbSetBeverages.Remove(this);
            context.SaveChanges();
        }
        public void ModifyBeverage(DatabaseContext context)
        {
            context.dbSetBeverages.Where(x => x.IdBeverage == IdBeverage).FirstOrDefault().ExpirationDate = ExpirationDate;
            context.dbSetBeverages.Where(x => x.IdBeverage == IdBeverage).FirstOrDefault().SaleDate = SaleDate.HasValue ? SaleDate.Value : null;

            context.SaveChanges();
        }
    }
}
