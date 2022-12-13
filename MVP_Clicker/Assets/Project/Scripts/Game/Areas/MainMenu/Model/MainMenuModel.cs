using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public class MainMenuModel : IMainMenuModel
    {
        public IGameResourcesModel GameResources { get; }
        public IMonsterModel Monster { get; }
        private readonly LogicHandler _logicHandler;

        public MainMenuModel()
        {
            GameResources = new GameResourcesModel();

            const int startMonsterHP = 3;
            const int startRewardForKilling = 1;
            Monster = new MonsterModel(startMonsterHP, startRewardForKilling);

            _logicHandler = new LogicHandler(GameResources, Monster);
        }
    }
}