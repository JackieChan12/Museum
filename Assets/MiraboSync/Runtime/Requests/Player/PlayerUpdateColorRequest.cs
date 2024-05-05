using MiraboSync.Colyseus;
using UnityEngine;

namespace MiraboSync
{
    public class PlayerUpdateColorRequest : IRequest<Unit>
    {
        public RGBA color;
    }

    public class PlayerUpdateColorHandler : ColyseusRequestHandler<PlayerUpdateColorRequest>
    {
        protected override string RequestEvent => "PLAYER_UPDATE_COLOR";
    }
}
