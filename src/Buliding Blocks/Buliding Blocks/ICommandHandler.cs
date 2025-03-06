using MediatR;


namespace Buliding_Blocks
{

    public interface ICommandHandler<in TCommand>: IRequestHandler<TCommand, Unit>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult>:IRequestHandler<TCommand, TResult>
        where TCommand: ICommand<TResult>
        where TResult : notnull
    {
    }
}
