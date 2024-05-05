using UnityEngine;

namespace MiraboSync
{
    public class PlayerUpdateHeadTransformRequest : IRequest<Unit>
    {
        public Vector3? position;
        public Vector3? rotation;
    }

    public class PlayerUpdateHeadTransformHandler : ColyseusRequestHandler
        <PlayerUpdateHeadTransformRequest>
    {
        protected override string RequestEvent => "PLAYER_UPDATE_HEAD_TRANSFORM";
    }
}
