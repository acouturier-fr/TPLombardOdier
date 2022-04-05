using DistributeurBoissons.Class;
using DistributeurBoissons.Controllers;
using DistributeurBoissons.Model;
using DistributeurBoissons.Views;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SQLite;

namespace DistributeurBoissons
{
    public partial class VendingMachineForm : Form, IMainView
    {
        public DatabaseContext _context { get; private set; }
        VendingMachineController _controller;
        public UserController _userController { get; set; }
        public MoneyController _moneyController { get; set; }
        public WalletController _walletController { get; set; }
        public BeverageController _beverageController { get; set; }
        public BeverageTypeController _beverageTypeController { get; set; }
        public User User { get; set; }
        public User Machine { get; set; }

        public VendingMachineForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller = new VendingMachineController(this);
            _context = _controller._context;

            _controller.LoadControllers(this);

            UserBox userBox = new UserBox(this);
            userBox.ShowDialog();
            if (userBox.ResultDialog != DialogResult.OK)
            {
                this.Close();
                return;
            }

            FillDataSources();
            InitializeView();
            Machine = _userController.GetMachine();
            if (_walletController.GetAllWallets(Machine).Count == 0)
                _walletController.CreateWallets(Machine, _moneyController.GetMoneys(((int)enumCurrency.CHF)));
            UpdateInserted();
        }

        private void InitializeView()
        {
            List<BeverageType> beverageTypes = _beverageTypeController.GetAllBeverageTypes();

            PrepareImages(beverageTypes);

            lstViewBeverageTypes.View = View.LargeIcon;
            lstViewBeverageTypes.LargeImageList = imgListBeverageType;

            CreateListViewItems(lstViewBeverageTypes, beverageTypes);
        }

        public void FillDataSources()
        {
            this.beverageTypeBindingSource.DataSource =
                _context.dbSetBeverageTypes.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._context.Dispose();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(User.IdUser);
            settingForm.ShowDialog();
            _controller.Reload();
        }

        private void btnBuyBeverageFromListView_Click(object sender, EventArgs e)
        {
            if(lstViewBeverageTypes.SelectedItems.Count > 0)
            {
                BeverageType selectedItem = (BeverageType)lstViewBeverageTypes.Items[lstViewBeverageTypes.SelectedIndices[0]].Tag;
                string message = string.Empty;
                message += _controller.BuyBeverageFromView(User.IdUser, selectedItem.IdBeverageType);

                MessageBox.Show(message);
            }
            else
                MessageBox.Show("Veuillez choisir une boisson");
        }

        private void btnInsertCoin_Click(object sender, EventArgs e)
        {
            MoneyForm moneyForm = new MoneyForm(this,MoneyFormMode.ExchangeMode);
            string message = "Vous avez inséré :" + Environment.NewLine;

            var Result = moneyForm.ShowDialog();

            if (Result == DialogResult.OK)
            {
                foreach (Wallet wallet in moneyForm.lstTempWallets)
                    message += _controller.InsertMoney(wallet);

                message += String.Format("Le montant inséré est de {0} {1}", (_controller.WalletSum(moneyForm.lstTempWallets)).ToString("0.00"), enumCurrency.CHF.ToString());

                UpdateInserted();
                MessageBox.Show(message);
            }
        }

        private void UpdateInserted()
        {
            lblInserted.Text = _controller.WalletSum(_controller.GetTempWallet()).ToString("0.00") + "CHF";
        }
        private void btnRefund_Click(object sender, EventArgs e)
        {
            string message = String.Empty;
            message += _controller.Refund(User);
            MessageBox.Show(message);
        }

        // TODO : déplacer ca dans une classe mere
        private void CreateListViewItem(ListView listView, BeverageType beverageType)
        {
            ListViewItem item = new ListViewItem();
            item.ImageIndex = imgListBeverageType.Images.IndexOfKey(beverageType.IdBeverageType.ToString());
            item.Text = beverageType.PriceName;
            item.Tag = beverageType;
            listView.Items.Add(item);
        }

        private void CreateListViewItems(ListView listView, List<BeverageType> beverageTypes)
        {
            listView.Items.Clear();
            foreach (BeverageType beverageType in beverageTypes)
                CreateListViewItem(listView, beverageType);
        }

        private void PrepareImages(List<BeverageType> beverageTypes)
        {
            Image img;

            imgListBeverageType.ImageSize = new Size(50, 100);

            foreach (BeverageType type in beverageTypes)
            {
                img = (Image)(new Bitmap(Image.FromFile(type.Image), new Size(50, 100)));
                imgListBeverageType.Images.Add(type.IdBeverageType.ToString(), img);
            }
        }

        private void userWalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoneyForm moneyForm = new MoneyForm(this, MoneyFormMode.UserViewMode);
            moneyForm.ShowDialog();
        }

        private void portefeuilleMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoneyForm moneyForm = new MoneyForm(this, MoneyFormMode.MachineViewMode);
            moneyForm.ShowDialog();
        }
    }
}