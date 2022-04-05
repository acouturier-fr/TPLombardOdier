using DistributeurBoissons.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DistributeurBoissons.Model
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public User() { }


        public User(string name, bool isAdmin)
        { 
            Name = name;
            IsAdmin = isAdmin;
        }

        public void CreateUser(DatabaseContext context)
        {
            context.dbSetUsers.Add(this);
            context.SaveChanges();
        }

        public void DeleteUser(DatabaseContext context)
        {
            context.dbSetUsers.Remove(this);
            context.SaveChanges();
        }
        public void ModifyUser(DatabaseContext context)
        {
            context.dbSetUsers.Where(x => x.IdUser == this.IdUser).FirstOrDefault().Name = Name;
            context.SaveChanges();
        }
    }
}
