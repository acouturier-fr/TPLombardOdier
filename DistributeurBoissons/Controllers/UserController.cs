using DistributeurBoissons.Class;
using DistributeurBoissons.Model;
using DistributeurBoissons.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons.Controllers
{
    public class UserController
    {
        public UserBox? _view;
        public DatabaseContext _dbContext;
        public List<User> lstUsers;

        public UserController(DatabaseContext context) 
        {
            _dbContext = context;
            lstUsers = _dbContext.dbSetUsers.ToList();
        }

        public UserController(UserBox view, DatabaseContext context)
        {
            _dbContext = context;
            lstUsers = _dbContext.dbSetUsers.ToList();
            _view = view;
        }

        public User CreateUser(string userName)
        {
            User user = new User(userName,false);
            user.CreateUser(_dbContext);
            return user;
        }

        public void DeleteUser(User user)
        {
            user.DeleteUser(_dbContext);
        }

        public void ModifyUser(User user, string username)
        {
            user.Name = username;
            user.ModifyUser(_dbContext);
        }

        public List<User> GetUsers()
        {
            Refresh();
            return lstUsers.Where(x => !x.IsAdmin).ToList();
        }

        public User GetUser(int idUser)
        {
            Refresh();
            return lstUsers.Where(x => x.IdUser == idUser).FirstOrDefault();
        }

        public User GetMachine()
        {
            Refresh();
            return lstUsers.Where(x => x.IsAdmin).FirstOrDefault();
        }

        public void Refresh()
        {
            lstUsers.Clear();
            lstUsers = _dbContext.dbSetUsers.ToList();
        }
    }
}
