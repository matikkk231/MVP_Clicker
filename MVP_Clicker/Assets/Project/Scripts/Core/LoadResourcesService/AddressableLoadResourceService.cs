using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Project.Scripts.Core.LoadResourcesService
{
    public class AddressableLoadResourceService : ILoadResourcesService
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
                _callsCounter[path]++;
                var asset = Addressables.LoadAssetAsync<T>(path);
                asset.WaitForCompletion();
                object obj = (object)asset.Result;
                _resources.Add(path, obj);
                return (T)asset.Result;
            }
            else
            {
                _callsCounter[path]++;
                object obj = _resources[path];
                var resource = (T)obj;
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
                object resource = _resources[path];
                Addressables.Release(resource);
                _callsCounter[path]--;
            }
        }
    }
}