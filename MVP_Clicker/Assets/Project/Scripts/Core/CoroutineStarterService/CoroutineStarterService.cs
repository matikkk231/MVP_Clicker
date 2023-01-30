using System.Collections;
using UnityEngine;

namespace Project.Scripts.Core.CoroutineStarterService
{
    public class CoroutineStarterService : MonoBehaviour, ICoroutineStarterService
    {
        public void StartCurrentCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }

        public void StopCurrentCoroutine(IEnumerator enumerator)
        {
            StopCoroutine(enumerator);
        }
    }
}