using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class User_DAO
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
            var us = db.UserAdmins.FirstOrDefault(x => x.ID == user.ID);
            us.UserName = user.UserName;
            us.Password = user.Password;
            us.FullName = user.FullName;
            us.Email = user.Email;
            db.SaveChanges();
            return us;
        }
        public int Login(string username, string password)
        {
            var user = db.UserAdmins.FirstOrDefault(x=> x.UserName == username);
            if(user == null)
            {
                return -1;// user khong ton tai
            }
            else
            {
                if(user.Password == password)
                {
                    return 1;// dang nhap thanh cong
                }
                else
                {
                    return 0;// sai mat khau
                }
            }
        }

        public UserAdmin getItem(string username)
        {
            return db.UserAdmins.FirstOrDefault(x => x.UserName == username);
        }

    }
}
