
using MediatR;

namespace Buliding_Blocks
{
    public  interface ICommand<out TResponse> :IRequest<TResponse>
    {
    }

    public interface ICommand : ICommand<Unit>
    {
    }
}
