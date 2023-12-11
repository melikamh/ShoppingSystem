using ShoppingSystem.Application.Abstractions.Messaging;
using ShoppingSystem.Application.Exceptions;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Domain.Errors;
using ShoppingSystem.Domain.Repositories;
using ShoppingSystem.Domain.Shared;
using ShoppingSystem.Domain.ValueObjects;
using ShoppingSystem.Infrastructure.Services;
using ShoppingSystem.Persistence.Repositories;

namespace ShoppingSystem.Application.ShoppingCartQueries.GetShoppingCartById
{
    internal sealed class GetShoppingCartByIdQueryHandler
    : IQueryHandler<GetShoppingCartByIdQuery, ShoppingCartResponse>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICacheService _cacheService;
        public GetShoppingCartByIdQueryHandler(IShoppingCartRepository shoppingCartRepository,
             ICacheService cacheService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _cacheService = cacheService;
        }
        public async Task<Result<ShoppingCartResponse>> Handle(
            GetShoppingCartByIdQuery request,
            CancellationToken cancellationToken)
        {
            var shoppingCart = new ShoppingCart();
            var shoppingCartId = new Guid();
            string cacheKey = $"Customer_{request.customerId}";
            string shoppingItemKey = $"ShoppingItem_{request.customerId}";
            string shoppingCartIdKey = $"shoppingCartId_{request.customerId}";
            shoppingCartId = _cacheService.GetOrSet(shoppingCartIdKey, () => shoppingCartId, TimeSpan.FromMinutes(5));
            if (shoppingCartId == Guid.Empty)
            {
                shoppingCart = _shoppingCartRepository.GetByCustomerIdAsync(request.customerId, cancellationToken).Result;
            }


            if (shoppingCart is null)
            {
                throw new ShoppingCartNotFound(shoppingCartId);
            }
            shoppingCartId = _cacheService.GetOrSet(shoppingCartIdKey, () => shoppingCart.Id, TimeSpan.FromMinutes(5));

            shoppingCart = _cacheService.GetOrSet(cacheKey, () => _shoppingCartRepository.GetAsync(shoppingCartId), TimeSpan.FromMinutes(5));


            var response = _cacheService.GetOrSet(shoppingItemKey, () =>
                            new ShoppingCartResponse(
                                shoppingCart.Id,
                                shoppingCart.DateTime,
                                shoppingCart.TotalCost(),
                                 shoppingCart.Items
                                    .Select(item => new ShoppingCartItemResponse(
                                        item.Product.Name,
                                        item.Price,
                                        item.Amount))
                                    .ToList()
                                    ),
                           TimeSpan.FromMinutes(5));

            return response;
        }
    }
}
