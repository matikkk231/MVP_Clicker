using UnityEngine;

namespace DefaultNamespace
{
    public class LoadResourcesService : ILoadResourcesService
    {
        public Object Load<T>(string path)
        {
            return Resources.Load(path);
        }

        public void Unload(Object obj)
        {
            Resources.UnloadAsset(obj);
        }
    }
}