using ShoppingSystem.Domain.Entities;

namespace ShoppingSystem.Application.ShoppingCartQueries.GetShoppingCartById
{
    public sealed record ShoppingCartItemResponse(
        string productName,
        int Price,
        int Amont
       
     );
}