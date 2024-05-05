using MiraboSync.Colyseus;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class CreateDrawingLineRequest : IRequest<CreateDrawingLineResponse>
    {
        public RGBA? color;
        public float? size;
        public string? style;
        public List<Vector3>? points;
    }

    public class CreateDrawingLineResponse
    {
        public string id;
    }

    [Preserve]
    public class CreateDrawingLineRequestHandler : ColyseusRequestHandler<CreateDrawingLineRequest, CreateDrawingLineResponse>
    {
        protected override string RequestEvent => "CREATE_DRAWING_LINE";
        protected override string ResponseEvent => "CREATE_DRAWING_LINE_RESPONSE";
    }
}
