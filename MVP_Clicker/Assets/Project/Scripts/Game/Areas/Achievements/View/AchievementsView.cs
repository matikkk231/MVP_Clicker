using Project.Scripts.Game.Areas.Achievement;
using Project.Scripts.Game.Areas.Achievement.MonsterKillingAchievement.Model;
using UnityEngine;

namespace Project.Scripts.Game.Areas.Achievements.View
{
    public class AchievementsView : MonoBehaviour, IAchievementsView
    {
        [SerializeField] private AchievementView _prefab;
        [SerializeField] private GameObject _perentPrefab;
        [SerializeField] private GameObject _openingButton;
        [SerializeField] private GameObject _achievementsMenu;

        public void CloseAchievementsMenu()
        {
            _openingButton.SetActive(true);
            _achievementsMenu.SetActive(false);
        }

        public void OpenAchievementsMenu()
        {
            _openingButton.SetActive(false);
            _achievementsMenu.SetActive(true);
        }

        public IAchievementView CreateAchievement()
        {
            var view = Instantiate(_prefab, _perentPrefab.transform, true);
            return view;
        }
    }
}