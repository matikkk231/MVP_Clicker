using Project.Scripts.Game.Areas.Skill.View;

namespace Project.Scripts.Game.Areas.Skills.View
{
    public interface ISkillMenuView
    {
        public void CloseMenu();
        public void OpenMenu();
        public ISkillView CreateSkillView();
    }
}