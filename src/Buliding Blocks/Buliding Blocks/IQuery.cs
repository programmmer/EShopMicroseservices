

using MediatR;

namespace Buliding_Blocks
{
    public   interface IQuery<out TResponse>:IRequest<TResponse>
        where TResponse : notnull
    {
    }
}
