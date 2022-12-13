namespace Project.Scripts.Core.ViewCreate
{
    public interface IBoxView<out T>
    {
        T View { get; }

    }
}