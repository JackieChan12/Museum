using UnityEngine;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class CreateImageRequest : IRequest<CreateImageResponse>
    {
        public string uri;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }

    public class CreateImageResponse
    {
        public string id;
    }

    [Preserve]
    public class CreateImageRequestHandler : ColyseusRequestHandler<CreateImageRequest, CreateImageResponse>
    {
        protected override string RequestEvent => "CREATE_IMAGE";
        protected override string ResponseEvent => "CREATE_IMAGE_RESPONSE";

    }
}
