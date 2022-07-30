using OnlinePharmacy.DataAccess.Data;
using OnlinePharmacy.DataAccess.Repository.IRepository;
using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.DataAccess.Repository
{
    public class ShoppingCartRepository:Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly OnlinePharmacyContext _db;
        public ShoppingCartRepository(OnlinePharmacyContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }
    }
}
