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
    public partial class UserBox : Form
    {
        public UserController _userController { get; set; }

        public DialogResult ResultDialog { get; set; }
        public User User { get; set; }
        public IMainView MainForm { get; set; }

        public UserBox(IMainView mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            ResultDialog = DialogResult.Abort;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _userController = new UserController(this, MainForm._context);

            cbxUser.ValueMember = "IdUser";
            cbxUser.DisplayMember = "Name";

            foreach (User user in _userController.GetUsers())
                cbxUser.Items.Add(user);
            cbxUser.SelectedIndex = cbxUser.Items.Count > 0 ? 0 : cbxUser.SelectedIndex;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (cbxUser.Items.Count != 0)
            {
                var user = cbxUser.SelectedItem as User;
                User = _userController.GetUser(user.IdUser);
                MainForm.User = User;
                this.Close();
                ResultDialog = DialogResult.OK;
            }
            else
                MessageBox.Show("Veuillez créer un utilisateur");
           
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if(txtUserName.TextLength > 0)
            {
                User = _userController.CreateUser(txtUserName.Text.Trim());
                MainForm._walletController.CreateWallets(User, MainForm._moneyController.GetMoneys(((int)enumCurrency.CHF)));
                MainForm.User = User;
                this.Close();
                ResultDialog = DialogResult.OK;
            }
        }
    }
}
