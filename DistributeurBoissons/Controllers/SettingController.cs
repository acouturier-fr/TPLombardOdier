using DistributeurBoissons.Class;
using DistributeurBoissons.Model;
using DistributeurBoissons.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DistributeurBoissons.Class.Logger;

namespace DistributeurBoissons.Controllers
{
    public class SettingController
    {
        SettingForm _view;
        public DatabaseContext _context { get; set; }

        List<Wallet> tempWallets = new List<Wallet>();
        private static readonly Logger Logger = new Logger();

        public SettingController(SettingForm view)
        {
            _view = view;
            _context = new DatabaseContext();
            LoadControllers(view);
            LoadDbSets();
            Logger.Log(Logtype.info, "Setting Controller Initialized");
        }
        public void LoadControllers(SettingForm view)
        {
            view._userController = new UserController(_context);
            view._moneyController = new MoneyController(_context);
            view._walletController = new WalletController(_context);
            view._beverageController = new BeverageController(_context);
            view._beverageTypeController = new BeverageTypeController(_context);
        }

        public void LoadDbSets()
        {
            _context.dbSetBeverageTypes.Load();
            _context.dbSetBeverages.Load();
            _context.dbSetCurrencys.Load();
            _context.dbSetMoney.Load();
            _context.dbSetUsers.Load();
            _context.dbSetWallets.Load();
        }

        public void AddBeverages(int idTypeBeverage,int amount,bool multiple = false)
        {
            _view._beverageController.CreateBeverages(DateTime.Now.AddDays(30), idTypeBeverage,amount);
            if(multiple)
                ActionDone();
        }
        public void GenerateBeverageStock()
        {
            Random random = new Random();
            List<BeverageType> lstBeverageTypes = _view._beverageTypeController.GetAllBeverageTypes();
            foreach (BeverageType beverageType in lstBeverageTypes)
                AddBeverages(beverageType.IdBeverageType, random.Next(1, 11),true);

            ActionDone();
        }

        public void ManageWalletManually(List<Wallet> wallets)
        {
            _view._walletController.FundWallets(_view.User, GenerateKvpForFunding(wallets));
            ActionDone();
        }

        public void GenerateRandomWallet()
        {
            List<KeyValuePair<Money, int>> lstMoneyAmounts = new List<KeyValuePair<Money, int>>();
            Random rnd = new Random();

            List<Money> lstMoneys = _view._moneyController.GetMoneys(((int)enumCurrency.CHF));

            lstMoneys.RemoveAt(rnd.Next(lstMoneys.Count));
            lstMoneys.RemoveAt(rnd.Next(lstMoneys.Count));
            lstMoneys.RemoveAt(rnd.Next(lstMoneys.Count));

            foreach (Money money in lstMoneys)
            {
                KeyValuePair<Money, int> kvp = new KeyValuePair<Money, int>(money, rnd.Next(0, 10));
                lstMoneyAmounts.Add(kvp);
            }

            _view._walletController.FundWallets(_view.User, lstMoneyAmounts);
            ActionDone();
        }

        public void AddTenOfEach(List<Wallet> wallets)
        {
            _view._walletController.FundWallets(_view.User, GenerateKvpForFunding(wallets,10));
            ActionDone();
        }

        public void EmptyWallets(List<Wallet> wallets)
        {
            _view._walletController.FundWallets(_view.User, GenerateKvpForFunding(wallets, 0, true));
            ActionDone();
        }

        private List<KeyValuePair<Money, int>> GenerateKvpForFunding(List<Wallet> wallets, int specificAmount = 0, bool emptyWallet = false)
        {
            List<KeyValuePair<Money, int>> lstMoneyAmounts = new List<KeyValuePair<Money, int>>();
            int valueForWallet;
            foreach (Wallet wallet in wallets)
            {
                valueForWallet = emptyWallet ? 0 : specificAmount > 0 ? specificAmount : wallet.Number;
                KeyValuePair<Money, int> kvp = new KeyValuePair<Money, int>(wallet.Money, valueForWallet);
                lstMoneyAmounts.Add(kvp);
            }
            return lstMoneyAmounts;
        }

        public void EmptyBeverageStock(List<BeverageType> lstBeverageTypes)
        {
            foreach(BeverageType beverageType in lstBeverageTypes)
                _view._beverageController.DeleteAllBeverage(beverageType.IdBeverageType);
            ActionDone();
        }

        private void ActionDone()
        {
            MessageBox.Show("Action effectuée avec succès");
        }
    }
}
