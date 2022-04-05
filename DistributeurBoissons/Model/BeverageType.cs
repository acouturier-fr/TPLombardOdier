using DistributeurBoissons.Class;
using DistributeurBoissons.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Model
{
    public class BeverageType
    {
        private readonly ObservableListSource<Beverage> _beverages =
                new ObservableListSource<Beverage>();

        [Key]
        public int IdBeverageType { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string PriceName { get { return Name + " - " + Price.ToString("0.00") + enumCurrency.CHF.ToString(); } }


        public virtual ObservableListSource<Beverage> Beverages { get { return _beverages; } }

        public BeverageType() { }

        public BeverageType(string name, decimal price)
        {
            Price = price;
            Name = name;
        }

        public void CreateBeverageType(DatabaseContext context)
        {
            context.dbSetBeverageTypes.Add(this);
            context.SaveChanges();
        }

        public void DeleteBeverageType(DatabaseContext context)
        {
            context.dbSetBeverageTypes.Remove(this);
            context.SaveChanges();
        }

        public void ModifyBeverageType(DatabaseContext context)
        {
            context.dbSetBeverageTypes.Where(x => x.IdBeverageType == IdBeverageType).FirstOrDefault().Price = Price;
            context.dbSetBeverageTypes.Where(x => x.IdBeverageType == IdBeverageType).FirstOrDefault().Name = Name;

            context.SaveChanges();
        }
    }
}
