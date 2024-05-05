using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiraboSync.View
{
    public class PlayerAvatarView : BasePlayerView
    {
        [SerializeField] GameObject _defaultAvatar;

        Action _unregisterCallback;
        private void Start()
        {
            SpawnAvatar(string.Empty);

            _unregisterCallback = _clientPlayer.Player.OnAvatarIdChange((avatarId, _) =>
            {
                SpawnAvatar(avatarId);
            });
        }

        private void OnDestroy()
        {
            _unregisterCallback?.Invoke();
        }

        GameObject _avatar;

        void SpawnAvatar(string avatarId)
        {
            if (_avatar != null)
            {
                GameObject.Destroy(_avatar);
            }

            Debug.Log($"AvatarId changed to {avatarId}");

            var avatarPrefab = Resources.Load<GameObject>($"Avatar/{avatarId}") ?? _defaultAvatar;
            _avatar = Instantiate(avatarPrefab, transform);
            _avatar.transform.localPosition = Vector3.zero;
            _avatar.transform.localRotation = Quaternion.identity;
        }
    }
}
