using Unity.VisualScripting;

namespace Project.Scripts.Core.ViewCreate
{
    public interface IBoxView<out T>
    {
        T View { get; }
        void Destroy();

    }
}