using DistributeurBoissons.Controllers;
using DistributeurBoissons.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributeurBoissons.Views
{
    public enum MoneyFormMode
    {
        ExchangeMode,
        SettingMode,
        UserViewMode,
        MachineViewMode
    }

    public partial class MoneyForm : Form
    {
        public MoneyForm(IMainView form, MoneyFormMode mode)
        {
            InitializeComponent();
            CallerForm = form;
            Mode = mode;
        }        

        private IMainView CallerForm { get; set; }
        public MoneyFormMode Mode { get; set; }
        public List<Wallet> lstTempWallets { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PrepareImages();
            InitializeView();
            lstTempWallets = new List<Wallet>();
        }
        
        private void InitializeView()
        {
            List<Money> lstMoney = CallerForm._moneyController.GetMoneys(1);
            User user = CallerForm.User;
            if (Mode == MoneyFormMode.MachineViewMode)
                user = CallerForm.Machine;
            Wallet wallet;

            lstViewMoney.View = View.LargeIcon;
            lstViewMoneyToInsert.View = View.LargeIcon;

            lstViewMoney.LargeImageList = imgListMoney;
            lstViewMoneyToInsert.LargeImageList = imgListMoney;

            foreach (Money money in lstMoney)
            {
                wallet = CallerForm._walletController.GetWallet(user, money);
                CreateListViewItem(lstViewMoney, wallet);
                if(Mode == MoneyFormMode.SettingMode)
                    CreateListViewItem(lstViewMoneyToInsert, wallet);
            }

            ManageMode(Mode);
        }

        public void ManageMode(MoneyFormMode mode)
        {
            switch (mode)
            {
                case MoneyFormMode.SettingMode:
                    lblExchangeMode2.Visible = false;
                    lblModeExchance.Visible = false;
                    break;
                case MoneyFormMode.ExchangeMode:
                    lblSettingMode.Visible = false;
                    break;
                case MoneyFormMode.UserViewMode:
                    lblExchangeMode2.Visible = false;
                    lblSettingMode.Visible = false;
                    btnValidateMoney.Visible = false;
                    lstViewMoneyToInsert.Visible = false;
                    btnPutBackInWallet.Visible = false;
                    btnTakeFromWallet.Visible = false;
                    lstViewMoney.Size = new System.Drawing.Size(this.ClientSize.Width-30, lstViewMoney.Height);
                    break;
                case MoneyFormMode.MachineViewMode:
                    lblExchangeMode2.Visible = false;
                    lblSettingMode.Visible = false;
                    btnValidateMoney.Visible = false;
                    lstViewMoneyToInsert.Visible = false;
                    btnPutBackInWallet.Visible = false;
                    btnTakeFromWallet.Visible = false;
                    lstViewMoney.Size = new System.Drawing.Size(this.ClientSize.Width - 30, lstViewMoney.Height);
                    break;
            }
        }

        private void PrepareImages()
        {
            List<Money> lstMoney = CallerForm._moneyController.GetMoneys(1);
            Image img;

            imgListMoney.ImageSize = new Size(100, 75);

            foreach (Money money in lstMoney)
            {
                Bitmap bitmap = new Bitmap(Image.FromFile(money.Image), new Size(200, 100));
                Rectangle section = new Rectangle(new Point(0, 0), new Size(100, 100));
                img = (Image)CropImage(bitmap, section);

                imgListMoney.Images.Add(money.IdMoney.ToString(), img);
            }
        }

        private Bitmap CropImage(Bitmap source, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }

        private void CreateListViewItem(ListView listView, Wallet wallet)
        {
            ListViewItem item = new ListViewItem();
            bool tempWallet = listView == lstViewMoneyToInsert;

            if (wallet.Number > 0 || (Mode == MoneyFormMode.SettingMode && !tempWallet))
            {
                item.ImageIndex = imgListMoney.Images.IndexOfKey(wallet.Money.IdMoney.ToString());
                item.Text = Mode == MoneyFormMode.SettingMode && !tempWallet ? String.Empty : wallet.Number.ToString();
                item.Tag = wallet;
                listView.Items.Add(item);
            }
        }

        private void CreateListViewItems(ListView listView, List<Wallet> wallets)
        {
            List<Wallet> lstOrderedWallets = wallets.OrderBy(x => x.Money.Value).ToList();
            listView.Items.Clear();
            foreach (Wallet wallet in lstOrderedWallets)
                CreateListViewItem(listView, wallet);
        }

        private void btnValidateMoney_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnTakeFromWallet_Click(object sender, EventArgs e)
        {
            ManageListView(lstViewMoney, true);
            btnTakeFromWallet.Enabled = false;
        }

        private void btnPutBackInWallet_Click(object sender, EventArgs e)
        {
            ManageListView(lstViewMoneyToInsert,false);
            btnPutBackInWallet.Enabled = false;
        }

        private void ManageListView(ListView listview, bool plus)
        {
            List<Wallet> buffer = Mode == MoneyFormMode.SettingMode ? CallerForm._walletController.GetAllWallets(CallerForm.User) : lstTempWallets;

            Wallet selectedItem = (Wallet)listview.Items[listview.SelectedIndices[0]].Tag;

            int idMoney = selectedItem.IdMoney;
            Money money = CallerForm._moneyController.GetMoney(idMoney);
            Wallet wallet = new Wallet(CallerForm.User, money);

            CallerForm._walletController.ManageWallet(ref buffer, wallet, plus);
            lstTempWallets = buffer;

            CreateListViewItems(lstViewMoneyToInsert, lstTempWallets);
            CreateListViewItems(lstViewMoney, AccountForTempWallets());
        }

        private List<Wallet> AccountForTempWallets()
        {
            List<Wallet> fakeUserWallets = new List<Wallet>();
            List<Wallet> realUserWallets = Mode == MoneyFormMode.SettingMode ? CallerForm._walletController.GetAllWallets(CallerForm.User) : CallerForm._walletController.GetWallets(CallerForm.User);

            foreach (Wallet wallet in realUserWallets)
            {
                Wallet buffer = new Wallet(wallet.User,wallet.Money,wallet.Number);

                if (lstTempWallets.Where(x => x.IdMoney == wallet.IdMoney).Any())
                {
                    buffer.Number -= lstTempWallets.Where(x => x.IdMoney == wallet.IdMoney).FirstOrDefault().Number;
                    fakeUserWallets.Add(buffer);
                }
                else
                    fakeUserWallets.Add(buffer);
            }
            return fakeUserWallets;
        }

        private void lstViewMoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTakeFromWallet.Enabled = lstViewMoney.SelectedItems.Count > 0;
        }

        private void lstViewMoneyToInsert_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPutBackInWallet.Enabled = lstViewMoneyToInsert.SelectedItems.Count > 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
