using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class UpdateDrawingLineRequest : IRequest<Unit>
    {
        public string id;
        public List<Vector3> addingPoints;
    }

    [Preserve]
    public class UpdateDrawingLineRequestHandler : ColyseusRequestHandler<UpdateDrawingLineRequest>
    {
        protected override string RequestEvent => "UPDATE_DRAWING_LINE";
    }
}
