using DistributeurBoissons.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Class
{
    public class DatabaseContext : DbContext
    {
        static string strExeFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        static string folderPath = Path.Combine(strExeFilePath, "Database");
        static string dbPath = Path.Combine(folderPath, "VendingMachine.sqlite");

        public DatabaseContext() : base(new SQLiteConnection() { ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = dbPath, ForeignKeys = true }.ConnectionString }, true) { }
        public DatabaseContext(DbConnection connection) : base(connection, true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Money> dbSetMoney { get; set; }
        public DbSet<Currency> dbSetCurrencys { get; set; }
        public DbSet<BeverageType> dbSetBeverageTypes { get; set; }
        public DbSet<Beverage> dbSetBeverages { get; set; }
        public DbSet<User> dbSetUsers { get; set; }
        public DbSet<Wallet> dbSetWallets { get; set; }

    }
}
