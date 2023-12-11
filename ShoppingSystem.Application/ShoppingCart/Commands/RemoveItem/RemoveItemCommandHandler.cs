using ShoppingSystem.Domain.Repositories;
using MediatR;
using ShoppingSystem.Persistence.Repositories;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Infrastructure.Services;
using ShoppingSystem.Domain.Shared;
using ShoppingSystem.Application.Exceptions;

namespace ShoppingSystem.Application.ShoppingCartCommands.RemoveItem
{
    internal sealed class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, Result<ShoppingCart>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public RemoveItemCommandHandler(
            IShoppingCartRepository shoppingCartRepository,
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            ICacheService cacheService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _cacheService = cacheService;
        }

        public async Task<Result<ShoppingCart>> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            string cacheKey = $"Customer_{request.customerId}";
            string shoppingCartIdKey = $"shoppingCartId_{request.customerId}";
            var shoppingCartId = _cacheService.Get<Guid>(shoppingCartIdKey);
            if (shoppingCartId == Guid.Empty)
                shoppingCartId = Guid.NewGuid();

            var shoppingCart = _cacheService.GetOrSet(cacheKey, () => _shoppingCartRepository.GetAsync(shoppingCartId), TimeSpan.FromMinutes(5));

            if (shoppingCart is null)
            {
                shoppingCart = ShoppingCart.Create(shoppingCartId,request.customerId, DateTime.Now);
            }
            var product = _productRepository.GetProductByIdAsync(request.productId).Result;
            if (product == null)
            {
                throw new ProductNotFound(request.productId);
            }

            var validRemove = shoppingCart.RemoveFromCart(product);
            if (validRemove)
            {
                ///remove basket if there is no Item
                if (shoppingCart.Items.Count == 0)
                {
                    _shoppingCartRepository.Delete(shoppingCart);
                }

                 _unitOfWork.SaveChanges(cancellationToken);
                _cacheService.GetOrSet(cacheKey, () => shoppingCart, TimeSpan.FromMinutes(5));
            }
            else
                shoppingCart = new ShoppingCart();

            return shoppingCart;
        }
    }
}
