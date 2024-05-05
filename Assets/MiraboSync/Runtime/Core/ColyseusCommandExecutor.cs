using Colyseus;
using Cysharp.Threading.Tasks;
using MiraboSync.Colyseus;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MiraboSync
{
    public class ColyseusCommandExecutor : ICommandExecutor
    {
        ColyseusRoom<SyncRoomState> _room;

        Dictionary<Type, object> _handlers = new Dictionary<Type, object>();

        public ColyseusCommandExecutor(ColyseusRoom<SyncRoomState> room)
        {
            _room = room;

            foreach (var type in typeof(ColyseusCommandExecutor).Assembly.GetTypes())
            {
                if (!type.IsAbstract && (typeof(IColyseusRequestHandler)).IsAssignableFrom(type))
                {
                    // UnityEngine.Debug.Log($"Registering {type.Name}");

                    var handler = Activator.CreateInstance(type);
                    var method = type.GetMethod("Register");
                    method.Invoke(handler, new object[] { _room });

                    foreach (var t in type.GetInterfaces())
                    {
                        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IColyseusRequestHandler<,>))
                        {
                            var requestType = t.GetGenericArguments()[0];
                            _handlers.Add(requestType, handler);

                            // UnityEngine.Debug.Log($"Registered {requestType.Name} to {type.Name}");
                        }
                    }
                }
            }
        }

        public async UniTask<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            if (_handlers.TryGetValue(request.GetType(), out var handler))
            {
                return await ((IRequestHandler<TResponse>)handler).Handle(request, cancellationToken);
            }

            throw new Exception($"No handler for {request.GetType().Name}");
        }
    }
}
