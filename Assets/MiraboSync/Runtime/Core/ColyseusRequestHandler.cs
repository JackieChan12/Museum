using Colyseus;
using Cysharp.Threading.Tasks;
using MiraboSync.Colyseus;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MiraboSync
{
    public abstract class ColyseusRequestHandler<TRequest, TResponse> : IColyseusRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected abstract string RequestEvent { get; }
        protected abstract string ResponseEvent { get; }

        public delegate void ResponseCallback(string error, TResponse data);
        Dictionary<ulong, ResponseCallback> _callbacks = new Dictionary<ulong, ResponseCallback>();
        ulong _nextId = 0;

        ColyseusRoom<SyncRoomState> _room;

        public void Register(ColyseusRoom<SyncRoomState> room)
        {
            _room = room;
            _room.OnMessage<CommandResponse>(ResponseEvent, HandleCommandResponse);
        }

        public async UniTask<TResponse> Handle(IRequest<TResponse> request, CancellationToken cancellationToken)
        {
            var id = ++_nextId;
            var utcs = new TaskCompletionSource<TResponse>();

            RegisterForCallback(id, (error, data) =>
            {
                if (error != null)
                {
                    utcs.SetException(new Exception(error));
                }
                else
                {
                    utcs.SetResult(data);
                }
            });

            _ = _room.Send(RequestEvent, new { payload = request, cid = id });

            return await utcs.Task;
        }

        void HandleCallback(ulong id, string error, TResponse data)
        {
            if (_callbacks.TryGetValue(id, out var callback))
            {
                callback(error, data);
                _callbacks.Remove(id);
            }
        }

        void RegisterForCallback(ulong id, ResponseCallback callback)
        {
            _callbacks.Add(id, callback);
        }

        void HandleCommandResponse(CommandResponse response)
        {
            if (response != null)
            {
                HandleCallback(response.cid, response.error, response.payload);
            }
        }

        public class CommandResponse
        {
            public ulong cid;
            public string error;
            public TResponse payload;
        }
    }

    public abstract class ColyseusRequestHandler<TRequest> : IColyseusRequestHandler<TRequest, Unit> where TRequest : IRequest<Unit>
    {
        protected abstract string RequestEvent { get; }
        ColyseusRoom<SyncRoomState> _room;

        public UniTask<Unit> Handle(IRequest<Unit> request, CancellationToken cancellationToken)
        {
            _ = _room.Send(RequestEvent, new { payload = request });
            return UniTask.FromResult(Unit.Default);
        }

        public void Register(ColyseusRoom<SyncRoomState> room)
        {
            _room = room;
        }
    }

    public interface IColyseusRequestHandler
    {
        void Register(ColyseusRoom<SyncRoomState> room);
    }

    public interface IColyseusRequestHandler<TRequest, TResponse> : IColyseusRequestHandler, IRequestHandler<TResponse>
    {

    }
}
