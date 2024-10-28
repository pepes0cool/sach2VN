using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebdotNet.DataAccess.Repository.IRepository;
using WebdotNet.Models;

namespace WebdotNet.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Products> productList = _unitOfWork.Products.GetAll();
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Products.Get(u => u.ID == id),
                Count = 1,
                ProductId = id
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart obj)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userID = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            obj.ApplicationUserId = userID;
            obj.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userID);
            obj.Product = _unitOfWork.Products.Get(u => u.ID == obj.ProductId);
            obj.Id = 0;
            obj.Price = obj.Product.Price;
            ShoppingCart cartFromDB = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userID && u.ProductId == obj.ProductId);
            if(cartFromDB == null)
            {
                _unitOfWork.ShoppingCart.Add(obj);
            }
            else
            {
                cartFromDB.Count += obj.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDB);
            }
            _unitOfWork.Save();
            TempData["Success"] = "Added to cart!";
            return RedirectToAction(nameof(Index));
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
