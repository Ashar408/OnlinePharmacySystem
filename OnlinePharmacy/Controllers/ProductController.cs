using Microsoft.AspNetCore.Mvc;
using OnlinePharmacy.DataAccess.Repository.IRepository;
using OnlinePharmacy.Models;

namespace OnlinePharmacy.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Company,Category");
            return View(products);
        }
    }
}
