using UnityEngine.Scripting;

namespace MiraboSync
{
    public class DeleteVideoRequest : IRequest<DeleteVideoResponse>
    {
        public string id;
    }

    public class DeleteVideoResponse
    {

    }

    [Preserve]
    public class DeleteVideoRequestHandler : ColyseusRequestHandler<DeleteVideoRequest, DeleteVideoResponse>
    {
        protected override string RequestEvent => "DELETE_VIDEO";
        protected override string ResponseEvent => "DELETE_VIDEO_RESPONSE";
    }
}
