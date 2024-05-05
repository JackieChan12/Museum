using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiraboSync.View
{
    public class PlayerHandsView : BasePlayerView
    {
        [SerializeField] Transform _leftHandTransform;
        [SerializeField] Transform _rightHandTransform;

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
                _leftHandTransform.localPosition = _clientPlayer.Player.hands.left.transform.position.ToUnityVector3();
                _leftHandTransform.localRotation = Quaternion.Euler(_clientPlayer.Player.hands.left.transform.rotation.ToUnityVector3());
                _rightHandTransform.localPosition = _clientPlayer.Player.hands.right.transform.position.ToUnityVector3();
                _rightHandTransform.localRotation = Quaternion.Euler(_clientPlayer.Player.hands.right.transform.rotation.ToUnityVector3());

                _unregisterCallbacks.Add(_clientPlayer.Player.hands.left.transform.position.OnChange(() =>
                {
                    _leftHandTransform.localPosition = _clientPlayer.Player.hands.left.transform.position.ToUnityVector3();
                }));

                _unregisterCallbacks.Add(_clientPlayer.Player.hands.left.transform.rotation.OnChange(() =>
                {
                    _leftHandTransform.localRotation = Quaternion.Euler(_clientPlayer.Player.hands.left.transform.rotation.ToUnityVector3());
                }));

                _unregisterCallbacks.Add(_clientPlayer.Player.hands.right.transform.position.OnChange(() =>
                {
                    _rightHandTransform.localPosition = _clientPlayer.Player.hands.right.transform.position.ToUnityVector3();
                }));

                _unregisterCallbacks.Add(_clientPlayer.Player.hands.right.transform.rotation.OnChange(() =>
                {
                    _rightHandTransform.localRotation = Quaternion.Euler(_clientPlayer.Player.hands.right.transform.rotation.ToUnityVector3());
                }));
            }
        }
    }
}
