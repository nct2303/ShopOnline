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
            var user = db.CustomerAccounts.FirstOrDefault(x=>x.customer_username == username);
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
        public CustomerAccount getItem(string username)
        {
            return db.CustomerAccounts.FirstOrDefault(x=> x.customer_username == username);
        }
        public CustomerAccount Update(CustomerAccount customer)
        {
            var us = db.CustomerAccounts.FirstOrDefault(x=> x.customer_id == customer.customer_id);
            us.customer_username = customer.customer_username;
            us.customer_password = customer.customer_password;
            db.SaveChanges();
            return us;
        }
        public CustomerAccount Add(CustomerAccount customer)
        {
            db.CustomerAccounts.Add(customer);
            db.SaveChanges();
            return customer;
        }
    }
}
