using System;
using Project.Scripts.Game.Areas.Skill.Config;
using Project.Scripts.Game.Areas.Skill.Model;
using Project.Scripts.Game.Areas.Skill.View;

namespace Project.Scripts.Game.Areas.Skill.Presenter
{
    public class SkillPresenter : IDisposable
    {
        private readonly ISkillModel _model;
        private readonly ISkillView _view;
        private readonly ISkillConfig _config;

        public SkillPresenter(ISkillModel model, ISkillView view, ISkillConfig config)
        {
            _model = model;
            _view = view;
            _config = config;

            _view.Description = config.Description;
            _view.Name = config.Name;
            _view.RecoveryDuration = config.RecoveryDuration;
            _view.SkillIcon = config.SkillIcon;
            AddListeners();
        }

        private void Activate()
        {
            _model.TryActivate();
        }

        private void AddListeners()
        {
            _view.Activated += Activate;
            _model.UpdatedCooldown += _view.SetShadowIntensityOnSkill;
        }

        private void RemoveListeners()
        {
            _view.Activated -= Activate;
            _model.UpdatedCooldown -= _view.SetShadowIntensityOnSkill;
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}