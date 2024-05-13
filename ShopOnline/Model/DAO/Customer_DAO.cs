using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Customer_DAO
    {
        ShopeeOnlineDBContext db = null;
        public Customer_DAO()
        {
            db = new ShopeeOnlineDBContext();
        }

        public int Login(string username, string password)
        {
            var user = db.Customers.FirstOrDefault(x=>x.customer_username == username);
            if(user == null)
            {
                return -1;
            }
            else 
            {
                if(user.customer_password == password)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public Customer getItem(string username)
        {
            return db.Customers.FirstOrDefault(x=> x.customer_username == username);
        }
    }
}
