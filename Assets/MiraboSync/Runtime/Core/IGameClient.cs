using Cysharp.Threading.Tasks;
using System.Threading;

namespace MiraboSync
{
    public interface IGameClient
    {
        UniTask Connect(string serverUrl);
        UniTask Disconnect();
    }
}
