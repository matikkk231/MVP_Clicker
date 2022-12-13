using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.Resource.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public interface IMainMenuModel
    {
        IGameResourcesModel GameResourcesModel { get; }
    }
}