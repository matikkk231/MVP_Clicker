using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Skill.Presenter;
using Project.Scripts.Game.Areas.SkillMenu.Config;
using Project.Scripts.Game.Areas.SkillMenu.Model;
using Project.Scripts.Game.Areas.SkillMenu.View;

namespace Project.Scripts.Game.Areas.SkillMenu.Presenter
{
    public class SkillMenuPresenter : IDisposable
    {
        private readonly List<SkillPresenter> _presenters;

        public SkillMenuPresenter(ISkillMenuModel model, ISkillMenuView view, ISkillMenuConfig config)
        {
            _presenters = new List<SkillPresenter>();
            foreach (var element in config.Collection)
            {
                _presenters.Add(new SkillPresenter(model.Collection[element.Value.Id], view.CreateSkillView(),
                    element.Value));
            }
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
        }
    }
}