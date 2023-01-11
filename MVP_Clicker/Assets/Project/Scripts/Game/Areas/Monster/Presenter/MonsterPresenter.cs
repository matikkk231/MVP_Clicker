using System;
using Project.Scripts.Game.Areas.Monster.Config;
using Project.Scripts.Game.Areas.Monster.Data;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Areas.Monster.View;

namespace Project.Scripts.Game.Areas.Monster.Presenter
{
    public class MonsterPresenter : IDisposable
    {
        private readonly IMonsterView _view;
        private readonly IMonsterModel _model;

        public MonsterPresenter(IMonsterView view, IMonsterModel model, IMonsterConfig monsterConfig)
        {
            _view = view;
            _model = model;
            _view.SetMonsterImage(monsterConfig.MonsterImage);
            AddListeners();
            OnUpdated();
        }

        public MonsterPresenter(IMonsterView view, IMonsterModel model, IMonsterData data)
        {
            _view = view;
            _model = model;
            AddListeners();
            OnUpdated();
        }

        private void OnUpdated()
        {
            _view.SetCurrentHp(_model.CurrentHp);
        }

        private void OnDamaged()
        {
            _model.Damage();
        }

        private void AddListeners()
        {
            _model.Updated += OnUpdated;
            _view.Damaged += OnDamaged;
        }

        private void RemoveListeners()
        {
            _model.Updated -= OnUpdated;
            _view.Damaged -= OnDamaged;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}