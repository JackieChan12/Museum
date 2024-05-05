using UnityEngine.Scripting;

namespace MiraboSync
{
    public class FinishEdittingObjectRequest : IRequest<Unit>
    {
        public string id;
    }

    [Preserve]
    public class FinishEdittingObjectRequestHandler : ColyseusRequestHandler<FinishEdittingObjectRequest>
    {
        protected override string RequestEvent => "FINISH_EDITING_OBJECT";
    }
}
