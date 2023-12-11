using ShoppingSystem.Domain.Entities;

namespace ShoppingSystem.Application.ShoppingCartQueries.GetShoppingCartById
{
    public sealed record ShoppingCartResponse(
        Guid ShoppingCartId,
        DateTime dateTim,
        int TotalCost,
        IReadOnlyCollection<ShoppingCartItemResponse> Items
     );
}