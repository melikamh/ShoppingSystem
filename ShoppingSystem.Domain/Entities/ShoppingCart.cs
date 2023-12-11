using ShoppingSystem.Domain.DomainEvents;
using ShoppingSystem.Domain.Primitives;
using ShoppingSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingSystem.Domain.Entities
{
    public class ShoppingCart : AggregateRoot<Guid>
    {

        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }

        private readonly List<ShoppingCartItem> _items = new();
        public IReadOnlyCollection<ShoppingCartItem> Items => _items;
        public ShoppingCart() { }
        internal ShoppingCart(Guid id, int customerId, DateTime dateTime)
        {
            Id = id;
            CustomerId = customerId;
            this.DateTime = dateTime;
        }
        public static ShoppingCart Create(Guid id, int customerId, DateTime dateTime)
        {
            var shoppingCart = new ShoppingCart(id, customerId, dateTime);

            return shoppingCart;
        }
        public bool AddItem(Product product, int amount)
        {

            if (product.InStock == 0)
                return false;

            var shoppingCartItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);
            var hasItem = _items.Any(i => i.Product.Id == product.Id);
            var isValidAmount = true;
            if (!hasItem)
            {
                if (amount > product.InStock)
                    isValidAmount = false;
                amount = Math.Min(product.InStock, amount);
                shoppingCartItem = new ShoppingCartItem(product, amount, product.Price, Id);
                _items.Add(shoppingCartItem);
            }
            else // if product exist in basket
            {
                if (product.InStock - shoppingCartItem.Amount - amount >= 0)// if InStoke is enough
                    shoppingCartItem.Price += (product.InStock - shoppingCartItem.Amount - amount) * product.Price;
                else
                {// if InStoke is not enogh 

                    isValidAmount = false;
                }
            }
            AddEvent(new ShoppingCartItemAdded(this, shoppingCartItem));
            return isValidAmount;
        }


        public bool RemoveFromCart(Product product)
        {
            var isValidRemove = false;
            var shoppingCartItem = _items.SingleOrDefault(
                s => s.Product.Id == product.Id && s.ShoppingCartId == Id);


            if (shoppingCartItem != null)
            {
                _items.Remove(shoppingCartItem);
                isValidRemove = true;
            }


            return isValidRemove;
        }

        public int TotalCost()
        {
            return _items.Sum(item => item.Price);
        }

    }
}