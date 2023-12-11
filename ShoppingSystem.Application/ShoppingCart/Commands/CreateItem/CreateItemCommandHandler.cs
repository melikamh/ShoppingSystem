using ShoppingSystem.Domain.Repositories;
using MediatR;
using ShoppingSystem.Persistence.Repositories;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Infrastructure.Services;
using ShoppingSystem.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace ShoppingSystem.Application.ShoppingCartCommands.CreateItem
{
    internal sealed class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Result<ShoppingCart>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        private readonly ILogger<CreateItemCommandHandler> _logger;

        public CreateItemCommandHandler(
            IShoppingCartRepository shoppingCartRepository,
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            ILogger<CreateItemCommandHandler> logger,
            ICacheService cacheService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<Result<ShoppingCart>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            string cacheKey = $"Customer_{request.customerId}";
            string shoppingCartIdKey = $"shoppingCartId_{request.customerId}";
            var shoppingCartId = _cacheService.Get<Guid>(shoppingCartIdKey);
            if (shoppingCartId == Guid.Empty)
                shoppingCartId = Guid.NewGuid();

            var shoppingCart = _cacheService.GetOrSet(cacheKey, () => _shoppingCartRepository.GetAsync(shoppingCartId), TimeSpan.FromMinutes(5));

            if (shoppingCart is null)
            {
                shoppingCart = ShoppingCart.Create(shoppingCartId, request.customerId, DateTime.Now);
                _unitOfWork.SaveChanges();
            }
            var product = _productRepository.GetProductByIdAsync(request.productId).Result;
            shoppingCart.AddItem(product, request.amount);

             _unitOfWork.SaveChanges();
            _cacheService.GetOrSet(cacheKey, () => shoppingCart, TimeSpan.FromMinutes(5));
            return shoppingCart;
        }
    }
}
