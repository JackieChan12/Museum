using UnityEngine;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class CreateVideoRequest : IRequest<CreateVideoResponse>
    {
        public string uri;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }

    public class CreateVideoResponse
    {
        public string id;
    }

    [Preserve]
    public class CreateVideoRequestHandler : ColyseusRequestHandler<CreateVideoRequest, CreateVideoResponse>
    {
        protected override string RequestEvent => "CREATE_VIDEO";
        protected override string ResponseEvent => "CREATE_VIDEO_RESPONSE";
    }
}
