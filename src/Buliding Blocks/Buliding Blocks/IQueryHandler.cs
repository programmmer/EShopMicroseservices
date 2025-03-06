using MediatR;


namespace Buliding_Blocks
{
    public interface IQueryHandler<in TRequest, TResult>:IRequestHandler<TRequest, TResult>
        where TRequest : IQuery<TResult>
        where TResult : notnull
    {
        
    }
    
    
}
