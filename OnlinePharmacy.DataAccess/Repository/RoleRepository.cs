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
    public class RoleRepository:Repository<Role>, IRoleRepository
    {
        private readonly OnlinePharmacyContext _db;
        public RoleRepository(OnlinePharmacyContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Role role)
        {
            _db.Roles.Update(role);
        }
    }
}
