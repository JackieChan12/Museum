using UnityEngine;

namespace MiraboSync.View
{
    public class ClientDrawingLine : MonoBehaviour
    {
        public MiraboSync.Colyseus.DrawLine DrawLine => _drawLine;
        private MiraboSync.Colyseus.DrawLine _drawLine;

        public bool IsLocalPlayerDrawing => _isLocalPlayerDrawing;
        private bool _isLocalPlayerDrawing;
        public void Initialize(MiraboSync.Colyseus.DrawLine drawLine, bool isLocalPlayerDrawing = false)
        {
            _drawLine = drawLine;
            _isLocalPlayerDrawing = isLocalPlayerDrawing;
        }
    }
}
