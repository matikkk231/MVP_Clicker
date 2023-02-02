using Project.Scripts.Game.Areas.Skill.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.SkillMenu.View
{
    public class SkillMenuView : MonoBehaviour, ISkillMenuView
    {
        [SerializeField] private GameObject _menuOpener;
        [SerializeField] private GameObject _menu;
        [SerializeField] private SkillView _prefab;
        [SerializeField] private GameObject _parent;


        public void CloseMenu()
        {
            _menuOpener.SetActive(true);
            _menu.SetActive(false);
        }

        public void OpenMenu()
        {
            _menuOpener.SetActive(false);
            _menu.SetActive(true);
        }

        public ISkillView CreateSkillView()
        {
            var skill = Instantiate(_prefab, _parent.transform, true);
            return skill;
        }
    }
}