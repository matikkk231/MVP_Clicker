using UnityEngine;

namespace DefaultNamespace
{
    public interface ILoadResourcesService
    {
        public Object Load<T>(string path);
        public void Unload(Object obj);
    }
}