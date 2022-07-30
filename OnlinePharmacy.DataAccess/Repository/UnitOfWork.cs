using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using OnlinePharmacy.DataAccess.Data;
using OnlinePharmacy.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlinePharmacyContext _db;
        public UnitOfWork(OnlinePharmacyContext db)
        {
            _db = db;
            Category = new CategoryRepository(db);
            Company = new CompanyRepository(db);
            Product = new ProductRepository(db);
            Role = new RoleRepository(db);
            User = new UserRepository(db);
            ShoppingCart = new ShoppingCartRepository(db);
            OrderDetail = new OrderDetailRepository(db);
            OrderHeader = new OrderHeaderRepository(db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IProductRepository Product { get; private set; }
        public IRoleRepository Role { get; private set; }
        public IUserRepository User { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public  IOrderHeaderRepository OrderHeader { get; private set; }
        public  IOrderDetailRepository OrderDetail { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }

    }

}
