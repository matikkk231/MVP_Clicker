using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Camera.View;

namespace Project.Scripts.Game.Base.GameViews
{
    public interface IGameViews
    {
        IViewCreator<ICameraView> Camera { get; }
        IViewCreator<IMainMenuView> MainMenu { get; }
    }
}