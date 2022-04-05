using DistributeurBoissons;
using DistributeurBoissons.Class;
using DistributeurBoissons.Controllers;
using DistributeurBoissons.Model;
using Effort.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissonsTest
{
    [TestClass]
    public class VendingMachineControllerTest
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

            WalletController walletController = new WalletController(_context);
            BeverageController beverageController = new BeverageController(_context);

            User machine = users.FirstOrDefault(x => x.IsAdmin);
            User user = users.FirstOrDefault(x => !x.IsAdmin);
            foreach (Wallet wallet in userWallets)
            {
                wallet.Number = 10;
                wallet.ModifyWallet(_context);
            }
            beverageController.CreateBeverage(DateTime.Now, beverageTypes.FirstOrDefault(x => x.Name == "Cola"));
        }

        [TestMethod]
        public void InsertMoneyTest()
        {
            VendingMachineForm form = new VendingMachineForm();
            VendingMachineController VendingMachine = new VendingMachineController(form, _context);
            form._walletController = new WalletController(_context);
            User machine = users.FirstOrDefault(x => x.IsAdmin);
            form.Machine = machine;

            User user = users.FirstOrDefault(x => !x.IsAdmin);
            Random random = new Random();
            int index = random.Next(0, moneys.Count);
            Wallet userWallet = userWallets.FirstOrDefault(x => x.IdUser == user.IdUser && x.IdMoney == moneys[index].IdMoney);
            Wallet machineWallet = userWallets.FirstOrDefault(x => x.IdUser == machine.IdUser && x.IdMoney == moneys[index].IdMoney);

            Wallet userWalletToAssert = new Wallet(userWallet.User, userWallet.Money, userWallet.Number);
            Wallet machineWalletToAssert = new Wallet(machineWallet.User, machineWallet.Money, machineWallet.Number);

            VendingMachine.InsertMoney(userWallet);

            Assert.AreEqual(machineWallet.Number, userWalletToAssert.Number + machineWalletToAssert.Number);
        }

        [TestMethod]
        public void BuyBeverageFromViewTest()
        {
            //Random random = new Random();

            //VendingMachineForm form = new VendingMachineForm();
            //WalletController walletController = new WalletController(_context);

            //form._walletController = walletController;
            //form._beverageController = new BeverageController(_context);
            //form._userController = new UserController(_context);
            //form._beverageTypeController = new BeverageTypeController(_context);

            //User machine = users.FirstOrDefault(x => x.IsAdmin);
            //form.Machine = machine;

            //User user = users.FirstOrDefault(x => !x.IsAdmin);
            //int index = random.Next(0, beverageTypes.Count);
            //BeverageType beverageTypeSelected = beverageTypes[index];

            //decimal sumToAssertUser = 0;
            //decimal sumToAssertMachine = 0;
            //decimal sumToAssertUser2 = 0;
            //decimal sumToAssertMachine2 = 0;

            //List<Wallet> wallets = new List<Wallet>();
            //for (int i = 0; i < random.Next(moneys.Count); i++)
            //{
            //    Wallet buffer = new Wallet(user, moneys[random.Next(1,moneys.Count)], random.Next(0, 4));
            //    wallets.Add(buffer);
            //    walletController.GiveWallet(buffer, machine);
            //    sumToAssertUser += buffer.Number * buffer.Money.Value;
            //}

            //List<Wallet> walletMachine = userWallets.Where(x => x.User.IsAdmin).ToList();
            //List<Wallet> walletUser = userWallets.Where(x => x.User == user).ToList();

            //foreach (Wallet buffer2 in walletMachine)
            //    sumToAssertMachine += buffer2.Number * buffer2.Money.Value;

            //VendingMachineController VendingMachine = new VendingMachineController(form, _context, wallets);
            //VendingMachine.BuyBeverageFromView(user.IdUser, beverageTypeSelected.IdBeverageType);

            //if (sumToAssertUser > beverageTypeSelected.Price)
            //{
            //    sumToAssertMachine += beverageTypeSelected.Price;
            //    sumToAssertUser -= beverageTypeSelected.Price;
            //}


            //foreach (Wallet buffer3 in walletMachine)
            //    sumToAssertMachine2 += buffer3.Number * buffer3.Money.Value;
            //foreach (Wallet buffer4 in walletUser)
            //    sumToAssertUser2 += buffer4.Number * buffer4.Money.Value;

            //Assert.AreEqual(sumToAssertMachine, sumToAssertMachine2);
            //Assert.AreEqual(sumToAssertUser, sumToAssertUser2);

        }

        [TestMethod]
        public void GivebackTest()
        {
            Random random = new Random();

            VendingMachineForm form = new VendingMachineForm();
            WalletController walletController = new WalletController(_context);

            form._walletController = walletController;

            User machine = users.FirstOrDefault(x => x.IsAdmin);
            User user = users.FirstOrDefault(x => !x.IsAdmin);
            form.Machine = machine;

            List<Wallet> wallets = new List<Wallet>();
            bool entirelyRefunded = false;
            decimal torendre = decimal.Parse("1,25");

            VendingMachineController VendingMachine = new VendingMachineController(form, _context, wallets);
            torendre = VendingMachine.CalculateDifference(torendre, ref wallets, ref entirelyRefunded, user);


            Assert.AreEqual(0, torendre);
        }

        [TestMethod]
        public void GivebackTestFail()
        {
            Random random = new Random();

            VendingMachineForm form = new VendingMachineForm();
            WalletController walletController = new WalletController(_context);

            form._walletController = walletController;

            User machine = users.FirstOrDefault(x => x.IsAdmin);
            User user = users.FirstOrDefault(x => !x.IsAdmin);
            form.Machine = machine;

            List<Wallet> wallets = new List<Wallet>();
            bool entirelyRefunded = false;
            decimal torendre = decimal.Parse("200");

            VendingMachineController VendingMachine = new VendingMachineController(form, _context, wallets);
            torendre = VendingMachine.CalculateDifference(torendre, ref wallets, ref entirelyRefunded, user);


            Assert.AreNotEqual(0, torendre);
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
