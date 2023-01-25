using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Core.LoadResourcesService
{
    public class LoadResourcesService : ILoadResourcesService
    {
        private readonly Dictionary<string, object> _resources = new();
        private readonly Dictionary<string, int> _callsCounter = new();

        public T Load<T>(string path)
        {
            if (!_callsCounter.ContainsKey(path))
            {
                _callsCounter.Add(path, 0);
            }

            if (_callsCounter[path] == 0)
            {
                object unityObject = Resources.Load(path);
                _resources.Add(path, unityObject);
            }

            _callsCounter[path]++;
            object obj = _resources[path];
            var resource = (T)obj;

            return resource;
        }

        public void Unload(string path)
        {
            if (_callsCounter[path] > 1)
            {
                _callsCounter[path]--;
            }
            else
            {
                object resource = _resources[path];
                Resources.UnloadAsset((Object)resource);
                _callsCounter[path]--;
            }
        }
    }
}