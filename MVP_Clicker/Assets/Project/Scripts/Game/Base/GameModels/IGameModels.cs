using Project.Scripts.Game.Areas.MainMenu.Model;

namespace Project.Scripts.Game.Base.GameModels
{
    public interface IGameModels
    {
        ICameraModel Camera { get; }
        IMainMenuModel MainMenu { get; }
  
    }
}