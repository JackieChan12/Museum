using UnityEngine;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class PlayerUpdateTransformRequest : IRequest<Unit>
    {
        public Vector3? position;
        public Vector3? rotation;
    }

    [Preserve]
    public class PlayerUpdateTransformHandler : ColyseusRequestHandler<PlayerUpdateTransformRequest>
    {
        protected override string RequestEvent => "PLAYER_UPDATE_TRANSFORM";
    }
}
