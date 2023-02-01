using UnityEngine;

namespace Project.Scripts.Game.Areas.Achievement
{
    [CreateAssetMenu(fileName = "achievement", menuName = "ScriptableObjects/Achievement")]
    public class AchievementConfig : ScriptableObject, IAchievementConfig
    {
        [SerializeField] private Sprite _achievementImage;
        [SerializeField] private Sprite _completedAchievementImage;
        [SerializeField] private int _requiredPointsToComplete;
        [SerializeField] private string _description;
        [SerializeField] private string _name;
        [SerializeField] private string _type;
        [SerializeField] private string _id;

        public string Id => _id;
        public string Type => _type;
        public Sprite AchievementImage => _achievementImage;
        public Sprite CompletedAchievementImage => _completedAchievementImage;
        public int RequiredPointsToComplete => _requiredPointsToComplete;
        public string Description => _description;
        public string Name => _name;
    }
}