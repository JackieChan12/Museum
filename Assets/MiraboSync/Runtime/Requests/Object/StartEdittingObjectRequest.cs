using UnityEngine.Scripting;

namespace MiraboSync
{
    public class StartEdittingObjectRequest : IRequest<StartEdittingObjectResponse>
    {
        public string id;
    }

    public class StartEdittingObjectResponse
    {
        public string id;
    }

    [Preserve]
    public class StartEdittingObjectRequestHandler : ColyseusRequestHandler<StartEdittingObjectRequest, StartEdittingObjectResponse>
    {
        protected override string RequestEvent => "START_EDITING_OBJECT";
        protected override string ResponseEvent => "START_EDITING_OBJECT_RESPONSE";
    }
}
