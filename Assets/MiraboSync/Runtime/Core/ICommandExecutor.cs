using System.Threading;
using Cysharp.Threading.Tasks;

namespace MiraboSync
{
    
    public interface ICommandExecutor
    {
        UniTask<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
