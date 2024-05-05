using MiraboSync.Colyseus;
using UnityEngine;

namespace MiraboSync
{
    public class PlayerUpdateHandsTransformRequest : IRequest<Unit>
    {
        public ColyseusTransform? left;
        public ColyseusTransform? right;
    }

    public class PlayerUpdateHandsTransformHandler : ColyseusRequestHandler
        <PlayerUpdateHandsTransformRequest>
    {
        protected override string RequestEvent => "PLAYER_UPDATE_HANDS_TRANSFORM";
    }
}
