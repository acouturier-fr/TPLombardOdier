using DistributeurBoissons.Class;
using DistributeurBoissons.Controllers;
using DistributeurBoissons.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributeurBoissons.Views
{
    public partial class SettingForm : Form, IMainView
    {
        public DatabaseContext _context { get; private set; }
        SettingController _controller;
        public UserController _userController { get; set; }
        public MoneyController _moneyController { get; set; }
        public WalletController _walletController { get; set; }
        public BeverageController _beverageController { get; set; }
        public BeverageTypeController _beverageTypeController { get; set; }
        public User User { get; set; }
        public int IdUser { get; set; }
        public User Machine { get; set; }

        public List<Wallet> tempWallets { get; set; }

        public SettingForm(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller = new SettingController(this);
            User = _userController.GetUser(IdUser);
            _context = _controller._context;
            FillDataSources();

            lblTrackbarBoisson.Text = trackBar1.Value.ToString();

            int index = cbxUser.Items.IndexOf(User);
            cbxUser.SelectedIndex = index;
        }

        public void FillDataSources()
        {
            this.beverageTypeBindingSource.DataSource =
                _context.dbSetBeverageTypes.Local.ToBindingList();
            this.userBindingSource.DataSource =
                _context.dbSetUsers.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._context.Dispose();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblTrackbarBoisson.Text = trackBar1.Value.ToString();
        }

        private void btnAddBoisson_Click(object sender, EventArgs e)
        {
            _controller.AddBeverages((int)cbxBeverageType.SelectedValue,trackBar1.Value);
        }

        private void btnRndGenBoisson_Click(object sender, EventArgs e)
        {
            _controller.GenerateBeverageStock();
        }

        private void btnWalletManage_Click(object sender, EventArgs e)
        {
            MoneyForm moneyForm = new MoneyForm(this,MoneyFormMode.SettingMode);
            string message = "You inserted :" + Environment.NewLine;

            var Result = moneyForm.ShowDialog();

            if (Result == DialogResult.OK)
                _controller.ManageWalletManually(moneyForm.lstTempWallets);
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                User = _userController.CreateUser(textBox1.Text);
                _walletController.CreateWallets(User,_moneyController.GetMoneys(((int)enumCurrency.CHF))) ;
                MessageBox.Show("Action effectuée avec succès");

            }
            else
                MessageBox.Show("Veuillez entrer un nom");
        }

        private void cbxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = cbxUser.SelectedItem as User;
            User = _userController.GetUser(user.IdUser);
        }

        private void btnWalletGenerate_Click(object sender, EventArgs e)
        {
            _controller.GenerateRandomWallet();
        }

        private void btnTenOfEach_Click(object sender, EventArgs e)
        {
            _controller.AddTenOfEach(_walletController.GetAllWallets(User));
        }

        private void btnEmptyWallet_Click(object sender, EventArgs e)
        {
            _controller.EmptyWallets(_walletController.GetAllWallets(User));
        }

        private void btnEmptyBeverageStock_Click(object sender, EventArgs e)
        {
            _controller.EmptyBeverageStock(_beverageTypeController.GetAllBeverageTypes());
        }
    }
}
