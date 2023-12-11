using Event_Planner.Application.Abstractions.Messaging;
using ShoppingSystem.Domain.Shared;
using MediatR;


namespace ShoppingSystem.Application.Abstractions.Messaging
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
     where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }

}
