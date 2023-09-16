using ArtGallery.Domain.Domain;
using ArtGallery.Domain.DTO;
using ArtGallery.Repository.Interface;
using ArtGallery.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger,IRepository<Product> productRepository, IRepository<ProductInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
        }

        public List<Product> GetAllProducts()
        {
            return this._productRepository.GetAll().ToList();
        }

        public Product GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }

        public void CreateNewProduct(Product p)
        {
            this._productRepository.Insert(p);
        }

        public void DeleteProduct(Guid id)
        {
            var product = this.GetDetailsForProduct(id);
            this._productRepository.Delete(product);
        }

        public void UpdateExistingProduct(Product p)
        {
            this._productRepository.Update(p);
        }


        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForProduct(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedProduct = product,
                SelectedProductId = product.Id,
                Quantity = 1
            };

            return model;
        }

        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCart = user.UserCart;

            if (item.SelectedProductId != null && userShoppingCart != null)
            {
                var product = this.GetDetailsForProduct(item.SelectedProductId);

                if (product != null)
                {
                    ProductInShoppingCart itemToAdd = new ProductInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        CurrentProduct = product,
                        ProductId = product.Id,
                        ShoppingCartId = userShoppingCart.Id,
                        ShoppingCart = userShoppingCart,
                        Quantity = item.Quantity
                    };

                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    _logger.LogInformation("Product is added to Shopping Cart successfully");
                    return true;
                }
                return false;
                
            }
            _logger.LogInformation(" testLog Error in AddToShoppingCart, SelectedProductId or userShoppingCart is null");
            return false;
        }

       

       

        


       
    }
}
