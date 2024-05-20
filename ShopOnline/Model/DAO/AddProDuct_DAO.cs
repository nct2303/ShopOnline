using Model.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AddProDuct_DAO
    {
        ShopeeOnlineDBContext db = null;
        public AddProDuct_DAO()
        {
            db = new ShopeeOnlineDBContext();
        }
        public Product Add(Product pd)
        {
            try
            {
                db.Products.Add(pd);
                db.SaveChanges();
                return pd;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                throw;  // Tái ném ngoại lệ sau khi ghi log chi tiết lỗi
            }
        }

        public Product Update(Product product)
        {
            var pd = db.Products.FirstOrDefault(x=>x.Id == product.Id);
            pd.Name = product.Name;
            pd.Size = product.Size;
            pd.Color = product.Color;
            pd.Description = product.Description;
            pd.Price = product.Price;
            pd.Image = product.Image;
            db.SaveChanges();
            return pd;
        }
    }
}
