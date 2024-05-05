using UnityEngine;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class UpdateObjectTransformRequest : IRequest<Unit>
    {
        public string objectId;
        public Vector3? position;
        public Vector3? rotation;
        public Vector3? scale;
    }

    [Preserve]
    public class UpdateObjectTransformRequestHandler : ColyseusRequestHandler<UpdateObjectTransformRequest>
    {
        protected override string RequestEvent => "UPDATE_OBJECT_TRANSFORM";
    }
}
