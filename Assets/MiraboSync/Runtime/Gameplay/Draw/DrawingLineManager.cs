using Cysharp.Threading.Tasks;
using MiraboSync.Colyseus;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;

namespace MiraboSync.View
{
    public class DrawingLineManager : MonoBehaviour
    {
        [SerializeField] private GameClient _gameClient;
        [SerializeField] private GameObject _drawingLinePrefab;
        CompositeDisposable _disposables = new CompositeDisposable();

        Dictionary<string, ClientDrawingLine> _clientDrawingLines = new Dictionary<string, ClientDrawingLine>();

        private void Start()
        {
            _gameClient.State.Subscribe(state =>
            {
                if (state == null)
                {
                    CleanUp();
                }
                else
                {
                    // Loop through all players and instantiate them
                    foreach (var key in state.drawLines.Keys)
                    {
                        var drawingLine = state.drawLines[key] as DrawLine;
                        SpawnDrawingLine((string)key, drawingLine);
                    }

                    // Listen for new players and instantiate them
                    state.drawLines.OnAdd((key, drawingLine) =>
                    {
                        SpawnDrawingLine(key, drawingLine);
                    });

                    // Listen for player removals and destroy them
                    state.drawLines.OnRemove((key, _) =>
                    {
                        DestroyDrawingLine(key);
                    });
                }
            }).AddTo(this);
        }

        void SpawnDrawingLine(string id, DrawLine drawingLine)
        {
            var drawingLineObject = Instantiate(_drawingLinePrefab, UnityEngine.Vector3.zero, Quaternion.identity);
            var drawingLineView = drawingLineObject.GetComponent<ClientDrawingLine>();
            drawingLineView.Initialize(drawingLine, drawingLine.creator == _gameClient.SessionId);

            _clientDrawingLines.Add(id, drawingLineView);
        }

        void DestroyDrawingLine(string id)
        {
            if (_clientDrawingLines.ContainsKey(id))
            {
                Destroy(_clientDrawingLines[id].gameObject);
                _clientDrawingLines.Remove(id);
            }
        }

        void CleanUp()
        {
            foreach (var key in _clientDrawingLines.Keys)
            {
                Destroy(_clientDrawingLines[key].gameObject);
            }

            _clientDrawingLines.Clear();
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }


        string _drawingLine;
        public async UniTask StartDrawingLine(Color color, float size, CancellationToken cancellationToken = default)
        {
            var response = await _gameClient.CommandExecutor.Send(new CreateDrawingLineRequest() { color = color.ToColyseusColor(), size = size });

            if (response != null)
            {
                UnityEngine.Debug.Log($"StartDrawingLine: {response.id}");
            }
            _drawingLine = response.id;
        }

        public async UniTaskVoid UpdateDrawingLine(List<UnityEngine.Vector3> addingPoints)
        {
            if (_drawingLine != null && !string.IsNullOrEmpty(_drawingLine))
            {
                await _gameClient.CommandExecutor.Send(new UpdateDrawingLineRequest { id = _drawingLine, addingPoints = addingPoints });
            }
        }

        public async UniTask EndDrawingLine()
        {
            if (_drawingLine != null && !string.IsNullOrEmpty(_drawingLine))
            {
                await _gameClient.CommandExecutor.Send(new FinishDrawingLineRequest { id = _drawingLine });
                _drawingLine = null;
            }
        }
    }
}
