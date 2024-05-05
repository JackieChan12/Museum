using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace MiraboSync
{
    public class CreateObjectRequest
        : IRequest<CreateObjectResponse>
    {
        public string model;
        public Vector3 position;
    }

    public class CreateObjectResponse
    {
        public string id;
    }

    [Preserve]
    public class CreateObjectHandler : ColyseusRequestHandler<CreateObjectRequest, CreateObjectResponse>
    {
        protected override string RequestEvent => "CREATE_OBJECT";
        protected override string ResponseEvent => "CREATE_OBJECT_RESPONSE";
    }
}
