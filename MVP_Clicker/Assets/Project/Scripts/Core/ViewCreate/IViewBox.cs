namespace Project.Scripts.Core.ViewCreate
{
    public interface IViewBox<out T>
    {
        void Destroy();

        T GetView { get; }

    }
}