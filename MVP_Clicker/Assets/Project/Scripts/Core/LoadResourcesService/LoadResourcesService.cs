using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Core.LoadResourcesService
{
    public class LoadResourcesService : ILoadResourcesService
    {
        private readonly Dictionary<string, Object> _resources = new();
        private readonly Dictionary<string, int> _callsCounter = new();

        public T Load<T>(string path)
        {
            T resource;
            if (!_callsCounter.ContainsKey(path))
            {
                _callsCounter.Add(path, 0);
            }

            if (_callsCounter[path] == 0)
            {
                object obj = Resources.Load(path);
                Object unityObject = (Object)obj;
                _resources.Add(path, unityObject);
                resource = (T)obj;
                _callsCounter[path]++;
                return resource;
            }
            else
            {
                _callsCounter[path]++;
                object obj = _resources[path];
                resource = (T)obj;
                return resource;
            }
        }

        public void Unload(string path)
        {
            if (_callsCounter[path] > 1)
            {
                _callsCounter[path]--;
            }
            else
            {
                Object resource = _resources[path];
                Resources.UnloadAsset(resource);
                _callsCounter[path]--;
            }
        }
    }
}