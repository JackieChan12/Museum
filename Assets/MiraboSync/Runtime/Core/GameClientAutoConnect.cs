using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MiraboSync
{
    [RequireComponent(typeof(GameClient))]
    public class GameClientAutoConnect : MonoBehaviour
    {

        [SerializeField] private string _serverUrl = "ws://localhost:2567";
        [SerializeField] private GameClient _gameClient;

        private void OnValidate()
        {
            if (_gameClient == null)
            {
                _gameClient = GetComponent<GameClient>();
            }
        }

        private void Start()
        {
            _gameClient.Connect(_serverUrl).Forget();
        }

        private void OnDestroy()
        {
            _gameClient.Disconnect().Forget();
        }
    }
}
