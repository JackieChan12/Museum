using UnityEngine;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class UpdateVideoRequest : IRequest<Unit>
    {
        public string id;
        public string? uri;
        public Vector3? position;
        public Vector3? rotation;
        public Vector3? scale;
    }

    [Preserve]
    public class UpdateVideoRequestHandler : ColyseusRequestHandler<UpdateVideoRequest>
    {
        protected override string RequestEvent => "UPDATE_VIDEO";
    }
}
