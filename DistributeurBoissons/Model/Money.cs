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
    public class Money
    {
        [Key]
        public int IdMoney { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }
        public int IdCurrency { get; set; }
        public virtual Currency Currency { get; set; }

        public string strValue { get { return Value.ToString("0.00") + Currency.Name; } }

        public Money() { }


        public Money(decimal value, string image)
        {
            Value = value;
            Image = image;
        }

        public void CreateMoney(DatabaseContext context)
        {
            context.dbSetMoney.Add(this);
            context.SaveChanges();
        }

        public void DeleteMoney(DatabaseContext context)
        {
            context.dbSetMoney.Remove(this);
            context.SaveChanges();
        }
        public void ModifyMoney(DatabaseContext context)
        {
            context.dbSetMoney.Where(x => x.IdMoney == this.IdMoney).FirstOrDefault().Value = Value;
            context.dbSetMoney.Where(x => x.IdMoney == this.IdMoney).FirstOrDefault().Image = Image;

            context.SaveChanges();
        }
    }
}
