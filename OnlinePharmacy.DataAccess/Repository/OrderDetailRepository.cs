
using BulkyBook.DataAccess.Repository.IRepository;
using OnlinePharmacy.DataAccess.Data;
using OnlinePharmacy.DataAccess.Repository;
using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private OnlinePharmacyContext _db;
        public OrderDetailRepository(OnlinePharmacyContext db):base(db)
        {
            _db = db;
        }


        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}
