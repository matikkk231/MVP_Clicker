namespace Project.Scripts.Core.LoadResourcesService
{
    public interface ILoadResourcesService
    {
        public T Load<T>(string path);
        public void Unload(string path);
    }
}