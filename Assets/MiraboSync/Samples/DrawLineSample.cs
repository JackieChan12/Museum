using Cysharp.Threading.Tasks;
using MiraboSync.View;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DrawLineSample : MonoBehaviour
{
    private void OnDisable()
    {
        CancelDrawing();
    }

    DrawingLineManager _drawingLineManager;

    private void Start()
    {
        _drawingLineManager = FindObjectOfType<DrawingLineManager>();
    }

    CancellationTokenSource _cancellationTokenSource;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            CancelDrawing();
        }
    }

    void StartDrawing()
    {
        CancelDrawing();
        _cancellationTokenSource = new CancellationTokenSource();
        _ = DrawingAsync(_cancellationTokenSource.Token);
    }

    async UniTask DrawingAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _drawingLineManager.StartDrawingLine(Color.red, 1f, cancellationToken);

            Vector3? lastPosition = null;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                var position = Camera.main.ScreenToWorldPoint(mousePosition);
                if (lastPosition == null || lastPosition.Value != position)
                {
                    lastPosition = position;
                    _ = _drawingLineManager.UpdateDrawingLine(new List<Vector3>() { position });
                }

                await UniTask.Yield();
            }
        }
        finally
        {
            await _drawingLineManager.EndDrawingLine();
        }
    }

    void CancelDrawing()
    {
        if (_cancellationTokenSource != null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }
    }
}
