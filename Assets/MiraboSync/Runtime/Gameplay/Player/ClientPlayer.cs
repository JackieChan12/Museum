using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MiraboSync.View
{
    public class ClientPlayer : MonoBehaviour
    {
        public MiraboSync.Colyseus.Player Player => _player;
        private MiraboSync.Colyseus.Player _player;
        public bool IsLocalPlayer => _isLocalPlayer;
        [SerializeField] private bool _isLocalPlayer;

        public void Initialize(MiraboSync.Colyseus.Player player, bool isLocalPlayer = false)
        {
            _player = player;
            _isLocalPlayer = isLocalPlayer;
        }
    }
}
