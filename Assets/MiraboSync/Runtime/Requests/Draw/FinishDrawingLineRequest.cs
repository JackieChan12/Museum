using UnityEngine.Scripting;

namespace MiraboSync
{
    public class FinishDrawingLineRequest : IRequest<Unit>
    {
        public string id;
    }

    [Preserve]
    public class FinishDrawingLineRequestHandler : ColyseusRequestHandler<FinishDrawingLineRequest>
    {
        protected override string RequestEvent => "FINISH_DRAWING_LINE";
    }
}
