using MediatR;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Domain.Shared;

namespace ShoppingSystem.Application.ShoppingCartCommands.RemoveItem
{
    public sealed record RemoveItemCommand(int customerId, int productId) : IRequest<Result<ShoppingCart>>;

}
