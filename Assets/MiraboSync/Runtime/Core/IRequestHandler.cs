using System.Threading;
using Cysharp.Threading.Tasks;

namespace MiraboSync
{
    public interface IRequestHandler<TResponse>
    {
        UniTask<TResponse> Handle(IRequest<TResponse> request, CancellationToken cancellationToken);
    }
}