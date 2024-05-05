using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace MiraboSync.View
{
    public class SyncPlayerTransformToServer : MonoBehaviour
    {
        ClientPlayer _clientPlayer;
        GameClient _gameClient;

        UnityEngine.Transform _transform;
        private void Start()
        {
            _transform = GetComponent<UnityEngine.Transform>();
            _clientPlayer = GetComponent<ClientPlayer>();
            _gameClient = FindObjectOfType<GameClient>();

            if (_clientPlayer != null && _clientPlayer.IsLocalPlayer)
            {
                this.UpdateAsObservable().Select(_ => (_transform.position, _transform.rotation)).DistinctUntilChanged().Subscribe(item =>
                {
                    _gameClient.CommandExecutor.Send(new PlayerUpdateTransformRequest()
                    {
                        position = item.position,
                        rotation = item.rotation.eulerAngles
                    });
                }).AddTo(this);
            }
        }
    }
}
