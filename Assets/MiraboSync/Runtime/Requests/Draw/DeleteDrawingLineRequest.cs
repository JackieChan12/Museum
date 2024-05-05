using UnityEngine.Scripting;

namespace MiraboSync
{
    public class DeleteDrawingLineRequest : IRequest<Unit>
    {
        public string id;
    }

    [Preserve]
    public class DeleteDrawingLineRequestHandler : ColyseusRequestHandler<DeleteDrawingLineRequest>
    {
        protected override string RequestEvent => "DELETE_DRAWING_LINE";
    }
}
