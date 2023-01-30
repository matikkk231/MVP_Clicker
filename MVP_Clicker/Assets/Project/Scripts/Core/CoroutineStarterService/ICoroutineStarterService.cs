using System;
using System.Collections;
using UnityEngine;

namespace Project.Scripts.Core.CoroutineStarterService
{
    public interface ICoroutineStarterService
    {
        void StartCurrentCoroutine(IEnumerator enumerator);
        void StopCurrentCoroutine(IEnumerator enumerator);
    }
}