namespace MiraboSync
{
    public class PlayerUpdateAvatarRequest : IRequest<Unit>
    {
        public string avatarId;
    }

    public class PlayerUpdateAvatarHandler : ColyseusRequestHandler
        <PlayerUpdateAvatarRequest>
    {
        protected override string RequestEvent => "PLAYER_UPDATE_AVATAR";
    }
}
