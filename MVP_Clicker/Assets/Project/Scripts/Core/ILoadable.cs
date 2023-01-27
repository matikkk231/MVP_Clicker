using System.Threading.Tasks;

namespace Project.Scripts.Core
{
    public interface ILoadable
    {
        Task LoadAsync();
    }
}