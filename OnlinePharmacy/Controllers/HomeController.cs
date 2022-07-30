using Microsoft.AspNetCore.Mvc;
using OnlinePharmacy.DataAccess;
using OnlinePharmacy.DataAccess.Repository.IRepository;
using OnlinePharmacy.Models;
using System.Diagnostics;

namespace OnlinePharmacy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Company");
            return View(products);
        }
        public IActionResult Details(int productId)
        {
            ShoppingCart cartobj = new()
            {
                Count = 1,
                ProductId = productId,
                Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == productId, includeProperties: "Category,Company"),
            };
            return View(cartobj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(u=> u.ProductId == shoppingCart.ProductId);
            if (cartFromDb == null)
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
                _unitOfWork.Save();
            }


            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}