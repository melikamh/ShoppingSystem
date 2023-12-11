using MediatR;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Domain.Shared;

namespace ShoppingSystem.Application.ShoppingCartCommands.CreateItem
{
    public sealed record CreateItemCommand(int customerId,int productId,int amount) : IRequest<Result<ShoppingCart>>;
}
