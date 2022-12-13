using Project.Scripts.Game.Areas.GameResources.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public class MainMenuModel : IMainMenuModel
    {
        public IGameResourcesModel GameResourcesModel { get; }

        public MainMenuModel()
        {
            GameResourcesModel = new GameResourcesModel();
        }
    }
}