using System;
using Project.Scripts.Game.Areas.Monster.Model;
using Project.Scripts.Game.Areas.Monster.View;

namespace Project.Scripts.Game.Areas.Monster.Presenter
{
    public class MonsterPresenter: IDisposable
    {
        private IMonsterView _view;
        private IMonsterModel _model;

        public MonsterPresenter(IMonsterView view, IMonsterModel model)
        {
            _view = view;
            _model = model;
            AddListeners();
            OnUpdated();
        }

        private void OnUpdated()
        {
            _view.SetCurrentHP(_model.CurrentHP);
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