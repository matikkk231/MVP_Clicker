namespace Project.Scripts.Core.ViewCreate
{
    public interface IViewCreator<out T>
    {
        IBoxView<T> CreateObject();
    }
}