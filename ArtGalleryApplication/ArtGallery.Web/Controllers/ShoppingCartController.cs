using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ArtGallery.Service.Interface;
using Humanizer.DateTimeHumanizeStrategy;
using Microsoft.EntityFrameworkCore;


namespace ArtGallery.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(this._shoppingCartService.getShoppingCartInfo(userId));
        }

        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = this._shoppingCartService.deleteProductFromSoppingCart(userId, id);
            if (result)
            {
                return RedirectToAction("Index", "ShoppingCart");

            }
            //error view to be implemented
            else
                return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = this._shoppingCartService.order(userId);

            if (result)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            else
                return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
