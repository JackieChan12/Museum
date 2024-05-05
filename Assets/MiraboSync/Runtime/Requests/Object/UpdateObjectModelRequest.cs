using UnityEngine.Scripting;

namespace MiraboSync
{
    public class UpdateObjectModelRequest : IRequest<Unit>
    {
        public string objectId;
        public string model;
    }

    [Preserve]
    public class UpdateObjectModelRequestHandler : ColyseusRequestHandler<UpdateObjectModelRequest>
    {
        protected override string RequestEvent => "UPDATE_OBJECT_MODEL";
    }
}
