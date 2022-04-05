using DistributeurBoissons.Class;
using DistributeurBoissons.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DistributeurBoissons.Class.Logger;

namespace DistributeurBoissons.Controllers
{
    /// <summary>
    /// Class <c>VendingMachineController</c> Manage all the core features of the vending machine
    /// </summary>
    public class VendingMachineController
    {
        VendingMachineForm _view;
        public DatabaseContext _context { get; set; }

        List<Wallet> _tempWallets = new List<Wallet>();
        private static readonly Logger Logger = new Logger();

        static string strExeFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        static string folderPath = Path.Combine(strExeFilePath, "Database");
        static string dbPath = Path.Combine(folderPath, "VendingMachine.sqlite");

        /// <summary>
        /// Method <c>VendingMachineController</c> Constructor, also used to load datas in dbset and initialize the database
        /// </summary>
        /// <param name="view"></param>
        public VendingMachineController(VendingMachineForm view)
        {
            _view = view;
            InitializeDb();
            _context = new DatabaseContext();
            LoadDbSets();
            Logger.Log(Logtype.info, "VendingMachine Controller Initialized");
        }

        /// <summary>
        ///  Method <c>VendingMachineController</c> Constructor for test
        /// </summary>
        /// <param name="view"></param>
        /// <param name="context"></param>
        /// <param name="tempWallets"></param>
        public VendingMachineController(VendingMachineForm view, DatabaseContext context, List<Wallet> tempWallets = null)
        {
            _view = view;
            InitializeDb();
            _context = context;
            LoadDbSets();
            if(tempWallets == null)
                tempWallets = new List<Wallet>();
            _tempWallets = tempWallets;

            Logger.Log(Logtype.info, "VendingMachine Controller Initialized");
        }

        public void Reload()
        {
            _context = new DatabaseContext();
            LoadControllers(_view);
        }

        public void LoadControllers(VendingMachineForm view)
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

        //public void BuyBeverage(int idUser, int idTypeBeverage)
        //{
        //    User user = _view._userController.GetUser(idUser);
        //    User machine = _view._userController.GetMachine();
        //    BeverageType beverageType = _view._beverageTypeController.GetBeverageType(idTypeBeverage);

        //    List<Wallet> lstMoneyAmountsToPay = new List<Wallet>();
        //    decimal sum = 0;
        //    int i = 0;

        //    while (sum < beverageType.Price || i > 30)
        //    {
        //        List<Wallet> lstMoneyAmountsUser = _view._walletController.GetWallets(user);
        //        Random random = new Random();
        //        int rnd = random.Next(lstMoneyAmountsUser.Count - 1);
        //        Wallet walletBuffer = lstMoneyAmountsUser.ElementAt(rnd);

        //        _view._walletController.ManageWallet(ref lstMoneyAmountsToPay, walletBuffer);
        //        _view._walletController.GiveMoney(walletBuffer, machine);

        //        sum += lstMoneyAmountsToPay.Last().Money.Value;
        //        i++;
        //    }

        //    string result = "You inserted :"; 
        //    foreach(Wallet wallet in lstMoneyAmountsToPay)
        //        result += Environment.NewLine + string.Format("{0} coin(s) of {1}", wallet.Number, wallet.Money.strValue);

        //    if (i > 30)
        //        MessageBox.Show("You didn't have enough money to pay");
        //    else
        //    {
        //        MessageBox.Show(result);
        //        GiveBackDifference(sum - beverageType.Price,user);
        //    }
        //}

        #region VendingMachine Features


        /// <summary>
        /// Method <c>CalculateDifference</c> Recursive method to calculate the amount of money returned to user (if any)
        /// </summary>
        /// <param name="overValue"></param>
        /// <param name="lstMoneyAmountsToPay"></param>
        /// <param name="entirelyRefunded"></param>
        /// <param name="user"></param>
        /// <returns>Amount of money returned to user</returns>
        public decimal CalculateDifference(decimal overValue, ref List<Wallet> lstMoneyAmountsToPay, ref bool entirelyRefunded,User user)
        {
            User machine = _view.Machine;
            List<Wallet> lstMoneyAmountsUser = _view._walletController.GetWallets(machine);

            if(overValue > 0)
            {
                var lst = lstMoneyAmountsUser.Where(x => x.Money.Value <= overValue).ToList();
                if(lst.Count > 0)
                {
                    lst = lst.OrderByDescending(x => x.Money.Value).ToList();
                    Wallet selectedWallet = lst.FirstOrDefault();
                    overValue -= selectedWallet.Money.Value;

                    _view._walletController.ManageWallet(ref lstMoneyAmountsToPay, selectedWallet);
                    _view._walletController.GiveMoney(selectedWallet, user);

                    return CalculateDifference(overValue, ref lstMoneyAmountsToPay, ref entirelyRefunded, user);
                }
                else
                    return overValue;
            }
            else
            {
                entirelyRefunded = true;
                return overValue;
            }
        }

        /// <summary>
        /// Method <c>GiveBackDifference</c> prepare and display the result of <c>CalculateDifference</c> and empties the wallet in memory used in case of refund
        /// </summary>
        /// <param name="overvalue"></param>
        /// <param name="user"></param>
        /// <returns>A string that will be displayed detailing the amount of each coins and if the machine could refund entirely the user</returns>
        public string GiveBackDifference(decimal overvalue, User user)
        {
            string resultText = String.Empty;
            if (overvalue > 0)
            {
                List<Wallet> lstMoneyAmountsToPay = new List<Wallet>();
                bool entirelyRefunded = false;

                decimal overValue = CalculateDifference(overvalue, ref lstMoneyAmountsToPay, ref entirelyRefunded,user);

                resultText = "Récupérez votre monnaie :";
                foreach (Wallet wallet in lstMoneyAmountsToPay)
                    resultText += Environment.NewLine + string.Format("{0} pièce(s) de {1}", wallet.Number, wallet.Money.strValue);
                if (!entirelyRefunded)
                    resultText += Environment.NewLine + String.Format("La machine n'a pas assez de pièce pour vous rembourser la somme de {0} restante. Nous vous prions d'accepter nos excuses.", overValue);
                else
                    _tempWallets.Clear();
            }
            resultText += Environment.NewLine + "Nous vous remercions pour votre achat";
            return resultText;
        }

        /// <summary>
        /// Method <c>Refund</c> to refund the user after he inserted money
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Message for user</returns>
        public string Refund(User user)
        {
            string resultText = string.Empty;
            if(_tempWallets.Count > 0)
            {
                User machine = _view._userController.GetMachine();
                foreach (Wallet wallet in _tempWallets)
                {
                    Wallet buffer = new Wallet(machine, wallet.Money, wallet.Number);
                    List<Wallet> lstbuffer = new List<Wallet>();
                    lstbuffer.AddRange(_tempWallets);
                    for (int i = 1; i <= buffer.Number; i++)
                        _view._walletController.ManageWallet(ref lstbuffer, buffer, false);
                    _view._walletController.GiveWallet(buffer, user);
                }

                resultText = "Veuillez récupérer votre monnaie";
                _tempWallets.Clear();
            }
            else
                resultText = "Vous devez d'abord insérer de la monnaie";

            return resultText;
        }

        /// <summary>
        /// Method <c>InsertMoney</c> used to insert money from a user to the machine and keep it in memory in case of refund
        /// </summary>
        /// <param name="wallet"></param>
        /// <returns>string related to the number of coins inserted by the user</returns>
        public string InsertMoney(Wallet wallet)
        {
            User machine = _view.Machine;

            for(int i = 1; i <= wallet.Number; i++)
                _view._walletController.ManageWallet(ref _tempWallets, wallet);
            _view._walletController.GiveWallet(wallet, machine);

            string resultText = String.Format("{0} pièce(s) de {1}", wallet.Number,wallet.Money.strValue) + Environment.NewLine;
            return resultText;
        }

        /// <summary>
        /// Method <c>BuyBeverageFromView</c> manage the "core" feature of the vending machine
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idBeverageType"></param>
        /// <returns>string that will be displayed to the user depending on what happened during the process</returns>
        public string BuyBeverageFromView(int idUser, int idBeverageType)
        {
            string resultText = string.Empty;
            try
            {
                User user = _view._userController.GetUser(idUser);
                BeverageType beverageType = _view._beverageTypeController.GetBeverageType(idBeverageType);
                int beverageAmount = _view._beverageController.GetUnexpiredBeverageAmount(beverageType);

                if (beverageAmount > 0)
                {
                    if (AreYouRichEnough(_tempWallets, beverageType.Price))
                        resultText = GiveBackDifference(WalletSum(_tempWallets) - beverageType.Price, user);
                    else
                        resultText = Refund(user);
                }
                else
                    resultText = "La boisson sélectionnée n'est pas disponible";
            }
            catch (Exception ex)
            {
                Logger.Log(Logtype.error, ex.Message);
                resultText = "Une erreur s'est produite. Veuillez nous excuser pour la gêne occasionnée";
            }

            return resultText;
        }

        /// <summary>
         /// Method <c>AreYouRichEnough</c> checks if the total amounts contained in wallets are superior to the toPay value
        /// </summary>
        /// <param name="wallets"></param>
        /// <param name="toPay"></param>
        /// <returns>the answer to the Method</returns>
        public bool AreYouRichEnough(List<Wallet> wallets, decimal toPay)
        {
            return WalletSum(wallets) > toPay;
        }

        /// <summary>
        /// Method <c>WalletSum</c> sums up all wallets 
        /// </summary>
        /// <param name="wallets"></param>
        /// <returns>sum of the wallet</returns>
        public decimal WalletSum(List<Wallet> wallets)
        {
            decimal amount = 0;
            foreach (Wallet wallet in wallets)
                amount += wallet.Money.Value * wallet.Number;

            return amount;
        }

        public List<Wallet> GetTempWallet()
        {
            if (_tempWallets.Any())
                return _tempWallets;
            else
                return new List<Wallet>();
        }
        #endregion


        #region DatabaseInit

        private void InitializeDb()
        {
            try
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                if (!File.Exists(dbPath))
                {
                    SQLiteConnection.CreateFile("DistributeurBoissonDb.sqlite");
                    Logger.Log(Logtype.info, "Database created");
                    PopulateDb();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logtype.error, ex.Message);
            }
        }

        private void PopulateDb()
        {
            List<String> SqlCommands = new List<String>();

            string sql = "CREATE TABLE BeverageType (IdBeverageType INTEGER PRIMARY KEY AUTOINCREMENT, Price REAL NOT NULL, Name VARCHAR NOT NULL, Image VARCHAR)";
            SqlCommands.Add(sql);

            sql = "CREATE TABLE Currency (IdCurrency INTEGER PRIMARY KEY AUTOINCREMENT, Name VARCHAR NOT NULL)";
            SqlCommands.Add(sql);

            sql = "CREATE TABLE Beverage (IdBeverage INTEGER PRIMARY KEY AUTOINCREMENT, ExpirationDate REAL NOT NULL, SaleDate REAL, IdBeverageType INTEGER NOT NULL REFERENCES BeverageType (IdBeverageType))";
            SqlCommands.Add(sql);

            sql = "CREATE TABLE User (IdUser INTEGER PRIMARY KEY AUTOINCREMENT, Name VARCHAR NOT NULL, IsAdmin BOOLEAN NOT NULL)";
            SqlCommands.Add(sql);

            sql = "CREATE TABLE Money (IdMoney INTEGER PRIMARY KEY AUTOINCREMENT, Value REAL NOT NULL, Image VARCHAR, IdCurrency INTEGER REFERENCES Currency(IdCurrency) )";
            SqlCommands.Add(sql);

            sql = "CREATE TABLE Wallet (IdUser INTEGER REFERENCES User (IdUser), IdMoney INTEGER REFERENCES Money (IdMoney), Number INTEGER NOT NULL, PRIMARY KEY (IdUser,IdMoney))";
            SqlCommands.Add(sql);

            sql = "INSERT INTO BeverageType (Price, Name, Image) VALUES ({0},{1},{2});";
            string path = Path.Combine(strExeFilePath, "Properties", "Ressources", "Drinks");
            string cmd = string.Format(sql, "1.50", "'Eau'", "'" + Path.Combine(path, "Water.png") + "'");
            cmd += string.Format(sql, "1.25", "'Cola'", "'" + Path.Combine(path, "Cola.png") + "'");
            cmd += string.Format(sql, "1.50", "'Soda Bleu'", "'" + Path.Combine(path, "BlueDrink.png") + "'");
            cmd += string.Format(sql, "1.30", "'Soda Orange'", "'" + Path.Combine(path, "OrangeDrink.png") + "'");
            cmd += string.Format(sql, "1.95", "'Café'", "'" + Path.Combine(path, "Coffee.png") + "'");
            cmd += string.Format(sql, "1.65", "'Limonade'", "'" + Path.Combine(path, "Lemonade.png") + "'");

            SqlCommands.Add(cmd);

            sql = "INSERT INTO Currency (IdCurrency,Name) VALUES (1,'CHF'); INSERT INTO Currency (IdCurrency,Name) VALUES (2,'Euro');";
            SqlCommands.Add(sql);

            sql = "INSERT INTO Money (Value,Image,IdCurrency) VALUES ({0},{1},{2});";
            path = Path.Combine(strExeFilePath, "Properties", "Ressources", "Money");
            cmd = string.Format(sql, "0.05", "'" + Path.Combine(path, "CHF0.05.png") + "'", 1);
            cmd += string.Format(sql, "0.1", "'" + Path.Combine(path, "CHF0.1.png") + "'", 1);
            cmd += string.Format(sql, "0.2", "'" + Path.Combine(path, "CHF0.2.png") + "'", 1);
            cmd += string.Format(sql, "0.5", "'" + Path.Combine(path, "CHF0.5.png") + "'", 1);
            cmd += string.Format(sql, "1", "'" + Path.Combine(path, "CHF1.png") + "'", 1);
            cmd += string.Format(sql, "2", "'" + Path.Combine(path, "CHF2.png") + "'", 1);
            cmd += string.Format(sql, "5", "'" + Path.Combine(path, "CHF5.png") + "'", 1);

            SqlCommands.Add(cmd);

            //sql = "INSERT INTO Money (Value,IdCurrency) VALUES (0.05,2); INSERT INTO Money (Value,IdCurrency) VALUES (0.10,2);INSERT INTO Money (Value,IdCurrency) VALUES (0.20,2);INSERT INTO Money (Value,IdCurrency) VALUES (0.5,2);INSERT INTO Money (Value,IdCurrency) VALUES (1,2);" +
            //    "INSERT INTO Money (Value,IdCurrency) VALUES (2,2)";
            //SqlCommands.Add(sql);

            sql = "INSERT INTO User (Name,IsAdmin) VALUES ('Machine',TRUE);";
            SqlCommands.Add(sql);

            ExecuteSqlCommands(SqlCommands);
        }

        private void ExecuteSqlCommands(List<String> lstCommands)
        {
            try
            {
                using (SQLiteConnection m_dbConnection = new SQLiteConnection(String.Format("Data Source={0};Version=3;", dbPath)))
                {
                    m_dbConnection.Open();

                    foreach (String cmd in lstCommands)
                    {
                        SQLiteCommand command = new SQLiteCommand(cmd, m_dbConnection);
                        command.ExecuteNonQuery();
                    }
                    m_dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logtype.error,ex.Message);
            }

        }
        #endregion
    }
}
