using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Areas.Achievement.MonsterKillingAchievement.Model
{
    public class AchievementView : MonoBehaviour, IAchievementView
    {
        private int _requiredPointsToComplete;
        private int _currentPoints;
        private Sprite _imageWhenCompleted;

        [SerializeField] private Image _achievementImage;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _progress;
        [SerializeField] private TextMeshProUGUI _name;


        public int RequiredPointsToComplete
        {
            get => _requiredPointsToComplete;
            set
            {
                _requiredPointsToComplete = value;
                UpdateProgress();
            }
        }

        public int CurrentPoints
        {
            get => _currentPoints;
            set
            {
                _currentPoints = value;
                UpdateProgress();
            }
        }

        public string Description
        {
            get => _description.text;
            set => _description.text = value;
        }

        public string Name
        {
            get => _name.text;
            set => _name.text = value;
        }

        public Sprite ImageWhenCompleted
        {
            get => _imageWhenCompleted;
            set => _imageWhenCompleted = value;
        }

        public Sprite AchievementImage
        {
            get => _achievementImage.sprite;
            set => _achievementImage.sprite = value;
        }

        public void CompleteAchievement()
        {
            _achievementImage.sprite = _imageWhenCompleted;
        }

        private void UpdateProgress()
        {
            _progress.text = _currentPoints + "from" + _requiredPointsToComplete;
        }
    }
}