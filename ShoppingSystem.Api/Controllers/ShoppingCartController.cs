using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Api.DTO;
using ShoppingSystem.API.Abstractions;
using ShoppingSystem.Application.ShoppingCartCommands.CreateItem;
using ShoppingSystem.Application.ShoppingCartCommands.RemoveItem;
using ShoppingSystem.Application.ShoppingCartQueries.GetShoppingCartById;
using ShoppingSystem.Domain.Entities;
using ShoppingSystem.Domain.Shared;

namespace ShoppingSystem.API.Controllers
{
    [Route("/ShoppingCart/Item")]
    public sealed class ShoppingCartController : ApiController
    {

        public ShoppingCartController(ISender sender)
            : base(sender)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetConferenceById(
           
            CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetShoppingCartByIdQuery(CustomerId);

                Result<ShoppingCartResponse> response = await Sender.Send(
                    query,
                    cancellationToken);

                return response.IsSuccess
                    ? Ok(response.Value)
                    : NotFound(response.Error);
            }
            catch (Exception)
            {
                return 
                   NotFound("");

            }
            
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] ItemDTO item,

            CancellationToken cancellationToken)
        {
            try
            {
                var command = new CreateItemCommand(CustomerId,item.ProductId,item.Amount);

                Result<ShoppingCart> response = await Sender.Send(command,cancellationToken);

                return response.IsSuccess
                    ? Ok(response.Value)
                    : NotFound(response.Error);
            }
            catch (Exception ex)
            {
                return
                   NotFound("");

            }

        }

        [HttpDelete]
  
        public async Task<IActionResult> updateAmount([FromBody] ItemDTO item,

            CancellationToken cancellationToken)
        {
            try
            {
                var command = new RemoveItemCommand(CustomerId, item.ProductId);

                Result<ShoppingCart> response = await Sender.Send(command, cancellationToken);

                return response.IsSuccess
                    ? Ok(response.Value)
                    : NotFound(response.Error);
            }
            catch (Exception)
            {
                return
                   NotFound("");

            }

        }
    }

}
