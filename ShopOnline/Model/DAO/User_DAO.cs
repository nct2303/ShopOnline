using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    internal class User_DAO
    {
        ShopeeOnlineDBContext db = null;
        public User_DAO()
        {
            db = new ShopeeOnlineDBContext();
        } 
        public UserAdmin Add(UserAdmin us)
        {
            db.UserAdmins.Add(us);
            db.SaveChanges();
            return us;
        }
        public UserAdmin Update(UserAdmin user)
        {
            var us = db.UserAdmins.FirstOrDefault(x => x.id == user.id);
            us.username = user.username;
            us.password = user.password;
            us.fullname = user.fullname;
            us.email = user.email;
            db.SaveChanges();
            return us;
        }
        public int Login(string username, string password)
        {
            int count = db.UserAdmins.Where(x=> x.username == username && x.password == password).Count();
        }
    }
}
