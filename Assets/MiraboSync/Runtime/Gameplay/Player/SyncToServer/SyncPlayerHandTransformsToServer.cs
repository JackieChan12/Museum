using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace MiraboSync.View
{
    public class SyncPlayerHandTransformsToServer : MonoBehaviour
    {
        [SerializeField] Transform _leftHandTransform;
        [SerializeField] Transform _rightHandTransform;

        ClientPlayer _clientPlayer;
        GameClient _gameClient;

        private void Start()
        {
            _clientPlayer = GetComponentInParent<ClientPlayer>();
            if (_clientPlayer == null || !_clientPlayer.IsLocalPlayer) return;

            _gameClient = FindObjectOfType<GameClient>();
            this.UpdateAsObservable().Select(_ => (_leftHandTransform.localPosition, _leftHandTransform.localRotation, _rightHandTransform.localPosition, _rightHandTransform.localRotation)).DistinctUntilChanged().Subscribe(item =>
            {
                // Log all hand transforms to server
                // Debug.Log($"Left: {item.Item1}, {item.Item2.eulerAngles}, Right: {item.Item3}, {item.Item4.eulerAngles}");
                _gameClient.CommandExecutor.Send(new PlayerUpdateHandsTransformRequest()
                {
                    left = new ColyseusTransform()
                    {
                        position = item.Item1,
                        rotation = item.Item2.eulerAngles
                    },
                    right = new ColyseusTransform()
                    {
                        position = item.Item3,
                        rotation = item.Item4.eulerAngles
                    }
                });
            }).AddTo(this);
        }
    }
}
