using System;
using Project.Scripts.Core.ViewCreate;
using Project.Scripts.Game.Areas.Models.Canvas;
using Project.Scripts.Game.Areas.Views.Canvas;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class MainMenuPresenter : IDisposable

    {
        private readonly IMainMenuModel _mainMenuModel;
        private readonly IViewBox<IMainMenuView> _MainMenuViewBox;

        private readonly IGameResourcesPresenter _moneyPresenter;
        private readonly IGameResourcesPresenter _damagePerTapPresenter;
        private readonly IMonsterPresenter _monsterPresenter;
        private readonly ILevelPresenter _levelPresenter;


        public MainMenuPresenter(IViewCreate<IMainMenuView> mainMenuViewBox, IMainMenuModel mainMenuModel)
        {
            _mainMenuModel = mainMenuModel;
            _MainMenuViewBox = mainMenuViewBox.CreateObject();

            _moneyPresenter = new MoneyPresenter(_MainMenuViewBox.GetView.GetMoneyView, _mainMenuModel.GetMoneyModel);
            _damagePerTapPresenter = new DamagePerTapPresenter(_MainMenuViewBox.GetView.GetDamagePerTapView,
                _mainMenuModel.GetDamagePerTapModel);
            _monsterPresenter =
                new MonsterPresenter(_MainMenuViewBox.GetView.GetMonsterView, _mainMenuModel.GetMonsterModel);
            _levelPresenter = new LevelPresenter(_MainMenuViewBox.GetView.GetLevelView, _mainMenuModel.GetLevelModel);

            AddListeners();
        }

        private void AddListeners()
        {
            _monsterPresenter.GetMonsterModel.GotDamageByTap += DamageMonster;
            _monsterPresenter.GetMonsterModel.MonsterDied += DieMonster;
            _levelPresenter.GetLevelModel.GotUpLevel += OnGotUpLevel;
        }

        private void RemoveListeners()
        {
            _monsterPresenter.GetMonsterModel.GotDamageByTap -= DamageMonster;
            _monsterPresenter.GetMonsterModel.MonsterDied -= DieMonster;
            _levelPresenter.GetLevelModel.GotUpLevel -= OnGotUpLevel;
        }

        private void DieMonster()
        {
            _moneyPresenter.GetGameResourcesModel.AmountOfResourseType +=
                _monsterPresenter.GetMonsterModel.MonsterReward;

            int monsterExperienceReward = 1;
            _levelPresenter.GetLevelModel.CurrentExperience += monsterExperienceReward;
        }

        private void DamageMonster()
        {
            _monsterPresenter.GetMonsterModel.CurrentMonsterHP -=
                _damagePerTapPresenter.GetGameResourcesModel.AmountOfResourseType;
        }

        private void OnGotUpLevel()
        {
            _monsterPresenter.GetMonsterModel.LevelUpMonster();
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}