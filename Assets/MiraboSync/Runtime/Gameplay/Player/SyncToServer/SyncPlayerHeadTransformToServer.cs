using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace MiraboSync.View
{
    public class SyncPlayerHeadTransformToServer : MonoBehaviour
    {
        ClientPlayer _clientPlayer;
        GameClient _gameClient;

        UnityEngine.Transform _transform;
        private void Start()
        {
            _transform = transform;
            _clientPlayer = GetComponentInParent<ClientPlayer>();
            _gameClient = FindObjectOfType<GameClient>();

            if (_clientPlayer != null && _clientPlayer.IsLocalPlayer)
            {
                this.UpdateAsObservable().Select(_ => _transform.localRotation).DistinctUntilChanged().Subscribe(localRotation =>
                {
                    _gameClient.CommandExecutor.Send(new PlayerUpdateHeadTransformRequest()
                    {
                        rotation = localRotation.eulerAngles
                    });
                }).AddTo(this);
            }
        }
    }
}
