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
    public class UserRepository:Repository<User>, IUserRepository
    {
        private readonly OnlinePharmacyContext _db;
        public UserRepository(OnlinePharmacyContext db) : base(db)
        {
            _db = db;
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
        }
    }
}
