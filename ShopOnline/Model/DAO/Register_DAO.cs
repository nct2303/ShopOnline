using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Register_DAO
    {
        ShopeeOnlineDBContext db = null;
        public Register_DAO()
        {
            db = new ShopeeOnlineDBContext();
        }

    }
}
