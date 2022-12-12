using System;
using Project.Scripts.Game.Areas.Models.Monster;
using Project.Scripts.Game.Areas.Views.Monster;

namespace Project.Scripts.Game.Areas.Presenters
{
    public class MonsterPresenter : IMonsterPresenter, IDisposable
    {
        private IMonsterView _monsterView;
        private IMonsterModel _monsterModel;

        public IMonsterModel GetMonsterModel
        {
            get => _monsterModel;
        }

        public IMonsterView GetMonsterView
        {
            get => _monsterView;
        }


        public MonsterPresenter(IMonsterView view, IMonsterModel model)
        {
            _monsterView = view;
            _monsterModel = model;
            AddListener();
            _monsterView.SetAmountOfMonsterHP(_monsterModel.CurrentMonsterHP);
        }

        private void AddListener()
        {
            _monsterModel.Updated += OnUpdated;
            _monsterView.GotDamagedByTap += DamageByTap;
        }

        private void RemoveListener()
        {
            _monsterModel.Updated -= OnUpdated;
            _monsterView.GotDamagedByTap -= DamageByTap;
        }

        private void OnUpdated()
        {
            _monsterView.SetAmountOfMonsterHP(_monsterModel.CurrentMonsterHP);
        }

        private void DamageByTap()
        {
            _monsterModel.GetDamage();
        }


        public void Dispose()
        {
            RemoveListener();
        }
    }
}