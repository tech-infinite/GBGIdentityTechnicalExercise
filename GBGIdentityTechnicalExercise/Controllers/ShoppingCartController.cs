using GBGIdentityTechnicalExercise.Models;
using GBGIdentityTechnicalExercise.Services;
using Microsoft.AspNetCore.Mvc;

namespace GBGIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var listOfProducts = _shoppingCart.GetProducts();
            return Ok(listOfProducts); // returns status code 200
        }


       [HttpPost]
       public ActionResult AddProductsToCart(Product product) 
       {
            _shoppingCart.AddProduct(product);
            return Ok();
       }

       [HttpDelete("{productName}")]
       public ActionResult RemoveProduct(string productToRemove) 
       {
            _shoppingCart.RemoveProduct(productToRemove);
            return Ok();
       }

        [HttpGet("checkout")]
        public ActionResult Checkout(bool hasLoyaltyCard)
        {
            // This will return list of products in alphabetical order along with their respective prices, any discounts applied, and the total cost
            var totalCost = _shoppingCart.CalculateTotaCost(hasLoyaltyCard);
            var products = _shoppingCart.GetProducts();
                       
            return Ok(new { Products = products, TotalCost = totalCost });
        }

    }
}

    


