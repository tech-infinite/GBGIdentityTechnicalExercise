using GBGIdentityTechnicalExercise.Models;

namespace GBGIdentityTechnicalExercise.Services
{
    public class ShoppingCart
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(string productName) 
        {
            var productToRemove = _products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (productToRemove != null) 
            {
                _products.Remove(productToRemove);
            }
        }
        public List<Product> GetProducts() 
        {
            return _products.OrderBy(p => p.Name).ToList();
        }

        public decimal CalculateTotaCost(bool hasLoyaltyCard) 
        {
            decimal totalPrice = 0;
            foreach (var product in _products) 
            {
                if (product.Name.Equals("Butter", StringComparison.OrdinalIgnoreCase) && hasLoyaltyCard)
                {
                    totalPrice += product.Price;
                }

                else if (product.Name.Equals("Sugar", StringComparison.OrdinalIgnoreCase) && hasLoyaltyCard) 
                {
                    totalPrice += product.Price - (product.Price * 0.1m);
                }

                else 
                {
                    totalPrice += product.Price;
                }
            }
            return totalPrice;
        }
    }
}
