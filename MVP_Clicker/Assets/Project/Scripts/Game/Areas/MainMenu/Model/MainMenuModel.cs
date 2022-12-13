using Project.Scripts.Game.Areas.GameResources.Model;
using Project.Scripts.Game.Areas.Monster.Model;

namespace Project.Scripts.Game.Areas.MainMenu.Model
{
    public class MainMenuModel : IMainMenuModel
    {
        public IGameResourcesModel GameResources { get; }
        public IMonsterModel Monster { get; }
        private LogicHandler _logicHandler;

        public MainMenuModel()
        {
            GameResources = new GameResourcesModel();

            int startMonsterHP = 3;
            int StartRewardForKilling = 1;
            Monster = new MonsterModel(startMonsterHP, StartRewardForKilling);

            _logicHandler = new LogicHandler(GameResources, Monster);


        }
    }
}