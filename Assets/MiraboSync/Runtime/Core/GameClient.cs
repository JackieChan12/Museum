using Colyseus;
using Cysharp.Threading.Tasks;
using MiraboSync.Colyseus;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MiraboSync
{
    public class GameClient : MonoBehaviour, IGameClient
    {
        public ICommandExecutor CommandExecutor => _commandExecutor;
        private ICommandExecutor _commandExecutor;

        ColyseusRoom<SyncRoomState> _room;
        public IReadOnlyReactiveProperty<SyncRoomState> State => _state;
        private ReactiveProperty<SyncRoomState> _state = new ReactiveProperty<SyncRoomState>();

        public string SessionId => _room.SessionId;

        public async UniTask Connect(string serverUrl)
        {
            var client = new ColyseusClient(serverUrl);
            _room = await client.JoinOrCreate<SyncRoomState>("SyncRoom", new Dictionary<string, object>(), new Dictionary<string, string>());
            _room.OnError += OnError;
            _commandExecutor = new ColyseusCommandExecutor(_room);
            _state.Value = _room.State;

            _room.State.OnChange(() =>
            {
                // Logs state as json
                Debug.Log(Newtonsoft.Json.JsonConvert.SerializeObject(_room.State));
            });

            Debug.LogError("Joined");
        }

        public async UniTask Disconnect()
        {
            _commandExecutor = null;
            _state.Value = null;

            if (_room == null)
            {
                return;
            }
            _room.OnError -= OnError;
            await _room.Leave();
        }

        // OnError
        private void OnError(int code, string message)
        {
            // Logs the error
            Debug.LogError($"Error {code}: {message}");
        }
    }
}
