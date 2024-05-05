using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiraboSync.View
{
    public class PlayerTransformView : BasePlayerView
    {
        UnityEngine.Transform _transform;

        private List<Action> _unregisterCallbacks = new List<Action>();
        private void OnDestroy()
        {
            foreach (var unregisterCallback in _unregisterCallbacks)
            {
                unregisterCallback?.Invoke();
            }

            _unregisterCallbacks.Clear();
        }


        private void Start()
        {
            if (!_clientPlayer.IsLocalPlayer)
            {
                _transform = transform;

                _transform.position = _clientPlayer.Player.position.ToUnityVector3();
                _transform.rotation = Quaternion.Euler(_clientPlayer.Player.rotation.ToUnityVector3());

                _unregisterCallbacks.Add(_clientPlayer.Player.position.OnChange(() =>
                {
                    _transform.position = _clientPlayer.Player.position.ToUnityVector3();
                }));

                _unregisterCallbacks.Add(_clientPlayer.Player.rotation.OnChange(() =>
                {
                    _transform.rotation = Quaternion.Euler(_clientPlayer.Player.rotation.ToUnityVector3());
                }));
            }
        }
    }
}
