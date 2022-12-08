namespace Project.Scripts.Core.ViewCreate
{
    public interface IViewCreate<out T>
    {
        IViewBox<T> CreateObject();
    }
}