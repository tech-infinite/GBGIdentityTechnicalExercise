using GBGIdentityTechnicalExercise.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBGIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Name = "Milk",
                Price = 0.99M
            },
            new Product
            {
                Name = "Bread",
                Price = 1.49M
            },
            new Product
            {
                Name = "Butter",
                Price = 1.87M
            },
            new Product
                       
            {
                Name = "Sugar",
                Price = 0.80M
            }

        };

        [HttpGet]
        public ActionResult<List<Product>> GetListOfProducts()
        {
            return Ok(products);    // returns status code 200, Success
        }

        [HttpGet("{productPrice}")]
        public ActionResult<List<Product>>GetProductByPrice(decimal productPrice)
        {
            var price = products.Find(x => x.Price == productPrice);
            if (price == null)
            {
                return NotFound("The product you're looking for, does not exist");
            }
            return Ok(price);
        }

        [HttpPost]
        public ActionResult<List<Product>> AddProductToCart(Product newProduct, bool hasLoyaltyCard = false)
        {
            // promotions applied for Butter and Sugar if the customer has a loyalty card
            if (hasLoyaltyCard)
            {
                if (newProduct.Name == "Butter")
                {
                    // Buy one, get one free
                    products.Add(newProduct);
                }
                else if (newProduct.Name == "Sugar")
                {
                    // 10% discount
                    newProduct.Price *= 0.9M;
                    products.Add(newProduct);
                }
                else
                {
                    products.Add(newProduct);
                }
            }
            else
            {
                products.Add(newProduct);
            }

            return Ok(products);
        }

        [HttpDelete("{productPrice}")]
        public ActionResult<List<Product>>RemoveProductFromCart(string name)
        {
            var productName = products.Find(x => x.Name == name);
            if (productName == null)
            {
                return NotFound("Error! Please check the product before performing this action");
            }
            products.Remove(productName);
            return Ok(products);
        }

        

    }
}

    


