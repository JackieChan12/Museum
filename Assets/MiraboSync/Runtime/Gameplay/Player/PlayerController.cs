using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiraboSync.View
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _speed = 5f;
        [SerializeField] ClientPlayer _clientPlayer;

        private void OnValidate()
        {
            if (_clientPlayer == null)
                _clientPlayer = GetComponent<ClientPlayer>();
        }

        private void Start()
        {
            if (_clientPlayer == null || !_clientPlayer.IsLocalPlayer)
            {
                enabled = false;
            }
        }

        private void Update()
        {
            Vector2 moveVector = Vector2.zero;

            // Move up down left right with arrow keys
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                moveVector += Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                moveVector += Vector2.down;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                moveVector += Vector2.left;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                moveVector += Vector2.right;
            }

            if (moveVector != Vector2.zero)
            {
                var moveVector3 = new Vector3(moveVector.x, 0, moveVector.y);
                transform.rotation = Quaternion.LookRotation(moveVector3, Vector3.up);
                transform.Translate(moveVector3.normalized * _speed * Time.deltaTime, Space.World);
            }
        }
    }
}
