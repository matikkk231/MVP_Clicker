using System.Threading.Tasks;

namespace Project.Scripts.Core.LoadResourcesService
{
    public interface ILoadResourcesService
    {
        public Task<T> Load<T>(string path);
        public void Unload(string path);
    }
}