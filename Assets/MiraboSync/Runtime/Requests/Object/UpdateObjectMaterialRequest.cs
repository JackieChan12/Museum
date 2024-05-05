using UnityEngine.Scripting;

namespace MiraboSync
{
    public class UpdateObjectMaterialRequest : IRequest<Unit>
    {
        public string objectId;
        public string material;
    }

    [Preserve]
    public class UpdateObjectMaterialRequestHandler : ColyseusRequestHandler<UpdateObjectMaterialRequest>
    {
        protected override string RequestEvent => "UPDATE_OBJECT_MATERIAL";
    }
}
