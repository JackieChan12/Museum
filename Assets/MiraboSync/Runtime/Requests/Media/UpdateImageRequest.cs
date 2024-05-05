using UnityEngine;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class UpdateImageRequest : IRequest<Unit>
    {
        public string id;
        public string? uri;
        public Vector3? position;
        public Vector3? rotation;
        public Vector3? scale;
    }

    [Preserve]
    public class UpdateImageRequestHandler : ColyseusRequestHandler<UpdateImageRequest>
    {
        protected override string RequestEvent => "UPDATE_IMAGE";
    }
}
