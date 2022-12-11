namespace Project.Scripts.Core.ViewCreate
{
    public interface IViewBox<out T>
    {
        T GetView { get; }

    }
}