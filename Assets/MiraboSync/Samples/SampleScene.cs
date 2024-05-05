using Colyseus;
using MiraboSync;
using MiraboSync.Colyseus;
using MiraboSync.View;
using System.Collections.Generic;
using UnityEngine;

public class SampleScene : MonoBehaviour
{
    [SerializeField] GameClient _gameClient;

    public void UpdatePlayerAvatar(string avatarId)
    {
        _gameClient.CommandExecutor.Send(new PlayerUpdateAvatarRequest() { avatarId = avatarId });
    }

    [SerializeField] string[] _avatarIds;

    int _avatarIndex = 0;
    [ContextMenu("TestUpdatePlayerAvatar")]
    public void TestUpdatePlayerAvatar()
    {
        if (_avatarIds != null && _avatarIds.Length > 0)
        {
            var avatarId = _avatarIds[++_avatarIndex % _avatarIds.Length];
            UpdatePlayerAvatar(avatarId);
        }
    }

    public void UpdatePlayerColor(Color color)
    {
        _gameClient.CommandExecutor.Send(new PlayerUpdateColorRequest() { color = color.ToColyseusColor() });
    }

    [ContextMenu("TestUpdatePlayerColor")]
    public void TestUpdatePlayerColor()
    {
        var color = new Color(Random.value, Random.value, Random.value);
        UpdatePlayerColor(color);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TestUpdatePlayerColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TestUpdatePlayerAvatar();
        }
    }
}
