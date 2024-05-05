using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiraboSync.View
{
    public class DrawingLineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _width = 0.1f;

        [SerializeField] ClientDrawingLine _clientDrawingLine;

        private void Start()
        {
            _updateColorRegister = _clientDrawingLine.DrawLine.color.OnChange(UpdateColor);
            UpdateColor();

            _updateSizeRegister = _clientDrawingLine.DrawLine.OnSizeChange((size, prev) =>
            {
                UpdateSize();
            });
            UpdateSize();

            _updatePointsRegister = _clientDrawingLine.DrawLine.points.OnChange((i, v) => UpdatePoint(i, v.ToUnityVector3()));
            UpdatePoints();
        }

        Action _updateColorRegister;
        void UpdateColor()
        {
            // Log color of the line
            var color = _clientDrawingLine.DrawLine.color.ToUnityColor();
            _lineRenderer.startColor = color;
            _lineRenderer.endColor = color;
        }

        Action _updateSizeRegister;
        void UpdateSize()
        {
            _lineRenderer.startWidth = _width * _clientDrawingLine.DrawLine.size;
            _lineRenderer.endWidth = _width * _clientDrawingLine.DrawLine.size;
        }


        Action _updatePointsRegister;
        void UpdatePoints()
        {
            var items = _clientDrawingLine.DrawLine.points.items;
            if (items.Count > 0)
            {
                _lineRenderer.positionCount = items.Count;
                _lineRenderer.SetPositions(items.Select(item => item.Value.ToUnityVector3()).ToArray());
            }
        }

        void UpdatePoint(int i, Vector3 value)
        {
            _lineRenderer.positionCount += 1;
            _lineRenderer.SetPosition(i, value);
        }

        private void OnDestroy()
        {
            _updateColorRegister?.Invoke();
            _updateSizeRegister?.Invoke();
            _updatePointsRegister?.Invoke();
        }
    }
}
