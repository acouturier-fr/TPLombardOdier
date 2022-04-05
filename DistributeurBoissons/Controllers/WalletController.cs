using DistributeurBoissons.Class;
using DistributeurBoissons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Controllers
{
    public class WalletController
    {
        public DatabaseContext _dbContext;
        public List<Wallet> _lstWallets;

        public WalletController(DatabaseContext context)
        {
            _dbContext = context;
            _lstWallets = _dbContext.dbSetWallets.ToList();
        }
        public Wallet CreateWallet(User user, Money money)
        {
            Wallet wallet = new Wallet(user, money);
            wallet.CreateWallet(_dbContext);
            return wallet;
        }

        public void CreateWallets(User user, List<Money> lstMoney)
        {
            foreach(Money money in lstMoney)
            {
                Wallet wallet = new Wallet(user, money);
                wallet.CreateWallet(_dbContext);
            }
        }

        public void ModifyWallet(Wallet wallet, int amount = 0)
        {
            wallet.Number = amount;
            wallet.ModifyWallet(_dbContext);
        }

        public void ModifyWallet(Wallet wallet)
        {
            wallet.ModifyWallet(_dbContext);
        }

        public void ModifyWallets(List<Wallet> lstWallets)
        {
            foreach (Wallet wallet in lstWallets)
            {
                ModifyWallet(wallet);
            }
        }

        public void GiveMoney(Wallet giver, Wallet receiver)
        {
            if(giver.IdMoney == receiver.IdMoney)
            {
                DecreaseWallet(giver);
                IncreaseWallet(receiver);
            }
        }
        public void GiveMoney(Wallet giver, User userReceiver)
        {
            Wallet receiver = GetWallet(userReceiver, giver.Money);
            GiveMoney(giver, receiver);
        }

        public void GiveWallet(Wallet giver, User userReceiver)
        {
            int index = giver.Number;
            Wallet receiver = GetWallet(userReceiver, giver.Money);
            for(int i = 1; i <= index; i++)
                GiveMoney(giver, receiver);
        }

        public void IncreaseWallet(Wallet wallet)
        {
            Wallet realWallet = GetWallet(wallet.User, wallet.Money);
            realWallet.Number++;
            ModifyWallet(realWallet);
        }

        public void DecreaseWallet(Wallet wallet)
        {
            Wallet realWallet = GetWallet(wallet.User, wallet.Money);
            realWallet.Number--;
            ModifyWallet(realWallet);
        }

        public void AddWallets(List<Wallet> lstMoneyAmounts, User user)
        {
            List<Wallet> lstWalletsSaved = GetWallets(user);

            foreach(Wallet wallet in lstMoneyAmounts)
            {
                if (lstWalletsSaved.Any(x => x.IdMoney == wallet.IdMoney))
                {
                    Wallet savedWallet = lstWalletsSaved.Where(x => x.IdMoney == wallet.IdMoney).FirstOrDefault();
                    lstWalletsSaved.Remove(savedWallet);
                    savedWallet.Number += wallet.Number;
                    lstWalletsSaved.Add(savedWallet);
                }
                else
                {
                    lstWalletsSaved.Add(wallet);
                }
            }
            ModifyWallets(lstWalletsSaved);
        }

        public Wallet GetWallet(User user, Money money)
        {
            Refresh();
            return _lstWallets.Where(x => x.IdUser == user.IdUser && x.IdMoney == money.IdMoney).FirstOrDefault();
        }

        public Wallet GetWallet(User user, int idMoney)
        {
            Refresh();
            return _lstWallets.Where(x => x.IdUser == user.IdUser && x.IdMoney == idMoney).FirstOrDefault();
        }

        public List<Wallet> GetWallets(User user)
        {
            Refresh();
            return _lstWallets.Where(x => x.User.IdUser == user.IdUser && x.Number > 0).ToList();
        }
        public List<Wallet> GetAllWallets(User user)
        {
            Refresh();
            return _lstWallets.Where(x => x.User.IdUser == user.IdUser).ToList();
        }

        public void FundWallets(User user, List<KeyValuePair<Money, int>> moneyAmounts)
        {
            foreach(KeyValuePair<Money, int> kvp in moneyAmounts)
            {
                ModifyWallet(GetWallet(user,kvp.Key),kvp.Value);
            }
        }

        public void ManageWallet(ref List<Wallet> lstWallets, Wallet otherWallet, bool plus = true)
        {
            if (lstWallets.Any(x => x.IdMoney == otherWallet.IdMoney))
            {
                var bufferWallet = lstWallets.Where(x => x.IdMoney == otherWallet.IdMoney).FirstOrDefault();
                lstWallets.Remove(bufferWallet);
                if (plus)
                    bufferWallet.Number++;
                else
                    bufferWallet.Number--;
                lstWallets.Add(bufferWallet);
            }
            else
                lstWallets.Add (new Wallet(otherWallet.User, otherWallet.Money, 1));
        }

        public void Refresh()
        {
            _lstWallets.Clear();
            _lstWallets = _dbContext.dbSetWallets.ToList();
        }
    }
}
