using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using MiraboSync.Colyseus;

namespace MiraboSync.View
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private GameClient _gameClient;
        [SerializeField] private GameObject _playerPrefab;
        CompositeDisposable _disposables = new CompositeDisposable();

        Dictionary<string, ClientPlayer> _clientPlayers = new Dictionary<string, ClientPlayer>();

        private void Start()
        {
            _gameClient.State.Subscribe(state =>
            {
                if (state == null)
                {
                    CleanUp();
                }
                else
                {
                    // Loop through all players and instantiate them
                    foreach (var key in state.players.Keys)
                    {
                        var player = state.players[key] as Player;
                        SpawnPlayer((string)key, player);
                    }

                    // Listen for new players and instantiate them
                    state.players.OnAdd((key, player) =>
                    {
                        SpawnPlayer(key, player);
                    });

                    // Listen for player removals and destroy them
                    state.players.OnRemove((key, _) =>
                    {
                        DestroyPlayer(key);
                    });
                }
            }).AddTo(this);
        }

        private void SpawnPlayer(string id, Player player)
        {
            var playerObject = Instantiate(_playerPrefab, player.position.ToUnityVector3(), Quaternion.Euler(player.rotation.ToUnityVector3()));
            var playerView = playerObject.GetComponent<ClientPlayer>();
            // Logs currentClientId and player id
            // Debug.LogError($"Current Client Id: {_gameClient.SessionId}, Player Id: {id}");
            playerView.Initialize(player, player.currentClientId == _gameClient.SessionId);

            _clientPlayers.Add(id, playerView);
        }

        void DestroyPlayer(string id)
        {
            if (_clientPlayers.ContainsKey(id))
            {
                Destroy(_clientPlayers[id].gameObject);
                _clientPlayers.Remove(id);
            }
        }

        void CleanUp()
        {
            _disposables.Clear();

            foreach (var key in _clientPlayers.Keys)
            {
                var playerObject = _clientPlayers[key];
                Destroy(playerObject);
            }

            _clientPlayers.Clear();
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}