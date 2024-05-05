using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiraboSync.View
{
    public class PlayerColorView : BasePlayerView
    {
        [SerializeField] MeshRenderer[] _meshRenderers;

        Action _unregisterCabllback;
        private void Start()
        {
            UpdateColor();
            _unregisterCabllback = _clientPlayer.Player.color.OnChange(() =>
            {
                UpdateColor();
            });
        }

        private void OnDestroy()
        {
            _unregisterCabllback?.Invoke();
        }

        private void UpdateColor()
        {
            var color = _clientPlayer.Player.color.ToUnityColor();
            foreach (var meshRenderer in _meshRenderers)
            {
                meshRenderer.material.color = color;
            }
        }
    }
}
