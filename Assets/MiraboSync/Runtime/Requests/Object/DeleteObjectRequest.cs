using UnityEngine.Scripting;

namespace MiraboSync
{
    public class DeleteObjectRequest : IRequest<DeleteObjectResponse>
    {
        public string id;
    }

    public class DeleteObjectResponse
    {

    }

    [Preserve]
    public class DeleteObjectHandler : ColyseusRequestHandler<DeleteObjectRequest, DeleteObjectResponse>
    {
        protected override string RequestEvent => "DELETE_OBJECT";
        protected override string ResponseEvent => "DELETE_OBJECT_RESPONSE";
    }
}
