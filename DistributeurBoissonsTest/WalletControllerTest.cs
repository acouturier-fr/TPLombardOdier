using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistributeurBoissons.Controllers;
using DistributeurBoissons.Model;
using DistributeurBoissons.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using Effort.Provider;

namespace DistributeurBoissonsTest
{
    [TestClass]
    public class WalletControllerTest
    {
        public DatabaseContext _context { get; set; }
        EffortConnection connection = Effort.DbConnectionFactory.CreateTransient();

        Currency currency { get; set; }
        List<BeverageType> beverageTypes { get; set; }
        List<Beverage> beverages { get; set; }
        List<User> users { get; set; }
        List<Money> moneys { get; set; }
        List<Wallet> userWallets { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _context = new DatabaseContext(connection);
            beverageTypes = CreateBeverageTypesTest();
            beverages = CreateBeveragesTest(beverageTypes);
            users = CreateUserTest();
            currency = CreateCurrencyTest();
            moneys = CreateMoneysTest(currency);
            userWallets = CreateWalletTest(users, moneys);
        }

        [TestMethod]
        public void IncreaseWalletTest()
        {
            WalletController walletControllerTest = new WalletController(_context);

            Random random = new Random();
            int index = random.Next(0, userWallets.Count);
            int valueWallet = userWallets[index].Number;

            walletControllerTest.IncreaseWallet(userWallets[index]);
            int valueWalletExpected = valueWallet + 1;

            Assert.AreEqual(valueWalletExpected, userWallets[index].Number);
        }

        [TestMethod]
        public void DecreaseWalletTest()
        {
            WalletController walletControllerTest = new WalletController(_context);

            Random random = new Random();
            int index = random.Next(0, userWallets.Count);
            int valueWallet = userWallets[index].Number;

            walletControllerTest.DecreaseWallet(userWallets[index]);
            int valueWalletExpected = valueWallet - 1;

            Assert.AreEqual(valueWalletExpected, userWallets[index].Number);
        }

        [TestMethod]
        public void FundWalletTest()
        {
            WalletController walletControllerTest = new WalletController(_context);

            Random random = new Random();
            int index = random.Next(0, users.Count);
            User user = users[index];

            List<KeyValuePair<Money,int>> lstkvp = new List<KeyValuePair<Money,int>>();
            KeyValuePair<Money,int> pair = new  KeyValuePair<Money, int>(moneys[random.Next(0,moneys.Count)],random.Next(1,11));
            lstkvp.Add(pair);
            pair = new KeyValuePair<Money, int>(moneys[random.Next(0, moneys.Count)], random.Next(1, 11));
            lstkvp.Add(pair);

            List<Wallet> walletsToCheck = new List<Wallet>();
            foreach (KeyValuePair<Money, int> kvp in lstkvp)
            {
                Wallet buffer = userWallets.Where(x => x.IdUser == user.IdUser && x.IdMoney == kvp.Key.IdMoney).FirstOrDefault();
                Wallet wallettocheck = new Wallet(user,buffer.Money,buffer.Number);
                walletsToCheck.Add(wallettocheck);
            }

            walletControllerTest.FundWallets(user, lstkvp);

            foreach(Wallet wallet in walletsToCheck)
            {
                int valueWalletExpected = wallet.Number + lstkvp.FirstOrDefault(x => x.Key.IdMoney == wallet.IdMoney).Value;
                Assert.AreEqual(valueWalletExpected, userWallets.FirstOrDefault(x => x.IdMoney == wallet.IdMoney && x.IdUser == user.IdUser).Number);
            }
        }

        public List<User> CreateUserTest()
        {

            _context.dbSetUsers.Add(new User { Name = "TestMachine", IsAdmin = true });
            _context.dbSetUsers.Add(new User { Name = "TestUser", IsAdmin = false });

            _context.SaveChanges();

            return _context.dbSetUsers.ToList();
        }
        public Currency CreateCurrencyTest()
        {
            _context.dbSetCurrencys.Add(new Currency { Name = "CHF" });
            _context.SaveChanges();

            return _context.dbSetCurrencys.ToList().FirstOrDefault();
        }

        public List<Money> CreateMoneysTest(Currency currency)
        {
            _context.dbSetMoney.Add(new Money { IdCurrency = currency.IdCurrency, Value = decimal.Parse("0,05") });
            _context.dbSetMoney.Add(new Money { IdCurrency = currency.IdCurrency, Value = decimal.Parse("0,1") });
            _context.dbSetMoney.Add(new Money { IdCurrency = currency.IdCurrency, Value = decimal.Parse("0,2") });
            _context.dbSetMoney.Add(new Money { IdCurrency = currency.IdCurrency, Value = decimal.Parse("0,5") });
            _context.dbSetMoney.Add(new Money { IdCurrency = currency.IdCurrency, Value = decimal.Parse("1") });
            _context.dbSetMoney.Add(new Money { IdCurrency = currency.IdCurrency, Value = decimal.Parse("2") });
            _context.dbSetMoney.Add(new Money { IdCurrency = currency.IdCurrency, Value = decimal.Parse("5") });

            _context.SaveChanges();

            return _context.dbSetMoney.ToList();
        }

        public List<Wallet> CreateWalletTest(List<User> users, List<Money> moneys)
        {
            foreach (Money money in moneys)
                foreach (User user in users)
                    _context.dbSetWallets.Add(new Wallet { IdUser = user.IdUser, IdMoney = money.IdMoney, Number = 0 });

            _context.SaveChanges();
            return _context.dbSetWallets.ToList();
        }
        public List<BeverageType> CreateBeverageTypesTest()
        {
            _context.dbSetBeverageTypes.Add(new BeverageType { Name = "Cola", Price = decimal.Parse("1,25") });
            _context.dbSetBeverageTypes.Add(new BeverageType { Name = "Water", Price = decimal.Parse("1,50") });
            _context.dbSetBeverageTypes.Add(new BeverageType { Name = "Blue Drink", Price = decimal.Parse("1,50") });
            _context.dbSetBeverageTypes.Add(new BeverageType { Name = "Orange Drink", Price = decimal.Parse("1,30") });
            _context.dbSetBeverageTypes.Add(new BeverageType { Name = "Coffee", Price = decimal.Parse("1,95") });

            _context.SaveChanges();

            return _context.dbSetBeverageTypes.ToList();
        }
        public List<Beverage> CreateBeveragesTest(List<BeverageType> beverageTypes)
        {
            foreach (BeverageType type in beverageTypes)
                _context.dbSetBeverages.Add(new Beverage { IdBeverageType = type.IdBeverageType, ExpirationDate = DateTime.UtcNow });

            _context.SaveChanges();
            return _context.dbSetBeverages.ToList();
        }

    }
}