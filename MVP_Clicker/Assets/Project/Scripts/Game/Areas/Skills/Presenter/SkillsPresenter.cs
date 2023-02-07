using System;
using System.Collections.Generic;
using Project.Scripts.Game.Areas.Skill.Presenter;
using Project.Scripts.Game.Areas.Skills.Config;
using Project.Scripts.Game.Areas.Skills.Model;
using Project.Scripts.Game.Areas.Skills.View;

namespace Project.Scripts.Game.Areas.Skills.Presenter
{
    public class SkillsPresenter : IDisposable
    {
        private readonly List<SkillPresenter> _presenters;

        public SkillsPresenter(ISkillsModel model, ISkillMenuView view, ISkillsConfig config)
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