using ShoppingSystem.Domain.Shared;
using MediatR;

namespace Event_Planner.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
