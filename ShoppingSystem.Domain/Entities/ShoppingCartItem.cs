using ShoppingSystem.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingSystem.Domain.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        private readonly List<Product> _product = new();
        public ShoppingCartItem() { }
        public ShoppingCartItem(Product product, int amount, int price, Guid shoppingCartId)
        {
            Product = product;
            Amount = amount;
            Price = price * amount;
            ShoppingCartId = shoppingCartId;
        }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public Guid ShoppingCartId { get; set; }

        public static ShoppingCartItem Create(Product product, int amount, int price, Guid shoppingCartId)
        {
            return new ShoppingCartItem(product, amount, price, shoppingCartId);
        }


    }
}
