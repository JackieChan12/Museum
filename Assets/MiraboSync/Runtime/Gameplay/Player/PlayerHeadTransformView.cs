using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiraboSync.View
{
    public class PlayerHeadTransformView : BasePlayerView
    {
        private Action _unregisterCallback;

        private void Start()
        {
            if (!_clientPlayer.IsLocalPlayer)
            {
                // _transform.localPosition = _clientPlayer.Player.position.ToUnityVector3();
                transform.localRotation = Quaternion.Euler(_clientPlayer.Player.head.rotation.ToUnityVector3());

                //_clientPlayer.Player.position.OnChange(() =>
                //{
                //    _transform.position = _clientPlayer.Player.position.ToUnityVector3();
                //});

                _unregisterCallback = _clientPlayer.Player.head.rotation.OnChange(() =>
                {
                    transform.localRotation = Quaternion.Euler(_clientPlayer.Player.head.rotation.ToUnityVector3());
                });
            }
        }

        private void OnDestroy()
        {
            _unregisterCallback?.Invoke();
        }
    }
}
