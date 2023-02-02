using Project.Scripts.Game.Areas.Skill.View;

namespace Project.Scripts.Game.Areas.SkillMenu.View
{
    public interface ISkillMenuView
    {
        public void CloseMenu();
        public void OpenMenu();
        public ISkillView CreateSkillView();
    }
}