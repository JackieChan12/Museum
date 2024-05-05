namespace MiraboSync
{
    public class PlayerUpdateHandStateRequest : IRequest<Unit>
    {
        public int handIndex;
        public string state;
    }

    public class PlayerUpdateHandStateRequestHandler : ColyseusRequestHandler<PlayerUpdateHandStateRequest>
    {
        protected override string RequestEvent => "PLAYER_UPDATE_HAND_STATE";
    }
}
