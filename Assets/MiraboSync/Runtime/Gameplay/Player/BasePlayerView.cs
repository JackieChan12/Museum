using MiraboSync.Colyseus;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace MiraboSync.View
{
    public abstract class BasePlayerView : MonoBehaviour
    {
        protected ClientPlayer _clientPlayer;

        protected virtual void Awake()
        {
            _clientPlayer = GetComponentInParent<ClientPlayer>();
            if (_clientPlayer == null)
            {
                UnityEngine.Debug.LogWarning($"ClientPlayer not found in parent of {gameObject.name}");
            }
        }
    }
}
