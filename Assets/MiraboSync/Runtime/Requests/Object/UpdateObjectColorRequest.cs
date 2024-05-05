using MiraboSync.Colyseus;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class UpdateObjectColorRequest : IRequest<Unit>
    {
        public string objectId;
        public RGBA color;
    }

    [Preserve]
    public class UpdateObjectColorRequestHandler : ColyseusRequestHandler<UpdateObjectColorRequest>
    {
        protected override string RequestEvent => "UPDATE_OBJECT_COLOR";
    }
}
