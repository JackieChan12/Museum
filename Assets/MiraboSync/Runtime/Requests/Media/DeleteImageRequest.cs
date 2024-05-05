using UnityEngine.Scripting;

namespace MiraboSync
{
    public class DeleteImageRequest : IRequest<DeleteImageResponse>
    {
        public string id;
    }


    public class DeleteImageResponse
    {

    }

    [Preserve]
    public class DeleteImageRequestHandler : ColyseusRequestHandler<DeleteImageRequest, DeleteImageResponse>
    {
        protected override string RequestEvent => "DELETE_IMAGE";
        protected override string ResponseEvent => "DELETE_IMAGE_RESPONSE";
    }
}
