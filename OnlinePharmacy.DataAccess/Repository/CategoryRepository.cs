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
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        private readonly OnlinePharmacyContext _db;
        public CategoryRepository(OnlinePharmacyContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
