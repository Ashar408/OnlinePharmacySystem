using Microsoft.AspNetCore.Mvc;
using OnlinePharmacy.DataAccess.Repository.IRepository;
using OnlinePharmacy.Models;

namespace OnlinePharmacy.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Role> roles = _unitOfWork.Role.GetAll();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Role.Add(role);
                _unitOfWork.Save();
                TempData["success"] = "Role Created Successfully";
                return RedirectToAction("Index");
            }
            return View(role);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var rolefromDb = _unitOfWork.Role.GetFirstOrDefault(c => c.Id == id);
            if (rolefromDb == null)
            {
                return NotFound();
            }
            return View(rolefromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Role.Update(role);
                _unitOfWork.Save();
                TempData["success"] = "Role Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(role);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var rolefromDb = _unitOfWork.Role.GetFirstOrDefault(c => c.Id == id);
            if (rolefromDb == null)
            {
                return NotFound();
            }
            return View(rolefromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Role.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Role.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Role Deleted Successfully";
            return RedirectToAction("Index");

        }

    }

}
