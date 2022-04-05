using DistributeurBoissons.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Model
{
    public class Currency
    {
        private readonly ObservableListSource<Money> _moneys =
               new ObservableListSource<Money>();

        [Key]
        public int IdCurrency { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Money> Moneys { get { return _moneys; } }
    }
}
