using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiraboSync
{
    public interface IRequest
    {

    }

    public interface IRequest<out TResponse> : IRequest
    {

    }
}
